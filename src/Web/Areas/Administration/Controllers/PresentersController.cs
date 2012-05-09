using System.Web.Mvc;
using Raven.Client;
using Web.Controllers;
using Web.Infrastructure.Security;
using Web.Models;

namespace Web.Areas.Administration.Controllers
{
    [Require(Role.Administrator)]
    public class PresentersController : RavenController
    {
        public PresentersController(IDocumentSession documentSession) : base(documentSession)
        { }

        public ActionResult Index()
        {
            return View();
        }

    }
}
