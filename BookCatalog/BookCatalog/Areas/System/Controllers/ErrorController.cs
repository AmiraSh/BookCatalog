namespace BookCatalog.UI.Areas.System.Controllers
{
    #region Using
    using global::System.Web.Mvc;
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