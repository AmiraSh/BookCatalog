//-----------------------------------------------------------------------
// <copyright file="BookController.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.Areas.MVC.Controllers
{
    #region Using
    using System.Controllers;
    using Components.Validation;
    using Components.ViewModels;
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Net;
    using global::System.Text;
    using global::System.Web.Mvc;
    using Infrastructure.Errors;
    using ServiceWrappers.Interfaces;
    #endregion

    /// <summary>
    /// Book's catalog controller.
    /// </summary>
    public class BookController : BaseController
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        private IBookServiceWrapper domainModel;

        /// <summary>
        /// Gets the domain model or creates new if it was null.
        /// </summary>
        private IBookServiceWrapper DomainModel
        {
            get
            {
                return this.domainModel != null ? this.domainModel : this.domainModel = (IBookServiceWrapper)DependencyResolver.Current.GetService(typeof(IBookServiceWrapper));
            }
        }

        /// <summary>
        /// Displays main page with books' list.
        /// </summary>
        /// <returns>Main page.</returns>
        public ActionResult Index()
        {
            return this.View(this.DomainModel.GetAllBooks());
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
        /// <param name="id">Book identifier.</param>
        /// <returns>Partial view.</returns>
        public ActionResult AddBookForm(int? id)
        {
            BookViewModel book = id == null ? new BookViewModel() : this.DomainModel.GetBook(id.Value);
            
            if (book == null)
            {
                throw new ArgumentException("Book does not exist.");
            }
            
            book.AuthorsOptions = new List<SelectListItem>();
            book.AuthorsOptions.AddRange(this.DomainModel.PopulateMultiSelectList().AsEnumerable());
            foreach (var author in book.AuthorsOptions)
            {
                author.Selected = book.Authors.FirstOrDefault(bookAuthor => bookAuthor.Id == int.Parse(author.Value)) != null;
            }

            return this.PartialView("BookForm", book);
        }

        /// <summary>
        /// Creates or edits a book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        /// <returns>Json with information about the book.</returns>
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
                Rating = bookVM.Rating,
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
            this.DomainModel.Delete(id);
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

        /// <summary>
        /// Returns XML file.
        /// </summary>
        /// <returns>XML file.</returns>
        public FileResult GetXMLFile()
        {
            byte[] bytes = Encoding.Default.GetBytes(this.DomainModel.GetXML());
            return this.File(bytes, global::System.Net.Mime.MediaTypeNames.Text.Xml, "bookcatalog.xml");
        }
    }
}