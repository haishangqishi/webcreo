using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IDAL;
using DALFactory;

namespace BLL
{
    public class machines
    {
        private readonly Imachines dal = DataAccess.Createmachines();
        public machines()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.machines model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.machines model)
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
        public Model.machines GetModel(int machId)
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
        public List<Model.machines> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// DataTable转List
        /// </summary>
        public List<Model.machines> DataTableToList(DataTable dt)
        {
            List<Model.machines> modelList = new List<Model.machines>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.machines model;
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
        /// 获得机床-机床详细列表
        /// </summary>
        public List<Common.MachineDetail> GetMachDetaList(string strWhere)
        {
            DataSet ds = dal.GetMachDetaList(strWhere);
            return MachDetaToList(ds.Tables[0]);
        }


        /// <summary>
        /// DataTable转List
        /// </summary>
        public List<Common.MachineDetail> MachDetaToList(DataTable dt)
        {
            List<Common.MachineDetail> modelList = new List<Common.MachineDetail>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Common.MachineDetail model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.MachDetaRowToModel(dt.Rows[n]);
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
