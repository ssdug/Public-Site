using System;
using System.Linq;
using System.Web.Mvc;
using Raven.Client;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : RavenController
    {
        public HomeController(IDocumentSession documentSession) : base(documentSession)
        { }

        public ActionResult Index()
        {
            var upcomingPresentations = DocumentSession.Query<Presentation>()
                                                .Where(x => x.PresentationDate > DateTime.Today.AddDays(-7))
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

        public ActionResult Privacy()
        {
            return View();
        }
    }
}
