namespace BookCatalog.Controllers
{
    #region Using
    using System;
    using System.Text;
    using System.Web.Mvc;
    using BusinessLogic.DomainModels;
    using BusinessLogic.ViewModels;
    using DAL.Interfaces;
    #endregion

    /// <summary>
    /// Author controller.
    /// </summary>
    public class AuthorController : Controller
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        private AuthorDomainModel domainModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class.
        /// </summary>
        /// <param name="authorRepository">Author repository.</param>
        public AuthorController(IAuthorRepository authorRepository)
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
        /// <param name="FirstName">First name.</param>
        /// <param name="LastName">Last name.</param>
        /// <param name="BooksCount">Books count (optional).</param>
        /// <returns>Author's page.</returns>
        public ActionResult Details(string FirstName, string LastName, int? BooksCount)
        {
            AuthorViewModel author = this.domainModel.GetAuthor(FirstName, LastName, BooksCount);
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

            return PartialView("AuthorEdit", author);
        }

        /// <summary>
        /// Creates of edits an author.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Json.</returns>
        [HttpPost]
        public JsonResult Manage(AuthorViewModel authorVM)
        {
            switch ((authorVM.Id == 0) ? this.domainModel.AddAuthor(authorVM) : this.domainModel.EditAuthor(authorVM))
            {
                case 0:
                    StringBuilder books = new StringBuilder();
                    foreach (var book in authorVM.Books)
                    {
                        books.Append(book.Key + ", " + book.Value + "\n");
                    }
                    return Json(new
                    {
                        Id = authorVM.Id,
                        FirstName = authorVM.FirstName,
                        SecondName = authorVM.SecondName,
                        BooksCount = authorVM.BooksCount,
                        Books = books,
                        Controls = "<input type='button' value='Edit' id='Edit' onclick='editBook(" + authorVM.Id + ")' class='makealink'> | <a href='Author/Details/" + authorVM.FirstName + "/" + authorVM.SecondName + "'>Details</a>  | <input type='button' value='Delete' id='Delete' onclick='deleteBook(" + authorVM.Id + ")' class='makealink'>"
                    });
                case 1:
                    ModelState.AddModelError("FirstName", "First name is required.");
                    return Json(new { error = "First name is required." });
                case 2:
                    ModelState.AddModelError("SecondName", "Second name is required.");
                    return Json(new { error = "Second name is required." });
            }

            return Json(new { error = "Unknown error." });
        }

        /// <summary>
        /// Deletes an author.
        /// </summary>
        /// <param name="id">Author id.</param>
        /// <returns>Json.</returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (this.domainModel.DeleteAuthor(id) == 1)
            {
                throw new ArgumentException("Author does not exist.");
            }

            return Json(id);
        }
    }
}