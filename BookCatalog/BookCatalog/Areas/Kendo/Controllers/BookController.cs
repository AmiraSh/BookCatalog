namespace BookCatalog.UI.Areas.Kendo.Controllers
{
    #region Using
    using System.Controllers;
    using BusinessLogic.DomainModel;
    using BusinessLogic.Validation;
    using BusinessLogic.ViewModels;
    using DAL.Interfaces;
    using global::Kendo.Mvc.Extensions;
    using global::Kendo.Mvc.UI;
    using global::System.Web.Mvc;
    using Infrastructure.Errors;
    using KendoAnalysing;
    #endregion

    /// <summary>
    /// Book's catalog controller.
    /// </summary>
    public class BookController : BaseController
    {
        /// <summary>
        /// Domain model.
        /// </summary>
        private BookDomainModel domainModel;

        /// <summary>
        /// Gets the domain model or creates new if it was null.
        /// </summary>
        private BookDomainModel DomainModel
        {
            get
            {
                if (domainModel == null)
                {
                    domainModel = new BookDomainModel((IBookRepository)DependencyResolver.Current.GetService(typeof(IBookRepository)), (IAuthorRepository)DependencyResolver.Current.GetService(typeof(IAuthorRepository)));
                }

                return domainModel;
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
            var sorts = KendoAnalyser.GetSorts(request.Sorts);
            var filters = KendoAnalyser.GetFilters(request.Filters);
            var books = this.DomainModel.GetBooks(out total, sorts, filters, request.PageSize, (request.Page - 1) * request.PageSize);
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
            this.DomainModel.DeleteBook(bookViewModel.Id);
            return this.Json(new[] { bookViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}