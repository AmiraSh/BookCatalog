namespace BookCatalog
{
    #region Using
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

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
