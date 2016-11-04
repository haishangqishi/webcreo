using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.IO;

namespace Common
{
    public class JsonUtils
    {

        /// <summary>
        /// 将实体转换成json字符串
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static string entityToJsonStr(UserInfo userInfo)
        {
            //将对象序列化json  
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UserInfo));
            //创建存储区为内存流  
            MemoryStream ms = new MemoryStream();
            //将json字符串写入内存流中  
            serializer.WriteObject(ms, userInfo);
            string strJson = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return strJson;
        }

        /// <summary>
        /// 将json数据反序列化为Dictionary
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static Dictionary<string, object> jsonToDictionary(string jsonStr)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<Dictionary<string, object>>(jsonStr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
