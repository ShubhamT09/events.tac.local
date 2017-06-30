using e.tac.local.Models;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Web.UI.XslControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e.tac.local.Controllers
{
    public class BreadcrumbController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        public IEnumerable<NavigationItem> CreateModel()
        {
            var currentItem = RenderingContext.Current.ContextItem;
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            var breadcrumb = RenderingContext.Current.ContextItem.Axes.GetAncestors()
                .Where(i => i.Axes.IsDecendantOf(homeItem))
                .Concat(new Item[] { currentItem })
                .ToList();

            IEnumerable<NavigationItem> NavigationList = breadcrumb.Select(s => new NavigationItem
            {
                Title = s.DisplayName,
                //Title = new HtmlString(FieldRenderer.Render(s, "ContentHeading", "DisableWebEditing=true")),
                Url = LinkManager.GetItemUrl(s),
                Active = (s.ID == currentItem.ID)
            });
            return NavigationList;

        }
    }
}