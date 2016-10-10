//-----------------------------------------------------------------------
// <copyright file="BaseController.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.Areas.System.Controllers
{
    #region Using
    using BookCatalog.Infrastructure.Logging;
    using global::System.Web.Mvc;
    using Microsoft.Practices.Unity;
    #endregion

    /// <summary>
    /// Base controller.
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// The logger.
        /// </summary>
        [Dependency]
        protected ILogger logger { get; set; }

        /// <summary>
        /// Overridden OnException method to catch server exceptions. If the request is AJAX return JSON else redirect user to Error view.
        /// </summary>
        /// <param name="filterContext">Exception context.</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            this.logger.Log(filterContext.Exception);
            filterContext.ExceptionHandled = true;
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { error = true, message = filterContext.Exception.Message }
                };
            }
            else
            {
                filterContext.Result = this.View("Error", new HandleErrorInfo(filterContext.Exception, filterContext.RouteData.Values["controller"].ToString(), filterContext.RouteData.Values["action"].ToString()));
            }

            base.OnException(filterContext);
        }
    }
}