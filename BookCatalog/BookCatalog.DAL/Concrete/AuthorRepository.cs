namespace BookCatalog.DAL.Concrete
{
    #region Using
    using System.Collections.Generic;
    using BookCatalog.DAL.Models;
    using Interfaces;
    #endregion

    /// <summary>
    /// Implementation of author repository interface.
    /// </summary>
    public sealed class AuthorRepository : GenericRepository<BookCatalogContext, Author>, IAuthorRepository
    {
        /// <summary>
        /// Gets author's books.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <returns>Author's books.</returns>
        public IEnumerable<Book> GetBooks(int authorId)
        {
            List<Book> books = new List<Book>();
            Author author = FindById(authorId);
            foreach (Book book in author.Books)
            {
                books.Add(book);
            }

            return books;
        }

        /// <summary>
        /// Set a new author book.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <param name="book">New author book.</param>
        public void SetBook(int authorId, Book book)
        {
            Author author = FindById(authorId);
            author.Books.Add(book);
        }
    }
}