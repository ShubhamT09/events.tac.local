using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e.tac.local.Models
{
    public class OverviewItem
    {
        public OverviewItem() { }

        public HtmlString Title { get; set; }

        public HtmlString Image { get; set; }

        public String Url { get; set; }
    }
}