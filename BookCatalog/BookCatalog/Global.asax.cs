﻿namespace BookCatalog.UI
{
    #region Using
    using System;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using BusinessLogic.AuthoMapperExtention;
    using BookCatalog.Infrastructure.Logging;
    using BookCatalog.Infrastructure.Logging.Concrete;
    using System.Web.Http;
    using App_Start;
    #endregion

    /// <summary>
    /// The class which is responsible for application-level events.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Exception logger.
        /// </summary>
        private ILogger logger = new Logger();
        
        /// <summary>
        /// Fired when the first instance of the HttpApplication class is created.
        /// </summary>
        protected void Application_Start()
        {
            this.logger = (ILogger)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ILogger));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfiguration.Configure();
        }

        /// <summary>
        /// Fired when an unhandled exception is encountered within the application.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event arguments.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            this.logger.Log(exception);
            Server.ClearError();
            Response.RedirectToRoute("ErrorPage");
        }
    }
}
