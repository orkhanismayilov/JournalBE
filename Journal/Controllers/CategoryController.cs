﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Journal.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Category(int id)
        {
            return View();
        }
    }
}