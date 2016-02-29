namespace BookCatalog.Controllers
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using System.Web.Mvc;
    using BusinessLogic.DomainModel;
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
    /// Book's catalog controller.
    /// </summary>
    public class BookController : BaseController
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        private BookDomainModel domainModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class.
        /// </summary>
        /// <param name="bookRepository">Book repository.</param>
        /// <param name="authorRepository">Author repository.</param>
        /// <param name="logger">Logger.</param>
        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository, ILogger logger) : base(logger)
        {
            this.domainModel = new BookDomainModel(bookRepository, authorRepository);
        }

        /// <summary>
        /// Displays main page with books' list.
        /// </summary>
        /// <returns>Main page.</returns>
        public ActionResult Index()
        {
            return this.View(this.domainModel.GetBooks());
        }

        /// <summary>
        /// Displays a book.
        /// </summary>
        /// <param name="id">Book id.</param>
        /// <returns>Book page.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BookViewModel book = this.domainModel.GetBook(id.Value);
            if (book == null)
            {
                throw new ArgumentException("Book does not exist.");
            }

            return this.View(book);
        }

        /// <summary>
        /// Gets a partial view for creating or editing new book.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Partial view.</returns>
        public ActionResult AddBookForm(int? id)
        {
            BookViewModel book;
            if (id == null)
            {
                book = new BookViewModel();
            }
            else
            {
                book = this.domainModel.GetBook(id.Value);
            }
            
            if (book == null)
            {
                throw new ArgumentException("Book does not exist.");
            }
            
            this.domainModel.PopulateMultiSelectList(book);
            return this.PartialView("BookForm", book);
        }

        /// <summary>
        /// Creates or edits a book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        /// <returns>Json.</returns>
        [HttpPost]
        public JsonResult Manage(BookViewModel bookVM)
        {
            try
            {
                Validator.Validate(bookVM);
            }
            catch (InvalidFieldValueException exception)
            {
                ModelState.AddModelError(exception.Field, exception.ValidationMessage);
                return this.Json(new { error = exception.ValidationMessage });
            }

            this.domainModel.Manage(bookVM);
            return this.Json(new
            {
                Id = bookVM.Id,
                Name = bookVM.Name,
                PublishedDate = bookVM.PublishedDate.ToString("MM/dd/yyyy"),
                PagesCount = bookVM.PagesCount,
                Authors = this.domainModel.GetAuthors(bookVM.Id)
            });
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="id">Book id.</param>
        /// <returns>Identifier of deleted item.</returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            this.domainModel.DeleteBook(id);
            return this.Json(id);
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
            return this.View(this.domainModel.PopulateMultiSelectList());
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
        public JsonResult KendoManage([DataSourceRequest]DataSourceRequest request, BookViewModel bookViewModel)
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

            this.domainModel.Manage(bookViewModel);
            return this.Json(new[] { bookViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="bookViewModel">Book view model.</param>
        /// <returns>Deleted entity.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Destroy([DataSourceRequest]DataSourceRequest request, BookViewModel bookViewModel)
        {
            this.domainModel.DeleteBook(bookViewModel.Id);
            return this.Json(new[] { bookViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}