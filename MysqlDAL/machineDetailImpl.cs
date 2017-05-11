using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using IDAL;
using DBUtility;

namespace MysqlDAL
{
    /// <summary>
    /// 数据访问类:machinedetailImpl
    /// </summary>
    public partial class machineDetailImpl : ImachineDetail
    {
        public machineDetailImpl()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.machineDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into machinedetail(");
            strSql.Append("madeId,machId,machPara,machParaValue,isDelete)");
            strSql.Append(" values (");
            strSql.Append("@madeId,@machId,@machPara,@machParaValue,@isDelete)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@madeId", MySqlDbType.Int32,11),
					new MySqlParameter("@machId", MySqlDbType.Int32,11),
					new MySqlParameter("@machPara", MySqlDbType.VarChar,40),
					new MySqlParameter("@machParaValue", MySqlDbType.VarChar,60),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11)};
            parameters[0].Value = model.madeId;
            parameters[1].Value = model.machId;
            parameters[2].Value = model.machPara;
            parameters[3].Value = model.machParaValue;
            parameters[4].Value = model.isDelete;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.machineDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update machinedetail set ");
            strSql.Append("machId=@machId,");
            strSql.Append("machPara=@machPara,");
            strSql.Append("machParaValue=@machParaValue,");
            strSql.Append("isDelete=@isDelete");
            strSql.Append(" where madeId=@madeId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@machId", MySqlDbType.Int32,11),
					new MySqlParameter("@machPara", MySqlDbType.VarChar,40),
					new MySqlParameter("@machParaValue", MySqlDbType.VarChar,60),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11),
					new MySqlParameter("@madeId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.machId;
            parameters[1].Value = model.machPara;
            parameters[2].Value = model.machParaValue;
            parameters[3].Value = model.isDelete;
            parameters[4].Value = model.madeId;

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
        public bool Delete(int madeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update machinedetail set isDelete=1 ");
            strSql.Append(" where madeId=@madeId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@madeId", MySqlDbType.Int32,11)			};
            parameters[0].Value = madeId;

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
        public Model.machineDetail GetModel(int madeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select madeId,machId,machPara,machParaValue,isDelete from machinedetail ");
            strSql.Append(" where madeId=@madeId and isDelete=0");
            MySqlParameter[] parameters = {
					new MySqlParameter("@madeId", MySqlDbType.Int32,11)			};
            parameters[0].Value = madeId;

            Model.machineDetail model = new Model.machineDetail();
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
            strSql.Append("select madeId,machId,machPara,machParaValue,isDelete ");
            strSql.Append(" FROM machinedetail where isDelete=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
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

