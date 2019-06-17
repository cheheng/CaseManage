using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase.WebUI.Controllers.Filter
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var cookie = context.HttpContext.Request.Cookies["user"];
            if (cookie == null)
            {
                var host = context.HttpContext.Request.Host.ToString();
                var url = $"http://{host}";

                //context.HttpContext.Response.Redirect(url);
                context.Result = new RedirectResult(url);
            }
            // context.HttpContext.Response.Redirect(Url.Action("Privacy", "Home"));
            //context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }
    }
}
