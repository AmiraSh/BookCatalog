namespace BookCatalog
{
    #region Using
    using System.Web.Mvc;
    using System.Web.Routing;
    #endregion

    /// <summary>
    /// Routes configuration.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers routes.
        /// </summary>
        /// <param name="routes">Routes collection.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ErrorPage",
                url: "Error/Index",
                defaults: new { controller = "Error", action = "Index" });

            routes.MapRoute(
                name: "AuthorDetails",
                url: "Author/Details/{FirstName}/{LastName}/{BooksCount}",
                defaults: new { controller = "Author", action = "Details", FirstName = UrlParameter.Optional, LastName = UrlParameter.Optional, BooksCount = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "Index", id = UrlParameter.Optional });
        }
    }
}
