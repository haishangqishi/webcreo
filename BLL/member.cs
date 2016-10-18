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

        int Add(Model.member model)
        {
            return dal.Add(model);
        }

        public bool Update(Model.member model)
        {
            return dal.Update(model);
        }

        public bool Delete(int mem_id)
        {
            return dal.Delete(mem_id);
        }

        public Model.member GetModel(int mem_id)
        {
            return dal.GetModel(mem_id);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public List<Model.member> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
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

        public Model.member GetMemberByName(string username)
        {
            return dal.GetMemberByName(username);
        }
    }
}
