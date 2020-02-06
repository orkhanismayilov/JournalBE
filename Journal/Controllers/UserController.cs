using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JournalProject.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult UserID(int id)
        {
            return View("User");
        }
    }
}