using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;
using Web.Infrastructure.Security;

namespace Web.Areas.Administration.Controllers
{
    [Require]
    public class PresentersController : RavenController
    {
        //
        // GET: /Administration/Presenters/
        
        public ActionResult Index()
        {
            return View();
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            var documentSession = ((RavenController)filterContext.Controller).DocumentSession;
        }

    }
}
