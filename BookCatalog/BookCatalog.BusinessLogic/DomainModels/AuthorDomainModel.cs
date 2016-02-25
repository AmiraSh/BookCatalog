namespace BookCatalog.BusinessLogic.DomainModels
{
    #region Using
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using AutoMapper;
    using DAL.Interfaces;
    using DAL.Models;
    using Infrastructure.Errors;
    using Infrastructure.Filtration;
    using Mappers;
    using ViewModels;
    #endregion

    /// <summary>
    /// Author domain model.
    /// </summary>
    public class AuthorDomainModel
    {
        /// <summary>
        /// Author repository.
        /// </summary>
        private IAuthorRepository authorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorDomainModel"/> class.
        /// </summary>
        /// <param name="authorRepository">Author repository.</param>
        public AuthorDomainModel(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        /// <summary>
        /// Gets authors.
        /// </summary>
        /// <returns>List of authors view model.</returns>
        public List<AuthorViewModel> GetAuthors()
        {
            return Mapper.Map<List<AuthorViewModel>>(this.authorRepository.GetAll().ToList());
        }

        /// <summary>
        /// Gets authors.
        /// </summary>
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

            return Mapper.Map<List<AuthorViewModel>>(this.authorRepository.Take(out total, sorts, filters, take, skip).ToList());
        }

        /// <summary>
        /// Gets author's books.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <returns>List of author's books.</returns>
        public List<Book> GetBooks(int authorId)
        {
            Author author = this.authorRepository.FindById(authorId);
            if (author == null)
            {
                throw new InvalidFieldValueException("Author does not exist.");
            }

            return author.Books.ToList();
        }

        /// <summary>
        /// Gets an author.
        /// </summary>
        /// <param name="id">Author id.</param>
        /// <returns>Author view model.</returns>
        public AuthorViewModel GetAuthor(int id)
        {
            return Mapper.Map<AuthorViewModel>(this.authorRepository.FindById(id));
        }

        /// <summary>
        /// Adds a new author to database.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        public void AddAuthor(AuthorViewModel authorVM)
        {
            Author author = Mapper.Map<Author>(authorVM);
            this.authorRepository.Add(author);
            this.authorRepository.SaveChanges();
            authorVM.Id = author.Id;
        }

        /// <summary>
        /// Edits an author in database.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        public void EditAuthor(AuthorViewModel authorVM)
        {
            Author author = this.authorRepository.FindById(authorVM.Id);
            AuthorMapper.Map(authorVM, ref author);
            this.authorRepository.SaveChanges();
        }

        /// <summary>
        /// Deletes an author.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        public void DeleteAuthor(int authorId)
        {
            Author author = this.authorRepository.FindById(authorId);
            if (author == null)
            {
                throw new InvalidFieldValueException("Author does not exist.");
            }

            this.authorRepository.Delete(author);
            this.authorRepository.SaveChanges();
        }
    }
}
