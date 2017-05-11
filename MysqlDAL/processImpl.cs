using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using IDAL;
using DBUtility;

namespace MysqlDAL
{
    /// <summary>
    /// 数据访问类:processImpl
    /// </summary>
    public partial class processImpl : Iprocess
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
            strSql.Append("procId,machId,toolId,procName,isDelete)");
            strSql.Append(" values (");
            strSql.Append("@procId,@machId,@toolId,@procName,@isDelete)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@procId", MySqlDbType.Int32,11),
					new MySqlParameter("@machId", MySqlDbType.Int32,11),
					new MySqlParameter("@toolId", MySqlDbType.Int32,11),
					new MySqlParameter("@procName", MySqlDbType.VarChar,30),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11)};
            parameters[0].Value = model.procId;
            parameters[1].Value = model.machId;
            parameters[2].Value = model.toolId;
            parameters[3].Value = model.procName;
            parameters[4].Value = model.isDelete;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
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
            strSql.Append(" where procId=@procId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@machId", MySqlDbType.Int32,11),
					new MySqlParameter("@toolId", MySqlDbType.Int32,11),
					new MySqlParameter("@procName", MySqlDbType.VarChar,30),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11),
					new MySqlParameter("@procId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.machId;
            parameters[1].Value = model.toolId;
            parameters[2].Value = model.procName;
            parameters[3].Value = model.isDelete;
            parameters[4].Value = model.procId;

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
        public bool Delete(int procId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update process set isDelete=1 ");
            strSql.Append(" where procId=@procId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@procId", MySqlDbType.Int32,11)			};
            parameters[0].Value = procId;

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
        public Model.process GetModel(int procId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select procId,machId,toolId,procName,isDelete from process ");
            strSql.Append(" where procId=@procId and isDelete=0");
            MySqlParameter[] parameters = {
					new MySqlParameter("@procId", MySqlDbType.Int32,11)			};
            parameters[0].Value = procId;

            Model.process model = new Model.process();
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select procId,machId,toolId,procName,isDelete ");
            strSql.Append(" FROM process where isDelete=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
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

        /// <summary>
        /// 获得工艺-机床列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetProcMachList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select p.procId,p.machId,p.procName,m.machName from process p");
            strSql.Append(" left join machines m on m.machId=p.machId where p.isDelete=0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Common.Process ProcMachRowToModel(DataRow row)
        {
            Common.Process model = new Common.Process();
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
                if (row["procName"] != null)
                {
                    model.procName = row["procName"].ToString();
                }
                if (row["machName"] != null)
                {
                    model.machName = row["machName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得工艺-刀具列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetProcToolList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select p.procId,p.toolId,p.procName,t.toolName from process p");
            strSql.Append(" left join tools t on t.toolId=p.toolId where p.isDelete=0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Common.Process ProcToolRowToModel(DataRow row)
        {
            Common.Process model = new Common.Process();
            if (row != null)
            {
                if (row["procId"] != null && row["procId"].ToString() != "")
                {
                    model.procId = int.Parse(row["procId"].ToString());
                }
                if (row["toolId"] != null && row["toolId"].ToString() != "")
                {
                    model.toolId = int.Parse(row["toolId"].ToString());
                }
                if (row["procName"] != null)
                {
                    model.procName = row["procName"].ToString();
                }
                if (row["toolName"] != null)
                {
                    model.toolName = row["toolName"].ToString();
                }
            }
            return model;
        }

    }
}

