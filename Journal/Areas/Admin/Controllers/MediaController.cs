using System;
using System.Web;
using System.Web.Mvc;
using JournalProject.Areas.Admin.Models;
using JournalProject.Models;
using JournalProject.Filters;

namespace JournalProject.Areas.Admin.Controllers
{
    [AdminAuth]
    public class MediaController : Controller
    {
        // POST: Admin/Media/Upload
        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                Media media = new Media()
                {
                    file = file,
                    savePath = Server.MapPath(GetMediaPath())
                };

                Image image = media.Add();

                var jsonImage = new
                {
                    image.id,
                    image.file_dir,
                    image.filename
                };

                return Json(jsonImage);
            }

            return Json("false");
        }

        public string GetMediaPath()
        {
            return "~" + Globals.MediaUploadsPath + DateTime.Today.ToString("yyyy/MM/dd") + "/";
        }
    }
}