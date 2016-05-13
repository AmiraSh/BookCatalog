//-----------------------------------------------------------------------
// <copyright file="AuthorController.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.Areas.Kendo.Controllers
{
    #region Using
    using System.Controllers;
    using global::System.Collections.Generic;
    using global::System.ComponentModel;
    using global::System.Web.Mvc;
    using Components.Validation;
    using Components.ViewModels;
    using global::Kendo.Mvc.Extensions;
    using global::Kendo.Mvc.UI;
    using Infrastructure.Errors;
    using Infrastructure.Filtration;
    using KendoAnalysing;
    using ServiceWrappers.Interfaces;
    #endregion

    /// <summary>
    /// Author controller.
    /// </summary>
    public class AuthorController : BaseController
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        private IAuthorServiceWrapper domainModel;

        /// <summary>
        /// Gets the domain model or creates new if it was null.
        /// </summary>
        private IAuthorServiceWrapper DomainModel
        {
            get
            {
                return this.domainModel != null ? this.domainModel : this.domainModel = (IAuthorServiceWrapper)DependencyResolver.Current.GetService(typeof(IAuthorServiceWrapper));
            }
        }
        
        /// <summary>
        /// Gets grid view.
        /// </summary>
        /// <returns>Grid view.</returns>
        public ActionResult Grid()
        {
            return this.View();
        }

        /// <summary>
        /// Gets partial view for books' rating chart.
        /// </summary>
        /// <param name="id">Author identifier.</param>
        /// <returns>Partial view for books' rating chart.</returns>
        public ActionResult BooksChart(int? id)
        {
            if (id == null)
            {
                return this.PartialView();
            }

            return this.PartialView(this.DomainModel.GetAuthor(id.Value));
        }

        /// <summary>
        /// Reads grids' elements.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <returns>Grids' elements.</returns>
        public JsonResult Read([DataSourceRequest]DataSourceRequest request)
        {
            int total;
            Dictionary<string, ListSortDirection> sorts = KendoAnalyser.GetSorts(request.Sorts);
            List<CustomFilter> filters = KendoAnalyser.GetFilters(request.Filters);
            List<AuthorViewModel> authors = this.DomainModel.GetAuthors(out total, sorts, filters, request.PageSize, (request.Page - 1) * request.PageSize);
            DataSourceResult result = authors.ToDataSourceResult(request);
            result.Data = authors;
            result.Total = total;
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creates or updates an entity.
        /// </summary>
        /// <param name="request">Data source request.</param>
        /// <param name="authorViewModel">Author view model.</param>
        /// <returns>Created or updated entity.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult KendoManage([DataSourceRequest]DataSourceRequest request, AuthorViewModel authorViewModel)
        {
            try
            {
                Validator.Validate(authorViewModel);
            }
            catch (InvalidFieldValueException exception)
            {
                this.ModelState.AddModelError(exception.Field, exception.ValidationMessage);
                return this.Json(new[] { authorViewModel }.ToDataSourceResult(request, this.ModelState));
            }

            this.DomainModel.Manage(authorViewModel);
            return this.Json(new[] { authorViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="request">Data source request.</param>
        /// <param name="authorViewModel">Author view model.</param>
        /// <returns>Deleted entity.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Destroy([DataSourceRequest]DataSourceRequest request, AuthorViewModel authorViewModel)
        {
            this.DomainModel.Delete(authorViewModel.Id);
            return this.Json(new[] { authorViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}