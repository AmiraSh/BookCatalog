//-----------------------------------------------------------------------
// <copyright file="AuthorController.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.API.Controllers
{
    #region Using
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Description;
    using System.Web.Mvc;
    using BookCatalog.Components.Validation;
    using BookCatalog.Components.ViewModels;
    using BookCatalog.Infrastructure.Errors;
    using System.Linq;
    using Services.ServiceWrappers.Interfaces;
    using Microsoft.Practices.Unity;
    #endregion

    /// <summary>
    /// Author api controller.
    /// </summary>
    public class AuthorController : ApiController
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        [Dependency]
        protected IAuthorServiceWrapper DomainModel { get; set; }

        /// <summary>
        /// Gets all authors.
        /// </summary>
        /// <returns>Authors' list.</returns>
        public IEnumerable<AuthorViewModel> GetAll()
        {
            return this.DomainModel.GetAllAuthors().AsEnumerable();
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
        /// <returns>Http action result.</returns>
        [ResponseType(typeof(AuthorViewModel))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                this.DomainModel.Delete(id);
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
        /// <returns>Http action result.</returns>
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
                return this.BadRequest(ModelState);
            }

            this.DomainModel.Manage(author);
            return this.CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
        }
    }
}
