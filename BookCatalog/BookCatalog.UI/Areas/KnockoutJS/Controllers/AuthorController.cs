//-----------------------------------------------------------------------
// <copyright file="AuthorController.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.Areas.KnockoutJS.Controllers
{
    #region Using
    using System.Controllers;
    using Components.Validation;
    using Components.ViewModels;
    using global::System;
    using global::System.Web.Mvc;
    using Infrastructure.Errors;
    using Services.ServiceWrappers.Interfaces;
    using Microsoft.Practices.Unity;
    #endregion

    /// <summary>
    /// Author controller.
    /// </summary>
    public class AuthorController : BaseController
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        [Dependency]
        protected IAuthorServiceWrapper DomainModel { get; set; }

        /// <summary>
        /// Displays a page with authors list.
        /// </summary>
        /// <returns>A page with authors' list.</returns>
        public ActionResult Index()
        {
            return this.View(this.DomainModel.GetAllAuthors());
        }

        /// <summary>
        /// Displays an author.
        /// </summary>
        /// <param name="id">Author identifier.</param>
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
        /// <returns>Json with information about the author.</returns>
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
        /// <returns>Json with identifier of deleted instance.</returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            this.DomainModel.Delete(id);
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
        /// <returns>Authors' list.</returns>
        public JsonResult GetAuthors()
        {
            return this.Json(this.DomainModel.GetAllAuthors(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets x top authors.
        /// </summary>
        /// <param name="searchModel">Search model.</param>
        /// <returns>Top authors.</returns>
        public ActionResult TopAuthors(SearchTopAuthorsViewModel searchModel)
        {
            return this.View(this.DomainModel.GetTopAuthors(searchModel));
        }
    }
}