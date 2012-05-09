using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Facebook;
using Raven.Client;
using Web.Models;

namespace Web.Controllers
{
    public class SessionController : RavenController
    {
        public SessionController(IDocumentSession documentSession) : base(documentSession)
        { }

        public JsonResult Create(string facebookToken)
        {
            var client = new FacebookClient(facebookToken);
            dynamic user = client.Get("me");
            
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
                siteUser = newUser;
            }

            FormsAuthentication.SetAuthCookie(siteUser.Id, false);

          return Json(new { user.id, user.name });
        }

    }
}
