using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    [Serializable]
    public class MachineDetail
    {
        private int _madeid;
        private string _machname;
        private string _machpara;
        private string _machparavalue;

        /// <summary>
        /// 机床详细表ID
        /// </summary>
        public int madeId
        {
            set { _madeid = value; }
            get { return _madeid; }
        }
        /// <summary>
        /// 机床名称
        /// </summary>
        public string machName
        {
            set { _machname = value; }
            get { return _machname; }
        }
        /// <summary>
        /// 机床参数
        /// </summary>
        public string machPara
        {
            set { _machpara = value; }
            get { return _machpara; }
        }
        /// <summary>
        /// 机床参数值
        /// </summary>
        public string machParaValue
        {
            set { _machparavalue = value; }
            get { return _machparavalue; }
        }

    }
}
