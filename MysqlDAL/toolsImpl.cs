﻿using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using IDAL;
using DBUtility;

namespace MysqlDAL
{
    /// <summary>
    /// 数据访问类:toolsImpl
    /// </summary>
    public partial class toolsImpl : Itools
    {
        public toolsImpl()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.tools model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tools(");
            strSql.Append("toolId,toolName,picName,isDelete)");
            strSql.Append(" values (");
            strSql.Append("@toolId,@toolName,@picName,@isDelete)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@toolId", MySqlDbType.Int32,11),
					new MySqlParameter("@toolName", MySqlDbType.VarChar,30),
					new MySqlParameter("@picName", MySqlDbType.VarChar,30),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11)};
            parameters[0].Value = model.toolId;
            parameters[1].Value = model.toolName;
            parameters[2].Value = model.picName;
            parameters[3].Value = model.isDelete;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.tools model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tools set ");
            strSql.Append("toolName=@toolName,");
            strSql.Append("picName=@picName,");
            strSql.Append("isDelete=@isDelete");
            strSql.Append(" where toolId=@toolId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@toolName", MySqlDbType.VarChar,30),
					new MySqlParameter("@picName", MySqlDbType.VarChar,30),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11),
					new MySqlParameter("@toolId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.toolName;
            parameters[1].Value = model.picName;
            parameters[2].Value = model.isDelete;
            parameters[3].Value = model.toolId;

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
        public bool Delete(int toolId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tools set isDelete=1 ");
            strSql.Append(" where toolId=@toolId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@toolId", MySqlDbType.Int32,11)			};
            parameters[0].Value = toolId;

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
        public Model.tools GetModel(int toolId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select toolId,toolName,picName,isDelete from tools ");
            strSql.Append(" where toolId=@toolId and isDelete=0");
            MySqlParameter[] parameters = {
					new MySqlParameter("@toolId", MySqlDbType.Int32,11)			};
            parameters[0].Value = toolId;

            Model.tools model = new Model.tools();
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
            strSql.Append("select toolId,toolName,picName,isDelete ");
            strSql.Append(" FROM tools where isDelete=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Model.tools DataRowToModel(DataRow row)
        {
            Model.tools model = new Model.tools();
            if (row != null)
            {
                if (row["toolId"] != null && row["toolId"].ToString() != "")
                {
                    model.toolId = int.Parse(row["toolId"].ToString());
                }
                if (row["toolName"] != null)
                {
                    model.toolName = row["toolName"].ToString();
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
        /// 获得刀具-刀具详细列表
        /// </summary>
        public DataSet GetToolDetaList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select td.todeId,t.toolName,t.picName,td.toolPara,td.toolParaValue from tools t");
            strSql.Append(" left join toolDetail td on td.toolId=t.toolId where t.isDelete=0 and td.isDelete=0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Common.ToolDetail ToolDetaRowToModel(DataRow row)
        {
            Common.ToolDetail model = new Common.ToolDetail();
            if (row != null)
            {
                if (row["todeId"] != null && row["todeId"].ToString() != "")
                {
                    model.todeId = int.Parse(row["todeId"].ToString());
                }
                if (row["toolName"] != null)
                {
                    model.toolName = row["toolName"].ToString();
                }
                if (row["picName"] != null)
                {
                    model.picName = row["picName"].ToString();
                }
                if (row["toolPara"] != null)
                {
                    model.toolPara = row["toolPara"].ToString();
                }
                if (row["toolParaValue"] != null)
                {
                    model.toolParaValue = row["toolParaValue"].ToString();
                }
            }
            return model;
        }

    }
}
