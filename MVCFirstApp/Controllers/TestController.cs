using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFirstApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public string PrintMessage()
        {
            return "<h1>Welcome</h1>" +
                    "<p>This is the first page in your MVC app</p>";
        }

        public string Play()
        {
            return "<h1>Welcome</h1>" +
                    "<p>This is the play page in your MVC app</p>";
        }

        public ActionResult TestView()
        {

            return View();
        }

        public string Welcome(string name, int numTimes = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + ", NumTimes is: " + numTimes);
        } 

        public string Welcome2(string name, int ID = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + ", ID is: " + ID);
        }
    }
}