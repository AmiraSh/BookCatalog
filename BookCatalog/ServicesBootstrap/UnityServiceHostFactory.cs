namespace BookCatalog.ServicesBootstrap
{
    #region Using
    using Microsoft.Practices.Unity;
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity.Mvc;
    using App_Start;
    #endregion Using

    public class UnityServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            UnityServiceHost serviceHost = new UnityServiceHost(serviceType, baseAddresses);
            var container = (UnityContainer)UnityConfig.GetConfiguredContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));            
            serviceHost.Container = container;
            return serviceHost;
        }
    }
}
