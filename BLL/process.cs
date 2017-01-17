using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALFactory;
using IDAL;
using System.Data;

namespace BLL
{
    public class process
    {
        private readonly Iprocess dal = DataAccess.Createprocess();
        public process()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.process model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.process model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int machId)
        {
            return dal.Delete(machId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.process GetModel(int machId)
        {
            return dal.GetModel(machId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.process> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// DataTable转List
        /// </summary>
        public List<Model.process> DataTableToList(DataTable dt)
        {
            List<Model.process> modelList = new List<Model.process>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.process model;
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

    }
}
