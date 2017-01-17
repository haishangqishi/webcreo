using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace SqlServerDAL
{
    class machineDetailImpl : ImachineDetail
    {
        public machineDetailImpl()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.machineDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into machineDetail(");
            strSql.Append("madeId,machId,machPara,machParaValue,isDelete)");
            strSql.Append(" values (");
            strSql.Append("@madeId,@machId,@machPara,@machParaValue,@isDelete)");
            SqlParameter[] parameters = {
					new SqlParameter("@madeId", SqlDbType.Int,4),
					new SqlParameter("@machId", SqlDbType.Int,4),
					new SqlParameter("@machPara", SqlDbType.VarChar,40),
					new SqlParameter("@machParaValue", SqlDbType.VarChar,40),
					new SqlParameter("@isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.madeId;
            parameters[1].Value = model.machId;
            parameters[2].Value = model.machPara;
            parameters[3].Value = model.machParaValue;
            parameters[4].Value = model.isDelete;

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
        public bool Update(Model.machineDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update machineDetail set ");
            strSql.Append("machId=@machId,");
            strSql.Append("machPara=@machPara,");
            strSql.Append("machParaValue=@machParaValue,");
            strSql.Append("isDelete=@isDelete");
            strSql.Append(" where madeId=@madeId ");
            SqlParameter[] parameters = {
					new SqlParameter("@machId", SqlDbType.Int,4),
					new SqlParameter("@machPara", SqlDbType.VarChar,40),
					new SqlParameter("@machParaValue", SqlDbType.VarChar,40),
					new SqlParameter("@isDelete", SqlDbType.Int,4),
					new SqlParameter("@madeId", SqlDbType.Int,4)};
            parameters[0].Value = model.machId;
            parameters[1].Value = model.machPara;
            parameters[2].Value = model.machParaValue;
            parameters[3].Value = model.isDelete;
            parameters[4].Value = model.madeId;

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
        public bool Delete(int madeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update machineDetail set isDelete=1");
            strSql.Append(" where madeId=@madeId");
            SqlParameter[] parameters = {
					new SqlParameter("@madeId", SqlDbType.Int,4)
			};
            parameters[0].Value = madeId;

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
        public Model.machineDetail GetModel(int madeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 madeId,machId,machPara,machParaValue,isDelete from machineDetail ");
            strSql.Append(" where madeId=@madeId and isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@madeId", SqlDbType.Int,4)			};
            parameters[0].Value = madeId;

            Model.machineDetail model = new Model.machineDetail();
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
            strSql.Append("select madeId,machId,machPara,machParaValue,isDelete ");
            strSql.Append(" FROM machineDetail where isDelete=0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Model.machineDetail DataRowToModel(DataRow row)
        {
            Model.machineDetail model = new Model.machineDetail();
            if (row != null)
            {
                if (row["madeId"] != null && row["madeId"].ToString() != "")
                {
                    model.madeId = int.Parse(row["madeId"].ToString());
                }
                if (row["machId"] != null && row["machId"].ToString() != "")
                {
                    model.machId = int.Parse(row["machId"].ToString());
                }
                if (row["machPara"] != null)
                {
                    model.machPara = row["machPara"].ToString();
                }
                if (row["machParaValue"] != null)
                {
                    model.machParaValue = row["machParaValue"].ToString();
                }
                if (row["isDelete"] != null && row["isDelete"].ToString() != "")
                {
                    model.isDelete = int.Parse(row["isDelete"].ToString());
                }
            }
            return model;
        }

    }
}
