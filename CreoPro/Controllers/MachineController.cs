using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreoPro.Controllers
{
    public class MachineController : Controller
    {
        private BLL.process bll_proc = null;
        private Model.process model_proc = null;

        #region 页面跳转
        /// <summary>
        /// 机床参数设置
        /// </summary>
        /// <returns></returns>
        public ActionResult machineSet()
        {
            return View();
        }
        #endregion

        /// <summary>
        /// 机床类型
        /// </summary>
        /// <returns></returns>
        public ActionResult machineType()
        {
            bll_proc = new BLL.process();
            List<Common.Process> list = bll_proc.GetProcMachList("p.machId is not null");
            ViewBag.list = list;
            return View();
        }

        /// <summary>
        /// 机床参数设置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult getMachineSet()
        {
            int machId = Convert.ToInt32(Request["machId"]);
            BLL.machines bll_mach = new BLL.machines();
            List<Common.MachineDetail> list = bll_mach.GetMachDetaList("m.machId=" + machId);
            int count = list.Count;
            List<Common.MachineDetail> sublist = new List<Common.MachineDetail>();
            if (count <= 9)
            {
                ViewBag.list1 = list;
                ViewBag.num = 1;
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    sublist.Add(list[i]);
                    list.RemoveAt(i);
                }
                ViewBag.list1 = sublist;
                ViewBag.list2 = list;
                ViewBag.num = 2;
            }
            return View("machineSet");
        }

    }
}
