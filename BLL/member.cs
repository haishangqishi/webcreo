using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IDAL;
using DALFactory;

namespace BLL
{
    public class member
    {
        private readonly Imember dal = DataAccess.Createmember();
        public member()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.member model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.member model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="mem_id"></param>
        /// <returns></returns>
        public bool Delete(int mem_id)
        {
            return dal.Delete(mem_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="mem_id"></param>
        /// <returns></returns>
        public Model.member GetModel(int mem_id)
        {
            return dal.GetModel(mem_id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取参数List
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<Model.member> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// DataTable转List
        /// </summary>
        public List<Model.member> DataTableToList(DataTable dt)
        {
            List<Model.member> modelList = new List<Model.member>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.member model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 根据用户名获取人员
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Model.member GetMemberByName(string username)
        {
            return dal.GetMemberByName(username);
        }
    }
}
