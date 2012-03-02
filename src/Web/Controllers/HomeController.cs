using System;
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

        public ActionResult Add()
        {
            if (!Session.Query<Presentation>().Any())
            {
                var presenter = new Presenter
                                    {
                                        Email = "glenn.block@mail.com",
                                        Name = "Glenn Block",
                                        Bio = "some stuff",
                                        Site = "http://www.microsoft.com"
                                    };

                var presentation = new Presentation
                                       {
                                           Title = "Node.js & Azure",
                                           Description = "woot",
                                           Presenter = new PresenterReference{ Id = presenter.Email, Name = presenter.Name },
                                           Booked = true,
                                           PresentationDate = new DateTime(2012, 3, 8)
                                       };

                Session.Store(presentation);
                Session.Store(presenter, presenter.Email);
            }

            return new HttpStatusCodeResult(200);

        }
    }
}
