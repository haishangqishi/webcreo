using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IDAL;
using DALFactory;

namespace BLL
{
    public class tools
    {
        private readonly Itools dal = DataAccess.Createtools();
        public tools()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.tools model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.tools model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int toolId)
        {
            return dal.Delete(toolId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.tools GetModel(int toolId)
        {
            return dal.GetModel(toolId);
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
        public List<Model.tools> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// DataTable转List
        /// </summary>
        public List<Model.tools> DataTableToList(DataTable dt)
        {
            List<Model.tools> modelList = new List<Model.tools>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.tools model;
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
        /// 获得刀具-刀具详细列表
        /// </summary>
        public List<Common.ToolDetail> GetToolDetaList(string strWhere)
        {
            DataSet ds = dal.GetToolDetaList(strWhere);
            return ToolDetaToList(ds.Tables[0]);
        }


        /// <summary>
        /// DataTable转List
        /// </summary>
        public List<Common.ToolDetail> ToolDetaToList(DataTable dt)
        {
            List<Common.ToolDetail> modelList = new List<Common.ToolDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Common.ToolDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.ToolDetaRowToModel(dt.Rows[n]);
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
