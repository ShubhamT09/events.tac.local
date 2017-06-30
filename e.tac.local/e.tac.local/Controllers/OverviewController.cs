using e.tac.local.Models;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e.tac.local.Controllers
{
    public class OverviewController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            var model = new OverviewList()
            {
                ReadMore = Sitecore.Globalization.Translate.Text("Read More")
            };
            Item currentItem = RenderingContext.Current.ContextItem;
            model.AddRange(currentItem.GetChildren().OrderBy(i => i.Created)
                .Select(i => new OverviewItem()
            //model.AddRange(RenderingContext.Current.ContextItem.GetChildren(Sitecore.Collections.ChildListOptions.SkipSorting)
            //    .Select(i => new OverviewItem()
                {
                    Url = LinkManager.GetItemUrl(i),
                    Title = new HtmlString(FieldRenderer.Render(i, "ContentHeading")),
                    Image = new HtmlString(FieldRenderer.Render(i, "decorationBanner", "mw=500&mh=333")),
                }
                ));
            return View(model);
        }
    }
}