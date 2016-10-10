using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using BookCatalog.Services.ServiceWrappers;
using BookCatalog.Infrastructure.Logging;
using BookCatalog.Infrastructure.Logging.Concrete;
using BookCatalog.Services.ServiceWrappers.Interfaces;
using BookCatalog.Services.ServiceWrappers.Concrete.WebService;
using BookCatalog.Services.ServiceWrappers.Concrete.WcfService;
using BookCatalog.Services.AuthorService;
using BookCatalog.Services.BookService;
using BookCatalog.Services.BookWebService;
using BookCatalog.Services.AuthorWebService;

namespace BookCatalog.Bootstrap.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            container.RegisterType<ILogger, Logger>();

            container.RegisterType<IAuthorService, AuthorServiceClient>(new InjectionConstructor());
            container.RegisterType<IBookService, BookServiceClient>(new InjectionConstructor());
            container.RegisterType<AuthorWebServiceSoap, AuthorWebServiceSoapClient>(new InjectionConstructor());
            container.RegisterType<BookWebServiceSoap, BookWebServiceSoapClient>(new InjectionConstructor());

            var _child = new ContainerWrapper(container.CreateChildContainer());

            switch (ConfigurationManager.AppSettings["service"])
            {
                case ServiceOptions.Web:
                    container.RegisterType<IAuthorServiceWrapper, WebAuthorServiceWrapper>(new InjectionConstructor(_child.Container.Resolve(typeof(AuthorWebServiceSoap))));
                    container.RegisterType<IBookServiceWrapper, WebBookServiceWrapper>(new InjectionConstructor(_child.Container.Resolve(typeof(BookWebServiceSoap))));
                    break;
                case ServiceOptions.Wcf:
                default:
                    container.RegisterType<IAuthorServiceWrapper, WcfAuthorServiceWrapper>(new InjectionConstructor(_child.Container.Resolve(typeof(IAuthorService))));
                    container.RegisterType<IBookServiceWrapper, WcfBookServiceWrapper>(new InjectionConstructor(_child.Container.Resolve(typeof(IBookService))));
                    break;
            }
        }

        public class ContainerWrapper : IDisposable
        {
            private UnityContainer _container;

            public UnityContainer Container { get { return _container; } }

            public ContainerWrapper(IUnityContainer container)
            {
                _container = (UnityContainer)container;
                Infrastructure.Logging.Concrete.InfoLogger.Log("ContainerWrapper", "Constructor");
            }

            ~ContainerWrapper()
            {
                Infrastructure.Logging.Concrete.InfoLogger.Log("ContainerWrapper", "Destructor");
            }

            public void Dispose()
            {
                _container.Dispose();
            }
        }
    }
}
