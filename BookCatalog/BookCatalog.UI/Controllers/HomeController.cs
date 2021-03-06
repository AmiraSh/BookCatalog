﻿//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI.Controllers
{
    #region Using
    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Displays main page.
        /// </summary>
        /// <returns>Main page.</returns>
        public ActionResult Index()
        {
            return this.View();
        }
    }
}