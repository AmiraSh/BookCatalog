using System.Web.Mvc;

namespace BookCatalog.UI.Areas.KendoAngular
{
    public class KendoAngularAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "KendoAngular";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "KendoAngular_default",
                "KendoAngular/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}