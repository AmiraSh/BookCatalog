//-----------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI
{
    #region Using
    using System.Net.Http.Headers;
    using System.Web.Http;
    #endregion

    /// <summary>
    /// Routes configuration.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers routes.
        /// </summary>
        /// <param name="config">Http configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "ApiWithAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
