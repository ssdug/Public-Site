using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client;
using Web.Infrastructure;

namespace Web.Controllers
{
    public abstract class RavenController : Controller
    {
        public  IDocumentSession DocumentSession { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DocumentSession = DocumentStoreHolder.DocumentStore.OpenSession();
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