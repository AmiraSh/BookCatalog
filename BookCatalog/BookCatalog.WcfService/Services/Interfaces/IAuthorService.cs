//-----------------------------------------------------------------------
// <copyright file="IAuthorService.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalogService
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ServiceModel;
    using BookCatalog.Components.ViewModels;
    using BookCatalog.Infrastructure.Filtration;
    #endregion Using

    /// <summary>
    /// Authors' service interface.
    /// </summary>
    [ServiceContract, ProtoBuf.ProtoContract]
    public interface IAuthorService
    {
        /// <summary>
        /// Gets authors.
        /// </summary>
        /// <returns>List of authors view model.</returns>
        [OperationContract]
        List<AuthorViewModel> GetAllAuthors();

        /// <summary>
        /// Gets authors' count.
        /// </summary>
        /// <returns>Authors' count.</returns>
        [OperationContract]
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
        [OperationContract]
        List<AuthorViewModel> GetAuthors(out int total, Dictionary<string, ListSortDirection> sorts, List<CustomFilter> filters, int take, int skip);

        /// <summary>
        /// Gets author's books.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <returns>List of author's books.</returns>
        [OperationContract]
        string GetBooks(int authorId);

        /// <summary>
        /// Gets an author.
        /// </summary>
        /// <param name="id">Author id.</param>
        /// <returns>Author view model.</returns>
        [OperationContract]
        AuthorViewModel GetAuthor(int id);

        /// <summary>
        /// Adds or edits an author.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Author identifier.</returns>
        [OperationContract]
        int Manage(AuthorViewModel authorVM);

        /// <summary>
        /// Deletes an author.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        [OperationContract]
        void Delete(int authorId);

        /// <summary>
        /// Gets x top authors in period no linger then 10 years.
        /// </summary>
        /// <param name="searchModel">Search model.</param>
        /// <returns>List of top authors.</returns>
        [OperationContract]
        List<TopAuthorViewModel> GetTopAuthors(SearchTopAuthorsViewModel searchModel);
    }
}
