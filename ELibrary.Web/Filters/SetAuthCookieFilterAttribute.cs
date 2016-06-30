using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ELibrary.Web.Filters
{
    public class SetAuthCookieFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var token = (filterContext.HttpContext.User.Identity as ClaimsIdentity)
                .FindFirst("access_token");

            if (token != null)
            {
                filterContext.HttpContext.Response.SetCookie(new HttpCookie("access_token", token.Value));
            }

            base.OnActionExecuted(filterContext);
        }
    }
}