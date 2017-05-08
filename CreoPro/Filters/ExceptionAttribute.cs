using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace CreoPro.Filters
{
    /// <summary>
    /// 错误页面过滤器
    /// </summary>
    public class ExceptionAttribute : HandleErrorAttribute
    {
        private ILog log = LogManager.GetLogger(typeof(ExceptionAttribute));

        public override void OnException(ExceptionContext filterContext)
        {
            //获取抛出异常的对象  
            Exception ex = filterContext.Exception;
            //写日志
            log.Info("系统错误：" + ex.ToString() + "\r\n*******************************");
            //错误页面跳转
            filterContext.HttpContext.Response.Redirect("/mainForm/error", true);
        }

    }
}
