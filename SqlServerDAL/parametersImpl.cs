using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using System.Data;
using System.Data.SqlClient;
using DBUtility;

namespace SqlServerDAL
{
    class parametersImpl : Iparameters
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
            strSql.Append("mem_id,moshu,deg,kongjing,L,rongxieNum,zhoutaiD,zhoutaiL,jiancaoW,jiancaoH,kongdaoD,celeng,jiancaoR,isStandard,serail,type)");
            strSql.Append(" values (");
            strSql.Append("@mem_id,@moshu,@deg,@kongjing,@L,@rongxieNum,@zhoutaiD,@zhoutaiL,@jiancaoW,@jiancaoH,@kongdaoD,@celeng,@jiancaoR,@isStandard,@serail,@type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@mem_id", SqlDbType.Int,4),
					new SqlParameter("@moshu", SqlDbType.Decimal,5),
					new SqlParameter("@deg", SqlDbType.Decimal,5),
					new SqlParameter("@kongjing", SqlDbType.Decimal,5),
					new SqlParameter("@L", SqlDbType.Decimal,5),
					new SqlParameter("@rongxieNum", SqlDbType.Int,4),
					new SqlParameter("@zhoutaiD", SqlDbType.Decimal,5),
					new SqlParameter("@zhoutaiL", SqlDbType.Decimal,5),
					new SqlParameter("@jiancaoW", SqlDbType.Decimal,5),
					new SqlParameter("@jiancaoH", SqlDbType.Decimal,5),
					new SqlParameter("@kongdaoD", SqlDbType.Decimal,5),
					new SqlParameter("@celeng", SqlDbType.Decimal,5),
					new SqlParameter("@jiancaoR", SqlDbType.Decimal,5),
					new SqlParameter("@isStandard", SqlDbType.Int,4),
					new SqlParameter("@serail", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.Int,4)};
            parameters[0].Value = model.mem_id;
            parameters[1].Value = model.moshu;
            parameters[2].Value = model.deg;
            parameters[3].Value = model.kongjing;
            parameters[4].Value = model.L;
            parameters[5].Value = model.rongxieNum;
            parameters[6].Value = model.zhoutaiD;
            parameters[7].Value = model.zhoutaiL;
            parameters[8].Value = model.jiancaoW;
            parameters[9].Value = model.jiancaoH;
            parameters[10].Value = model.kongdaoD;
            parameters[11].Value = model.celeng;
            parameters[12].Value = model.jiancaoR;
            parameters[13].Value = model.isStandard;
            parameters[14].Value = model.serail;
            parameters[15].Value = model.type;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.parameters model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update parameters set ");
            strSql.Append("mem_id=@mem_id,");
            strSql.Append("moshu=@moshu,");
            strSql.Append("deg=@deg,");
            strSql.Append("kongjing=@kongjing,");
            strSql.Append("L=@L,");
            strSql.Append("rongxieNum=@rongxieNum,");
            strSql.Append("zhoutaiD=@zhoutaiD,");
            strSql.Append("zhoutaiL=@zhoutaiL,");
            strSql.Append("jiancaoW=@jiancaoW,");
            strSql.Append("jiancaoH=@jiancaoH,");
            strSql.Append("kongdaoD=@kongdaoD,");
            strSql.Append("celeng=@celeng,");
            strSql.Append("jiancaoR=@jiancaoR,");
            strSql.Append("isStandard=@isStandard,");
            strSql.Append("serail=@serail,");
            strSql.Append("type=@type");
            strSql.Append(" where parm_id=@parm_id");
            SqlParameter[] parameters = {
					new SqlParameter("@mem_id", SqlDbType.Int,4),
					new SqlParameter("@moshu", SqlDbType.Decimal,5),
					new SqlParameter("@deg", SqlDbType.Decimal,5),
					new SqlParameter("@kongjing", SqlDbType.Decimal,5),
					new SqlParameter("@L", SqlDbType.Decimal,5),
					new SqlParameter("@rongxieNum", SqlDbType.Int,4),
					new SqlParameter("@zhoutaiD", SqlDbType.Decimal,5),
					new SqlParameter("@zhoutaiL", SqlDbType.Decimal,5),
					new SqlParameter("@jiancaoW", SqlDbType.Decimal,5),
					new SqlParameter("@jiancaoH", SqlDbType.Decimal,5),
					new SqlParameter("@kongdaoD", SqlDbType.Decimal,5),
					new SqlParameter("@celeng", SqlDbType.Decimal,5),
					new SqlParameter("@jiancaoR", SqlDbType.Decimal,5),
					new SqlParameter("@isStandard", SqlDbType.Int,4),
					new SqlParameter("@serail", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@parm_id", SqlDbType.Int,4)};
            parameters[0].Value = model.mem_id;
            parameters[1].Value = model.moshu;
            parameters[2].Value = model.deg;
            parameters[3].Value = model.kongjing;
            parameters[4].Value = model.L;
            parameters[5].Value = model.rongxieNum;
            parameters[6].Value = model.zhoutaiD;
            parameters[7].Value = model.zhoutaiL;
            parameters[8].Value = model.jiancaoW;
            parameters[9].Value = model.jiancaoH;
            parameters[10].Value = model.kongdaoD;
            parameters[11].Value = model.celeng;
            parameters[12].Value = model.jiancaoR;
            parameters[13].Value = model.isStandard;
            parameters[14].Value = model.serail;
            parameters[15].Value = model.type;
            parameters[16].Value = model.parm_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int parm_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from parameters ");
            strSql.Append(" where parm_id=@parm_id");
            SqlParameter[] parameters = {
					new SqlParameter("@parm_id", SqlDbType.Int,4)
			};
            parameters[0].Value = parm_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public Model.parameters GetModel(int parm_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 parm_id,mem_id,moshu,deg,kongjing,L,rongxieNum,zhoutaiD,zhoutaiL,jiancaoW,jiancaoH,kongdaoD,celeng,jiancaoR,isStandard,serail,type from parameters ");
            strSql.Append(" where parm_id=@parm_id");
            SqlParameter[] parameters = {
					new SqlParameter("@parm_id", SqlDbType.Int,4)
			};
            parameters[0].Value = parm_id;

            Model.parameters model = new Model.parameters();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select parm_id,mem_id,moshu,deg,kongjing,L,rongxieNum,zhoutaiD,zhoutaiL,jiancaoW,jiancaoH,kongdaoD,celeng,jiancaoR,isStandard,serail,type ");
            strSql.Append(" FROM parameters ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Model.parameters DataRowToModel(DataRow row)
        {
            Model.parameters model = new Model.parameters();
            if (row != null)
            {
                if (row["parm_id"] != null && row["parm_id"].ToString() != "")
                {
                    model.parm_id = int.Parse(row["parm_id"].ToString());
                }
                if (row["mem_id"] != null && row["mem_id"].ToString() != "")
                {
                    model.mem_id = int.Parse(row["mem_id"].ToString());
                }
                if (row["moshu"] != null && row["moshu"].ToString() != "")
                {
                    model.moshu = decimal.Parse(row["moshu"].ToString());
                }
                if (row["deg"] != null && row["deg"].ToString() != "")
                {
                    model.deg = decimal.Parse(row["deg"].ToString());
                }
                if (row["kongjing"] != null && row["kongjing"].ToString() != "")
                {
                    model.kongjing = decimal.Parse(row["kongjing"].ToString());
                }
                if (row["L"] != null && row["L"].ToString() != "")
                {
                    model.L = decimal.Parse(row["L"].ToString());
                }
                if (row["rongxieNum"] != null && row["rongxieNum"].ToString() != "")
                {
                    model.rongxieNum = int.Parse(row["rongxieNum"].ToString());
                }
                if (row["zhoutaiD"] != null && row["zhoutaiD"].ToString() != "")
                {
                    model.zhoutaiD = decimal.Parse(row["zhoutaiD"].ToString());
                }
                if (row["zhoutaiL"] != null && row["zhoutaiL"].ToString() != "")
                {
                    model.zhoutaiL = decimal.Parse(row["zhoutaiL"].ToString());
                }
                if (row["jiancaoW"] != null && row["jiancaoW"].ToString() != "")
                {
                    model.jiancaoW = decimal.Parse(row["jiancaoW"].ToString());
                }
                if (row["jiancaoH"] != null && row["jiancaoH"].ToString() != "")
                {
                    model.jiancaoH = decimal.Parse(row["jiancaoH"].ToString());
                }
                if (row["kongdaoD"] != null && row["kongdaoD"].ToString() != "")
                {
                    model.kongdaoD = decimal.Parse(row["kongdaoD"].ToString());
                }
                if (row["celeng"] != null && row["celeng"].ToString() != "")
                {
                    model.celeng = decimal.Parse(row["celeng"].ToString());
                }
                if (row["jiancaoR"] != null && row["jiancaoR"].ToString() != "")
                {
                    model.jiancaoR = decimal.Parse(row["jiancaoR"].ToString());
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
            }
            return model;
        }

    }
}
