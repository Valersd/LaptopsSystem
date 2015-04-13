using System.Web.Mvc;

namespace LaptopsSystem.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_elmah",
                "Admin/elmah/{type}",
                new { action = "Index", controller = "Elmah", type = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "LaptopsSystem.Web.Areas.Admin.Controllers" }
            );
        }
    }
}