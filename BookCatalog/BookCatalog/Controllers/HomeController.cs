namespace BookCatalog.Controllers
{
    #region Using
    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Displays main page.
        /// </summary>
        /// <returns>Main page.</returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Displays a page with books grid.
        /// </summary>
        /// <returns>The page.</returns>
        public ActionResult BookGrid()
        {
            return this.View();
        }

        /// <summary>
        /// Displays a page with authors grid.
        /// </summary>
        /// <returns>The page.</returns>
        public ActionResult AuthorGrid()
        {
            return this.View();
        }
    }
}