namespace BookCatalog.BusinessLogic.DomainModels
{
    #region Using
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;
    using DAL.Interfaces;
    using DAL.Models;
    using Infrastructure.Errors;
    using Mappers;
    using Validation;
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
        /// Gets an author.
        /// </summary>
        /// <param name="id">Author id.</param>
        /// <returns>List of authors view model.</returns>
        public List<AuthorViewModel> GetAuthors()
        {
            return AuthorMapper.Map(this.authorRepository.GetAll().ToList());
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
            return AuthorMapper.Map(this.authorRepository.FindById(id));
        }

        /// <summary>
        /// Adds a new author to database.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Status of operation.</returns>
        public void AddAuthor(AuthorViewModel authorVM)
        {
            Author author = AuthorMapper.Map(authorVM);
            this.authorRepository.Add(author);
            this.authorRepository.SaveChanges();
            authorVM.Id = author.Id;
        }

        /// <summary>
        /// Edits an author in database.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Status of operation.</returns>
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
        /// <returns>Status of operation.</returns>
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
