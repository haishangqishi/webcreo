using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    [Serializable]
    public class ToolDetail
    {
        private int _todeid;
        private string _toolname;
        private string _toolpara;
        private string _toolparavalue;
        private string _picname;

        /// <summary>
        /// 刀具详细表ID
        /// </summary>
        public int todeId
        {
            set { _todeid = value; }
            get { return _todeid; }
        }
        /// <summary>
        /// 刀具名称
        /// </summary>
        public string toolName
        {
            get { return _toolname; }
            set { _toolname = value; }
        }
        /// <summary>
        /// 刀具参数
        /// </summary>
        public string toolPara
        {
            set { _toolpara = value; }
            get { return _toolpara; }
        }
        /// <summary>
        /// 刀具参数值
        /// </summary>
        public string toolParaValue
        {
            set { _toolparavalue = value; }
            get { return _toolparavalue; }
        }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string picName
        {
            set { _picname = value; }
            get { return _picname; }
        }
    }
}
