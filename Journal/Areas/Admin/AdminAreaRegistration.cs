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

            // MEDIA ROUTES
            context.MapRoute(
                "Media Upload",
                "admin/media/upload/",
                new { controller = "Media", action = "Upload" }
            );

            // JOURNALS ROUTES
            context.MapRoute(
                "Journals List",
                "admin/journals/",
                new { controller = "Journals", action = "Index" }
            );

            context.MapRoute(
                "Published Journals",
                "admin/journals/published/",
                new { controller = "Journals", action = "Published" }
            );

            context.MapRoute(
                "Non-published Journals",
                "admin/journals/non-published/",
                new { controller = "Journals", action = "NonPublished" }
            );

            context.MapRoute(
                "Deleted Journals",
                "admin/journals/deleted/",
                new { controller = "Journals", action = "Deleted" }
            );

            context.MapRoute(
                "Add Journals",
                "admin/journals/add/",
                new { controller = "Journals", action = "Add" }
            );

            context.MapRoute(
                "Edit Journals",
                "admin/journals/edit/{id}",
                new { controller = "Journals", action = "Edit", id = 0 }
            );

            context.MapRoute(
                "Delete Journals",
                "admin/journals/delete/{id}",
                new { controller = "Journals", action = "Delete", id = 0 }
            );
        }
    }
}