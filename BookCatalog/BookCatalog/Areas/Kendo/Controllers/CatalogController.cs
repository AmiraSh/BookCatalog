namespace BookCatalog.UI.Areas.Kendo.Controllers
{
    #region Using
    using global::System.Web.Mvc;
    #endregion

    public class CatalogController : Controller
    {
        /// <summary>
        /// Gets main page.
        /// </summary>
        /// <returns>Main page.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}