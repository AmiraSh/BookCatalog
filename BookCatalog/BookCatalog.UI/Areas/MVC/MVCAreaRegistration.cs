//-----------------------------------------------------------------------
// <copyright file="MVCAreaRegistration.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.Areas.MVC
{
    #region Using
    using global::System.Web.Mvc;
    #endregion

    /// <summary>
    /// MVC area registration.
    /// </summary>
    public class MVCAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Area name.
        /// </summary>
        public override string AreaName 
        {
            get 
            {
                return "MVC";
            }
        }

        /// <summary>
        /// Registers ares.
        /// </summary>
        /// <param name="context">Area registration context.</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(name: "AuthorDetails", url: "MVC/Author/Details/{id}/{FirstName}/{LastName}/{BooksCount}", defaults: new { area = "MVC", controller = "Author", action = "Details", id = UrlParameter.Optional, FirstName = UrlParameter.Optional, LastName = UrlParameter.Optional, BooksCount = UrlParameter.Optional });
            context.MapRoute("MVC_default", "MVC/{controller}/{action}/{id}", new { area = "MVC", controller = "Book", action = "Index", id = UrlParameter.Optional });
        }
    }
}