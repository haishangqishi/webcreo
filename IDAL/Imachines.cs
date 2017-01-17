using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IDAL
{
    public interface Imachines
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(Model.machines model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Model.machines model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="mach_id"></param>
        /// <returns></returns>
        bool Delete(int mach_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="mach_id"></param>
        /// <returns></returns>
        Model.machines GetModel(int mach_id);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetList(string strWhere);

        /// <summary>
        /// row转model
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        Model.machines DataRowToModel(DataRow row);

        /// <summary>
        /// 获得机床-机床详细列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetMachDetaList(string strWhere);

        /// <summary>
        /// row转model
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        Common.MachineDetail MachDetaRowToModel(DataRow row);

    }
}
