using MVCFirstApp.Models;
using MVCFirstApp.Services.Business;
using MVCFirstApp.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVCFirstApp.Controllers
{
    public class LoginController : Controller
    {
        SecurityService securityService = new SecurityService();
        private static MyLogger1 logger = MyLogger1.GetInstance();

        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }


        [HttpPost]
        [CustomActionAttribute]
        public ActionResult Login(UserModel user)
        {
            MyLogger1.GetInstance().Info("Entering LoginController.Login()");
            MyLogger1.GetInstance().Info("Paramerters are " + new JavaScriptSerializer().Serialize(user));

            try
            {
                bool success = securityService.Authenticate(user);

                if (success)
                {
                    MyLogger1.GetInstance().Info("Exiting LoginController.Login() with login passed");
                    return View("LoginSuccess", user);
                }
                else
                {
                    MyLogger1.GetInstance().Info("Exiting LoginController.Login() with login failed");
                    return View("LoginFailed");
                }
            }
            catch(Exception e)
            {
                MyLogger1.GetInstance().Error("Exception LoginController: " + e.Message);
                return View("LoginFailed");
            }
            

        }

        [HttpGet]
        [CustomAutherization]
        public ActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("I am a protected method if the proper attribute is applied to me");
        }

        [HttpGet]
        public string GetUsers()
        {
            var cache = MemoryCache.Default;

            List<UserModel> users = cache.Get("Users") as List<UserModel>;

            if(users == null)
            {
                MyLogger1.GetInstance().Info("Noah's app: Creating users and putting them into a cache");

                users = new List<UserModel>();
                users.Add(new UserModel("Noah", "1234"));
                users.Add(new UserModel("Shad", "1234"));
                users.Add(new UserModel("Mark", "1234"));

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60.0);
                cache.Set("Users", users, policy);
            }
            else
            {
                MyLogger1.GetInstance().Info("Noah's app: Got users from the cache");
            }

            return new JavaScriptSerializer().Serialize(users);
        }
    }
}