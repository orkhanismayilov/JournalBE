using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JournalProject.Areas.Admin.Models
{
    public class Breadcrumb
    {
        public string title;
        public string link = "";
        public string state = "";
        public bool isLeaf = false;
    }
}