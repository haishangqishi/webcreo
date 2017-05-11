using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using IDAL;
using DBUtility;

namespace MysqlDAL
{
    /// <summary>
    /// 数据访问类:memberImpl
    /// </summary>
    public partial class memberImpl : Imember
    {
        public memberImpl()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into member(");
            strSql.Append("userName,userPwd,userRole,email,phone,sex,cadPath,creoSetup,gundaoSetup,isDelete)");
            strSql.Append(" values (");
            strSql.Append("@userName,@userPwd,@userRole,@email,@phone,@sex,@cadPath,@creoSetup,@gundaoSetup,@isDelete)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@userName", MySqlDbType.VarChar,20),
					new MySqlParameter("@userPwd", MySqlDbType.VarChar,64),
					new MySqlParameter("@userRole", MySqlDbType.Int32,11),
					new MySqlParameter("@email", MySqlDbType.VarChar,50),
					new MySqlParameter("@phone", MySqlDbType.VarChar,20),
					new MySqlParameter("@sex", MySqlDbType.Int32,11),
					new MySqlParameter("@cadPath", MySqlDbType.VarChar,200),
					new MySqlParameter("@creoSetup", MySqlDbType.VarChar,200),
					new MySqlParameter("@gundaoSetup", MySqlDbType.VarChar,200),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.userPwd;
            parameters[2].Value = model.userRole;
            parameters[3].Value = model.email;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.sex;
            parameters[6].Value = model.cadPath;
            parameters[7].Value = model.creoSetup;
            parameters[8].Value = model.gundaoSetup;
            parameters[9].Value = model.isDelete;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
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
            strSql.Append("cadPath=@cadPath,");
            strSql.Append("creoSetup=@creoSetup,");
            strSql.Append("gundaoSetup=@gundaoSetup,");
            strSql.Append("isDelete=@isDelete");
            strSql.Append(" where memId=@memId");
            MySqlParameter[] parameters = {
					new MySqlParameter("@userName", MySqlDbType.VarChar,20),
					new MySqlParameter("@userPwd", MySqlDbType.VarChar,64),
					new MySqlParameter("@userRole", MySqlDbType.Int32,11),
					new MySqlParameter("@email", MySqlDbType.VarChar,50),
					new MySqlParameter("@phone", MySqlDbType.VarChar,20),
					new MySqlParameter("@sex", MySqlDbType.Int32,11),
					new MySqlParameter("@cadPath", MySqlDbType.VarChar,200),
					new MySqlParameter("@creoSetup", MySqlDbType.VarChar,200),
					new MySqlParameter("@gundaoSetup", MySqlDbType.VarChar,200),
					new MySqlParameter("@isDelete", MySqlDbType.Int32,11),
					new MySqlParameter("@memId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.userName;
            parameters[1].Value = model.userPwd;
            parameters[2].Value = model.userRole;
            parameters[3].Value = model.email;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.sex;
            parameters[6].Value = model.cadPath;
            parameters[7].Value = model.creoSetup;
            parameters[8].Value = model.gundaoSetup;
            parameters[9].Value = model.isDelete;
            parameters[10].Value = model.memId;

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
        public bool Delete(int memId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update member set isDelete=1");
            strSql.Append(" where memId=@memId");
            MySqlParameter[] parameters = {
					new MySqlParameter("@memId", MySqlDbType.Int32)
			};
            parameters[0].Value = memId;

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
        public Model.member GetModel(int memId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select memId,userName,userPwd,userRole,email,phone,sex,cadPath,creoSetup,gundaoSetup,isDelete from member ");
            strSql.Append(" where memId=@memId and isDelete=0");
            MySqlParameter[] parameters = {
					new MySqlParameter("@memId", MySqlDbType.Int32)
			};
            parameters[0].Value = memId;

            Model.member model = new Model.member();
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
            strSql.Append("select memId,userName,userPwd,userRole,email,phone,sex,cadPath,creoSetup,gundaoSetup,isDelete ");
            strSql.Append(" FROM member where isDelete=0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// row转model
        /// </summary>
        public Model.member DataRowToModel(DataRow row)
        {
            Model.member model = new Model.member();
            if (row != null)
            {
                if (row["memId"] != null && row["memId"].ToString() != "")
                {
                    model.memId = int.Parse(row["memId"].ToString());
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
                if (row["cadPath"] != null)
                {
                    model.cadPath = row["cadPath"].ToString();
                }
                if (row["creoSetup"] != null)
                {
                    model.creoSetup = row["creoSetup"].ToString();
                }
                if (row["gundaoSetup"] != null)
                {
                    model.gundaoSetup = row["gundaoSetup"].ToString();
                }
                if (row["isDelete"] != null && row["isDelete"].ToString() != "")
                {
                    model.isDelete = int.Parse(row["isDelete"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 根据用户名获取人员
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Model.member GetMemberByName(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select memId,userName,userPwd,userRole,email,phone,sex,cadPath,creoSetup,gundaoSetup,isDelete from member ");
            strSql.Append(" where userName=@username and isDelete=0");
            MySqlParameter[] parameters = {
					new MySqlParameter("@username", MySqlDbType.VarChar,20)
			};
            parameters[0].Value = username;

            Model.member model = new Model.member();
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

    }
}

