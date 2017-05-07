using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public class StrUtils
    {
        /// <summary>
        /// 字符串非空判断
        /// </summary>
        /// <param name="str"></param>
        /// <returns>空：false，非空：true</returns>
        public static bool strNotNUll(string str)
        {
            bool flag = true;
            if (str == null || str.Length == 0)
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 判断字符串是否为数字或小数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool strIsNumber(string str)
        {
            bool flag = false;
            if (strNotNUll(str))
            {
                Regex rex = new Regex(@"^(-|\+)?\d+(\.\d+)?$");//数字或小数
                if (rex.IsMatch(str))
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// map转换成String
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        public static string mapToStr<T>(Dictionary<string, T> map)
        {
            StringBuilder strb = new StringBuilder();
            string key;
            string value;
            foreach (KeyValuePair<string, T> kvp in map)
            {
                key = kvp.Key.ToString();
                value = kvp.Value.ToString();
                strb.Append(key + ":" + value + ",");
            }
            return strb.ToString().Substring(0, strb.Length - 1);
        }

    }
}
