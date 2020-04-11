using MVCFirstApp.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFirstApp.Controllers
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + ":" + filterContext.ActionDescriptor.ActionName;
            MyLogger1.GetInstance().Info("Exiting controller: " + name);
        }
        
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + ":" + filterContext.ActionDescriptor.ActionName;
            MyLogger1.GetInstance().Info("Exiting controller: " + name);
        }
    }
}