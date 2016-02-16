namespace BookCatalog.Controllers
{
    #region Using
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using System.Web.Mvc;
    using BusinessLogic.DomainModel;
    using BusinessLogic.ViewModels;
    using DAL.Interfaces;
    #endregion

    /// <summary>
    /// Book's catalog controller.
    /// </summary>
    public class BookController : Controller
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
        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            this.domainModel = new BookDomainModel(bookRepository, authorRepository);
        }

        /// <summary>
        /// Displays main page with books' list.
        /// </summary>
        /// <returns>Main page.</returns>
        public ActionResult Index()
        {
            return View(this.domainModel.GetBooksList());
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
                return HttpNotFound();
            }

            return View(book);
        }

        /// <summary>
        /// Populates multi select list.
        /// </summary>
        /// <param name="options"></param>
        public void PopulateMultiSelectList(Dictionary<int, string> options)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var author in options)
            {
                items.Add(new SelectListItem { Value = author.Key.ToString(), Text = author.Value });
            }

            ViewData["AuthorsOptions"] = new MultiSelectList(items, "Value", "Text");
        }

        /// <summary>
        /// Gets a partial view for creating or editing new book.
        /// </summary>
        /// <returns>Partial view.</returns>
        public ActionResult AddBookForm(int? id)
        {
            this.PopulateMultiSelectList(this.domainModel.GetAuthorsOptions());
            if (id == null)
            {
                return PartialView("BookForm", new BookViewModel());
            }

            BookViewModel book = this.domainModel.GetBook(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }

            foreach (var item in (ViewData["AuthorsOptions"] as MultiSelectList).Items)
            {
                if (book.AuthorsIds.Contains(int.Parse((item as SelectListItem).Value)))
                {
                    (item as SelectListItem).Selected = true;
                }
            }

            return PartialView("BookForm", book);
        }

        /// <summary>
        /// Creates or edits a book.
        /// </summary>
        /// <param name="bookVM">Book view model.</param>
        /// <returns>Json.</returns>
        [HttpPost]
        public JsonResult Manage(BookViewModel bookVM)
        {
            switch ((bookVM.Id == 0) ? this.domainModel.AddBook(bookVM) : this.domainModel.EditBook(bookVM))
            {
                case 0:
                    StringBuilder authors = new StringBuilder();
                    foreach (var author in this.domainModel.GetAuthors(bookVM.Id))
                    {
                        authors.Append(author + "\n");
                    }
                    return Json(new
                    {
                        Id = bookVM.Id,
                        Name = bookVM.Name,
                        PublishedDate = bookVM.PublishedDate.ToString("MM/dd/yyyy"),
                        PagesCount = bookVM.PagesCount,
                        Authors = authors.ToString(),
                        Controls = "<input type='button' value='Edit' id='Edit' onclick='editBook(" + bookVM.Id + ")' class='makealink'> | <a href='Book/Details/" + bookVM.Id + "'>Details</a> | <input type='button' value='Delete' id='Delete' onclick='deleteBook(" + bookVM.Id + ")' class='makealink'>"
                    });
                case 1:
                    ModelState.AddModelError("AuthorsIds", "You need to specify at least one author.");
                    return Json(new { error = "You need to specify at least one author." });
                case 2:
                    ModelState.AddModelError("Name", "Name is required.");
                    return Json(new { error = "Name is required." });
                case 3:
                    ModelState.AddModelError("PagesCount", "Pages' count should be in range from 1 to 20,000.");
                    return Json(new { error = "Pages' count should be in range from 1 to 20,000." });
                case 4:
                    ModelState.AddModelError("PublishedDate", "Published day should ealier then today.");
                    return Json(new { error = "Published day should ealier then today." });
                case 5:
                    ModelState.AddModelError("PublishedDate", "Published day is in wrong format.");
                    return Json(new { error = "Published day is in wrong format." });
            }

            return Json(new { error = "Unknown error." });
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="id">Book id.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (this.domainModel.DeleteBook(id) == 1)
            {
                return HttpNotFound();
            }

            return Json(id);
        }
    }
}