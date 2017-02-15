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
    public class toolDetailImpl : ItoolDetail
    {
        public toolDetailImpl()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.toolDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into toolDetail(");
            strSql.Append("toolId,toolPara,toolParaValue,isDelete)");
            strSql.Append(" values (");
            strSql.Append("@toolId,@toolPara,@toolParaValue,@isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@toolId", SqlDbType.Int,4),
					new SqlParameter("@toolPara", SqlDbType.VarChar,40),
					new SqlParameter("@toolParaValue", SqlDbType.VarChar,40),
					new SqlParameter("@isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.toolId;
            parameters[1].Value = model.toolPara;
            parameters[2].Value = model.toolParaValue;
            parameters[3].Value = model.isDelete;

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
        public bool Update(Model.toolDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update toolDetail set ");
            strSql.Append("toolId=@toolId,");
            strSql.Append("toolPara=@toolPara,");
            strSql.Append("toolParaValue=@toolParaValue,");
            strSql.Append("isDelete=@isDelete");
            strSql.Append(" where todeId=@todeId");
            SqlParameter[] parameters = {
					new SqlParameter("@toolId", SqlDbType.Int,4),
					new SqlParameter("@toolPara", SqlDbType.VarChar,40),
					new SqlParameter("@toolParaValue", SqlDbType.VarChar,40),
					new SqlParameter("@isDelete", SqlDbType.Int,4),
					new SqlParameter("@todeId", SqlDbType.Int,4)};
            parameters[0].Value = model.toolId;
            parameters[1].Value = model.toolPara;
            parameters[2].Value = model.toolParaValue;
            parameters[3].Value = model.isDelete;
            parameters[4].Value = model.todeId;

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
        public bool Delete(int todeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update toolDetail set isDelete=1");
            strSql.Append(" where todeId=@todeId");
            SqlParameter[] parameters = {
					new SqlParameter("@todeId", SqlDbType.Int,4)
			};
            parameters[0].Value = todeId;

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
        public Model.toolDetail GetModel(int todeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 todeId,toolId,toolPara,toolParaValue,isDelete from toolDetail ");
            strSql.Append(" where todeId=@todeId and isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@todeId", SqlDbType.Int,4)			};
            parameters[0].Value = todeId;

            Model.toolDetail model = new Model.toolDetail();
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
            strSql.Append("select todeId,toolId,toolPara,toolParaValue,isDelete ");
            strSql.Append(" FROM toolDetail where isDelete=0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Model.toolDetail DataRowToModel(DataRow row)
        {
            Model.toolDetail model = new Model.toolDetail();
            if (row != null)
            {
                if (row["todeId"] != null && row["todeId"].ToString() != "")
                {
                    model.todeId = int.Parse(row["todeId"].ToString());
                }
                if (row["toolId"] != null && row["toolId"].ToString() != "")
                {
                    model.toolId = int.Parse(row["toolId"].ToString());
                }
                if (row["toolPara"] != null)
                {
                    model.toolPara = row["toolPara"].ToString();
                }
                if (row["toolParaValue"] != null)
                {
                    model.toolParaValue = row["toolParaValue"].ToString();
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
