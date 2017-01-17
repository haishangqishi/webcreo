using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IDAL
{
    public interface ImachineDetail
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(Model.machineDetail model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Model.machineDetail model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="made_id"></param>
        /// <returns></returns>
        bool Delete(int made_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="made_id"></param>
        /// <returns></returns>
        Model.machineDetail GetModel(int made_id);

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
        Model.machineDetail DataRowToModel(DataRow row);

    }
}
