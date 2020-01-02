using System;
using System.Web;
using System.Web.Mvc;
using Journal.Areas.Admin.Models;
using Journal.Models;

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
                    savePath = Server.MapPath(GetMediaPath())
                };

                media.Add();

                return Json("OK", JsonRequestBehavior.AllowGet);
            }

            return Json("false", JsonRequestBehavior.AllowGet);
        }

        public string GetMediaPath()
        {
            return "~" + Globals.MediaUploadsPath + DateTime.Today.ToString("yyyy/MM/dd") + "/";
        }
    }
}