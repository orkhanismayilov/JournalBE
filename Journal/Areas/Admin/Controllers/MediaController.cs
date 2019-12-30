using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Journal.Areas.Admin.Models;

namespace Journal.Areas.Admin.Controllers
{
    public class MediaController : Controller
    {
        // POST: Admin/Media/Upload
        public JsonResult Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                Media media = new Media()
                {
                    file = file,
                    savePath = GetMediaPath()
                };

                media.Add(file);

                return Json("OK", JsonRequestBehavior.AllowGet);
            }

            return Json("false", JsonRequestBehavior.AllowGet);
        }

        public string GetMediaPath()
        {
            return Server.MapPath("~/uploads/images/" + DateTime.Today.ToString("yyyy/MM/dd") + "/");
        }
    }
}