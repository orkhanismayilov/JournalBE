﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JournalProject.Models;

namespace JournalProject.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Category(int id)
        {
            return View();
        }
    }
}