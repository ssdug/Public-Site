using System.Web.Mvc;
using Raven.Client;

namespace Web.Controllers
{
    public abstract class RavenController : Controller
    {
        public  IDocumentSession DocumentSession { get; set; }

        protected RavenController(IDocumentSession documentSession)
        {
            DocumentSession = documentSession;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            using (DocumentSession)
            {
                if (filterContext.Exception != null)
                    return;

                DocumentSession.SaveChanges();
            }
        }

    }
}