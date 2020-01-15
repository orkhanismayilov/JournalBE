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
    public class CategoriesController : Controller
    {
        JournalEntities db = new JournalEntities();
        ViewCategories viewCategories = new ViewCategories();

        // GET: Admin/Categories
        public ActionResult Index()
        {
            List<Category> categoriesList = db.Categories.OrderByDescending(c => c.id).Take(10).ToList();
            viewCategories.CategoriesList = categoriesList;
            return View(model: viewCategories);
        }

        // GET: Admin/Categories/Add
        public ActionResult Add()
        {
            viewCategories.Breadcrumbs.Add(new Breadcrumb
            {
                title = "Add",
                state = "active",
                isLeaf = true
            });

            List<Image> lastImages = db.Images.Take(18).ToList();
            viewCategories.Images = lastImages;

            return View(model: viewCategories);
        }

        // POST: Admin/Categories/Add
        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            string alias = collection["alias"];

            if (!CheckAlias(alias))
            {
                return View(model: viewCategories);
            }

            if (CategoryExists(alias))
            {
                return View(model: viewCategories);
            }

            if (CollectionIsEmpty(collection))
            {
                return View(model: viewCategories);
            }

            Category category = new Category
            {
                title_az = collection["title_az"].ToString(),
                title_en = collection["title_en"].ToString(),
                alias = collection["alias"].ToString(),
                isActive = Convert.ToByte(collection["isActive"].ToString())
            };

            category.link_short = "/categories/" + category.alias + "/";
            category.link = Globals.ProjectURL + category.link_short;

            if (!string.IsNullOrWhiteSpace(collection["title_img_id"]) && Convert.ToInt32(collection["title_img_id"]) > 0)
            {
                category.title_img_id = Convert.ToInt32(collection["title_img_id"]);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/Categories/Edit/{id}
        public ActionResult Edit(int id)
        {
            viewCategories.Breadcrumbs.Add(new Breadcrumb
            {
                title = "Edit",
                state = "active",
                isLeaf = true
            });

            if (id == 0)
            {
                return View("Error404", model: viewCategories);
            }

            List<Image> lastImages = db.Images.Take(18).ToList();
            viewCategories.Images = lastImages;

            Category category = db.Categories.Find(id);
            viewCategories.Category = category;
            return View(model: viewCategories);
        }

        // POST: Admin/Categories/Edit/{id}
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (id == 0)
            {
                return View("Error404", model: viewCategories);
            }

            Category category = db.Categories.Find(id);
            viewCategories.Category = category;

            string alias = collection["alias"];

            if (!CheckAlias(alias))
            {
                return View(model: viewCategories);
            }

            if (CategoryExistsById(alias, id))
            {
                return View(model: viewCategories);
            }

            if (CollectionIsEmpty(collection))
            {
                return View(model: viewCategories);
            }

            category.title_az = collection["title_az"].ToString();
            category.title_en = collection["title_en"].ToString();
            category.alias = collection["alias"].ToString();
            category.isActive = Convert.ToByte(collection["isActive"].ToString());

            category.link_short = "/categories/" + category.alias + "/";
            category.link = Globals.ProjectURL + category.link_short;

            if (string.IsNullOrWhiteSpace(collection["title_img_id"]))
            {
                category.title_img_id = null;
            }
            else if (Convert.ToInt32(collection["title_img_id"]) > 0 && Convert.ToInt32(collection["title_img_id"]) != category.title_img_id)
            {
                category.title_img_id = Convert.ToInt32(collection["title_img_id"]);
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/Categories/Delete/{id}
        public ActionResult Delete(int id)
        {
            viewCategories.Breadcrumbs.Add(new Breadcrumb
            {
                title = "Delete",
                state = "active",
                isLeaf = true
            });

            if (id == 0)
            {
                return View("Error404", model: viewCategories);
            }

            Category category = db.Categories.Find(id);
            viewCategories.Category = category;
            return View(model: viewCategories);
        }

        // POST: Admin/Categories/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (id == 0)
            {
                return View("Error404", model: viewCategories);
            }

            Category category = db.Categories.Find(id);

            db.Categories.Remove(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        private bool CheckAlias(string alias)
        {
            Regex aliasRegex = new Regex("^[a-zA-Z0-9]+$", RegexOptions.Multiline);
            if (!aliasRegex.IsMatch(alias))
            {
                viewCategories.ErrorMsg = "Alias format is wrong! Whitespace and special chars is not allowed.";
                return false;
            };

            return true;
        }

        private bool CategoryExists(string alias)
        {
            if (db.Categories.Where(c => c.alias == alias).FirstOrDefault() != null)
            {
                viewCategories.ErrorMsg = "Category with alias \"" + alias + "\" already exists";
                return true;
            }

            return false;
        }

        private bool CategoryExistsById(string alias, int id)
        {
            if (db.Categories.Where(c => c.alias == alias && c.id != id).FirstOrDefault() != null)
            {
                viewCategories.ErrorMsg = "Category with alias \"" + alias + "\" already exists";
                return true;
            }

            return false;
        }

        private bool CollectionIsEmpty(FormCollection collection)
        {
            if (string.IsNullOrWhiteSpace(collection["title_az"]) || string.IsNullOrWhiteSpace(collection["title_en"]) || string.IsNullOrWhiteSpace(collection["alias"]))
            {
                viewCategories.ErrorMsg = "All input fields are required";
                return true;
            }

            return false;
        }
    }
}