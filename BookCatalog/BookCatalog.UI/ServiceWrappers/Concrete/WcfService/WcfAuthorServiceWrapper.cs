//-----------------------------------------------------------------------
// <copyright file="WcfAuthorServiceWrapper.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.ServiceWrappers.Concrete.WcfService
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;
    using AuthorService;
    using BookCatalog.Components.ViewModels;
    using Infrastructure.Filtration;
    using Interfaces;
    #endregion Using

    /// <summary>
    /// Wcf author service wrapper.
    /// </summary>
    public class WcfAuthorServiceWrapper : IAuthorServiceWrapper
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        private IAuthorService domainModel;

        /// <summary>
        /// Gets the domain model or creates new if it was null.
        /// </summary>
        private IAuthorService DomainModel
        {
            get
            {
                return this.domainModel != null ? this.domainModel : this.domainModel = (IAuthorService)DependencyResolver.Current.GetService(typeof(IAuthorService));
            }
        }

        /// <summary>
        /// Gets authors.
        /// </summary>
        /// <returns>List of authors view model.</returns>
        public List<AuthorViewModel> GetAllAuthors()
        {
            return this.DomainModel.GetAllAuthors();
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
            GetAuthorsResponse response = this.DomainModel.GetAuthors(new GetAuthorsRequest(sorts, filters, take, skip));
            total = response.total;
            return response.GetAuthorsResult;
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
        public void Manage(AuthorViewModel authorVM)
        {
            int authorId = this.DomainModel.Manage(authorVM);
            authorVM.Id = authorId;
        }

        /// <summary>
        /// Deletes an author.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        public void Delete(int authorId)
        {
            this.DomainModel.Delete(authorId);
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