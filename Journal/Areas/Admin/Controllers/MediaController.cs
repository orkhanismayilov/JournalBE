using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Journal.Areas.Admin.Controllers
{
    public class MediaController : Controller
    {
        // POST: Admin/Media/Upload
        public JsonResult Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string path = getMediaPath();
                Directory.CreateDirectory(path);

                file.SaveAs(Path.Combine(path, fileName));

                return Json("OK", JsonRequestBehavior.AllowGet);
            }

            return Json("false", JsonRequestBehavior.AllowGet);
        }

        public string getMediaPath()
        {
            return Server.MapPath("~/uploads/images/" + DateTime.Today.ToString("yyyy/MM/dd") + "/");
        }
    }
}