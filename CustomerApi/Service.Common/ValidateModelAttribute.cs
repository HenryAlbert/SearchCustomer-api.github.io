using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Customer.App_Start
{
    /// <summary>
    /// Returns 400 if the ModelState is invalid.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public bool ReturnsBadRequest { get; set; } = false;

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
        
            if (actionContext.ActionArguments.ContainsValue(null))
            {
                actionContext.ModelState.AddModelError("Error", "Null Model Not Allowed");

                if (ReturnsBadRequest)
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse
                        (HttpStatusCode.BadRequest, actionContext.ModelState);
                }
            }

            if (actionContext.ModelState.IsValid)
                return;

            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
        }
    }
}