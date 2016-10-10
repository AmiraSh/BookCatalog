namespace BookCatalog.ServicesBootstrap
{
    #region Using
    using Microsoft.Practices.Unity;
    using System;
    using System.ServiceModel;
    #endregion Using

    public class UnityServiceHost : ServiceHost
    {
        public UnityContainer Container { get; set; }


        public UnityServiceHost()
            : base()
        {
            Container = new UnityContainer();
        }

        public UnityServiceHost(Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses)
        {
            Container = new UnityContainer();
        }

        protected override void OnOpening()
        {
            base.OnOpening();

            if (this.Description.Behaviors.Find<UnityServiceBehavior>() == null)
                this.Description.Behaviors.Add(new UnityServiceBehavior(Container));

        }
    }
}
