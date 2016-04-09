namespace BookCatalog.API.Controllers
{
    #region Using
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Description;
    using System.Web.Mvc;
    using BookCatalog.BusinessLogic.DomainModels;
    using BookCatalog.BusinessLogic.Validation;
    using BookCatalog.BusinessLogic.ViewModels;
    using BookCatalog.DAL.Interfaces;
    using BookCatalog.Infrastructure.Errors;
    #endregion

    /// <summary>
    /// Author api controller.
    /// </summary>
    public class AuthorController : ApiController
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        private AuthorDomainModel domainModel;

        /// <summary>
        /// Gets the domain model or creates new if it was null.
        /// </summary>
        private AuthorDomainModel DomainModel
        {
            get
            {
                if (domainModel == null)
                {
                    domainModel = new AuthorDomainModel((IAuthorRepository)DependencyResolver.Current.GetService(typeof(IAuthorRepository)));
                }

                return domainModel;
            }
        }

        /// <summary>
        /// Gets all authors.
        /// </summary>
        /// <returns>Authors' list.</returns>
        public IEnumerable<AuthorViewModel> GetAll()
        {
            return this.DomainModel.GetAuthors();
        }

        /// <summary>
        /// Gets author's details.
        /// </summary>
        /// <param name="id">Author identifier.</param>
        /// <returns>Author details.</returns>
        [ResponseType(typeof(AuthorViewModel))]
        public IHttpActionResult Get(int id)
        {
            AuthorViewModel author = this.DomainModel.GetAuthor(id);
            if (author == null)
            {
                return this.NotFound();
            }

            return this.Ok(author);
        }

        /// <summary>
        /// Deletes an author.
        /// </summary>
        /// <param name="id">Author identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(AuthorViewModel))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                this.DomainModel.DeleteAuthor(id);
            }
            catch (InvalidFieldValueException)
            {
                return this.NotFound();
            }

            return this.Ok(this.DomainModel.GetAuthor(id));
        }

        /// <summary>
        /// Creates or edits an author.
        /// </summary>
        /// <param name="author">Author view model.</param>
        /// <returns></returns>
        [ResponseType(typeof(AuthorViewModel))]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Manage(AuthorViewModel author)
        {
            try
            {
                Validator.Validate(author);
            }
            catch (InvalidFieldValueException exception)
            {
                this.ModelState.AddModelError(exception.Field, exception.ValidationMessage);
                return BadRequest(ModelState);
            }

            this.DomainModel.Manage(author);
            return this.CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
        }
    }
}
