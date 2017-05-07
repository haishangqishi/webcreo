using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Common;
using System.IO;

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
        /// 登录验证
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
                if (model_mem != null)
                {
                    if (password == model_mem.userPwd)
                    {
                        if (isRemeber != null)//记住密码
                        {
                            if (isRemeber == "true")
                            {
                                //写入cookie，用于登录判断
                                HttpCookie Username = new HttpCookie("username", username);
                                HttpCookie Password = new HttpCookie("password", password);
                                Username.Expires = System.DateTime.Now.AddMinutes(30);
                                Password.Expires = System.DateTime.Now.AddMinutes(30);
                                Response.Cookies.Add(Username);
                                Response.Cookies.Add(Password);
                            }
                        }
                        //写入Session，用于页面间传值
                        UserInfo userInfo = setUserInfo(model_mem);
                        Session["userEntity"] = userInfo;
                        return View("/Views/mainForm/index.cshtml");//直接返回视图，不在对应文件夹下需要写全路径
                        //return RedirectToAction("../mainForm/index");//跳转到不同Controller下action
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 登录
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
                if (model_mem != null)
                {
                    if (Password.Value == model_mem.userPwd)
                    {
                        //写入Session，用于页面间传值
                        UserInfo userInfo = setUserInfo(model_mem);
                        Session["userEntity"] = userInfo;
                        return View("/Views/mainForm/index.cshtml");
                    }
                }
            }
            return View();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult register()
        {
            return View();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult loginout()
        {
            if (Session["userEntity"] != null)
            {
                Session.Remove("userEntity");//清除Session
                Response.Cookies["username"].Expires = System.DateTime.Now.AddSeconds(-1);//Expires过期时间
                Response.Cookies["password"].Expires = System.DateTime.Now.AddSeconds(-1);
            }
            return View("login");//返回View中对应文件夹下的视图
        }

        /// <summary>
        /// 将Model赋给实体
        /// </summary>
        /// <param name="model_mem"></param>
        /// <returns></returns>
        private UserInfo setUserInfo(Model.member model_mem)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.mem_id = model_mem.mem_id;
            userInfo.UserName = model_mem.userName;
            userInfo.UserPwd = model_mem.userPwd;
            if (model_mem.userRole != null)
            {
                userInfo.UserRole = (int)model_mem.userRole;
            }
            userInfo.Email = model_mem.email;
            userInfo.Phone = model_mem.phone;
            userInfo.CreoSetup = model_mem.creoSetup;
            userInfo.CreoWorkSpace = model_mem.creoWorkSpace;
            userInfo.GundaoSetup = model_mem.gundaoSetup;

            return userInfo;
        }


    }
}
