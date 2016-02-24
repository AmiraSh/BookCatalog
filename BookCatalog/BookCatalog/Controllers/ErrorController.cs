﻿namespace BookCatalog.Controllers
{
    #region Using
    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// Error controller.
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Displays error page.
        /// </summary>
        /// <returns>Error page.</returns>
        public ActionResult Index()
        {
            return this.View();
        }
    }
}