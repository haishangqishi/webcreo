using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreoPro.Controllers
{
    public class MachineController : Controller
    {

        #region 页面跳转
        /// <summary>
        /// 机床类型
        /// </summary>
        /// <returns></returns>
        public ActionResult machineType()
        {
            return View();
        }
        /// <summary>
        /// 机床参数设置
        /// </summary>
        /// <returns></returns>
        public ActionResult machineSet()
        {
            return View();
        }
        #endregion

    }
}
