//-----------------------------------------------------------------------
// <copyright file="CatalogController.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.Areas.Kendo.Controllers
{
    #region Using
    using global::System.Web.Mvc;
    #endregion

    /// <summary>
    /// Catalog controller.
    /// </summary>
    public class CatalogController : Controller
    {
        /// <summary>
        /// Gets main page.
        /// </summary>
        /// <returns>Main page.</returns>
        public ActionResult Index()
        {
            return this.View();
        }
    }
}