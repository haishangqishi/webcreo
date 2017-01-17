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
    public class processImpl : Iprocess
    {
        public processImpl()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.process model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into process(");
            strSql.Append("machId,toolId,procName,isDelete)");
            strSql.Append(" values (");
            strSql.Append("@machId,@toolId,@procName,@isDelete)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@machId", SqlDbType.Int,4),
					new SqlParameter("@toolId", SqlDbType.Int,4),
					new SqlParameter("@procName", SqlDbType.VarChar,30),
					new SqlParameter("@isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.machId;
            parameters[1].Value = model.toolId;
            parameters[2].Value = model.procName;
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
        public bool Update(Model.process model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update process set ");
            strSql.Append("machId=@machId,");
            strSql.Append("toolId=@toolId,");
            strSql.Append("procName=@procName,");
            strSql.Append("isDelete=@isDelete");
            strSql.Append(" where procId=@procId");
            SqlParameter[] parameters = {
					new SqlParameter("@machId", SqlDbType.Int,4),
					new SqlParameter("@toolId", SqlDbType.Int,4),
					new SqlParameter("@procName", SqlDbType.VarChar,30),
					new SqlParameter("@isDelete", SqlDbType.Int,4),
					new SqlParameter("@procId", SqlDbType.Int,4)};
            parameters[0].Value = model.machId;
            parameters[1].Value = model.toolId;
            parameters[2].Value = model.procName;
            parameters[3].Value = model.isDelete;
            parameters[4].Value = model.procId;

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
        public bool Delete(int procId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update process set isDelete=1");
            strSql.Append(" where procId=@procId");
            SqlParameter[] parameters = {
					new SqlParameter("@procId", SqlDbType.Int,4)
			};
            parameters[0].Value = procId;

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
        public Model.process GetModel(int procId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 procId,machId,toolId,procName,isDelete from process ");
            strSql.Append(" where procId=@procId");
            SqlParameter[] parameters = {
					new SqlParameter("@procId", SqlDbType.Int,4)
			};
            parameters[0].Value = procId;

            Model.process model = new Model.process();
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
            strSql.Append("select procId,machId,toolId,procName,isDelete ");
            strSql.Append(" FROM process ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Model.process DataRowToModel(DataRow row)
        {
            Model.process model = new Model.process();
            if (row != null)
            {
                if (row["procId"] != null && row["procId"].ToString() != "")
                {
                    model.procId = int.Parse(row["procId"].ToString());
                }
                if (row["machId"] != null && row["machId"].ToString() != "")
                {
                    model.machId = int.Parse(row["machId"].ToString());
                }
                if (row["toolId"] != null && row["toolId"].ToString() != "")
                {
                    model.toolId = int.Parse(row["toolId"].ToString());
                }
                if (row["procName"] != null)
                {
                    model.procName = row["procName"].ToString();
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
