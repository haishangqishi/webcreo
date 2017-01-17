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
    public class machinesImpl : Imachines
    {
        public machinesImpl()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.machines model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into machines(");
            strSql.Append("machId,machName,isDelete)");
            strSql.Append(" values (");
            strSql.Append("@machId,@machName,@isDelete)");
            SqlParameter[] parameters = {
					new SqlParameter("@machId", SqlDbType.Int,4),
					new SqlParameter("@machName", SqlDbType.VarChar,30),
					new SqlParameter("@isDelete", SqlDbType.Int,4)};
            parameters[0].Value = model.machId;
            parameters[1].Value = model.machName;
            parameters[2].Value = model.isDelete;

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
        public bool Update(Model.machines model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update machines set ");
            strSql.Append("machName=@machName,");
            strSql.Append("isDelete=@isDelete");
            strSql.Append(" where machId=@machId ");
            SqlParameter[] parameters = {
					new SqlParameter("@machName", SqlDbType.VarChar,30),
					new SqlParameter("@isDelete", SqlDbType.Int,4),
					new SqlParameter("@machId", SqlDbType.Int,4)};
            parameters[0].Value = model.machName;
            parameters[1].Value = model.isDelete;
            parameters[2].Value = model.machId;

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
        public bool Delete(int machId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update machines set isDelete=1");
            strSql.Append(" where machId=@machId");
            SqlParameter[] parameters = {
					new SqlParameter("@madeId", SqlDbType.Int,4)
			};
            parameters[0].Value = machId;

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
        public Model.machines GetModel(int machId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 machId,machName,isDelete from machines ");
            strSql.Append(" where machId=@machId and isDelete=0");
            SqlParameter[] parameters = {
					new SqlParameter("@machId", SqlDbType.Int,4)
            };
            parameters[0].Value = machId;

            Model.machines model = new Model.machines();
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
            strSql.Append("select machId,machName,isDelete ");
            strSql.Append(" FROM machines where isDelete=0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Model.machines DataRowToModel(DataRow row)
        {
            Model.machines model = new Model.machines();
            if (row != null)
            {
                if (row["machId"] != null && row["machId"].ToString() != "")
                {
                    model.machId = int.Parse(row["machId"].ToString());
                }
                if (row["machName"] != null)
                {
                    model.machName = row["machName"].ToString();
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
