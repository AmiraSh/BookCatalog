namespace BookCatalog.UI.Areas.Angular.Controllers
{
    #region Using
    using global::System.Web.Mvc;
    #endregion

    /// <summary>
    /// Home controller.
    /// </summary>
    public class CatalogController : Controller
    {
        /// <summary>
        /// Displays a page with books grid.
        /// </summary>
        /// <returns>The page.</returns>
        public ActionResult Books()
        {
            return this.View();
        }

        /// <summary>
        /// Displays a page with authors grid.
        /// </summary>
        /// <returns>The page.</returns>
        public ActionResult Authors()
        {
            return this.View();
        }
    }
}