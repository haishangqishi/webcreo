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
        /// 参数输入
        /// </summary>
        /// <returns></returns>
        public ActionResult paraInput()
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
        /// 获取当前用户（json格式，前台用）
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
        public JsonResult startCreo()
        {
            UserInfo userInfo = getUserInfo();
            if (userInfo != null)
            {
                string creoSetup = userInfo.CreoSetup;//安装路径
                string creoWorkSpace = Server.MapPath("/") + "files";//工作目录
                if (creoSetup != "" && creoSetup != "")
                {
                    //runProE("D:\\creo2.0\\Creo 2.0\\Parametric\\bin\\parametric.exe", "D:\\creo2.0Save");
                    //runProE(creoSetup, creoWorkSpace, null);
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
        private void runProE(string exePath, string workDir, Dictionary<string, object> map)
        {
            CCpfcAsyncConnection cAC = null;
            IpfcBaseSession session;
            IpfcModelDescriptor descModel;
            IpfcModel model;
            IpfcSolid solid;
            IpfcRegenInstructions ins;
            IpfcParameterOwner paOwner;

            try
            {
                setConfig(exePath);//设置配置文件
                cAC = new CCpfcAsyncConnection();
                //asyncConnection = cAC.Start(exePath + " -g:no_graphics -i:rpc_input", ".");
                asyncConnection = cAC.Start(exePath, ".");
                session = asyncConnection.Session as IpfcBaseSession;//获取session(会话)
                session.ChangeDirectory(workDir);// 设置工作目录
                descModel = (new CCpfcModelDescriptor()).Create((int)EpfcModelType.EpfcMDL_PART, "chilungundaozzx_xiu.prt", null);//获取工作目录下的零件模型描述
                model = session.RetrieveModel(descModel);//零件模型
                paOwner = (IpfcParameterOwner)model;
                //map = selectFamTab1();//测试数据

                //模型更新
                Dictionary<string, double> mapGoal = null;
                if (map != null)
                {
                    mapGoal = new Dictionary<string, double>();
                    string value;
                    foreach (KeyValuePair<string, object> kvp in map)
                    {
                        value = kvp.Value.ToString();
                        if (StrUtils.strIsNumber(value))
                        {
                            mapGoal.Add(kvp.Key, Double.Parse(value));
                        }
                    }
                    updateFamTab(paOwner, mapGoal);
                }

                if (model.Type == (int)EpfcModelType.EpfcMDL_PART)
                {
                    solid = (IpfcSolid)model;
                    ins = (new CCpfcRegenInstructions()).Create(true, null, null);
                    ins.UpdateInstances = true;
                    solid.Regenerate(ins);
                }

                model.Display();//模型显示
                addData(mapGoal);//写入数据库
            }
            catch (Exception ex)
            {
                ex.ToString();
                if (asyncConnection != null)
                {
                    if (asyncConnection.IsRunning())
                    {
                        asyncConnection.End();
                    }
                }
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
        /// 生成模型
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult createModel()
        {
            string jsonStr = Request["paras"];
            Dictionary<string, object> map = JsonUtils.jsonToDictionary(jsonStr);

            UserInfo userInfo = getUserInfo();
            if (userInfo != null)
            {
                string creoSetup = userInfo.CreoSetup;//安装路径
                string creoWorkSpace = Server.MapPath("/") + "files";//工作目录
                if (creoSetup != "" && creoSetup != "")
                {
                    runProE(creoSetup, creoWorkSpace, map);
                    return Json("success");
                }
                else
                {
                    return Json("Creo安装路径或者Creo工作目录为空！");
                }
            }
            return null;
        }

        /// <summary>
        /// 获取当前用户（后台用）
        /// </summary>
        /// <returns></returns>
        private UserInfo getUserInfo()
        {
            UserInfo userInfo = null;
            if (Session["userEntity"] != null)
            {
                userInfo = Session["userEntity"] as UserInfo;
            }
            return userInfo;
        }

        /// <summary>
        /// 修改Creo配置文件（设置模型重生为解决方式）
        /// </summary>
        /// <param name="creoSetup"></param>
        private void setConfig(string exePath)
        {
            int index = exePath.IndexOf("Parametric");
            string path = exePath.Substring(0, index) + "Common Files\\M080\\text\\config.pro";

            try
            {
                StreamReader reader = new StreamReader(path, Encoding.Default);
                String text = reader.ReadToEnd();
                if (text.IndexOf("regen_failure_handling") > -1)
                {
                    if (text.IndexOf("regen_failure_handling no_resolve_mode") > -1)
                    {
                        text.Replace("no_resolve_mode", "resolve_mode");
                    }
                }
                else
                {
                    text += " regen_failure_handling resolve_mode";
                }
                reader.Close();
                System.IO.File.WriteAllText(path, text, Encoding.Default);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="map"></param>
        private void addData(Dictionary<string, double> map)
        {
            UserInfo userInfo = getUserInfo();
            int mem_id = 0;
            if (userInfo != null)
            {
                mem_id = userInfo.mem_id;
            }

            bll_parm = new BLL.parameters();
            model_parm = new Model.parameters();
            model_parm.mem_id = mem_id;
            if (map != null)
            {
                string key;
                double value;
                foreach (KeyValuePair<string, double> kvp in map)
                {
                    key = kvp.Key;
                    value = kvp.Value;
                    switch (key)
                    {
                        case "MN":
                            model_parm.moshu = Convert.ToDecimal(value);
                            break;
                        case "ZG":
                            model_parm.rongxieNum = Convert.ToInt32(value);
                            break;
                        case "DEG":
                            model_parm.deg = Convert.ToDecimal(value);
                            break;
                        case "L":
                            model_parm.L = Convert.ToDecimal(value);
                            break;
                        case "DL":
                            model_parm.zhoutaiD = Convert.ToDecimal(value);
                            break;
                        case "D":
                            model_parm.kongjing = Convert.ToDecimal(value);
                            break;
                        case "DLO":
                            model_parm.kongdaoD = Convert.ToDecimal(value);
                            break;
                        case "L1":
                            model_parm.kongdaoL = Convert.ToDecimal(value);
                            break;
                        case "T1":
                            model_parm.jiancaoH = Convert.ToDecimal(value);
                            break;
                        case "A":
                            model_parm.zhoutaiL = Convert.ToDecimal(value);
                            break;
                        case "B":
                            model_parm.jiancaoW = Convert.ToDecimal(value);
                            break;
                        case "C":
                            model_parm.celeng = Convert.ToDecimal(value);
                            break;
                        default:
                            break;
                    }
                }
                bll_parm.Add(model_parm);
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
            IpfcModel model;

            try
            {
                cAC = new CCpfcAsyncConnection();
                asyncConnection = cAC.Connect(DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value);
                session = asyncConnection.Session as IpfcBaseSession;
                session.ChangeDirectory("D:\\creo2.0Save");
                model = session.CurrentModel;

                //ipfcSession.UIShowMessageDialog("abcde", null);//显示消息弹框
                //printError(ipfcSession, "locationString", "errorString", 1);
                //writeMsg(session, "locationString", "errorString", 1);
                //ipfcSession.UIReadIntMessage(0, 3);//从消息窗口读数据(获取弹框中操作)

                //ipfcSession.UIDisplayFeatureParams();
                //IpfcSelectionOptions opt = null;

                //retrieveModel(session, (int)EpfcModelType.EpfcMDL_PART, "D:\\creo2.0Save");
                //selectFeatures(session,3);
                //printMassProperties(session);

                //selectParas(session);
                //Dictionary<string, double> map = selectFamTab(model);
            }
            catch (Exception ex)
            {
                ex.ToString();
                if (asyncConnection != null)
                {
                    if (asyncConnection.IsRunning())
                    {
                        asyncConnection.End();
                    }
                }
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
        private void printError(IpfcSession ipfcSession, string location, string err, int errorCode)
        {
            Istringseq message;
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
        private void writeMsg(IpfcBaseSession session, string location, string err, int errorCode)
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
        private void retrieveModel(IpfcBaseSession session, int type, string stdPath)
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
        private void selectFeatures(IpfcBaseSession session, int max)
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
        /// 获取模型所有参数
        /// </summary>
        /// <param name="session"></param>
        private void selectParas(IpfcBaseSession session)
        {
            try
            {
                IpfcParameterOwner paOwner = session.CurrentModel as IpfcParameterOwner;
                CpfcParameters paras = paOwner.ListParams();
                IpfcParameter para;
                IpfcParamValue paValue;

                StringBuilder stb = new StringBuilder();
                int num = paras.Count;
                for (int i = 0; i < num; i++)
                {
                    para = paras[i];
                    if (para != null)
                    {
                        if (i > 1)
                        {
                            paValue = para.GetScaledValue();
                            stb.Append(paValue.DoubleValue + ",");//参数列表
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 获取模型特征
        /// </summary>
        /// <param name="session"></param>
        private void selectFeature(IpfcBaseSession session)
        {
            try
            {
                //获取模型项母体
                IpfcModelItemOwner owner = session.CurrentModel as IpfcModelItemOwner;
                //获取所有的特征
                CpfcModelItems items = owner.ListItems(EpfcModelItemType.EpfcITEM_FEATURE);

                IpfcModelItem item;
                int count = items.Count;
                StringBuilder stb = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    item = (IpfcModelItem)items[i];
                    if (item != null)
                    {
                        if (item.GetName() != null)
                        {
                            stb.Append(item.GetName() + ",");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 获取模型质量属性
        /// </summary>
        /// <param name="session"></param>
        private void printMassProperties(IpfcBaseSession session)
        {
            IpfcModel model;
            IpfcSolid solid;
            IpfcMassProperty solidProperties;
            CpfcPoint3D gravityCentre = new CpfcPoint3D();
            try
            {
                model = session.CurrentModel;
                solid = (IpfcSolid)model;
                solidProperties = solid.GetMassProperty(null);
                gravityCentre = solidProperties.GravityCenter;
                int type = model.Type;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 获取族表中参数，放到map中<名称,值>
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        private Dictionary<string, double> selectFamTab(IpfcParameterOwner paOwner)
        {
            Dictionary<string, double> map = new Dictionary<string, double>();

            IpfcFamilyMember famtab;
            CpfcFamilyTableColumns facols;
            IpfcFamilyTableColumn facol;
            IpfcBaseParameter para;

            try
            {
                famtab = (IpfcFamilyMember)paOwner;
                facols = famtab.ListColumns();
                string paraName;
                double paraValue;
                for (int i = 0; i < facols.Count; i++)
                {
                    facol = facols[i];
                    paraName = facol.Symbol;
                    para = (IpfcBaseParameter)paOwner.GetParam(paraName);
                    paraValue = para.Value.DoubleValue;
                    map.Add(paraName, paraValue);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return map;
        }

        /// <summary>
        /// 更新模型参数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="map"></param>
        private void updateFamTab(IpfcParameterOwner paOwner, Dictionary<string, double> map)
        {
            IpfcBaseParameter para;
            IpfcParamValue paraValue;

            try
            {
                foreach (KeyValuePair<string, double> kvp in map)
                {
                    para = (IpfcBaseParameter)paOwner.GetParam(kvp.Key);
                    paraValue = (new CMpfcModelItem()).CreateDoubleParamValue(kvp.Value);
                    para.Value = paraValue;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 测试用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Dictionary<string, object> selectFamTab1()
        {
            Dictionary<string, object> map = new Dictionary<string, object>();

            map.Add("MN", 6.0);
            map.Add("ZG", 16.0);
            map.Add("DEG", 110.0);
            map.Add("L", 110);
            map.Add("DL", 70.0);
            map.Add("D", 40.0);
            map.Add("DLO", 42.0);
            map.Add("L1", 28.0);
            map.Add("T1", 43.5);
            map.Add("A", 5.0);
            map.Add("B", 10.1);
            map.Add("C", 1.0);

            return map;
        }

        #endregion

        #endregion

        #region 参数输入页面
        /// <summary>
        /// 初始加载页面，同时加载参数列表
        /// </summary>
        /// <returns></returns>
        //public ActionResult paraInput()
        //{
        //    int pageIndex = 1;
        //    int totalRow = 0;
        //    UserInfo userInfo = getUserInfo();
        //    Dictionary<string, object> map = new Dictionary<string, object>();
        //    if (userInfo != null)
        //    {
        //        map.Add("mem_id", userInfo.mem_id);
        //    }

        //    bll_parm = new BLL.parameters();
        //    List<Model.parameters> list_parm = bll_parm.GetModelList(map, pageIndex, out totalRow);
        //    string strJson = JsonUtils.ObjectToJson(list_parm);
        //    ViewBag.list = list_parm;
        //    return View();
        //}

        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <returns></returns>
        public JsonResult paraList()
        {
            string jsonStr = Request["formData"];
            int pageIndex = 1;
            int totalRow = 0;
            UserInfo userInfo = getUserInfo();
            Dictionary<string, object> map = new Dictionary<string, object>();
            if (StrUtils.strNotNUll(jsonStr))
            {
                map = JsonUtils.jsonToDictionary(jsonStr);
            }
            if (Request["pageIndex"] != null)
            {
                pageIndex = Convert.ToInt32(Request["pageIndex"].ToString());
            }
            if (userInfo != null)
            {
                map.Add("mem_id", userInfo.mem_id);
            }

            bll_parm = new BLL.parameters();
            List<Model.parameters> list_parm = bll_parm.GetModelList(map, pageIndex, out totalRow);
            string strJson = JsonUtils.ObjectToJson(list_parm);

            Pager pager = new Pager();
            pager.setPage(pageIndex);// 指定页码
            pager.setTotalRow(totalRow);

            return Json(new { list = strJson, totalPage = pager.getTotalPage() });
        }
        #endregion

    }
}
