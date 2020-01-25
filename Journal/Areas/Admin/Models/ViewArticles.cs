using Journal.Models;
using System.Collections.Generic;
using System.Linq;

namespace Journal.Areas.Admin.Models
{
    public class ViewArticles
    {
        JournalEntities db = new JournalEntities();

        public ViewArticles() { 
            CategoriesList = db.Categories.Where(c => c.status == 1).ToList();
            TagsList = db.Tags.ToList();
            Images = db.Images.OrderByDescending(i => i.id).Take(18).ToList();
        }

        public Article Article { get; set; } = new Article();
        public List<Breadcrumb> Breadcrumbs { get; set; } = new List<Breadcrumb>()
        {
            new Breadcrumb
            {
                title = "Articles",
                link = "/admin/articles/published"
            }
        };
        public List<Article> ArticlesList { get; set; } = new List<Article>();
        public List<Category> CategoriesList { get; set; } = new List<Category>();
        public List<Tag> TagsList { get; set; } = new List<Tag>();
        public List<Image> Images { get; set; } = new List<Image>();
        public string ErrorMsg { get; set; } = "";
        public IDictionary<int, string> Statuses { get; set; } = new Dictionary<int, string>
        {
            { 0, "Non-published" },
            { 1, "Published" },
            { 2, "Deleted" }
        };
    }
}