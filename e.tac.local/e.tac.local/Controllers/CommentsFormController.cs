using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAC.Utils.Mvc;

namespace e.tac.local.Controllers
{
    public class CommentsFormController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        [ValidateFormHandler]
        public ActionResult Index(string comment, string name)
        {
            return View();
        }
    }
}