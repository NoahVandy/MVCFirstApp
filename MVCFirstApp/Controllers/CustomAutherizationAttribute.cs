using System;
using System.Web.Mvc;

namespace MVCFirstApp.Controllers
{
    internal class CustomAutherizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Login");
        }
    }
}