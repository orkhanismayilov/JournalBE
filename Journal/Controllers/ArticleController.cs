using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JournalProject.Controllers
{
    public class ArticleController : BaseController
    {
        // GET: Article
        public ActionResult Article(int id)
        {
            return View();
        }
    }
}