using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Journal.Areas.Admin.Controllers
{
    public class IssuesController : Controller
    {
        // GET: Admin/Issues
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Issues/Published
        public ActionResult Published()
        {
            return View();
        }

        // GET: Admin/Issues/Non-published
        public ActionResult NonPublished()
        {
            return View();
        }

        // GET: Admin/Issues/Deleted
        public ActionResult Deleted()
        {
            return View();
        }

        // GET: Admin/Issues/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: Admin/Issues/Add
        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            return View();
        }

        // GET: Admin/Issues/Edit/{id}
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Issues/Edit/{id}
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            return View();
        }

        // GET: Admin/Issues/Delete/{id}
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Issues/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            return View();
        }
    }
}