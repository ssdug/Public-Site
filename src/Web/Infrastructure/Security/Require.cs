using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Controllers;
using Web.Models;

namespace Web.Infrastructure.Security
{
    public class RequireAttribute : ActionFilterAttribute, IAuthorizationFilter
    {

        public RequireAttribute(params Role[] roles)
        {
            Roles = roles;
        }
        public IEnumerable<Role> Roles { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var documentSession = ((RavenController) filterContext.Controller).DocumentSession;
                var user = documentSession.Load<User>(filterContext.HttpContext.User.Identity.Name);

                if (!Roles.All(x => user.Roles.Contains(x)))
                    filterContext.Result = new HttpUnauthorizedResult();
            }

            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}