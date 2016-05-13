//-----------------------------------------------------------------------
// <copyright file="AuthorService.svc.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalogService
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using BookCatalog.BusinessLogic.AutoMapperExtention.Configurations;
    using BookCatalog.BusinessLogic.DomainModels;
    using BookCatalog.Components.ViewModels;
    using BookCatalog.Infrastructure.Filtration;
    #endregion Using

    /// <summary>
    /// Authors' service.
    /// </summary>
    [AutomapServiceBehavior]
    public class AuthorService : IAuthorService
    {
        /// <summary>
        /// Author domain model.
        /// </summary>
        private AuthorDomainModel domainModel;

        /// <summary>
        /// Gets author domain model.
        /// </summary>
        private AuthorDomainModel DomainModel
        {
            get
            {
                return this.domainModel != null ? this.domainModel : this.domainModel = new AuthorDomainModel();
            }
        }

        /// <summary>
        /// Gets authors.
        /// </summary>
        /// <returns>List of authors view model.</returns>
        public List<AuthorViewModel> GetAllAuthors()
        {
            return this.DomainModel.GetAuthors();
        }

        /// <summary>
        /// Gets authors' count.
        /// </summary>
        /// <returns>Authors' count.</returns>
        public int GetAuthorsCount()
        {
            return this.DomainModel.GetAuthorsCount();
        }

        /// <summary>
        /// Gets authors.
        /// </summary>
        /// <param name="total">Total count.</param>
        /// <param name="sorts">Sorting settings.</param>
        /// <param name="filters">Filters settings.</param>
        /// <param name="take">Count of elements to take.</param>
        /// <param name="skip">Count of elements to skip.</param>
        /// <returns>List of authors view model.</returns>
        public List<AuthorViewModel> GetAuthors(out int total, Dictionary<string, ListSortDirection> sorts, List<CustomFilter> filters, int take, int skip)
        {
            return this.DomainModel.GetAuthors(out total, sorts, filters, take, skip);
        }

        /// <summary>
        /// Gets author's books.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <returns>List of author's books.</returns>
        public string GetBooks(int authorId)
        {
            return this.DomainModel.GetBooks(authorId);
        }

        /// <summary>
        /// Gets an author.
        /// </summary>
        /// <param name="id">Author id.</param>
        /// <returns>Author view model.</returns>
        public AuthorViewModel GetAuthor(int id)
        {
            return this.DomainModel.GetAuthor(id);
        }

        /// <summary>
        /// Adds or edits an author.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Author identifier.</returns>
        public int Manage(AuthorViewModel authorVM)
        {
            return this.DomainModel.Manage(authorVM);
        }

        /// <summary>
        /// Deletes an author.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        public void Delete(int authorId)
        {
            this.DomainModel.DeleteAuthor(authorId);
        }

        /// <summary>
        /// Gets x top authors in period no linger then 10 years.
        /// </summary>
        /// <param name="searchModel">Search model.</param>
        /// <returns>List of top authors.</returns>
        public List<TopAuthorViewModel> GetTopAuthors(SearchTopAuthorsViewModel searchModel)
        {
            return this.DomainModel.GetTopAuthors(searchModel);
        }
    }
}
