using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.IO;
using Newtonsoft.Json;
using Model;

namespace CreoPro.Controllers
{
    public class MemberController : Controller
    {
        private BLL.member bll_mem = null;
        private member model_mem = null;

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

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult updateUser()
        {
            string jsonStr = Request["formData"];
            Dictionary<String, Object> map = JsonUtils.jsonToDictionary(jsonStr);

            string username = map["txtusername"].ToString();
            string password = map["txtpwd"].ToString();
            string phone = map["txtphone"].ToString();
            string email = map["txtemail"].ToString();
            string cadPath = map["txtcadPath"].ToString();
            string creoSetup = map["txtcreoSetup"].ToString();

            UserInfo userInfo = null;
            if (Session["userEntity"] != null)
            {
                userInfo = Session["userEntity"] as UserInfo;
            }
            bll_mem = new BLL.member();
            model_mem = new member();
            model_mem = bll_mem.GetMemberByName(userInfo.UserName);

            if (StrUtils.strNotNUll(username))
            {
                model_mem.userName = username;
                userInfo.UserName = username;
            }
            if (StrUtils.strNotNUll(password))
            {
                model_mem.userPwd = password;
                userInfo.UserPwd = password;
            }
            if (StrUtils.strNotNUll(phone))
            {
                model_mem.phone = phone;
                userInfo.Phone = phone;
            }
            if (StrUtils.strNotNUll(email))
            {
                model_mem.email = email;
                userInfo.Email = email;
            }
            if (StrUtils.strNotNUll(creoSetup))
            {
                model_mem.creoSetup = creoSetup;
                userInfo.CreoSetup = creoSetup;
            }
            if (StrUtils.strNotNUll(cadPath))
            {
                model_mem.cadPath = cadPath;
                userInfo.CadPath = cadPath;
            }
            bool flag = bll_mem.Update(model_mem);

            //保存后重置session
            Session["userEntity"] = userInfo;
            return Json(flag.ToString());
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult addUser()
        {
            string jsonStr = Request["formData"];
            Dictionary<string, object> map = JsonUtils.jsonToDictionary(jsonStr);

            string username = map["txtusername"].ToString();
            bll_mem = new BLL.member();
            model_mem = new member();
            model_mem = bll_mem.GetMemberByName(username);
            if (model_mem != null)//用户已存在
            {
                return Json("False");
            }

            string password = map["txtpwd"].ToString();
            string phone = map["txtphone"].ToString();
            string email = map["txtemail"].ToString();
            string cadPath = map["txtcadPath"].ToString();
            string creoSetup = map["txtcreoSetup"].ToString();

            model_mem = new member();//重新实例化
            if (StrUtils.strNotNUll(username))
            {
                model_mem.userName = username;
            }
            if (StrUtils.strNotNUll(password))
            {
                model_mem.userPwd = password;
            }
            if (StrUtils.strNotNUll(phone))
            {
                model_mem.phone = phone;
            }
            if (StrUtils.strNotNUll(email))
            {
                model_mem.email = email;
            }
            if (StrUtils.strNotNUll(creoSetup))
            {
                model_mem.creoSetup = creoSetup;
            }
            if (StrUtils.strNotNUll(cadPath))
            {
                model_mem.cadPath = cadPath;
            }
            model_mem.isDelete = 0;
            bll_mem.Add(model_mem);

            return Json("True");
        }

        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult hasUserName()
        {
            string username = Request["username"];

            bll_mem = new BLL.member();
            if (StrUtils.strNotNUll(username))
            {
                model_mem = bll_mem.GetMemberByName(username);
            }
            if (model_mem == null)
            {
                return Json("False");
            }
            else
            {
                return Json("True");
            }
        }

        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult rightPwd()
        {
            string username = Request["username"];
            string password = Request["password"];

            bll_mem = new BLL.member();
            if (StrUtils.strNotNUll(username))
            {
                model_mem = bll_mem.GetMemberByName(username);
            }
            if (model_mem != null)
            {
                if (password == model_mem.userPwd)
                {
                    return Json("True");
                }
            }
            return Json("False");
        }

        /// <summary>
        /// 验证是否填写滚刀系统安装路径（暂不用）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult hasGundaoSetup()
        {
            UserInfo userInfo = null;
            if (Session["userEntity"] != null)
            {
                userInfo = Session["userEntity"] as UserInfo;
            }

            string gundaoSetup = "";
            if (userInfo != null)
            {
                gundaoSetup = userInfo.GundaoSetup;//安装路径
                if (gundaoSetup == "")
                {
                    return Json("滚刀系统安装路径为空！");
                }
            }
            return Json("true");
        }

    }
}
