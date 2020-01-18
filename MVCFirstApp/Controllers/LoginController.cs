using MVCFirstApp.Models;
using MVCFirstApp.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFirstApp.Controllers
{
    public class LoginController : Controller
    {
        SecurityService securityService = new SecurityService();

        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }


        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            Boolean success = securityService.Authenticate(user);

            if (success)
            {
                return View("LoginSuccess", user);
            }
            else
            {
                return View("LoginFailed");
            }

        }
    }
}