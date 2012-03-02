﻿using System;
using System.Linq;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : RavenController
    {
        public ActionResult Index()
        {
            var upcomingPresentations = Session.Query<Presentation>()
                                                .Where(x => x.PresentationDate > DateTime.Now)
                                                .Where(x => x.Booked)
                                                .OrderBy(x => x.PresentationDate)
                                                .Take(3)
                                                .AsEnumerable();
                                       
            return View(upcomingPresentations);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
