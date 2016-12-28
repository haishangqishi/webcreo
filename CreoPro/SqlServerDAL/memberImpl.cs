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
    class memberImpl : Imember
    {
        public int Add(Model.member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into member(");
            strSql.Append("userName,userPwd,userRole,email,phone,sex,creoSetup,creoWorkSpace,isWork)");
            strSql.Append(" values (");
            strSql.Append("@userName,@userPwd,@userRole,@email,@phone,@sex,@creoSetup,@creoWorkSpace,@isWork)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@userName", SqlDbType.VarChar,100),
                    new SqlParameter("@userPwd", SqlDbType.VarChar,100),
                    new SqlParameter("@userRole", SqlDbType.Int,4),
                    new SqlParameter("@email", SqlDbType.VarChar,50),
                    new SqlParameter("@phone", SqlDbType.VarChar,20),
                    new SqlParameter("@sex", SqlDbType.Int,4),
                    new SqlParameter("@creoSetup", SqlDbType.VarChar,200),
                    new SqlParameter("@creoWorkSpace", SqlDbType.VarChar,200),
                    new SqlParameter("@isWork", SqlDbType.Int,4)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.userPwd;
            parameters[2].Value = model.userRole;
            parameters[3].Value = model.email;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.sex;
            parameters[6].Value = model.creoSetup;
            parameters[7].Value = model.creoWorkSpace;
            parameters[8].Value = model.isWork;

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

        public bool Update(Model.member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update member set ");
            strSql.Append("userName=@userName,");
            strSql.Append("userPwd=@userPwd,");
            strSql.Append("userRole=@userRole,");
            strSql.Append("email=@email,");
            strSql.Append("phone=@phone,");
            strSql.Append("sex=@sex,");
            strSql.Append("creoSetup=@creoSetup,");
            strSql.Append("creoWorkSpace=@creoWorkSpace,");
            strSql.Append("isWork=@isWork");
            strSql.Append(" where mem_id=@mem_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@userName", SqlDbType.VarChar,100),
                    new SqlParameter("@userPwd", SqlDbType.VarChar,100),
                    new SqlParameter("@userRole", SqlDbType.Int,4),
                    new SqlParameter("@email", SqlDbType.VarChar,50),
                    new SqlParameter("@phone", SqlDbType.VarChar,20),
                    new SqlParameter("@sex", SqlDbType.Int,4),
                    new SqlParameter("@creoSetup", SqlDbType.VarChar,200),
                    new SqlParameter("@creoWorkSpace", SqlDbType.VarChar,200),
                    new SqlParameter("@isWork", SqlDbType.Int,4),
                    new SqlParameter("@mem_id", SqlDbType.Int,4)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.userPwd;
            parameters[2].Value = model.userRole;
            parameters[3].Value = model.email;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.sex;
            parameters[6].Value = model.creoSetup;
            parameters[7].Value = model.creoWorkSpace;
            parameters[8].Value = model.isWork;
            parameters[9].Value = model.mem_id;

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

        public bool Delete(int mem_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from member ");
            strSql.Append(" where mem_id=@mem_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@mem_id", SqlDbType.Int,4)
            };
            parameters[0].Value = mem_id;

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

        public Model.member GetModel(int mem_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 mem_id,userName,userPwd,userRole,email,phone,sex,creoSetup,creoWorkSpace,isWork from member ");
            strSql.Append(" where mem_id=@mem_id");
            SqlParameter[] parameters = {
                    new SqlParameter("@mem_id", SqlDbType.Int,4)
            };
            parameters[0].Value = mem_id;

            Model.member model = new Model.member();
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

        public System.Data.DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mem_id,userName,userPwd,userRole,email,phone,sex,creoSetup,creoWorkSpace,isWork ");
            strSql.Append(" FROM member ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Model.member> GetModelList(string strWhere)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.member DataRowToModel(DataRow row)
        {
            Model.member model = new Model.member();
            if (row != null)
            {
                if (row["mem_id"] != null && row["mem_id"].ToString() != "")
                {
                    model.mem_id = int.Parse(row["mem_id"].ToString());
                }
                if (row["userName"] != null)
                {
                    model.userName = row["userName"].ToString();
                }
                if (row["userPwd"] != null)
                {
                    model.userPwd = row["userPwd"].ToString();
                }
                if (row["userRole"] != null && row["userRole"].ToString() != "")
                {
                    model.userRole = int.Parse(row["userRole"].ToString());
                }
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["sex"] != null && row["sex"].ToString() != "")
                {
                    model.sex = int.Parse(row["sex"].ToString());
                }
                if (row["creoSetup"] != null)
                {
                    model.creoSetup = row["creoSetup"].ToString();
                }
                if (row["creoWorkSpace"] != null)
                {
                    model.creoWorkSpace = row["creoWorkSpace"].ToString();
                }
                if (row["isWork"] != null && row["isWork"].ToString() != "")
                {
                    model.isWork = int.Parse(row["isWork"].ToString());
                }
            }
            return model;
        }
    }
}
