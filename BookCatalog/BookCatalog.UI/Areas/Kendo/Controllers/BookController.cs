//-----------------------------------------------------------------------
// <copyright file="BookController.cs" company="Apriorit">
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
    using Services.ServiceWrappers.Interfaces;
    using Microsoft.Practices.Unity;
    #endregion

    /// <summary>
    /// Book's catalog controller.
    /// </summary>
    public class BookController : BaseController
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        [Dependency]
        protected IBookServiceWrapper DomainModel { get; set; }
        
        /// <summary>
        /// Gets grid view.
        /// </summary>
        /// <returns>Grid view.</returns>
        public ActionResult Grid()
        {
            return this.View(this.DomainModel.PopulateMultiSelectList());
        }

        /// <summary>
        /// Reads grids' elements.
        /// </summary>
        /// <param name="request">Data source request.</param>
        /// <returns>Grids' elements.</returns>
        public JsonResult Read([DataSourceRequest]DataSourceRequest request)
        {
            int total;
            Dictionary<string, ListSortDirection> sorts = KendoAnalyser.GetSorts(request.Sorts);
            List<CustomFilter> filters = KendoAnalyser.GetFilters(request.Filters);
            List<BookViewModel> books = this.DomainModel.GetBooks(out total, sorts, filters, request.PageSize, (request.Page - 1) * request.PageSize);
            DataSourceResult result = books.ToDataSourceResult(request);
            result.Data = books;
            result.Total = total;
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creates or updates an entity.
        /// </summary>
        /// <param name="request">Data source request.</param>
        /// <param name="bookViewModel">Book view model.</param>
        /// <returns>Created or updated entity.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult KendoManage([DataSourceRequest]DataSourceRequest request, BookViewModel bookViewModel)
        {
            try
            {
                Validator.Validate(bookViewModel);
            }
            catch (InvalidFieldValueException exception)
            {
                this.ModelState.AddModelError(exception.Field, exception.ValidationMessage);
                return this.Json(new[] { bookViewModel }.ToDataSourceResult(request, this.ModelState));
            }

            this.DomainModel.Manage(bookViewModel);
            return this.Json(new[] { bookViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="request">Data source request.</param>
        /// <param name="bookViewModel">Book view model.</param>
        /// <returns>Deleted entity.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Destroy([DataSourceRequest]DataSourceRequest request, BookViewModel bookViewModel)
        {
            this.DomainModel.Delete(bookViewModel.Id);
            return this.Json(new[] { bookViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}