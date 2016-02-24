namespace BookCatalog.Controllers
{
    #region Using
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using KendoAnalysing;
    using BookCatalog.BusinessLogic.DomainModel;
    using BookCatalog.BusinessLogic.Validation;
    using BookCatalog.BusinessLogic.ViewModels;
    using BookCatalog.DAL.Interfaces;
    using BookCatalog.Infrastructure.Errors;
    #endregion

    /// <summary>
    /// Books controller for Kendo UI Grid.
    /// </summary>
    public class BooksController : Controller
    {
        /// <summary>
        /// Books domain model.
        /// </summary>
        private BookDomainModel domainModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="bookRepository">Books repository.</param>
        /// <param name="authorRepository">Authors repository.</param>
        public BooksController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            this.domainModel = new BookDomainModel(bookRepository, authorRepository);
        }

        /// <summary>
        /// Index.
        /// </summary>
        /// <returns>Index view.</returns>
        public ActionResult Index()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var author in this.domainModel.GetAuthorsOptions())
            {
                items.Add(new SelectListItem { Value = author.Key.ToString(), Text = author.Value });
            }

            this.ViewData["AuthorsOptions"] = new MultiSelectList(items, "Value", "Text");
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
            var books = this.domainModel.GetBooks(out total, sorts, filters, request.PageSize, (request.Page - 1) * request.PageSize);
            DataSourceResult result = books.ToDataSourceResult(request);
            result.Data = books;
            result.Total = total;
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creates or updates an entity.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="bookViewModel">Book view model.</param>
        /// <returns>Created or updated entity.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Manage([DataSourceRequest]DataSourceRequest request, BookViewModel bookViewModel)
        {
            try
            {
                Validator.Validate(bookViewModel);
            }
            catch (InvalidFieldValueException exception)
            {
                this.ModelState.AddModelError(exception.Field, exception.ValidationMessage);
                return this.Json(new[] { bookViewModel }.ToDataSourceResult(request, this.ModelState));
            }

            if (bookViewModel.Id == 0)
            {
                this.domainModel.AddBook(bookViewModel);
            }
            else
            {
                this.domainModel.EditBook(bookViewModel);
            }
            
            return this.Json(new[] { bookViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="bookViewModel">Book view model.</param>
        /// <returns>Deleted entity.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, BookViewModel bookViewModel)
        {
            this.domainModel.DeleteBook(bookViewModel.Id);
            return this.Json(new[] { bookViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
