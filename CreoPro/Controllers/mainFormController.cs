using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.Script.Serialization;

namespace CreoPro.Controllers
{
    public class mainFormController : Controller
    {
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult index()
        {
            return View();
        }

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        public ActionResult getCurrentUser()
        {
            if (Session["userEntity"] != null)
            {
                UserInfo userInfo = Session["userEntity"] as UserInfo;
                //将对象序列化json  
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UserInfo));
                //创建存储区为内存流  
                MemoryStream ms = new MemoryStream();
                //将json字符串写入内存流中  
                serializer.WriteObject(ms, userInfo);
                StreamReader reader = new StreamReader(ms);
                ms.Position = 0;
                string strRes = reader.ReadToEnd();
                reader.Close();
                ms.Close();
                return Json(strRes);
            }
            return null;
        }
    }
}
