namespace BookCatalog.Controllers
{
    #region Using
    using System.Web.Mvc;
    using BookCatalog.BusinessLogic.DomainModels;
    using BookCatalog.BusinessLogic.Validation;
    using BookCatalog.BusinessLogic.ViewModels;
    using BookCatalog.DAL.Interfaces;
    using BookCatalog.Infrastructure.Errors;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using KendoAnalysing;
    #endregion

    /// <summary>
    /// Authors controller for Kendo UI Grid.
    /// </summary>
    public class AuthorsController : Controller
    {
        /// <summary>
        /// Authors domain model.
        /// </summary>
        private AuthorDomainModel domainModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsController"/> class.
        /// </summary>
        /// <param name="authorRepository">Authors repository.</param>
        public AuthorsController(IAuthorRepository authorRepository)
        {
            this.domainModel = new AuthorDomainModel(authorRepository);
        }

        /// <summary>
        /// Index.
        /// </summary>
        /// <returns>Index view.</returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Reads grids' elements.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <returns>Grids' elements.</returns>
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            int total;
            var sorts = KendoAnalyser.GetSorts(request.Sorts);
            var filters = KendoAnalyser.GetFilters(request.Filters);
            var authors = this.domainModel.GetAuthors(out total, sorts, filters, request.PageSize, (request.Page - 1) * request.PageSize);            
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
        public ActionResult Manage([DataSourceRequest]DataSourceRequest request, AuthorViewModel authorViewModel)
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

            if (authorViewModel.Id == 0)
            {
                this.domainModel.AddAuthor(authorViewModel);
            }
            else
            {
                this.domainModel.EditAuthor(authorViewModel);
            }
            
            return this.Json(new[] { authorViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="authorViewModel">Author view model.</param>
        /// <returns>Deleted entity.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, AuthorViewModel authorViewModel)
        {
            this.domainModel.DeleteAuthor(authorViewModel.Id);
            return this.Json(new[] { authorViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
