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

            // CATEGORIES ROUTES
            context.MapRoute(
                "Categories List",
                "admin/categories/",
                new { controller = "Categories", action = "Index" }
            );

            context.MapRoute(
                "Add Categories",
                "admin/categories/add/",
                new { controller = "Categories", action = "Add" }
            );

            context.MapRoute(
                "Edit Categories",
                "admin/categories/edit/{id}",
                new { controller = "Categories", action = "Edit", id = 0 }
            );

            context.MapRoute(
                "Delete Categories",
                "admin/categories/delete/{id}",
                new { controller = "Categories", action = "Delete", id = 0 }
            );

            // TAGS ROUTES
            context.MapRoute(
                "Tags List",
                "admin/tags/",
                new { controller = "Tags", action = "Index" }
            );

            context.MapRoute(
                "Add Tags",
                "admin/tags/add/",
                new { controller = "Tags", action = "Add" }
            );

            context.MapRoute(
                "Edit Tags",
                "admin/tags/edit/{id}",
                new { controller = "Tags", action = "Edit", id = 0 }
            );

            context.MapRoute(
                "Delete Tags",
                "admin/tags/delete/{id}",
                new { controller = "Tags", action = "Delete", id = 0 }
            );
        }
    }
}