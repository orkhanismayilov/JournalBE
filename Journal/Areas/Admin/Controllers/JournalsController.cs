using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Journal.Areas.Admin.Models;
using Journal.Models;

namespace Journal.Areas.Admin.Controllers
{
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
            foreach (Image image in lastImages)
            {
                image.thumbnail = image.file_dir + "thumbnails/" + image.filename;
                image.image_large = image.file_dir + "1920x1080" + image.filename;
                image.image_medium_vertical = image.file_dir + "500x720" + image.filename;
                image.image_medium_horizontal = image.file_dir + "600x320" + image.filename;
                image.image_square = image.file_dir + "300x300" + image.filename;
            }
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