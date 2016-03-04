namespace BookCatalog.Controllers
{
    using System.Collections.Generic;
    #region Using
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using System.Web.Mvc;
    using BusinessLogic.DomainModel;
    using BusinessLogic.Validation;
    using BusinessLogic.ViewModels;
    using DAL.Interfaces;
    using Infrastructure.Errors;
    #endregion

    /// <summary>
    /// Book api controller.
    /// </summary>
    public class BooksController : ApiController
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
        /// Gets all books.
        /// </summary>
        /// <returns>Books' list.</returns>
        public IEnumerable<BookViewModel> GetBooks()
        {
            return this.DomainModel.GetBooks();
        }

        /// <summary>
        /// Gets book's details.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>Book details.</returns>
        [ResponseType(typeof(BookViewModel))]
        public IHttpActionResult GetBook(int id)
        {
            BookViewModel book = this.DomainModel.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(BookViewModel))]
        public IHttpActionResult DeleteBook(int id)
        {
            try
            {
                this.DomainModel.DeleteBook(id);
            }
            catch (InvalidFieldValueException)
            {
                return NotFound();
            }

            return Ok(this.DomainModel.GetBook(id));
        }

        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <param name="book">Book view model.</param>
        /// <returns></returns>
        [ResponseType(typeof(BookViewModel))]
        [System.Web.Http.HttpPost]
        public IHttpActionResult ManageBook(BookViewModel book)
        {
            book.AuthorsIds.AddRange(book.Authors.Select(author => author.Id).ToList());
            try
            {
                Validator.Validate(book);
            }
            catch (InvalidFieldValueException exception)
            {
                ModelState.AddModelError("error", exception.ValidationMessage);
                return BadRequest(ModelState);
            }

            this.DomainModel.Manage(book);
            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }
    }
}