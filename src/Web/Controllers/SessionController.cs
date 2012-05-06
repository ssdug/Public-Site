using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;

namespace Web.Controllers
{
    public class SessionController : RavenController
    {
        //
        // GET: /Session/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string facebookToken)
        {
            var client = new FacebookClient(facebookToken);
            dynamic user = client.Get("me");

          return Json(user);
        }

    }
}
