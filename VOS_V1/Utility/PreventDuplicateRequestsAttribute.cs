using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Threading.Tasks;

namespace VOS_V1.Utility
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class PreventDuplicateRequestAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Form.ContainsKey("__RequestVerificationToken"))
            {
                await context.HttpContext.Session.LoadAsync();

                var currentToken = context.HttpContext.Request.Form["__RequestVerificationToken"].ToString();
                var lastToken = context.HttpContext.Session.GetString("LastProcessedToken");

                if (lastToken == currentToken)
                {
                    context.ModelState.AddModelError(string.Empty, "Looks like you accidentally submitted the same form twice.");
                }
                else
                {
                    context.HttpContext.Session.SetString("LastProcessedToken", currentToken);
                    await context.HttpContext.Session.CommitAsync();
                }
            }

            await next();
        }
    }
}
