//-----------------------------------------------------------------------
// <copyright file="AuthorDomainModel.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.BusinessLogic.DomainModels
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using DAL.Concrete;
    using DAL.Interfaces;
    using DAL.Models;
    using Infrastructure.Errors;
    using Infrastructure.Filtration;
    using Components.ViewModels;
    #endregion

    /// <summary>
    /// Author domain model.
    /// </summary>
    public class AuthorDomainModel
    {        
        /// <summary>
        /// Gets author repository.
        /// </summary>
        private IAuthorRepository AuthorRepository { get; set; }
        
        public AuthorDomainModel(IAuthorRepository authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        /// <summary>
        /// Gets authors.
        /// </summary>
        /// <returns>List of authors view model.</returns>
        public List<AuthorViewModel> GetAuthors()
        {
            return Mapper.Map<List<AuthorViewModel>>(this.AuthorRepository.GetAll().ToList());
        }

        /// <summary>
        /// Gets authors' count.
        /// </summary>
        /// <returns>Authors' count.</returns>
        public int GetAuthorsCount()
        {
            return this.AuthorRepository.GetSize();
        }

        /// <summary>
        /// Gets authors.
        /// </summary>
        /// <param name="total">Total count.</param>
        /// <param name="sorts">Sotrs.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="take">Count of elements to take.</param>
        /// <param name="skip">Count of elements to skip.</param>
        /// <returns>List of authors view model.</returns>
        public List<AuthorViewModel> GetAuthors(out int total, Dictionary<string, ListSortDirection> sorts, List<CustomFilter> filters, int take, int skip)
        {
            if (sorts.Count == 0)
            {
                sorts.Add("Id", ListSortDirection.Ascending);
            }

            return Mapper.Map<List<AuthorViewModel>>(this.AuthorRepository.Take(out total, sorts, filters, take, skip).ToList());
        }

        /// <summary>
        /// Gets authors.
        /// </summary>
        /// <param name="total">Total count.</param>
        /// <param name="sorts">Sotrs.</param>
        /// <param name="filters">Filters.</param>
        /// <param name="take">Count of elements to take.</param>
        /// <param name="skip">Count of elements to skip.</param>
        /// <returns>List of authors view model.</returns>
        public List<AuthorViewModel> GetAuthors(out int total, List<Sort> sorts, List<CustomFilter> filters, int take, int skip)
        {
            return this.GetAuthors(out total, sorts.ToDictionary(s => s.FieldName, s => s.SortDirection), filters, take, skip);
        }

        /// <summary>
        /// Gets author's books.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <returns>List of author's books.</returns>
        public string GetBooks(int authorId)
        {
            Author author = this.AuthorRepository.FindById(authorId);
            if (author == null)
            {
                throw new InvalidFieldValueException("Author does not exist.");
            }

            StringBuilder books = new StringBuilder();
            string separator = ", ";
            foreach (var book in author.Books.ToList())
            {
                books.Append(book.Name);
                books.Append(separator);
                books.AppendLine(book.PublishedDate.Year.ToString());
            }

            return books.ToString();
        }

        /// <summary>
        /// Gets an author.
        /// </summary>
        /// <param name="id">Author id.</param>
        /// <returns>Author view model.</returns>
        public AuthorViewModel GetAuthor(int id)
        {
            return Mapper.Map<AuthorViewModel>(this.AuthorRepository.FindById(id));
        }

        /// <summary>
        /// Adds or edits an author.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Author identifier.</returns>
        public int Manage(AuthorViewModel authorVM)
        {
            return authorVM.Id == 0 ? this.AddAuthor(authorVM) : this.EditAuthor(authorVM);
        }

        /// <summary>
        /// Adds a new author to database.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Author identifier.</returns>
        public int AddAuthor(AuthorViewModel authorVM)
        {
            Author author = Mapper.Map<Author>(authorVM);
            this.AuthorRepository.Add(author);
            this.AuthorRepository.SaveChanges();
            return authorVM.Id = author.Id;
        }

        /// <summary>
        /// Edits an author in database.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Author identifier.</returns>
        public int EditAuthor(AuthorViewModel authorVM)
        {
            Author author = this.AuthorRepository.FindById(authorVM.Id);
            Mapper.Map<AuthorViewModel, Author>(authorVM, author);
            this.AuthorRepository.SaveChanges();
            return author.Id;
        }

        /// <summary>
        /// Deletes an author.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        public void DeleteAuthor(int authorId)
        {
            Author author = this.AuthorRepository.FindById(authorId);
            if (author == null)
            {
                throw new InvalidFieldValueException("Author does not exist.");
            }

            this.AuthorRepository.Delete(author);
            this.AuthorRepository.SaveChanges();
        }

        /// <summary>
        /// Gets x top authors in period no linger then 10 years.
        /// </summary>
        /// <param name="searchModel">Search model.</param>
        /// <returns>List of top authors.</returns>
        public List<TopAuthorViewModel> GetTopAuthors(SearchTopAuthorsViewModel searchModel)
        {
            return Mapper.Map<List<TopAuthorViewModel>>(this.AuthorRepository.GetTopAuthors(searchModel.Count, searchModel.BeginDate, searchModel.EndDate));
        }
    }
}
