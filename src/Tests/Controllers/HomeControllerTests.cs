using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FizzWare.NBuilder;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Embedded;
using Web.Controllers;
using Web.Infrastructure;
using Web.Models;

namespace SSDNUG.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private IDocumentStore documentStore;
        private IList<Presentation> presentations;

        [SetUp]
        public void SetUp()
        {
            documentStore = new EmbeddableDocumentStore {RunInMemory = true}.Initialize();
        }

        [Test]
        public void Index_should_display_three_upcoming_booked_presentations()
        {
            var presentations = new[]
                                    {
                                        new Presentation { Booked = true, PresentationDate = DateTime.Today.AddMonths(-1)},
                                        new Presentation { Booked = true, PresentationDate = DateTime.Today},
                                        new Presentation { Booked = true, PresentationDate = DateTime.Today.AddMonths(1)},
                                        new Presentation { Booked = true, PresentationDate = DateTime.Today.AddMonths(2)},
                                        new Presentation { Booked = true, PresentationDate = DateTime.Today.AddMonths(3)},
                                    };

            PrepareSession(presentations);

            var controller = new HomeController(documentStore.OpenSession());
            var result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<Presentation>;

            Assert.That(model.Count(), Is.EqualTo(3));
            Assert.That(model.All(x => x.Booked), Is.True);
            Assert.That(model.All(x => x.PresentationDate > DateTime.Today.AddDays(-7)), Is.True);
            Assert.That(model.Select(x => x.PresentationDate),
                Is.EquivalentTo(model.OrderBy(x => x.PresentationDate).Select(x => x.PresentationDate)));
        }

        private void PrepareSession(IEnumerable<Presentation> presentations)
        {
            var session = documentStore.OpenSession();
            presentations.Each(session.Store);
            session.SaveChanges();
        }
    }
}
