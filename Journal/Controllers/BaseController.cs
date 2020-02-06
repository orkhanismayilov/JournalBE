using System;
using System.Collections.Generic;
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

            new Languages().SetLanguage(lang);
            return base.BeginExecuteCore(callback, state);
        }
    }
}