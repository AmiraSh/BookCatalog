//-----------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="Apriorit">
//     Copyright (c). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BookCatalog.UI
{
    #region Using
    using System.Web.Optimization;
    #endregion

    /// <summary>
    /// Bundles configuration.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registers bundles.
        /// </summary>
        /// <param name="bundles">Bundles collection.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-validate").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/dataTables.bootstrap.min.js",
                      "~/Scripts/dataTables.scroller.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/dataTables.bootstrap.min.css",
                      "~/Content/dataTables.scroller.min.css",
                      "~/Content/site.css",
                      "~/Content/custom.css"));

            bundles.Add(new ScriptBundle("~/bundles/multiselect").Include(
                      "~/Scripts/chosen.jquery.js",
                      "~/Content/css/chosen.css"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/kendo/kendo.all.min.js",
                "~/Scripts/kendo/kendo.angular.min.js",
                "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                "~/Content/kendo/kendo.common-bootstrap.min.css",
                "~/Content/kendo/kendo.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                      "~/Scripts/angular.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/appjs").Include(
                      "~/Scripts/angularController/authorController.js",
                      "~/Scripts/angularController/bookController.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                      "~/Scripts/knockout-3.4.0.js",
                      "~/Scripts/knockoutjs/bookscript.js"));

            bundles.IgnoreList.Clear();
        }
    }
}
