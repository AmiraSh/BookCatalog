//-----------------------------------------------------------------------
// <copyright file="IAuthorRepository.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.DAL.Interfaces
{
    #region Using
    using System;
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

        /// <summary>
        /// Gets top x authors in specific period, no longer then 10 years.
        /// </summary>
        /// <param name="count">Count of authors to return.</param>
        /// <param name="beginDate">Begin date.</param>
        /// <param name="endDate">End date.</param>
        /// <returns>Top authors.</returns>
        IDictionary<Author, int> GetTopAuthors(int count, DateTime beginDate, DateTime endDate);
    }
}