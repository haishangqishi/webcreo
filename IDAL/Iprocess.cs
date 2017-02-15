using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IDAL
{
    public interface Iprocess
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(Model.process model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Model.process model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="procId"></param>
        /// <returns></returns>
        bool Delete(int procId);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="procId"></param>
        /// <returns></returns>
        Model.process GetModel(int procId);

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
        Model.process DataRowToModel(DataRow row);

        /// <summary>
        /// 获得工艺-机床列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetProcMachList(string strWhere);

        /// <summary>
        /// row转model
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        Common.Process ProcMachRowToModel(DataRow row);

        /// <summary>
        /// 获得工艺-刀具列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetProcToolList(string strWhere);

        /// <summary>
        /// row转model
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        Common.Process ProcToolRowToModel(DataRow row);

    }
}
