namespace BookCatalog.UI.Areas.KendoAngular.Controllers
{
    #region Using
    using global::System.Web.Mvc;
    #endregion

    /// <summary>
    /// Controller to work with authors using kendo + angular.
    /// </summary>
    public class AuthorController : Controller
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