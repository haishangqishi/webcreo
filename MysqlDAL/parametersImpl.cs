using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using IDAL;
using DBUtility;
using System.Collections.Generic;

namespace MysqlDAL
{
    /// <summary>
    /// 数据访问类:parametersImpl
    /// </summary>
    public partial class parametersImpl : Iparameters
    {
        public parametersImpl()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.parameters model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into parameters(");
            strSql.Append("moshu,chigaoXishu,xuanxiang,faxiangYaLiJiao,jingxiangXiShu,jingduClass,waijing,kongjing,quanchang,caoxingAngle,rongxieCaoXing,rongxieNum,dingreHouAngle,chiqianAngle,ZTDiameter,ZTlength,ZTdaoleng,jiancaoWidth,jiancaoHeight,jiancaoYuanHu,NKDiameter,NKlength,aqz,aqy,hegq,sfzg,hgq,tz,r1,r2,dfg,H,lamtaf,R0,k,cerenAngle,isStandard,serail,type,memId,dimNum,isDelete)");
            strSql.Append(" values (");
            strSql.Append("@moshu,@chigaoXishu,@xuanxiang,@faxiangYaLiJiao,@jingxiangXiShu,@jingduClass,@waijing,@kongjing,@quanchang,@caoxingAngle,@rongxieCaoXing,@rongxieNum,@dingreHouAngle,@chiqianAngle,@ZTDiameter,@ZTlength,@ZTdaoleng,@jiancaoWidth,@jiancaoHeight,@jiancaoYuanHu,@NKDiameter,@NKlength,@aqz,@aqy,@hegq,@sfzg,@hgq,@tz,@r1,@r2,@dfg,@H,@lamtaf,@R0,@k,@cerenAngle,@isStandard,@serail,@type,@memId,@dimNum,@isDelete)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@moshu", MySqlDbType.Float,6),
					new MySqlParameter("@chigaoXishu", MySqlDbType.Float,6),
					new MySqlParameter("@xuanxiang", MySqlDbType.VarChar,50),
					new MySqlParameter("@faxiangYaLiJiao", MySqlDbType.Float,6),
					new MySqlParameter("@jingxiangXiShu", MySqlDbType.Float,6),
					new MySqlParameter("@jingduClass", MySqlDbType.Float,6),
					new MySqlParameter("@waijing", MySqlDbType.Float,6),
					new MySqlParameter("@kongjing", MySqlDbType.Float,6),
					new MySqlParameter("@quanchang", MySqlDbType.Float,6),
					new MySqlParameter("@caoxingAngle", MySqlDbType.Float,6),
					new MySqlParameter("@rongxieCaoXing", MySqlDbType.VarChar,50),
					new MySqlParameter("@rongxieNum", MySqlDbType.Int32,11),
					new MySqlParameter("@dingreHouAngle", MySqlDbType.Float,6),
					new MySqlParameter("@chiqianAngle", MySqlDbType.Float,6),
					new MySqlParameter("@ZTDiameter", MySqlDbType.Float,6),
					new MySqlParameter("@ZTlength", MySqlDbType.Float,6),
					new MySqlParameter("@ZTdaoleng", MySqlDbType.Float,6),
					new MySqlParameter("@jiancaoWidth", MySqlDbType.Float,5),
					new MySqlParameter("@jiancaoHeight", MySqlDbType.Float,5),
					new MySqlParameter("@jiancaoYuanHu", MySqlDbType.Float,6),
					new MySqlParameter("@NKDiameter", MySqlDbType.Float,6),
					new MySqlParameter("@NKlength", MySqlDbType.Float,6),
					new MySqlParameter("@aqz", MySqlDbType.Float,6),
					new MySqlParameter("@aqy", MySqlDbType.Float,6),
					new MySqlParameter("@hegq", MySqlDbType.Float,6),
					new MySqlParameter("@sfzg", MySqlDbType.Float,6),
					new MySqlParameter("@hgq", MySqlDbType.Float,6),
					new MySqlParameter("@tz", MySqlDbType.Float,6),
					new MySqlParameter("@r1", MySqlDbType.Float,6),
					new MySqlParameter("@r2", MySqlDbType.Float,6),
					new MySqlParameter("@dfg", MySqlDbType.Float,6),
					new MySqlParameter("@H", MySqlDbType.Float,6),
					new MySqlParameter("@lamtaf", MySqlDbType.Float,6),
					new MySqlParameter("@R0", MySqlDbType.Float,6),
					new MySqlParameter("@k", MySqlDbType.Float,6),
					new MySqlParameter("@cerenAngle", MySqlDbType.Float,6),
					new MySqlParameter("@isStandard", MySqlDbType.Int32,11),
					new MySqlParameter("@serail", MySqlDbType.Int32,11),
					new MySqlParameter("@type", MySqlDbType.Int32,11),
					new MySqlParameter("@memId", MySqlDbType.Int32,11),
					new MySqlParameter("@dimNum", MySqlDbType.Int32,11),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11)};
            parameters[0].Value = model.moshu;
            parameters[1].Value = model.chigaoXishu;
            parameters[2].Value = model.xuanxiang;
            parameters[3].Value = model.faxiangYaLiJiao;
            parameters[4].Value = model.jingxiangXiShu;
            parameters[5].Value = model.jingduClass;
            parameters[6].Value = model.waijing;
            parameters[7].Value = model.kongjing;
            parameters[8].Value = model.quanchang;
            parameters[9].Value = model.caoxingAngle;
            parameters[10].Value = model.rongxieCaoXing;
            parameters[11].Value = model.rongxieNum;
            parameters[12].Value = model.dingreHouAngle;
            parameters[13].Value = model.chiqianAngle;
            parameters[14].Value = model.ZTDiameter;
            parameters[15].Value = model.ZTlength;
            parameters[16].Value = model.ZTdaoleng;
            parameters[17].Value = model.jiancaoWidth;
            parameters[18].Value = model.jiancaoHeight;
            parameters[19].Value = model.jiancaoYuanHu;
            parameters[20].Value = model.NKDiameter;
            parameters[21].Value = model.NKlength;
            parameters[22].Value = model.aqz;
            parameters[23].Value = model.aqy;
            parameters[24].Value = model.hegq;
            parameters[25].Value = model.sfzg;
            parameters[26].Value = model.hgq;
            parameters[27].Value = model.tz;
            parameters[28].Value = model.r1;
            parameters[29].Value = model.r2;
            parameters[30].Value = model.dfg;
            parameters[31].Value = model.H;
            parameters[32].Value = model.lamtaf;
            parameters[33].Value = model.R0;
            parameters[34].Value = model.k;
            parameters[35].Value = model.cerenAngle;
            parameters[36].Value = model.isStandard;
            parameters[37].Value = model.serail;
            parameters[38].Value = model.type;
            parameters[39].Value = model.memId;
            parameters[40].Value = model.dimNum;
            parameters[41].Value = model.isDelete;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.parameters model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update parameters set ");
            strSql.Append("moshu=@moshu,");
            strSql.Append("chigaoXishu=@chigaoXishu,");
            strSql.Append("xuanxiang=@xuanxiang,");
            strSql.Append("faxiangYaLiJiao=@faxiangYaLiJiao,");
            strSql.Append("jingxiangXiShu=@jingxiangXiShu,");
            strSql.Append("jingduClass=@jingduClass,");
            strSql.Append("waijing=@waijing,");
            strSql.Append("kongjing=@kongjing,");
            strSql.Append("quanchang=@quanchang,");
            strSql.Append("caoxingAngle=@caoxingAngle,");
            strSql.Append("rongxieCaoXing=@rongxieCaoXing,");
            strSql.Append("rongxieNum=@rongxieNum,");
            strSql.Append("dingreHouAngle=@dingreHouAngle,");
            strSql.Append("chiqianAngle=@chiqianAngle,");
            strSql.Append("ZTDiameter=@ZTDiameter,");
            strSql.Append("ZTlength=@ZTlength,");
            strSql.Append("ZTdaoleng=@ZTdaoleng,");
            strSql.Append("jiancaoWidth=@jiancaoWidth,");
            strSql.Append("jiancaoHeight=@jiancaoHeight,");
            strSql.Append("jiancaoYuanHu=@jiancaoYuanHu,");
            strSql.Append("NKDiameter=@NKDiameter,");
            strSql.Append("NKlength=@NKlength,");
            strSql.Append("aqz=@aqz,");
            strSql.Append("aqy=@aqy,");
            strSql.Append("hegq=@hegq,");
            strSql.Append("sfzg=@sfzg,");
            strSql.Append("hgq=@hgq,");
            strSql.Append("tz=@tz,");
            strSql.Append("r1=@r1,");
            strSql.Append("r2=@r2,");
            strSql.Append("dfg=@dfg,");
            strSql.Append("H=@H,");
            strSql.Append("lamtaf=@lamtaf,");
            strSql.Append("R0=@R0,");
            strSql.Append("k=@k,");
            strSql.Append("cerenAngle=@cerenAngle,");
            strSql.Append("isStandard=@isStandard,");
            strSql.Append("serail=@serail,");
            strSql.Append("type=@type,");
            strSql.Append("memId=@memId,");
            strSql.Append("dimNum=@dimNum,");
            strSql.Append("isDelete=@isDelete");
            strSql.Append(" where parmId=@parmId");
            MySqlParameter[] parameters = {
					new MySqlParameter("@moshu", MySqlDbType.Float,6),
					new MySqlParameter("@chigaoXishu", MySqlDbType.Float,6),
					new MySqlParameter("@xuanxiang", MySqlDbType.VarChar,50),
					new MySqlParameter("@faxiangYaLiJiao", MySqlDbType.Float,6),
					new MySqlParameter("@jingxiangXiShu", MySqlDbType.Float,6),
					new MySqlParameter("@jingduClass", MySqlDbType.Float,6),
					new MySqlParameter("@waijing", MySqlDbType.Float,6),
					new MySqlParameter("@kongjing", MySqlDbType.Float,6),
					new MySqlParameter("@quanchang", MySqlDbType.Float,6),
					new MySqlParameter("@caoxingAngle", MySqlDbType.Float,6),
					new MySqlParameter("@rongxieCaoXing", MySqlDbType.VarChar,50),
					new MySqlParameter("@rongxieNum", MySqlDbType.Int32,11),
					new MySqlParameter("@dingreHouAngle", MySqlDbType.Float,6),
					new MySqlParameter("@chiqianAngle", MySqlDbType.Float,6),
					new MySqlParameter("@ZTDiameter", MySqlDbType.Float,6),
					new MySqlParameter("@ZTlength", MySqlDbType.Float,6),
					new MySqlParameter("@ZTdaoleng", MySqlDbType.Float,6),
					new MySqlParameter("@jiancaoWidth", MySqlDbType.Float,5),
					new MySqlParameter("@jiancaoHeight", MySqlDbType.Float,5),
					new MySqlParameter("@jiancaoYuanHu", MySqlDbType.Float,6),
					new MySqlParameter("@NKDiameter", MySqlDbType.Float,6),
					new MySqlParameter("@NKlength", MySqlDbType.Float,6),
					new MySqlParameter("@aqz", MySqlDbType.Float,6),
					new MySqlParameter("@aqy", MySqlDbType.Float,6),
					new MySqlParameter("@hegq", MySqlDbType.Float,6),
					new MySqlParameter("@sfzg", MySqlDbType.Float,6),
					new MySqlParameter("@hgq", MySqlDbType.Float,6),
					new MySqlParameter("@tz", MySqlDbType.Float,6),
					new MySqlParameter("@r1", MySqlDbType.Float,6),
					new MySqlParameter("@r2", MySqlDbType.Float,6),
					new MySqlParameter("@dfg", MySqlDbType.Float,6),
					new MySqlParameter("@H", MySqlDbType.Float,6),
					new MySqlParameter("@lamtaf", MySqlDbType.Float,6),
					new MySqlParameter("@R0", MySqlDbType.Float,6),
					new MySqlParameter("@k", MySqlDbType.Float,6),
					new MySqlParameter("@cerenAngle", MySqlDbType.Float,6),
					new MySqlParameter("@isStandard", MySqlDbType.Int32,11),
					new MySqlParameter("@serail", MySqlDbType.Int32,11),
					new MySqlParameter("@type", MySqlDbType.Int32,11),
					new MySqlParameter("@memId", MySqlDbType.Int32,11),
					new MySqlParameter("@dimNum", MySqlDbType.Int32,11),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11),
					new MySqlParameter("@parmId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.moshu;
            parameters[1].Value = model.chigaoXishu;
            parameters[2].Value = model.xuanxiang;
            parameters[3].Value = model.faxiangYaLiJiao;
            parameters[4].Value = model.jingxiangXiShu;
            parameters[5].Value = model.jingduClass;
            parameters[6].Value = model.waijing;
            parameters[7].Value = model.kongjing;
            parameters[8].Value = model.quanchang;
            parameters[9].Value = model.caoxingAngle;
            parameters[10].Value = model.rongxieCaoXing;
            parameters[11].Value = model.rongxieNum;
            parameters[12].Value = model.dingreHouAngle;
            parameters[13].Value = model.chiqianAngle;
            parameters[14].Value = model.ZTDiameter;
            parameters[15].Value = model.ZTlength;
            parameters[16].Value = model.ZTdaoleng;
            parameters[17].Value = model.jiancaoWidth;
            parameters[18].Value = model.jiancaoHeight;
            parameters[19].Value = model.jiancaoYuanHu;
            parameters[20].Value = model.NKDiameter;
            parameters[21].Value = model.NKlength;
            parameters[22].Value = model.aqz;
            parameters[23].Value = model.aqy;
            parameters[24].Value = model.hegq;
            parameters[25].Value = model.sfzg;
            parameters[26].Value = model.hgq;
            parameters[27].Value = model.tz;
            parameters[28].Value = model.r1;
            parameters[29].Value = model.r2;
            parameters[30].Value = model.dfg;
            parameters[31].Value = model.H;
            parameters[32].Value = model.lamtaf;
            parameters[33].Value = model.R0;
            parameters[34].Value = model.k;
            parameters[35].Value = model.cerenAngle;
            parameters[36].Value = model.isStandard;
            parameters[37].Value = model.serail;
            parameters[38].Value = model.type;
            parameters[39].Value = model.memId;
            parameters[40].Value = model.dimNum;
            parameters[41].Value = model.isDelete;
            parameters[42].Value = model.parmId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int parmId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update parameters set isDelete=1 ");
            strSql.Append(" where parmId=@parmId");
            MySqlParameter[] parameters = {
					new MySqlParameter("@parmId", MySqlDbType.Int32)
			};
            parameters[0].Value = parmId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.parameters GetModel(int parmId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select parmId,moshu,chigaoXishu,xuanxiang,faxiangYaLiJiao,jingxiangXiShu,jingduClass,waijing,kongjing,quanchang,caoxingAngle,rongxieCaoXing,rongxieNum,dingreHouAngle,chiqianAngle,ZTDiameter,ZTlength,ZTdaoleng,jiancaoWidth,jiancaoHeight,jiancaoYuanHu,NKDiameter,NKlength,aqz,aqy,hegq,sfzg,hgq,tz,r1,r2,dfg,H,lamtaf,R0,k,cerenAngle,isStandard,serail,type,memId,dimNum,isDelete from parameters ");
            strSql.Append(" where parmId=@parmId and isDelete=0");
            MySqlParameter[] parameters = {
					new MySqlParameter("@parmId", MySqlDbType.Int32)
			};
            parameters[0].Value = parmId;

            Model.parameters model = new Model.parameters();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(Dictionary<string, object> map, int pageIndex, out int total)
        {
            List<string> sqlList = new List<string>();

            int pageSize = 10;
            int mem_id = 0;
            if (map != null)
            {
                if (map.ContainsKey("pageSize") && map["pageSize"].ToString() != "")
                {
                    pageSize = Convert.ToInt32(map["pageSize"].ToString());
                }
                if (map.ContainsKey("mem_id") && map["mem_id"].ToString() != "")
                {
                    mem_id = Convert.ToInt32(map["mem_id"].ToString());
                }
            }
            string sqlLimit = getSql(map);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + pageSize + " parm_id,mem_id,moshu,deg,kongjing,L,rongxieNum,zhoutaiD,zhoutaiL,jiancaoW,jiancaoH,kongdaoD,kongdaoL,celeng,jiancaoR,isStandard,serail,type,qianjiao,dingrenAngle,cerenAngle,isDelete from ");
            strSql.Append(" (select ROW_NUMBER() OVER (ORDER BY parm_id ASC) AS RowNumber,* FROM parameters where isDelete=0 and (mem_id=1 or mem_id=" + mem_id + ") " + sqlLimit + " ) as tmp ");
            strSql.Append(" WHERE RowNumber > " + pageSize * (pageIndex - 1) + sqlLimit);
            sqlList.Add(strSql.ToString());

            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("select count(*) ");
            strSql1.Append(" FROM parameters where isDelete=0 and (mem_id=1 or mem_id=" + mem_id + ") " + sqlLimit);
            sqlList.Add(strSql1.ToString());

            return DbHelperMySQL.ExecuteSqlTran_page(sqlList, out total);
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Model.parameters DataRowToModel(DataRow row)
        {
            Model.parameters model = new Model.parameters();
            if (row != null)
            {
                if (row["parmId"] != null && row["parmId"].ToString() != "")
                {
                    model.parmId = int.Parse(row["parmId"].ToString());
                }
                if (row["moshu"] != null && row["moshu"].ToString() != "")
                {
                    model.moshu = decimal.Parse(row["moshu"].ToString());
                }
                if (row["chigaoXishu"] != null && row["chigaoXishu"].ToString() != "")
                {
                    model.chigaoXishu = decimal.Parse(row["chigaoXishu"].ToString());
                }
                if (row["xuanxiang"] != null)
                {
                    model.xuanxiang = row["xuanxiang"].ToString();
                }
                if (row["faxiangYaLiJiao"] != null && row["faxiangYaLiJiao"].ToString() != "")
                {
                    model.faxiangYaLiJiao = decimal.Parse(row["faxiangYaLiJiao"].ToString());
                }
                if (row["jingxiangXiShu"] != null && row["jingxiangXiShu"].ToString() != "")
                {
                    model.jingxiangXiShu = decimal.Parse(row["jingxiangXiShu"].ToString());
                }
                if (row["jingduClass"] != null && row["jingduClass"].ToString() != "")
                {
                    model.jingduClass = decimal.Parse(row["jingduClass"].ToString());
                }
                if (row["waijing"] != null && row["waijing"].ToString() != "")
                {
                    model.waijing = decimal.Parse(row["waijing"].ToString());
                }
                if (row["kongjing"] != null && row["kongjing"].ToString() != "")
                {
                    model.kongjing = decimal.Parse(row["kongjing"].ToString());
                }
                if (row["quanchang"] != null && row["quanchang"].ToString() != "")
                {
                    model.quanchang = decimal.Parse(row["quanchang"].ToString());
                }
                if (row["caoxingAngle"] != null && row["caoxingAngle"].ToString() != "")
                {
                    model.caoxingAngle = decimal.Parse(row["caoxingAngle"].ToString());
                }
                if (row["rongxieCaoXing"] != null)
                {
                    model.rongxieCaoXing = row["rongxieCaoXing"].ToString();
                }
                if (row["rongxieNum"] != null && row["rongxieNum"].ToString() != "")
                {
                    model.rongxieNum = int.Parse(row["rongxieNum"].ToString());
                }
                if (row["dingreHouAngle"] != null && row["dingreHouAngle"].ToString() != "")
                {
                    model.dingreHouAngle = decimal.Parse(row["dingreHouAngle"].ToString());
                }
                if (row["chiqianAngle"] != null && row["chiqianAngle"].ToString() != "")
                {
                    model.chiqianAngle = decimal.Parse(row["chiqianAngle"].ToString());
                }
                if (row["ZTDiameter"] != null && row["ZTDiameter"].ToString() != "")
                {
                    model.ZTDiameter = decimal.Parse(row["ZTDiameter"].ToString());
                }
                if (row["ZTlength"] != null && row["ZTlength"].ToString() != "")
                {
                    model.ZTlength = decimal.Parse(row["ZTlength"].ToString());
                }
                if (row["ZTdaoleng"] != null && row["ZTdaoleng"].ToString() != "")
                {
                    model.ZTdaoleng = decimal.Parse(row["ZTdaoleng"].ToString());
                }
                if (row["jiancaoWidth"] != null && row["jiancaoWidth"].ToString() != "")
                {
                    model.jiancaoWidth = decimal.Parse(row["jiancaoWidth"].ToString());
                }
                if (row["jiancaoHeight"] != null && row["jiancaoHeight"].ToString() != "")
                {
                    model.jiancaoHeight = decimal.Parse(row["jiancaoHeight"].ToString());
                }
                if (row["jiancaoYuanHu"] != null && row["jiancaoYuanHu"].ToString() != "")
                {
                    model.jiancaoYuanHu = decimal.Parse(row["jiancaoYuanHu"].ToString());
                }
                if (row["NKDiameter"] != null && row["NKDiameter"].ToString() != "")
                {
                    model.NKDiameter = decimal.Parse(row["NKDiameter"].ToString());
                }
                if (row["NKlength"] != null && row["NKlength"].ToString() != "")
                {
                    model.NKlength = decimal.Parse(row["NKlength"].ToString());
                }
                if (row["aqz"] != null && row["aqz"].ToString() != "")
                {
                    model.aqz = decimal.Parse(row["aqz"].ToString());
                }
                if (row["aqy"] != null && row["aqy"].ToString() != "")
                {
                    model.aqy = decimal.Parse(row["aqy"].ToString());
                }
                if (row["hegq"] != null && row["hegq"].ToString() != "")
                {
                    model.hegq = decimal.Parse(row["hegq"].ToString());
                }
                if (row["sfzg"] != null && row["sfzg"].ToString() != "")
                {
                    model.sfzg = decimal.Parse(row["sfzg"].ToString());
                }
                if (row["hgq"] != null && row["hgq"].ToString() != "")
                {
                    model.hgq = decimal.Parse(row["hgq"].ToString());
                }
                if (row["tz"] != null && row["tz"].ToString() != "")
                {
                    model.tz = decimal.Parse(row["tz"].ToString());
                }
                if (row["r1"] != null && row["r1"].ToString() != "")
                {
                    model.r1 = decimal.Parse(row["r1"].ToString());
                }
                if (row["r2"] != null && row["r2"].ToString() != "")
                {
                    model.r2 = decimal.Parse(row["r2"].ToString());
                }
                if (row["dfg"] != null && row["dfg"].ToString() != "")
                {
                    model.dfg = decimal.Parse(row["dfg"].ToString());
                }
                if (row["H"] != null && row["H"].ToString() != "")
                {
                    model.H = decimal.Parse(row["H"].ToString());
                }
                if (row["lamtaf"] != null && row["lamtaf"].ToString() != "")
                {
                    model.lamtaf = decimal.Parse(row["lamtaf"].ToString());
                }
                if (row["R0"] != null && row["R0"].ToString() != "")
                {
                    model.R0 = decimal.Parse(row["R0"].ToString());
                }
                if (row["k"] != null && row["k"].ToString() != "")
                {
                    model.k = decimal.Parse(row["k"].ToString());
                }
                if (row["cerenAngle"] != null && row["cerenAngle"].ToString() != "")
                {
                    model.cerenAngle = decimal.Parse(row["cerenAngle"].ToString());
                }
                if (row["isStandard"] != null && row["isStandard"].ToString() != "")
                {
                    model.isStandard = int.Parse(row["isStandard"].ToString());
                }
                if (row["serail"] != null && row["serail"].ToString() != "")
                {
                    model.serail = int.Parse(row["serail"].ToString());
                }
                if (row["type"] != null && row["type"].ToString() != "")
                {
                    model.type = int.Parse(row["type"].ToString());
                }
                if (row["memId"] != null && row["memId"].ToString() != "")
                {
                    model.memId = int.Parse(row["memId"].ToString());
                }
                if (row["dimNum"] != null && row["dimNum"].ToString() != "")
                {
                    model.dimNum = int.Parse(row["dimNum"].ToString());
                }
                if (row["isDelete"] != null && row["isDelete"].ToString() != "")
                {
                    model.isDelete = int.Parse(row["isDelete"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 条件sql
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        private string getSql(Dictionary<string, object> map)
        {
            StringBuilder strSql = new StringBuilder();
            int flag = 1;//是否标准
            if (map != null)
            {
                if (map.ContainsKey("moshu") && map["moshu"].ToString() != "")
                {
                    strSql.Append(" and moshu=" + Convert.ToDecimal(map["moshu"].ToString()));
                }
                if (map.ContainsKey("rongxieNum") && map["rongxieNum"].ToString() != "")
                {
                    strSql.Append(" and rongxieNum=" + Convert.ToDecimal(map["rongxieNum"].ToString()));
                }
                if (map.ContainsKey("deg") && map["deg"].ToString() != "")
                {
                    strSql.Append(" and deg=" + Convert.ToDecimal(map["deg"].ToString()));
                }
                if (!map.ContainsKey("isStandard"))
                {
                    if (map.ContainsKey("serail") || map.ContainsKey("type"))
                    {
                        flag = 0;
                    }
                }
                else
                {
                    if (map.ContainsKey("serail") && map["serail"].ToString() != "")
                    {
                        string serail = map["serail"].ToString();
                        if (serail == "0")
                        {
                            strSql.Append(" and serail in(1,2)");
                        }
                        else
                        {
                            strSql.Append(" and serail=" + serail);
                        }
                    }
                    if (map.ContainsKey("type") && map["type"].ToString() != "")
                    {
                        string type = map["type"].ToString();
                        if (type == "0")
                        {
                            strSql.Append(" and type in(1,2)");
                        }
                        else
                        {
                            strSql.Append(" and type=" + type);
                        }
                    }
                }
                strSql.Append(" and isStandard=" + flag);
            }
            return strSql.ToString();
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT * FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby);
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.parmId desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from parameters T ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return DbHelperMySQL.Query(strSql.ToString());
        //}

    }
}

