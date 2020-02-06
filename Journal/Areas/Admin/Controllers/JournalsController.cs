using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JournalProject.Areas.Admin.Models;
using JournalProject.Models;
using JournalProject.Filters;

namespace JournalProject.Areas.Admin.Controllers
{
    [AdminAuth]
    public class JournalsController : Controller
    {
        JournalEntities db = new JournalEntities();
        ViewJournals viewJournals = new ViewJournals();

        // GET: Admin/Journals
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Journals/Published
        public ActionResult Published()
        {
            return View();
        }

        // GET: Admin/Journals/Non-published
        public ActionResult NonPublished()
        {
            return View();
        }

        // GET: Admin/Journals/Deleted
        public ActionResult Deleted()
        {
            return View();
        }

        // GET: Admin/Journals/Add
        public ActionResult Add()
        {
            viewJournals.Breadcrumbs.Add(new Breadcrumb
            {
                title = "Add",
                state = "active",
                isLeaf = true
            });

            List<Image> lastImages = db.Images.Take(18).ToList();
            viewJournals.Images = lastImages;

            return View(model: viewJournals);
        }

        // POST: Admin/Journals/Add
        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            return View();
        }

        // GET: Admin/Journals/Edit/{id}
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Journals/Edit/{id}
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            return View();
        }

        // GET: Admin/Journals/Delete/{id}
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Journals/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            return View();
        }
    }
}