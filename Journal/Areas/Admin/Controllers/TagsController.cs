using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using Journal.Models;
using Journal.Areas.Admin.Models;

namespace Journal.Areas.Admin.Controllers
{
    public class TagsController : Controller
    {
        JournalEntities db = new JournalEntities();
        ViewTags viewTags = new ViewTags();

        // GET: Admin/Tags
        public ActionResult Index()
        {
            List<Tag> tagsList = db.Tags.OrderByDescending(t => t.id).Take(10).ToList();
            viewTags.TagsList = tagsList;
            return View(model: viewTags);
        }

        // GET: Admin/Tags/Add
        public ActionResult Add()
        {
            viewTags.Breadcrumbs.Add(new Breadcrumb
            {
                title = "Add",
                state = "active",
                isLeaf = true
            });

            return View(model: viewTags);
        }

        // POST: Admin/Tags/Add
        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            string alias = collection["alias"];

            if (!CheckAlias(alias))
            {
                return View(model: viewTags);
            }

            if (TagExists(alias))
            {
                return View(model: viewTags);
            }

            if (CollectionIsEmpty(collection))
            {
                return View(model: viewTags);
            }

            Tag tag = new Tag
            {
                title_az = collection["title_az"].ToString(),
                title_en = collection["title_en"].ToString(),
                alias = collection["alias"].ToString(),
            };

            tag.link_short = "/tags/" + tag.alias + "/";
            tag.link = Globals.ProjectURL + tag.link_short;

            db.Tags.Add(tag);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/Tags/Edit/{id}
        public ActionResult Edit(int id)
        {
            viewTags.Breadcrumbs.Add(new Breadcrumb
            {
                title = "Edit",
                state = "active",
                isLeaf = true
            });

            if (id == 0)
            {
                return View("Error404", model: viewTags);
            }

            Tag tag = db.Tags.Find(id);
            viewTags.Tag = tag;
            return View(model: viewTags);
        }

        // POST: Admin/Tags/Edit/{id}
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (id == 0)
            {
                return View("Error404", model: viewTags);
            }

            Tag tag = db.Tags.Find(id);
            viewTags.Tag = tag;

            string alias = collection["alias"];

            if (!CheckAlias(alias))
            {
                return View(model: viewTags);
            }

            if (TagExistsById(alias, id))
            {
                return View(model: viewTags);
            }

            if (CollectionIsEmpty(collection))
            {
                return View(model: viewTags);
            }

            tag.title_az = collection["title_az"].ToString();
            tag.title_en = collection["title_en"].ToString();
            tag.alias = collection["alias"].ToString();
            tag.link_short = "/tags/" + tag.alias + "/";
            tag.link = Globals.ProjectURL + tag.link_short;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/Tags/Delete/{id}
        public ActionResult Delete(int id)
        {
            viewTags.Breadcrumbs.Add(new Breadcrumb
            {
                title = "Delete",
                state = "active",
                isLeaf = true
            });

            if (id == 0)
            {
                return View("Error404", model: viewTags);
            }

            Tag tag = db.Tags.Find(id);
            viewTags.Tag = tag;
            return View(model: viewTags);
        }

        // POST: Admin/Tags/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (id == 0)
            {
                return View("Error404", model: viewTags);
            }

            Tag tag = db.Tags.Find(id);
            db.Tags.Remove(tag);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        private bool CheckAlias(string alias)
        {
            Regex aliasRegex = new Regex("^[a-zA-Z0-9]+$", RegexOptions.Multiline);
            if (!aliasRegex.IsMatch(alias))
            {
                viewTags.ErrorMsg = "Alias format is wrong! Whitespace and special chars is not allowed.";
                return false;
            };

            return false;
        }

        private bool TagExists(string alias)
        {
            if (db.Tags.Where(t => t.alias == alias).FirstOrDefault() != null)
            {
                viewTags.ErrorMsg = "Tag with alias \"" + alias + "\" already exists";
                return true;
            }

            return false;
        }

        private bool TagExistsById(string alias, int id)
        {
            if (db.Tags.Where(t => t.alias == alias && t.id != id).FirstOrDefault() != null)
            {
                viewTags.ErrorMsg = "Tag with alias \"" + alias + "\" already exists";
                return true;
            }

            return false;
        }

        private bool CollectionIsEmpty(FormCollection collection)
        {
            if (string.IsNullOrWhiteSpace(collection["title_az"]) || string.IsNullOrWhiteSpace(collection["title_en"]) || string.IsNullOrWhiteSpace(collection["alias"]))
            {
                viewTags.ErrorMsg = "All input fields are required";
                return true;
            }

            return false;
        }
    }
}