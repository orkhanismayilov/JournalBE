using Journal.Models;
using System.Collections.Generic;

namespace Journal.Areas.Admin.Models
{
    public class ViewCategories
    {
        public ViewCategories() { }

        public Category Category { get; set; } = new Category();
        public List<Breadcrumb> Breadcrumbs { get; set; } = new List<Breadcrumb>()
        {
            new Breadcrumb
            {
                title = "Categories",
                link = "/admin/categories/"
            }
        };
        public List<Category> CategoriesList { get; set; } = new List<Category>();
        public List<Image> Images { get; set; } = new List<Image>();
        public string ErrorMsg { get; set; } = "";
        public IDictionary<int, string> ActiveStatusList { get; set; } = new Dictionary<int, string>
        {
            { 0, "Inactive" },
            { 1, "Active" }
        };
    }
}