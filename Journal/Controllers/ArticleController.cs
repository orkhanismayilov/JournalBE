using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Journal.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Article(int id)
        {
            return View();
        }
    }
}