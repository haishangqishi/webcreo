using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Common;
using System.IO;
using Newtonsoft.Json;

namespace CreoPro.Controllers
{
    public class MemberController : Controller
    {
        private BLL.member bll_mem = null;
        private Model.member model_mem = null;

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
            //获取前台json
            StreamReader reader = new StreamReader(Request.InputStream);
            string jsonStr = reader.ReadToEnd();
            Dictionary<String, Object> map = JsonUtils.jsonToDictionary(jsonStr);

            string username = map["txtusername"].ToString();
            string password = map["txtpwd"].ToString();
            string phone = map["txtphone"].ToString();
            string email = map["txtemail"].ToString();
            string creoSetup = map["txtcreoSetup"].ToString();
            string creoWorkSpace = map["txtcreoWorkSpace"].ToString();

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
            if (StrUtils.strNotNUll(creoWorkSpace))
            {
                model_mem.creoWorkSpace = creoWorkSpace;
                userInfo.CreoWorkSpace = creoWorkSpace;
            }
            bool flag = bll_mem.Update(model_mem);

            //保存后重置session
            Session["userEntity"] = userInfo;
            return Json(flag.ToString());
        }


    }
}
