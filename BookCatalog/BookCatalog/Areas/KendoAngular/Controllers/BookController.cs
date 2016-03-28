namespace BookCatalog.UI.Areas.KendoAngular.Controllers
{
    #region Using
    using global::System.Web.Mvc;
    #endregion

    /// <summary>
    /// Controller to work with books using kendo + angular.
    /// </summary>
    public class BookController : Controller
    {
        /// <summary>
        /// Index page.
        /// </summary>
        /// <returns>Index page.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}