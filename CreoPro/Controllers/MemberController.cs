using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace CreoPro.Controllers
{
    public class MemberController : Controller
    {
        #region 页面跳转
        /// <summary>
        /// 个人资料
        /// </summary>
        /// <returns></returns>
        public ActionResult memDetial()
        {
            return View();
        }
        #endregion
    }
}
