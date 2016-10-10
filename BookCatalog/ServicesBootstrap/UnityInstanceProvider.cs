namespace BookCatalog.ServicesBootstrap
{
    #region Using
    using Microsoft.Practices.Unity;
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;
    #endregion Using

    public class UnityInstanceProvider : IInstanceProvider
    {
        public UnityContainer Container { set; get; }
        public Type ServiceType { set; get; }


        public UnityInstanceProvider() : this(null)
        {
        }

        public UnityInstanceProvider(Type type)
        {
            ServiceType = type;
            Container = new UnityContainer();
        }

        // Get Service instace via unity container
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return Container.Resolve(ServiceType);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}
