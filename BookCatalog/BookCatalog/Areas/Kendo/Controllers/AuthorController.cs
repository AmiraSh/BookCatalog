namespace BookCatalog.UI.Areas.Kendo.Controllers
{
    #region Using
    using System.Controllers;
    using BusinessLogic.DomainModels;
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
    /// Author controller.
    /// </summary>
    public class AuthorController : BaseController
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
        /// Grid.
        /// </summary>
        /// <returns>Grid view.</returns>
        public ActionResult Grid()
        {
            return this.View();
        }

        /// <summary>
        /// Gets partial view for books' rating chart.
        /// </summary>
        /// <param name="Id">Author identifier.</param>
        /// <returns>Partial view for books' rating chart.</returns>
        public ActionResult BooksChart(int? Id)
        {
            if (Id == null)
            {
                return this.PartialView();
            }

            return this.PartialView(this.DomainModel.GetAuthor(Id.Value));
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
            var authors = this.DomainModel.GetAuthors(out total, sorts, filters, request.PageSize, (request.Page - 1) * request.PageSize);
            DataSourceResult result = authors.ToDataSourceResult(request);
            result.Data = authors;
            result.Total = total;
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creates or updates an entity.
        /// </summary>
        /// <param name="request">Request.</param>
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
        /// <param name="request">Request.</param>
        /// <param name="authorViewModel">Author view model.</param>
        /// <returns>Deleted entity.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Destroy([DataSourceRequest]DataSourceRequest request, AuthorViewModel authorViewModel)
        {
            this.DomainModel.DeleteAuthor(authorViewModel.Id);
            return this.Json(new[] { authorViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}