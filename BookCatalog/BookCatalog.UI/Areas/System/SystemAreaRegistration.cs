//-----------------------------------------------------------------------
// <copyright file="SystemAreaRegistration.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.Areas.System
{
    #region Using
    using global::System.Web.Mvc;
    #endregion

    /// <summary>
    /// System area registration.
    /// </summary>
    public class SystemAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Area name.
        /// </summary>
        public override string AreaName 
        {
            get 
            {
                return "System";
            }
        }

        /// <summary>
        /// Registers ares.
        /// </summary>
        /// <param name="context">Area registration context.</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("System_default", "System/{controller}/{action}/{id}", new { id = UrlParameter.Optional });
        }
    }
}