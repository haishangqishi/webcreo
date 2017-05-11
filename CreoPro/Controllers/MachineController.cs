using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using CreoPro.Filters;
using Model;

namespace CreoPro.Controllers
{
    [CustomFilter]
    public class MachineController : Controller
    {
        private BLL.process bll_proc = null;
        private process model_proc = null;

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
            int machId = Convert.ToInt32(Request["txtMachId"]);
            string machName = Request["txtMachName"];
            ViewBag.machName = machName;

            BLL.machines bll_mach = new BLL.machines();
            List<Common.MachineDetail> list = bll_mach.GetMachDetaList("m.machId=" + machId);
            int count = list.Count;
            List<Common.MachineDetail> sublist1 = new List<Common.MachineDetail>();
            List<Common.MachineDetail> sublist2 = new List<Common.MachineDetail>();
            string picName = "";
            int colNum = 10;//自定义列数
            if (StrUtils.strNotNUll(machName) && machName == "Z3063x18摇臂钻床")
            {
                colNum = 9;
            }
            if (count > 0)
            {
                picName = list[0].picName;
                if (count <= colNum)
                {
                    sublist1 = list;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (i < colNum)
                        {
                            sublist1.Add(list[i]);
                        }
                        else
                        {
                            sublist2.Add(list[i]);
                        }
                    }
                }
            }
            ViewBag.list1 = sublist1;
            ViewBag.list2 = sublist2;
            ViewBag.picPath = "../../Content/images/" + picName;
            return View("machineSet");
        }

    }
}
