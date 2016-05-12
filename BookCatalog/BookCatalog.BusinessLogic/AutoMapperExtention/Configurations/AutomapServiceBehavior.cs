//-----------------------------------------------------------------------
// <copyright file="AutomapServiceBehavior.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.BusinessLogic.AutoMapperExtention.Configurations
{
    #region Using
    using System;
    using System.Collections.ObjectModel;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using BookCatalog.BusinessLogic.AutoMapperExtention;
    #endregion Using

    /// <summary>
    /// Auto mapper service configuration.
    /// </summary>
    public sealed class AutomapServiceBehavior : Attribute, IServiceBehavior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutomapServiceBehavior"/> class.
        /// </summary>
        public AutomapServiceBehavior()
        {
        }
        
        /// <summary>
        /// Adds binding parameters.
        /// </summary>
        /// <param name="serviceDescription">Service description.</param>
        /// <param name="serviceHostBase">Service host base.</param>
        /// <param name="endpoints">Endpoints' collection.</param>
        /// <param name="bindingParameters">Binding parameters.</param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            AutoMapperConfiguration.Configure();
        }

        /// <summary>
        /// Apply dispatch behavior.
        /// </summary>
        /// <param name="serviceDescription">Service description.</param>
        /// <param name="serviceHostBase">Service host base.</param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }

        /// <summary>
        /// Validates entity.
        /// </summary>
        /// <param name="serviceDescription">Service description.</param>
        /// <param name="serviceHostBase">Service host base.</param>
        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }
    }
}