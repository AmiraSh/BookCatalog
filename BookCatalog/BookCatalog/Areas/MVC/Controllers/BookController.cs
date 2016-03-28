﻿namespace BookCatalog.UI.Areas.MVC.Controllers
{
    #region Using
    using System.Controllers;
    using BusinessLogic.DomainModel;
    using BusinessLogic.Validation;
    using BusinessLogic.ViewModels;
    using DAL.Interfaces;
    using global::System;
    using global::System.Net;
    using global::System.Web.Mvc;
    using Infrastructure.Errors;
    using KendoAnalysing;
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
        /// Gets the domain model or creates new if it was null.
        /// </summary>
        private BookDomainModel DomainModel
        {
            get
            {
                if (domainModel == null)
                {
                    domainModel = new BookDomainModel((IBookRepository)DependencyResolver.Current.GetService(typeof(IBookRepository)), (IAuthorRepository)DependencyResolver.Current.GetService(typeof(IAuthorRepository)));
                }

                return domainModel;
            }
        }

        /// <summary>
        /// Displays main page with books' list.
        /// </summary>
        /// <returns>Main page.</returns>
        public ActionResult Index()
        {
            return this.View(this.DomainModel.GetBooks());
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

            BookViewModel book = this.DomainModel.GetBook(id.Value);
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
                book = this.DomainModel.GetBook(id.Value);
            }
            
            if (book == null)
            {
                throw new ArgumentException("Book does not exist.");
            }
            
            this.DomainModel.PopulateMultiSelectList(book);
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

            this.DomainModel.Manage(bookVM);
            return this.Json(new
            {
                Id = bookVM.Id,
                Name = bookVM.Name,
                PublishedDate = bookVM.PublishedDate.ToString("MM/dd/yyyy"),
                PagesCount = bookVM.PagesCount,
                Authors = this.DomainModel.GetAuthors(bookVM.Id)
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
            this.DomainModel.DeleteBook(id);
            return this.Json(id);
        }

        /// <summary>
        /// Gets books' count.
        /// </summary>
        /// <returns>Books' count.</returns>
        public JsonResult GetBooksCount()
        {
            return this.Json(this.DomainModel.GetBooksCount(), JsonRequestBehavior.AllowGet);
        }
    }
}