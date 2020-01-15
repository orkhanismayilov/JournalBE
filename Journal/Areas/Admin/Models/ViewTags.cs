using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Journal.Models;

namespace Journal.Areas.Admin.Models
{
    public class ViewTags
    {
        public ViewTags() { }

        public Tag Tag { get; set; } = new Tag();
        public List<Breadcrumb> Breadcrumbs { get; set; } = new List<Breadcrumb>()
        {
            new Breadcrumb
            {
                title = "Tags",
                link = "/admin/tags/"
            }
        };
        public List<Tag> TagsList { get; set; } = new List<Tag>();
        public string ErrorMsg { get; set; } = "";
    }
}