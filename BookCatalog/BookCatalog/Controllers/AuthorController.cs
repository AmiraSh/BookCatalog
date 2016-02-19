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
        /// Initializes a new instance of the <see cref="BookController"/> class.
        /// </summary>
        /// <param name="authorRepository">Author repository.</param>
        public AuthorController(IAuthorRepository authorRepository, ILogger logger) : base(logger)
        {
            this.domainModel = new AuthorDomainModel(authorRepository);
        }

        /// <summary>
        /// Displays a page with authors list.
        /// </summary>
        /// <returns>A page with autors' list.</returns>
        public ActionResult Index()
        {
            return View(this.domainModel.GetAuthors());
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
            AuthorViewModel author = this.domainModel.GetAuthor(id);
            if (author == null)
            {
                throw new ArgumentException("Author does not exist.");
            }

            return View(author);
        }

        /// <summary>
        /// Gets a partial view for creating new book.
        /// </summary>
        /// <returns>Partial view.</returns>
        public ActionResult AddAuthorForm(int? id)
        {
            if (id == null)
            {
                return PartialView("AuthorForm", new AuthorViewModel());
            }

            AuthorViewModel author = this.domainModel.GetAuthor(id.Value);
            if (author == null)
            {
                throw new ArgumentException("Author does not exist.");
            }

            return PartialView("AuthorForm", author);
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
                return Json(new { error = exception.ValidationMessage });
            }

            if (authorVM.Id == 0)
            {
                this.domainModel.AddAuthor(authorVM);
            }
            else
            {
                this.domainModel.EditAuthor(authorVM);
            }
            
            StringBuilder books = new StringBuilder();
            foreach (var book in this.domainModel.GetBooks(authorVM.Id))
            {
                books.Append(book.Name + ", " + book.PublishedDate.Year + "\n");
            }
            return Json(new
            {
                Id = authorVM.Id,
                FirstName = authorVM.FirstName,
                SecondName = authorVM.SecondName,
                BooksCount = authorVM.BooksCount,
                Books = books.ToString()
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
            this.domainModel.DeleteAuthor(id);
            return Json(id);
        }
    }
}