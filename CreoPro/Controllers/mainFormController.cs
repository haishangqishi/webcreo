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
                //IpfcModelItemOwner owner = (IpfcModelItemOwner)model;
                ////获取所有的特征
                //CpfcModelItems items = owner.ListItems(EpfcModelItemType.EpfcITEM_FEATURE);
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

                ////获取模型项母体
                //IpfcModelItemOwner owner = session.CurrentModel as IpfcModelItemOwner;
                ////获取所有的特征
                //CpfcModelItems items = owner.ListItems(EpfcModelItemType.EpfcITEM_FEATURE);

                session.ChangeDirectory("D:\\creo2.0Save");
                //IpfcModel ipfcModel = session.GetActiveModel();
                //IpfcModel ipfcModel1 = session.CurrentModel;

                IpfcSession ipfcSession = asyncConnection.Session;
                //ipfcSession.UIShowMessageDialog("abcde", null);//显示消息弹框
                //printError(ipfcSession, "locationString", "errorString", 1);
                //writeMsg(session, "locationString", "errorString", 1);
                //ipfcSession.UIReadIntMessage(0, 3);//从消息窗口读数据(获取弹框中操作)

                //ipfcSession.UIDisplayFeatureParams();
                //IpfcSelectionOptions opt = null;

                //retrieveModel(session, (int)EpfcModelType.EpfcMDL_PART, "D:\\creo2.0Save");
                //selectFeatures(session,3);
                //printMassProperties(session);

                selectParas(session);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }

        #region 测试方法
        /// <summary>
        /// 写消息到消息窗口（消息位于左下角）
        /// </summary>
        /// <param name="ipfcSession"></param>
        /// <param name="location"></param>
        /// <param name="err"></param>
        /// <param name="errorCode"></param>
        public void printError(IpfcSession ipfcSession, string location, string err, int errorCode)
        {
            Istringseq message = null;
            try
            {
                message = new Cstringseq();
                message.Set(0, err);
                message.Set(1, errorCode.ToString());
                message.Set(2, location);
                ipfcSession.UIDisplayMessage("D:\\mymessage.txt", "USER Error: %0s of code %1s at %2s", message);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 写消息到内存
        /// </summary>
        /// <param name="session"></param>
        /// <param name="location"></param>
        /// <param name="err"></param>
        /// <param name="errorCode"></param>
        public void writeMsg(IpfcBaseSession session, string location, string err, int errorCode)
        {
            Istringseq message = null;
            try
            {
                message = new Cstringseq();
                message.Set(0, err);
                message.Set(1, errorCode.ToString());
                message.Set(2, location);
                session.GetMessageContents("D:\\mymessage.txt", "USER Error: %0s of code %1s at %2s", message);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 模型恢复
        /// </summary>
        /// <param name="session"></param>
        /// <param name="type"></param>
        /// <param name="stdPath"></param>
        public void retrieveModel(IpfcBaseSession session, int type, string stdPath)
        {
            IpfcModelDescriptor descModel;
            IpfcModel model;
            try
            {
                descModel = (new CCpfcModelDescriptor()).Create(type, "chilungundaozx3yz.prt.1", null);
                model = session.RetrieveModel(descModel);//获取模型，但不显示
                model.Display();
                //session.OpenFile(descModel);//模型显示，类似model.Display();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 选择特征
        /// </summary>
        /// <param name="session"></param>
        /// <param name="max">提醒选择个数</param>
        public void selectFeatures(IpfcBaseSession session, int max)
        {
            CpfcSelections selections;
            IpfcSelectionOptions selectionOptions;
            try
            {
                selectionOptions = (new CCpfcSelectionOptions()).Create("feature");
                selectionOptions.MaxNumSels = max;
                selections = session.Select(selectionOptions, null);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 获取模型参数
        /// </summary>
        /// <param name="session"></param>
        public void selectParas(IpfcBaseSession session)
        {
            try
            {
                //获取模型项母体
                IpfcModelItemOwner owner = session.CurrentModel as IpfcModelItemOwner;
                //获取所有的特征
                CpfcModelItems items = owner.ListItems(EpfcModelItemType.EpfcITEM_FEATURE);

                CpfcModelItems it = owner.ListItems(EpfcArgValueType.EpfcARG_V_DOUBLE);

                IpfcModelItem item;
                int count = items.Count;
                for (int i = 0; i < count; i++)
                {
                    item = (IpfcModelItem)items[i];
                }

                IpfcModelItem item2;
                IpfcBaseParameter paras;
                int count2 = it.Count;
                StringBuilder stb = new StringBuilder();
                for (int i = 0; i < count2; i++)
                {
                    item2 = (IpfcModelItem)items[i];
                    if (item2.GetName() != null)
                    {
                        stb.Append(item2.GetName()+",");
                    }
                }

                //IpfcModel ipfcModel = session.CurrentModel;
                //IpfcBaseParameter paras=
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 获取模型质量属性(有bug)
        /// </summary>
        /// <param name="session"></param>
        public void printMassProperties(IpfcBaseSession session)
        {
            IpfcModel model;
            //IpfcSolid solid;
            //IpfcMassProperty solidProperties;
            CpfcPoint3D gravityCentre = new CpfcPoint3D();
            try
            {
                model = session.CurrentModel;
                //solid = CType(model, IpfcSolid)
                //solidProperties = solid.GetMassProperty(Nothing)
                //gravityCentre = solidProperties.GravityCenter
                int type = model.Type;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        #endregion

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
