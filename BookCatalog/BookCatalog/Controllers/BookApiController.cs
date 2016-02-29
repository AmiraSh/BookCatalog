namespace BookCatalog.Controllers
{
    #region Using
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using BusinessLogic.DomainModel;
    using BusinessLogic.Validation;
    using BusinessLogic.ViewModels;
    using DAL.Interfaces;
    using Infrastructure.Errors;
    #endregion

    /// <summary>
    /// Book api controller.
    /// </summary>
    public class BookApiController : ApiController
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
        public BookApiController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            this.domainModel = new BookDomainModel(bookRepository, authorRepository);
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>Books' list.</returns>
        public IQueryable<BookViewModel> GetBooks()
        {
            return this.domainModel.GetBooks().AsQueryable();
        }

        /// <summary>
        /// Gets book's details.
        /// </summary>
        /// <param name="id">Book identifier.</param>
        /// <returns>Book details.</returns>
        [ResponseType(typeof(BookViewModel))]
        public IHttpActionResult GetBook(int id)
        {
            BookViewModel book = this.domainModel.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// Creates or updates a book.
        /// </summary>
        /// <param name="book">Book view model.</param>
        /// <returns></returns>
        [ResponseType(typeof(BookViewModel))]
        public IHttpActionResult ManageBook(BookViewModel book)
        {
            try
            {
                Validator.Validate(book);
            }
            catch (InvalidFieldValueException exception)
            {
                ModelState.AddModelError(exception.Field, exception.ValidationMessage);
                return BadRequest(ModelState);
            }

            this.domainModel.Manage(book);
            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
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
                this.domainModel.DeleteBook(id);
            }
            catch (InvalidFieldValueException)
            {
                return NotFound();
            }

            return Ok(this.domainModel.GetBook(id));
        }


        //// PUT: api/BookApi/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutBook(int id, Book book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != book.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(book).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/BookApi
        //[ResponseType(typeof(Book))]
        //public IHttpActionResult PostBook(Book book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Books.Add(book);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        //}
    }
}