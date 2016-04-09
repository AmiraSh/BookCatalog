namespace BookCatalog.UI.Areas.Kendo
{
    #region Using
    using global::System.Web.Mvc;
    #endregion

    /// <summary>
    /// Kendo area registration.
    /// </summary>
    public class KendoAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Area name.
        /// </summary>
        public override string AreaName 
        {
            get 
            {
                return "Kendo";
            }
        }

        /// <summary>
        /// Registers ares.
        /// </summary>
        /// <param name="context">Context.</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Kendo_default",
                "Kendo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}