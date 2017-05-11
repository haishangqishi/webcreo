using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using IDAL;
using DBUtility;

namespace MysqlDAL
{
    /// <summary>
    /// 数据访问类:machinesImpl
    /// </summary>
    public partial class machinesImpl : Imachines
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
            strSql.Append("machId,machName,picName,isDelete)");
            strSql.Append(" values (");
            strSql.Append("@machId,@machName,@picName,@isDelete)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@machId", MySqlDbType.Int32,11),
					new MySqlParameter("@machName", MySqlDbType.VarChar,30),
					new MySqlParameter("@picName", MySqlDbType.VarChar,30),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11)};
            parameters[0].Value = model.machId;
            parameters[1].Value = model.machName;
            parameters[2].Value = model.picName;
            parameters[3].Value = model.isDelete;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.machines model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update machines set ");
            strSql.Append("machName=@machName,");
            strSql.Append("picName=@picName,");
            strSql.Append("isDelete=@isDelete");
            strSql.Append(" where machId=@machId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@machName", MySqlDbType.VarChar,30),
					new MySqlParameter("@picName", MySqlDbType.VarChar,30),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11),
					new MySqlParameter("@machId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.machName;
            parameters[1].Value = model.picName;
            parameters[2].Value = model.isDelete;
            parameters[3].Value = model.machId;

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
        public bool Delete(int machId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update machines set isDelete=1 ");
            strSql.Append(" where machId=@machId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@machId", MySqlDbType.Int32,11)			};
            parameters[0].Value = machId;

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
        public Model.machines GetModel(int machId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select machId,machName,picName,isDelete from machines ");
            strSql.Append(" where machId=@machId and isDelete=0");
            MySqlParameter[] parameters = {
					new MySqlParameter("@machId", MySqlDbType.Int32,11)			};
            parameters[0].Value = machId;

            Model.machines model = new Model.machines();
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
            strSql.Append("select machId,machName,picName,isDelete ");
            strSql.Append(" FROM machines where isDelete=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
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
                if (row["picName"] != null)
                {
                    model.picName = row["picName"].ToString();
                }
                if (row["isDelete"] != null && row["isDelete"].ToString() != "")
                {
                    model.isDelete = int.Parse(row["isDelete"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得机床-机床详细列表
        /// </summary>
        public DataSet GetMachDetaList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select md.madeId,m.machName,m.picName,md.machPara,md.machParaValue from machines m");
            strSql.Append(" left join machineDetail md on md.machId=m.machId where m.isDelete=0 and (md.isDelete=0 or md.isDelete is null) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Common.MachineDetail MachDetaRowToModel(DataRow row)
        {
            Common.MachineDetail model = new Common.MachineDetail();
            if (row != null)
            {
                if (row["madeId"] != null && row["madeId"].ToString() != "")
                {
                    model.madeId = int.Parse(row["madeId"].ToString());
                }
                if (row["machName"] != null)
                {
                    model.machName = row["machName"].ToString();
                }
                if (row["picName"] != null)
                {
                    model.picName = row["picName"].ToString();
                }
                if (row["machPara"] != null)
                {
                    model.machPara = row["machPara"].ToString();
                }
                if (row["machParaValue"] != null)
                {
                    model.machParaValue = row["machParaValue"].ToString();
                }
            }
            return model;
        }

    }
}

