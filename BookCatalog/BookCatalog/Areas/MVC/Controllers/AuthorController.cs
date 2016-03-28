namespace BookCatalog.UI.Areas.MVC.Controllers
{
    #region Using
    using System.Controllers;
    using BusinessLogic.DomainModels;
    using BusinessLogic.Validation;
    using BusinessLogic.ViewModels;
    using DAL.Interfaces;
    using global::System;
    using global::System.Web.Mvc;
    using Infrastructure.Errors;
    using KendoAnalysing;
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
    }
}