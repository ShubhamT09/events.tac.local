using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using e.tac.local.Areas.Importer.Models;

using Newtonsoft.Json;
using Sitecore.Data;
using Sitecore.Data.Items;

using Sitecore.SecurityModel;
using Sitecore;

namespace e.tac.local.Areas.Importer.Controllers
{
    public class EventsController : Controller
    {
        // GET: Importer/Events
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string parentPath)
        {

            IEnumerable<Event> events = null;
            using (var reader = new System.IO.StreamReader(file.InputStream))
            {
                var contents = reader.ReadToEnd();
                try
                {
                    events = JsonConvert.DeserializeObject<IEnumerable<Event>>(contents);
                }
                catch (Exception ex)
                {
                    //to be added later
                }
            }
            var database = Sitecore.Configuration.Factory.GetDatabase("master");
            var parentItem = database.GetItem(Request["parentPath"]);
            var templateID = new TemplateID(new ID("{59710269-A3E0-433D-8B7A-78028E1EA9C5}"));
            using (new SecurityDisabler())
            {
                foreach (var ev in events)
                {
                    Item item = parentItem.Add(ev.Name, templateID);
                    item.Editing.BeginEdit();
                    item["ContentHeading"] = ev.ContentHeading;
                    item["ContentIntro"] = ev.ContentIntro;
                    item["Highlights"] = ev.Highlights;
                    item["Start Date"] = Sitecore.DateUtil.ToIsoDate(ev.StartDate);
                    item.Fields["Duration"].Value = ev.Duration.ToString();
                    item.Fields["Difficulty Level"].Value = ev.Difficulty.ToString();
                    item.Fields[FieldIDs.Workflow].Value = "{22FCB63A-D908-4F71-B2F1-480169542174}";
                    item.Fields[FieldIDs.WorkflowState].Value = "{E301D455-E721-455C-8292-3A6B97A2251C}";
                    item.Editing.EndEdit();
                }
            }
            return View();
        }
    }
}