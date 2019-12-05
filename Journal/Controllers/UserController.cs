using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Journal.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult UserID(int id)
        {
            return View("User");
        }
    }
}