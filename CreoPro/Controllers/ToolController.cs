using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreoPro.Controllers
{
    public class ToolController : Controller
    {

        #region 页面跳转
        /// <summary>
        /// 刀具类型
        /// </summary>
        /// <returns></returns>
        public ActionResult toolType()
        {
            return View();
        }
        /// <summary>
        /// 刀具参数设置
        /// </summary>
        /// <returns></returns>
        public ActionResult toolSet()
        {
            return View();
        }
        #endregion

    }
}
