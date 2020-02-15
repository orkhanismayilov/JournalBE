using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JournalProject.Models;

namespace JournalProject.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string lang = Languages.GetDefaultLang();

            if (!string.IsNullOrWhiteSpace(HttpContext.Request.RequestContext.RouteData.Values["lang"]?.ToString()))
            {
                lang = HttpContext.Request.RequestContext.RouteData.Values["lang"].ToString();
            }

            if (!new Languages().SetLanguage(lang)) {
                Response.Redirect("/");
            };
            return base.BeginExecuteCore(callback, state);
        }

        public string RazorToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}