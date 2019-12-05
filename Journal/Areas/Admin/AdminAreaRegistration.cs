using System.Web.Mvc;

namespace Journal.Areas.Admin
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
                "Dashboard",
                "admin/",
                new { controller = "Dashboard", action = "Index" }
            );
        }
    }
}