using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Journal.Models;
using Journal.Areas.Admin.Models;

namespace Journal.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        JournalEntities db = new JournalEntities();
        ViewArticles viewArticles = new ViewArticles();

        // GET: Admin/Articles/Published
        public ActionResult Published()
        {
            List<Article> articlesList = db.Articles.Where(a => a.status == 1).OrderByDescending(a => a.date).Take(20).ToList();
            viewArticles.ArticlesList = articlesList;
            return View(model: viewArticles);
        }

        // GET: Admin/Articles/Non-Published
        public ActionResult NonPublished()
        {
            List<Article> articlesList = db.Articles.Where(a => a.status == 0).OrderByDescending(a => a.date).Take(20).ToList();
            viewArticles.ArticlesList = articlesList;
            return View(model: viewArticles);
        }

        // GET: Admin/Articles/Featured
        public ActionResult Featured()
        {
            List<FeaturedArticle> featuredArticlesList = db.FeaturedArticles.ToList();
            List<int> featuredArticleIds = new List<int>();

            foreach (FeaturedArticle featured in featuredArticlesList)
            {
                featuredArticleIds.Add(featured.id);
            }

            List<Article> articlesList = db.Articles.Where(a => featuredArticleIds.Any(i => i == a.id)).ToList();
            viewArticles.ArticlesList = articlesList;
            return View(model: viewArticles);
        }

        // GET: Admin/Articles/Deleted
        public ActionResult Deleted()
        {
            List<Article> articlesList = db.Articles.Where(a => a.status == 2).ToList();
            viewArticles.ArticlesList = articlesList;
            return View(model: viewArticles);
        }

        // GET: Admin/Articles/Add
        public ActionResult Add()
        {
            List<Category> categories = db.Categories.Where(c => c.status == 1).ToList();
            viewArticles.CategoriesList = categories;

            List<Tag> tags = db.Tags.ToList();
            viewArticles.TagsList = tags;

            return View(model: viewArticles);
        }
    }
}