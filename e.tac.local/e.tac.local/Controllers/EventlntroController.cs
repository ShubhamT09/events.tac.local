﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Web.UI.WebControls;
using Sitecore.Mvc.Presentation;
using e.tac.local.Models;


namespace e.tac.local.Controllers
{
    public class EventlntroController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View(CreateModel());
        }
        public static EventIntro CreateModel()
        {
            var item = RenderingContext.Current.ContextItem;
            var eventIntro = new EventIntro()
            {
                Heading = new HtmlString(FieldRenderer.Render(item, "ContentHeading")),
                EventImage = new HtmlString(FieldRenderer.Render(item, "Event Image", "mw=400")),
                Highlights = new HtmlString(FieldRenderer.Render(item, "Highlights")),
                Intro = new HtmlString(FieldRenderer.Render(item, "ContentIntro")),
                StartDate = new HtmlString(FieldRenderer.Render(item, "Start Date")),
                Duration = new HtmlString(FieldRenderer.Render(item, "Duration")),
                Difficulty = new HtmlString(FieldRenderer.Render(item, "Difficulty Level")),
            };
            return eventIntro;

        }
    }
}