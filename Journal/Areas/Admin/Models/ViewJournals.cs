using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Journal.Models;

namespace Journal.Areas.Admin.Models
{
    public class ViewJournals
    {
        public ViewJournals() { }

        public List<Breadcrumb> Breadcrumbs { get; set; } = new List<Breadcrumb>()
        {
            new Breadcrumb
            {
                title = "Journals",
                link = "/admin/journals/",
            }
        };
        public List<Image> Images { get; set; } = new List<Image>();
    }
}