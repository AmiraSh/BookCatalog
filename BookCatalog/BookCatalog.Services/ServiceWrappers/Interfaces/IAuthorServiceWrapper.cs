//-----------------------------------------------------------------------
// <copyright file="IAuthorServiceWrapper.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.Services.ServiceWrappers.Interfaces
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using BookCatalog.Components.ViewModels;
    using Infrastructure.Filtration;
    #endregion Using

    /// <summary>
    /// Author service wrapper interface.
    /// </summary>
    public interface IAuthorServiceWrapper
    {
        /// <summary>
        /// Gets authors.
        /// </summary>
        /// <returns>List of authors view model.</returns>
        List<AuthorViewModel> GetAllAuthors();

        /// <summary>
        /// Gets authors' count.
        /// </summary>
        /// <returns>Authors' count.</returns>
        int GetAuthorsCount();

        /// <summary>
        /// Gets authors.
        /// </summary>
        /// <param name="total">Total count.</param>
        /// <param name="sorts">Sorting settings.</param>
        /// <param name="filters">Filters settings.</param>
        /// <param name="take">Count of elements to take.</param>
        /// <param name="skip">Count of elements to skip.</param>
        /// <returns>List of authors view model.</returns>
        List<AuthorViewModel> GetAuthors(out int total, Dictionary<string, ListSortDirection> sorts, List<CustomFilter> filters, int take, int skip);

        /// <summary>
        /// Gets author's books.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <returns>List of author's books.</returns>
        string GetBooks(int authorId);

        /// <summary>
        /// Gets an author.
        /// </summary>
        /// <param name="id">Author id.</param>
        /// <returns>Author view model.</returns>
        AuthorViewModel GetAuthor(int id);

        /// <summary>
        /// Adds or edits an author.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        void Manage(AuthorViewModel authorVM);

        /// <summary>
        /// Deletes an author.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        void Delete(int authorId);

        /// <summary>
        /// Gets x top authors in period no linger then 10 years.
        /// </summary>
        /// <param name="searchModel">Search model.</param>
        /// <returns>List of top authors.</returns>
        List<TopAuthorViewModel> GetTopAuthors(SearchTopAuthorsViewModel searchModel);
    }
}