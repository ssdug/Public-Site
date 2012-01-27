using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the South Sound .NET Users Group!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
