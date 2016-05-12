namespace BookCatalog.UI.Areas.Kendo.Controllers
{
    #region Using
    using System.Controllers;
    using Components.Validation;
    using Components.ViewModels;
    using global::Kendo.Mvc.Extensions;
    using global::Kendo.Mvc.UI;
    using global::System.Collections.Generic;
    using global::System.ComponentModel;
    using global::System.Web.Mvc;
    using Infrastructure.Errors;
    using Infrastructure.Filtration;
    using KendoAnalysing;
    using ServiceWrappers.Interfaces;
    #endregion

    /// <summary>
    /// Book's catalog controller.
    /// </summary>
    public class BookController : BaseController
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        private IBookServiceWrapper domainModel;

        /// <summary>
        /// Gets the domain model or creates new if it was null.
        /// </summary>
        private IBookServiceWrapper DomainModel
        {
            get
            {
                return domainModel != null ? domainModel : domainModel = (IBookServiceWrapper)DependencyResolver.Current.GetService(typeof(IBookServiceWrapper));
            }
        }
        
        /// <summary>
        /// Grid.
        /// </summary>
        /// <returns>Grid view.</returns>
        public ActionResult Grid()
        {
            return this.View(this.DomainModel.PopulateMultiSelectList());
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
            List<BookViewModel> books = this.DomainModel.GetBooks(out total, sorts, filters, request.PageSize, (request.Page - 1) * request.PageSize);
            DataSourceResult result = books.ToDataSourceResult(request);
            result.Data = books;
            result.Total = total;
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creates or updates an entity.
        /// </summary>
        /// <param name="request">Request.</param>
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
        /// <param name="request">Request.</param>
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