using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using CreoPro.Filters;

namespace CreoPro.Controllers
{
    [CustomFilter]
    public class ToolController : Controller
    {
        private BLL.process bll_proc = null;
        private Model.process model_proc = null;

        #region 页面跳转
        /// <summary>
        /// 刀具参数设置
        /// </summary>
        /// <returns></returns>
        public ActionResult toolSet()
        {
            return View();
        }
        #endregion

        /// <summary>
        /// 刀具类型
        /// </summary>
        /// <returns></returns>
        public ActionResult toolType()
        {
            bll_proc = new BLL.process();
            List<Common.Process> list = bll_proc.GetProcToolList("p.toolId is not null");
            ViewBag.list = list;
            return View();
        }

        /// <summary>
        /// 刀具参数设置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult getToolSet()
        {
            int toolId = Convert.ToInt32(Request["txtToolId"]);
            string toolName = Request["txtToolName"];
            ViewBag.toolName = toolName;

            BLL.tools bll_tool = new BLL.tools();
            List<Common.ToolDetail> list = bll_tool.GetToolDetaList("t.toolId=" + toolId);
            int count = list.Count;
            List<Common.ToolDetail> sublist1 = new List<Common.ToolDetail>();
            List<Common.ToolDetail> sublist2 = new List<Common.ToolDetail>();
            string picName = "";
            int colNum = 10;//自定义列数
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
            return View("toolSet");
        }

    }

}
