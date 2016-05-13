//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.WebService
{
    #region Using
    using System;
    using BusinessLogic.AutoMapperExtention;
    #endregion

    /// <summary>
    /// The class which is responsible for application-level events.
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Fired when the first instance of the HttpApplication class is created.
        /// </summary>
        protected void Application_Start(object sender, EventArgs e)
        {
            AutoMapperConfiguration.Configure();
        }
    }
}