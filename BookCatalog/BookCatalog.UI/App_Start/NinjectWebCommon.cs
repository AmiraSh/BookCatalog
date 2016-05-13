//-----------------------------------------------------------------------
// <copyright file="NinjectWebCommon.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BookCatalog.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BookCatalog.UI.App_Start.NinjectWebCommon), "Stop")]

namespace BookCatalog.UI.App_Start
{
    #region Using
    using System;
    using System.Configuration;
    using System.Web;
    using Infrastructure.Logging;
    using Infrastructure.Logging.Concrete;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using ServiceWrappers;
    using ServiceWrappers.Concrete.WcfService;
    using ServiceWrappers.Concrete.WebService;
    using ServiceWrappers.Interfaces;
    #endregion

    /// <summary>
    /// Ninject class.
    /// </summary>
    public static class NinjectWebCommon 
    {
        /// <summary>
        /// Bootstrapper.
        /// </summary>
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILogger>().To<Logger>();
            kernel.Bind<BookService.IBookService>().To<BookService.BookServiceClient>();
            kernel.Bind<AuthorService.IAuthorService>().To<AuthorService.AuthorServiceClient>();
            kernel.Bind<BookWebService.BookWebServiceSoap>().To<BookWebService.BookWebServiceSoapClient>();
            kernel.Bind<AuthorWebService.AuthorWebServiceSoap>().To<AuthorWebService.AuthorWebServiceSoapClient>();
            switch (ConfigurationManager.AppSettings["service"])
            {
                case ServiceOptions.Web:
                    kernel.Bind<IAuthorServiceWrapper>().To<WebAuthorServiceWrapper>();
                    kernel.Bind<IBookServiceWrapper>().To<WebBookServiceWrapper>();
                    break;
                case ServiceOptions.Wcf:
                default:
                    kernel.Bind<IAuthorServiceWrapper>().To<WcfAuthorServiceWrapper>();
                    kernel.Bind<IBookServiceWrapper>().To<WcfBookServiceWrapper>();
                    break;
            }
        }        
    }
}
