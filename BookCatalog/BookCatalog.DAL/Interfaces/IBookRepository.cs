namespace BookCatalog.DAL.Interfaces
{
    #region Using
    using System.Collections.Generic;
    using BookCatalog.DAL.Models;
    #endregion

    /// <summary>
    /// Book repository interface.
    /// </summary>
    public interface IBookRepository : IGenericRepository<Book>
    {
        /// <summary>
        /// Gets book's authors.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        /// <returns>Book's authors.</returns>
        IEnumerable<Author> GetAuthors(int bookId);

        /// <summary>
        /// Set a new book author.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        /// <param name="author">New book author.</param>
        void SetAuthor(int bookId, Author author);

        /// <summary>
        /// Set a book authors.
        /// </summary>
        /// <param name="bookId">Book id.</param>
        /// <param name="authorsIds">Book authors' ids.</param>
        void SetAuthors(int bookId, List<int> authorsIds);
    }
}