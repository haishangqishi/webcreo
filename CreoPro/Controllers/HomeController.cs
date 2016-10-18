using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace CreoPro.Controllers
{
    public class HomeController : Controller
    {
        creo_dataEntities db;
        private BLL.member bll_mem = null;
        private Model.member model_mem = null;

        public HomeController()
        {
            db = new creo_dataEntities();
        }

        /// <summary>
        /// 演示后台向界面传值
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult loginValidate()
        {
            string username = Request["username"];
            string password = Request["password"];
            string isRemeber = Request["remember"];

            if (username != null)
            {
                bll_mem = new BLL.member();
                model_mem = new member();
                model_mem = bll_mem.GetMemberByName(username);
                if (password == model_mem.userPwd)
                {
                    if (isRemeber != null)//记住密码
                    {
                        if (isRemeber == "true")
                        {
                            HttpCookie Username = new HttpCookie("username", username);
                            HttpCookie Password = new HttpCookie("password", password);
                            Response.Cookies.Add(Username);
                            Response.Cookies.Add(Password);
                        }
                    }
                    return RedirectToAction("index", "mainForm");
                }
            }
            return null;
        }

        /// <summary>
        /// 演示后台获取界面的值
        /// </summary>
        /// <returns></returns>
        public ActionResult login()
        {
            HttpCookie Username = HttpContext.Request.Cookies["username"];
            HttpCookie Password = HttpContext.Request.Cookies["password"];
            if (Username != null && Password != null)//判断是否处于登录状态
            {
                bll_mem = new BLL.member();
                model_mem = new member();
                model_mem = bll_mem.GetMemberByName(Username.Value);
                if (Password.Value == model_mem.userPwd)
                {
                    return RedirectToAction("index", "mainForm");
                }
            }
            return View();
        }

    }
}
