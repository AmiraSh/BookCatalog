//-----------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI
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
                url: "System/Error/Index",
                defaults: new { area = "System", controller = "Error", action = "Index" },
                namespaces: new[] { "BookCatalog.UI.Areas.System.Controllers" });
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
