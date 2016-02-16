namespace BookCatalog.DAL.Interfaces
{
    #region Using

    using System.Collections.Generic;
    using BookCatalog.DAL.Models;

    #endregion

    /// <summary>
    /// Author repository interface.
    /// </summary>
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        /// <summary>
        /// Gets author's books.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <returns>Author's books.</returns>
        IEnumerable<Book> GetBooks(int authorId);

        /// <summary>
        /// Set a new author book.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <param name="book">New author book.</param>
        void SetBook(int authorId, Book book);
    }
}