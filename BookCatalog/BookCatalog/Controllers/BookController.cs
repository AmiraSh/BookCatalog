namespace BookCatalog.API.Controllers
{
    #region Using
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using System.Web.Mvc;
    using ViewModels.Validation;
    using ViewModels.ViewModels;
    using Infrastructure.Errors;
    using UI.BookService;
    #endregion

    /// <summary>
    /// Book api controller.
    /// </summary>
    public class BookController : ApiController
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        private IBookService domainModel;

        /// <summary>
        /// Gets the domain model or creates new if it was null.
        /// </summary>
        private IBookService DomainModel
        {
            get
            {
                return domainModel != null ? domainModel : domainModel = (IBookService)DependencyResolver.Current.GetService(typeof(IBookService));
            }
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>Books' list.</returns>
        public IEnumerable<BookViewModel> GetAll()
        {
            return this.DomainModel.GetAllBooks().AsEnumerable();
        }

        /// <summary>
        /// Gets book's details.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>Book details.</returns>
        [ResponseType(typeof(BookViewModel))]
        public IHttpActionResult Get(int id)
        {
            BookViewModel book = this.DomainModel.GetBook(id);
            if (book == null)
            {
                return this.NotFound();
            }

            return this.Ok(book);
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(BookViewModel))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                this.DomainModel.Delete(id);
            }
            catch (InvalidFieldValueException)
            {
                return this.NotFound();
            }

            return this.Ok(this.DomainModel.GetBook(id));
        }

        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <param name="book">Book view model.</param>
        /// <returns></returns>
        [ResponseType(typeof(BookViewModel))]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Manage(BookViewModel book)
        {
            book.AuthorsIds.AddRange(book.Authors.Select(author => author.Id).ToList());
            try
            {
                Validator.Validate(book);
            }
            catch (InvalidFieldValueException exception)
            {
                this.ModelState.AddModelError("error", exception.ValidationMessage);
                return BadRequest(ModelState);
            }

            this.DomainModel.Manage(book);
            return this.CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }
    }
}