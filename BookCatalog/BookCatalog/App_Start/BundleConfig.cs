namespace BookCatalog
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

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            
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
                      "~/Content/jquery.dataTables.min.css",
                      "~/Content/dataTables.scroller.min.css",
                      "~/Content/site.css",
                      "~/Content/custom.css"));
        }
    }
}
