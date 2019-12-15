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
            // DASHBOARD ROUTES
            context.MapRoute(
                "Dashboard",
                "admin/",
                new { controller = "Dashboard", action = "Index" }
            );

            // ISSUES ROUTES
            context.MapRoute(
                "Issues List",
                "admin/issues/",
                new { controller = "Issues", action = "Index" }
            );

            context.MapRoute(
                "Published Issues",
                "admin/issues/published/",
                new { controller = "Issues", action = "Published" }
            );

            context.MapRoute(
                "Non-published Issues",
                "admin/issues/non-published/",
                new { controller = "Issues", action = "NonPublished" }
            );

            context.MapRoute(
                "Deleted Issues",
                "admin/issues/deleted/",
                new { controller = "Issues", action = "Deleted" }
            );

            context.MapRoute(
                "Add Issues",
                "admin/issues/add/",
                new { controller = "Issues", action = "Create" }
            );

            context.MapRoute(
                "Edit Issues",
                "admin/issues/edit/{id}",
                new { controller = "Issues", action = "Edit", id = 0 }
            );

            context.MapRoute(
                "Delete Issues",
                "admin/issues/delete/{id}",
                new { controller = "Issues", action = "Delete", id = 0 }
            );
        }
    }
}