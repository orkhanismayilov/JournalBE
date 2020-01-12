using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Journal.Models;

namespace Journal.Areas.Admin.Models
{
    public class ViewTags
    {
        public ViewTags()
        {
            Breadcrumbs.Add(new Breadcrumb
            {
                title = "Tags",
                link = "/admin/tags/",
            });
        }

        public Tag Tag { get; set; }
        public List<Breadcrumb> Breadcrumbs { get; set; } = new List<Breadcrumb>();
        public List<Tag> TagsList { get; set; }
        public string ErrorMsg { get; set; }
    }
}