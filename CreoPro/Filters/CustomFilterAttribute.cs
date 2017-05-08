using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CreoPro.Filters
{
    /// <summary>
    /// Session过期判断过滤器
    /// </summary>
    public class CustomFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["userEntity"] == null)
            {
                FormsAuthentication.SignOut();
                filterContext.HttpContext.Response.Redirect("/Home/loginout", true);
            }
        }
    }

}
