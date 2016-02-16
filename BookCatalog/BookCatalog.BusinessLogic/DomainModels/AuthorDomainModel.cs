namespace BookCatalog.BusinessLogic.DomainModels
{
    #region Using
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;
    using DAL.Interfaces;
    using DAL.Models;
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
        public List<AuthorViewModel> GetAuthors()
        {
            return AuthorMapper.Map(this.authorRepository.GetAll().ToList());
        }

        /// <summary>
        /// Gets an author.
        /// </summary>
        /// <param name="id">Author id.</param>
        public AuthorViewModel GetAuthor(int id)
        {
            return AuthorMapper.Map(this.authorRepository.FindById(id));
        }

        /// <summary>
        /// Adds a new author to database.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Status of operation.</returns>
        public int AddAuthor(AuthorViewModel authorVM)
        {
            int validCheck = Validator.Validate(authorVM);
            if (validCheck == 0)
            {
                Author author = AuthorMapper.Map(authorVM);
                this.authorRepository.Add(author);
                this.authorRepository.SaveChanges();
                authorVM.Id = author.Id;
            }

            return validCheck;
        }

        /// <summary>
        /// Edits an author in database.
        /// </summary>
        /// <param name="authorVM">Author view model.</param>
        /// <returns>Status of operation.</returns>
        public int EditAuthor(AuthorViewModel authorVM)
        {
            int validCheck = Validator.Validate(authorVM);
            if (validCheck == 0)
            {
                Author author = this.authorRepository.FindById(authorVM.Id);
                AuthorMapper.Map(authorVM, ref author);
                this.authorRepository.SaveChanges();
            }

            return validCheck;
        }

        /// <summary>
        /// Deletes an author.
        /// </summary>
        /// <param name="authorId">Author id.</param>
        /// <returns>Status of operation.</returns>
        public int DeleteAuthor(int authorId)
        {
            Author author = this.authorRepository.FindById(authorId);
            if (author == null)
            {
                return 1;
            }

            this.authorRepository.Delete(author);
            this.authorRepository.SaveChanges();
            return 0;
        }
    }
}
