using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Journal.Controllers
{
    public class IssuesController : Controller
    {
        // GET: Issue
        public ActionResult Issue(int id)
        {
            return View();
        }

        // GET: AllIssues
        public ActionResult AllIssues()
        {
            return View();
        }
    }
}