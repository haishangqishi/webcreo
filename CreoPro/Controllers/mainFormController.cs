using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using pfcls;

namespace CreoPro.Controllers
{
    public class mainFormController : Controller
    {
        IpfcAsyncConnection asyncConnection = null;
        private BLL.parameters bll_parm = null;
        private Model.parameters model_parm = null;

        #region 页面跳转
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult index()
        {
            return View();
        }
        /// <summary>
        /// 模型显示
        /// </summary>
        /// <returns></returns>
        public ActionResult modelShow()
        {
            return View();
        }
        /// <summary>
        /// 仿真加工
        /// </summary>
        /// <returns></returns>
        public ActionResult simuProc()
        {
            return View();
        }
        /// <summary>
        /// 生成NC文件
        /// </summary>
        /// <returns></returns>
        public ActionResult ncfile()
        {
            return View();
        }
        /// <summary>
        /// 铲磨工艺优化
        /// </summary>
        /// <returns></returns>
        public ActionResult grindProc()
        {
            return View();
        }
        #endregion

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getCurrentUser()
        {
            if (Session["userEntity"] != null)
            {
                UserInfo userInfo = Session["userEntity"] as UserInfo;
                string strJson = JsonUtils.entityToJsonStr(userInfo);
                return Json(strJson);
            }
            return null;
        }

        #region Creo相关
        /// <summary>
        /// 启动Creo
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult startCreo()
        {
            UserInfo userInfo = null;
            if (Session["userEntity"] != null)
            {
                userInfo = Session["userEntity"] as UserInfo;
                string creoSetup = userInfo.CreoSetup;//安装路径
                string creoWorkSpace = userInfo.CreoWorkSpace;//工作目录
                if (creoSetup != "" && creoSetup != "")
                {
                    //runProE("D:\\creo2.0\\Creo 2.0\\Parametric\\bin\\parametric.exe", "D:\\creo2.0Save");
                    runProE(creoSetup, creoWorkSpace);
                    return null;
                }
                else
                {
                    return Json("Creo安装路径或者Creo工作目录为空！");
                }
            }
            return null;
        }

        /// <summary>
        /// 行选项：-i 和 -g 标识使 Pro/ENGINEER 运行在无图形，无交互模式
        /// </summary>
        /// <param name="exePath">安装路径</param>
        /// <param name="workDir">工作目录</param>
        public void runProE(string exePath, string workDir)
        {
            //IpfcAsyncConnection asyncConnection = null;
            CCpfcAsyncConnection cAC = null;
            IpfcBaseSession session;
            try
            {
                cAC = new CCpfcAsyncConnection();
                //asyncConnection = cAC.Start(exePath + " -g:no_graphics -i:rpc_input", ".");
                asyncConnection = cAC.Start(exePath, ".");
                session = asyncConnection.Session as IpfcBaseSession;
                // 设置工作目录
                session.ChangeDirectory(workDir);
                // C#进程调用和其它将进行的其它进程
                IpfcModelDescriptor descModel;
                IpfcModel model;
                // 载入工作目录下的 "chilungundaozx3yz.prt.1" 文件
                descModel = (new CCpfcModelDescriptor()).Create((int)EpfcModelType.EpfcMDL_PART, "chilungundaozx3yz.prt.1", null);
                model = session.RetrieveModel(descModel);
                model.Display();
                //获取模型项母体
                IpfcModelItemOwner owner = (IpfcModelItemOwner)model;
                //获取所有的特征
                CpfcModelItems items = owner.ListItems(EpfcModelItemType.EpfcITEM_FEATURE);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally  // 当完成，结束 Pro/ENGINEER 会话
            {
                //if (asyncConnection != null)
                //{
                //    if (asyncConnection.IsRunning())
                //    {
                //        asyncConnection.End();
                //    }
                //}
            }
        }

        /// <summary>
        /// 测试Creo
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult testCreo()
        {
            CCpfcAsyncConnection cAC = null;
            IpfcBaseSession session;
            try
            {
                cAC = new CCpfcAsyncConnection();
                asyncConnection = cAC.Connect(DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value);
                session = asyncConnection.Session as IpfcBaseSession;

                //获取模型项母体
                IpfcModelItemOwner owner = session.CurrentModel as IpfcModelItemOwner;
                //获取所有的特征
                CpfcModelItems items = owner.ListItems(EpfcModelItemType.EpfcITEM_FEATURE);

                string aa = session.GetCurrentDirectory();
                session.ChangeDirectory("D:\\creo2.0Save");
                aa = session.GetCurrentDirectory();
                //string bb = session.GetCurrentWS();
                IpfcModel ipfcModel = session.GetActiveModel();
                IpfcModel ipfcModel1 = session.CurrentModel;
                
                Istringseq message =new Cstringseq();
                IpfcSession ipfcSession = asyncConnection.Session;
                ipfcSession.UIShowMessageDialog("abcde", null);
                //ipfcSession.UIDisplayFeatureParams(
                //IpfcSelection selection=
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
        #endregion

        #region 参数输入页面
        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <returns></returns>
        public ActionResult paraInput()
        {
            bll_parm = new BLL.parameters();
            List<Model.parameters> list_parm = bll_parm.GetModelList("");
            string strJson = JsonUtils.ObjectToJson(list_parm);
            ViewBag.name = "hello";
            ViewBag.list = list_parm;
            return View();
        }
        #endregion
    }
}
