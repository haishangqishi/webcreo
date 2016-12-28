using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IDAL;
using DALFactory;

namespace BLL
{
    public class parameters
    {
        private readonly Iparameters dal = DataAccess.Createparameters();
        public parameters()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.parameters model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.parameters model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="parm_id"></param>
        /// <returns></returns>
        public bool Delete(int parm_id)
        {
            return dal.Delete(parm_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="parm_id"></param>
        /// <returns></returns>
        public Model.parameters GetModel(int parm_id)
        {
            return dal.GetModel(parm_id);
        }

        /// <summary>
        /// 获取参数List
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<Model.parameters> GetModelList(Dictionary<string, object> map, int pageIndex, out int total)
        {
            DataSet ds = dal.GetList(map, pageIndex, out total);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        ///DataTable转List
        /// </summary>
        public List<Model.parameters> DataTableToList(DataTable dt)
        {
            List<Model.parameters> modelList = new List<Model.parameters>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.parameters model;
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
