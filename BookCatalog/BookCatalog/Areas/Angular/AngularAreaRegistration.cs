namespace BookCatalog.UI.Areas.Angular
{
    #region Using
    using global::System.Web.Mvc;
    #endregion

    /// <summary>
    /// Angular area registration.
    /// </summary>
    public class AngularAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Area name.
        /// </summary>
        public override string AreaName 
        {
            get 
            {
                return "Angular";
            }
        }

        /// <summary>
        /// Registers ares.
        /// </summary>
        /// <param name="context">Context.</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Angular_default",
                "Angular/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}