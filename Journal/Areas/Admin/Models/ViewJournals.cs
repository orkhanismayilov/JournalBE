using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Journal.Areas.Admin.Models
{
    public class ViewJournals
    {
        public List<Breadcrumb> Breadcrumbs { get; set; } = new List<Breadcrumb>();

        public ViewJournals()
        {
            Breadcrumbs.Add(new Breadcrumb
            {
                title = "Journals",
                link = "/admin/journals/",
            });
        }
    }
}