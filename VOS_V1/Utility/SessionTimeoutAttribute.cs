using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace VOS_V1.Utility
{
    public class SessionTimeoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session.Get("UserID");
            
            if (user == null)
            {
                filterContext.Result = new RedirectResult("~/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

        //public override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    //filterContext.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
        //    //filterContext.HttpContext.Response.Headers["Expires"] = "-1";
        //    //filterContext.HttpContext.Response.Headers["Pragma"] = "no-cache";
        //    filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    HttpContext.Current.Response.Cache.SetNoServerCaching();
        //    HttpContext.Current.Response.Cache.SetNoStore();
        //    base.OnResultExecuting(filterContext);
        //}
    }
}
