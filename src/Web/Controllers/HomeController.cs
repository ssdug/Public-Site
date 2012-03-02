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
                                           Presenter = new PresenterReference { Id = presenter.Email, Name = presenter.Name },
                                           Booked = true,
                                           PresentationDate = new DateTime(2012, 3, 8)
                                       };

                Session.Store(presentation);

                Session.Store(presenter, presenter.Email);
            }
            else
            {
                var presenter = new Presenter
                {
                    Email = "zaph@restaurant.galaxy",
                    Name = "Zaphod Beeblebrox",
                    Bio = "check the guide",
                    Site = "http://www.microsoft.com"
                };

                var presentation = new Presentation
                {
                    Title = "Heart of Gold",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur id fermentum erat. Donec ut lorem ante, vestibulum consectetur ante. Suspendisse interdum bibendum nisi consequat interdum. Donec mollis laoreet arcu nec sodales. Aenean eu libero eget ipsum tristique dictum vel venenatis enim. Phasellus nec iaculis quam. Pellentesque ut nisi turpis, sit amet euismod ligula. Nulla facilisi. Etiam scelerisque massa a enim malesuada a aliquam nibh tristique. Praesent scelerisque, mauris in eleifend vulputate, enim odio pulvinar urna, id malesuada leo velit non arcu. Mauris hendrerit, elit sit amet porta mattis, velit tellus feugiat ante, sed facilisis velit lacus a nunc. Mauris consectetur ornare massa.",
                    Presenter = new PresenterReference { Id = presenter.Email, Name = presenter.Name },
                    Booked = true,
                    PresentationDate = new DateTime(2012, 4, 12)
                };

                Session.Store(presentation);

                Session.Store(presenter, presenter.Email);
            }

            return new HttpStatusCodeResult(200);

        }
    }
}
