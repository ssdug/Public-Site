using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Facebook;
using Web.Models;

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

        public JsonResult Create(string facebookToken)
        {
            var client = new FacebookClient(facebookToken);
            dynamic user = client.Get("me");
            FormsAuthentication.SetAuthCookie(user.Username, false);
            string userId = user.id;
            var siteUser = DocumentSession.Query<User>()
                                          .SingleOrDefault(x => x.Id == userId);

            if(siteUser == null)
            {
                var newUser = new User
                                  {
                                      Name = user.name,
                                      Roles = { Role.User }
                                  };

                DocumentSession.Store(newUser, user.id);
            }

          return Json(new { user.id, user.name });
        }

    }
}
