using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    [Serializable]
    public class Process
    {
        private int _procid;
        private int? _machid;
        private int? _toolid;
        private string _procname;
        private string _machname;
        private string _toolname;

        /// <summary>
        /// 工艺表ID
        /// </summary>
        public int procId
        {
            set { _procid = value; }
            get { return _procid; }
        }
        /// <summary>
        /// 机床ID
        /// </summary>
        public int? machId
        {
            set { _machid = value; }
            get { return _machid; }
        }
        /// <summary>
        /// 刀具ID
        /// </summary>
        public int? toolId
        {
            set { _toolid = value; }
            get { return _toolid; }
        }
        /// <summary>
        /// 工艺名称
        /// </summary>
        public string procName
        {
            set { _procname = value; }
            get { return _procname; }
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
        /// 刀具名称
        /// </summary>
        public string toolName
        {
            set { _toolname = value; }
            get { return _toolname; }
        }

    }
}
