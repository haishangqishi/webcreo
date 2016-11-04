using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
