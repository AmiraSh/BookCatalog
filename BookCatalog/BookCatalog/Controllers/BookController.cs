﻿namespace BookCatalog.Controllers
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
        /// Populates multi select list.
        /// </summary>
        /// <param name="options">Options to populate.</param>
        public void PopulateMultiSelectList(Dictionary<int, string> options)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var author in options)
            {
                items.Add(new SelectListItem { Value = author.Key.ToString(), Text = author.Value });
            }

            this.ViewData["AuthorsOptions"] = new MultiSelectList(items, "Value", "Text");
        }

        /// <summary>
        /// Gets a partial view for creating or editing new book.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>Partial view.</returns>
        public ActionResult AddBookForm(int? id)
        {
            this.PopulateMultiSelectList(this.domainModel.GetAuthorsOptions());
            if (id == null)
            {
                return this.PartialView("BookForm", new BookViewModel());
            }

            BookViewModel book = this.domainModel.GetBook(id.Value);
            if (book == null)
            {
                throw new ArgumentException("Book does not exist.");
            }

            foreach (var item in (ViewData["AuthorsOptions"] as MultiSelectList).Items)
            {
                if (book.AuthorsIds.Contains(int.Parse((item as SelectListItem).Value)))
                {
                    (item as SelectListItem).Selected = true;
                }
            }

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

            if (bookVM.Id == 0)
            {
                this.domainModel.AddBook(bookVM);
            }
            else
            {
                this.domainModel.EditBook(bookVM);
            }

            StringBuilder authors = new StringBuilder();
            foreach (var author in this.domainModel.GetAuthors(bookVM.Id))
            {
                authors.Append(author + "\n");
            }

            return this.Json(new
            {
                Id = bookVM.Id,
                Name = bookVM.Name,
                PublishedDate = bookVM.PublishedDate.ToString("MM/dd/yyyy"),
                PagesCount = bookVM.PagesCount,
                Authors = authors.ToString()
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
    }
}