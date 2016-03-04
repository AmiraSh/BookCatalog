namespace BookCatalog.Controllers
{
    #region Using
    using System;
    using System.Text;
    using System.Web.Mvc;
    using BusinessLogic.DomainModels;
    using BusinessLogic.Validation;
    using BusinessLogic.ViewModels;
    using DAL.Interfaces;
    using Infrastructure.Errors;
    using Infrastructure.Logging;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using KendoAnalysing;
    using Newtonsoft.Json;
    #endregion

    /// <summary>
    /// Author controller.
    /// </summary>
    public class AuthorController : BaseController
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        private AuthorDomainModel domainModel;

        /// <summary>
        /// Gets the domain model or creates new if it was null.
        /// </summary>
        private AuthorDomainModel DomainModel
        {
            get
            {
                if (domainModel == null)
                {
                    domainModel = new AuthorDomainModel((IAuthorRepository)DependencyResolver.Current.GetService(typeof(IAuthorRepository)));
                }

                return domainModel;
            }
        }

        /// <summary>
        /// Displays a page with authors list.
        /// </summary>
        /// <returns>A page with authors' list.</returns>
        public ActionResult Index()
        {
            return this.View(this.DomainModel.GetAuthors());
        }

        /// <summary>
        /// Displays an author.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="FirstName">First name.</param>
        /// <param name="LastName">Last name.</param>
        /// <param name="BooksCount">Books count (optional).</param>
        /// <returns>Author's page.</returns>
        public ActionResult Details(int id, string FirstName, string LastName, int? BooksCount)
        {
            AuthorViewModel author = this.DomainModel.GetAuthor(id);
            if (author == null)
            {
                throw new ArgumentException("Author does not exist.");
            }

            return this.View(author);
        }

        /// <summary>
        /// Gets a partial view for creating new book.
        /// </summary>
        /// <param name="id">Book's identifier.</param>
        /// <returns>Partial view.</returns>
        public ActionResult AddAuthorForm(int? id)
        {
            if (id == null)
            {
                return this.PartialView("AuthorForm", new AuthorViewModel());
            }

            AuthorViewModel author = this.DomainModel.GetAuthor(id.Value);
            if (author == null)
            {
                throw new ArgumentException("Author does not exist.");
            }

            return this.PartialView("AuthorForm", author);
        }

        /// <summary>
        /// Creates of edits an author.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Json.</returns>
        [HttpPost]
        public JsonResult Manage(AuthorViewModel authorVM)
        {
            try
            {
                Validator.Validate(authorVM);
            }
            catch (InvalidFieldValueException exception)
            {
                ModelState.AddModelError(exception.Field, exception.ValidationMessage);
                return this.Json(new { error = exception.ValidationMessage });
            }

            this.DomainModel.Manage(authorVM);            
            return this.Json(new
            {
                Id = authorVM.Id,
                FirstName = authorVM.FirstName,
                SecondName = authorVM.SecondName,
                BooksCount = authorVM.BooksCount,
                Books = this.DomainModel.GetBooks(authorVM.Id)
            });
        }

        /// <summary>
        /// Deletes an author.
        /// </summary>
        /// <param name="id">Author id.</param>
        /// <returns>Json.</returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            this.DomainModel.DeleteAuthor(id);
            return this.Json(id);
        }

        /// <summary>
        /// Gets authors' count.
        /// </summary>
        /// <returns>Authors' count.</returns>
        public JsonResult GetAuthorsCount()
        {
            return this.Json(this.DomainModel.GetAuthorsCount(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets authors.
        /// </summary>
        /// <returns>Authors.</returns>
        public JsonResult GetAuthors()
        {
            return this.Json(this.DomainModel.GetAuthors(), JsonRequestBehavior.AllowGet);
        }

        ///-----------------------
        ///      Kendo Part
        ///-----------------------
        /// <summary>
        /// Grid.
        /// </summary>
        /// <returns>Grid view.</returns>
        public ActionResult Grid()
        {
            return this.View();
        }

        /// <summary>
        /// Gets partial view for books' rating chart.
        /// </summary>
        /// <param name="Id">Author identifier.</param>
        /// <returns>Partial view for books' rating chart.</returns>
        public ActionResult BooksChart(int? Id)
        {
            if (Id == null)
            {
                return this.PartialView();
            }

            return this.PartialView(this.DomainModel.GetAuthor(Id.Value));
        }

        /// <summary>
        /// Reads grids' elements.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <returns>Grids' elements.</returns>
        public JsonResult Read([DataSourceRequest]DataSourceRequest request)
        {
            int total;
            var sorts = KendoAnalyser.GetSorts(request.Sorts);
            var filters = KendoAnalyser.GetFilters(request.Filters);
            var authors = this.DomainModel.GetAuthors(out total, sorts, filters, request.PageSize, (request.Page - 1) * request.PageSize);
            DataSourceResult result = authors.ToDataSourceResult(request);
            result.Data = authors;
            result.Total = total;
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creates or updates an entity.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="authorViewModel">Author view model.</param>
        /// <returns>Created or updated entity.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult KendoManage([DataSourceRequest]DataSourceRequest request, AuthorViewModel authorViewModel)
        {
            try
            {
                Validator.Validate(authorViewModel);
            }
            catch (InvalidFieldValueException exception)
            {
                this.ModelState.AddModelError(exception.Field, exception.ValidationMessage);
                return this.Json(new[] { authorViewModel }.ToDataSourceResult(request, this.ModelState));
            }

            this.DomainModel.Manage(authorViewModel);
            return this.Json(new[] { authorViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="authorViewModel">Author view model.</param>
        /// <returns>Deleted entity.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Destroy([DataSourceRequest]DataSourceRequest request, AuthorViewModel authorViewModel)
        {
            this.DomainModel.DeleteAuthor(authorViewModel.Id);
            return this.Json(new[] { authorViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}