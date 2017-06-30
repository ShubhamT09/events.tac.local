using Sitecore.Analytics;
using Sitecore.Analytics.Model.Entities;
using Sitecore.Analytics.Outcome.Extensions;
using Sitecore.Analytics.Outcome.Model;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAC.Utils.Mvc;

namespace e.tac.local.Controllers
{
    public class SubscribeFormController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        [ValidateFormHandler]
        public ActionResult Index(string email)
        {
            Sitecore.Analytics.Tracker.Current.Session.Identify(email);
            var contact = Sitecore.Analytics.Tracker.Current.Contact;
            var emails = contact.GetFacet<IContactEmailAddresses>("Emails");
            if(!emails.Entries.Contains("personal"))
            {
                emails.Preferred = "personal";
                var personalEmail = emails.Entries.Create("personal");
                personalEmail.SmtpAddress = email;
            }
            var outcome = new ContactOutcome(ID.NewID, new ID("{F1A68003-6CD0-44C7-B7FD-556041A68090}"), new ID(contact.ContactId));
            Tracker.Current.RegisterContactOutcome(outcome);

            return View("Confirmation");
        }
    }
}