using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DALFactory;
using System.Data;

namespace BLL
{
    public class machineDetail
    {
        private readonly ImachineDetail dal = DataAccess.CreatemachineDetail();
        public machineDetail()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.machineDetail model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.machineDetail model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int madeId)
        {
            return dal.Delete(madeId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.machineDetail GetModel(int madeId)
        {
            return dal.GetModel(madeId);
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
        public List<Model.machineDetail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// DataTable转List
        /// </summary>
        public List<Model.machineDetail> DataTableToList(DataTable dt)
        {
            List<Model.machineDetail> modelList = new List<Model.machineDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.machineDetail model;
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
