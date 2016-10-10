//-----------------------------------------------------------------------
// <copyright file="KnockoutJSAreaRegistration.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.Areas.KnockoutJS
{
    #region Using
    using global::System.Web.Mvc;
    #endregion

    /// <summary>
    /// KnockoutJS area registration.
    /// </summary>
    public class KnockoutJSAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Area name.
        /// </summary>
        public override string AreaName 
        {
            get 
            {
                return "KnockoutJS";
            }
        }

        /// <summary>
        /// Registers ares.
        /// </summary>
        /// <param name="context">Area registration context.</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "KnockoutJS_default",
                "KnockoutJS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}