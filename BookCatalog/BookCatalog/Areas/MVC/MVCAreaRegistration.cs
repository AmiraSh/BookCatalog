using System.Web.Mvc;

namespace BookCatalog.UI.Areas.MVC
{
    public class MVCAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MVC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "AuthorDetails",
                url: "MVC/Author/Details/{id}/{FirstName}/{LastName}/{BooksCount}",
                defaults: new { area = "MVC", controller = "Author", action = "Details", id = UrlParameter.Optional, FirstName = UrlParameter.Optional, LastName = UrlParameter.Optional, BooksCount = UrlParameter.Optional });

            context.MapRoute(
                "MVC_default",
                "MVC/{controller}/{action}/{id}",
                new
                { area = "MVC", controller = "Book", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}