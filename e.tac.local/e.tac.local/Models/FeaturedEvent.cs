using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e.tac.local.Models
{
    public class FeaturedEvent
    {
        public FeaturedEvent() { }
        public HtmlString Heading { get; set; }
        public HtmlString Intro { get; set; }
        public HtmlString EventImage { get; set; }

        public String CssClass { get; set; }
        public string URL { get; set; }

    }
}