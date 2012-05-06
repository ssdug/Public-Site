using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AuthenticationController : RavenController
    {
        //
        // GET: /Authentication/

        public ActionResult Index()
        {
            return View();
        }

    }
}
