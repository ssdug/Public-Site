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
            presentations = Builder<Presentation>.CreateListOfSize(5)
                                                .TheFirst(1).With(x => x.PresentationDate = DateTime.Today.AddDays(-1))
                                                .With(x => x.Booked = true)
                                                .TheNext(4).With(x => x.PresentationDate > DateTime.Today)
                                                .With(x => x.Booked = true)
                                                .TheLast(1).With(x => x.Booked = false)
                                                .Build();
            var session = documentStore.OpenSession();
            presentations.Each(session.Store);
            session.SaveChanges();
        }

        [Test]
        public void Index_should_display_three_upcoming_booked_presentations()
        {
            var controller = new HomeController { Session = documentStore.OpenSession() };
            var result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<Presentation>;

            Assert.That(model.Count(), Is.EqualTo(3));
            Assert.That(model.All(x => x.Booked), Is.True);
            Assert.That(model.All(x => x.PresentationDate > DateTime.Today), Is.True);
            Assert.That(model.Select(x => x.PresentationDate),
                Is.EquivalentTo(model.OrderBy(x => x.PresentationDate).Select(x => x.PresentationDate)));
        }
    }
}
