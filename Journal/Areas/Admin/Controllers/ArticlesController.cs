using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JournalProject.Models;
using JournalProject.Areas.Admin.Models;
using JournalProject.Filters;

namespace JournalProject.Areas.Admin.Controllers
{
    [AdminAuth]
    public class ArticlesController : Controller
    {
        JournalEntities db = new JournalEntities();
        ViewArticles viewArticles = new ViewArticles();

        // GET: Admin/Article
        public ActionResult Index()
        {
            List<Article> articlesList = db.Articles.OrderByDescending(a => a.date).Take(20).ToList();
            viewArticles.ArticlesList = articlesList;
            return View(model: viewArticles);
        }

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
            return View(model: viewArticles);
        }

        // POST: Admin/Articles/Add
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(FormCollection collection)
        {
            string title_az = Request.Form["title_az"];
            string title_en = Request.Form["title_en"];

            string excerpt_az = Request.Form["excerpt_az"];
            string excerpt_en = Request.Form["excerpt_en"];

            string content_az = Request.Form["content_az"];
            string content_en = Request.Form["content_en"];

            string category_id = Request.Form["category_id"];
            string tags = Request.Form["tags[]"];

            string status = Request.Form["status"];

            string title_img_id = Request.Form["title_img_id"];

            if (string.IsNullOrWhiteSpace(title_az) || string.IsNullOrWhiteSpace(title_en))
            {
                viewArticles.ErrorMsg = "Title is required field! ";
                return View(model: viewArticles);
            }

            if (string.IsNullOrWhiteSpace(category_id))
            {
                viewArticles.ErrorMsg = "Category is required field!";
                return View(model: viewArticles);
            }


            Article article = new Article
            {
                title_az = title_az,
                title_en = title_en,
                excerpt_az = excerpt_az,
                excerpt_en = excerpt_en,
                content_az = content_az,
                content_en = content_en,
                status = Convert.ToByte(status)
            };

            if (!string.IsNullOrWhiteSpace(title_img_id))
            {
                article.title_img_id = Convert.ToInt32(title_img_id);
            }

            if(article.status == 1)
            {
                article.date = DateTime.Now;
            }

            db.Articles.Add(article);
            db.SaveChanges();

            ArticlesCategory articlesCategory = new ArticlesCategory
            {
                article_id = article.id,
                category_id = Convert.ToInt32(category_id)
            };

            db.ArticlesCategories.Add(articlesCategory);

            if (string.IsNullOrWhiteSpace(tags))
            {
                List<string> tagsList = tags.Split(',').ToList();

                foreach (string tag in tagsList)
                {
                    ArticlesTag articlesTag = new ArticlesTag
                    {
                        article_id = article.id,
                        tag_id = Convert.ToInt32(tag)
                    };

                    db.ArticlesTags.Add(articlesTag);
                }
            }

            db.SaveChanges();

            if (article.status == 0)
            {
                return RedirectToAction("NonPublished");
            }
            else
            {
                return RedirectToAction("Published");
            }
        }
    }
}