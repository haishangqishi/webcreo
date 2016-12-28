using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IDAL
{
    public interface Iparameters
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(Model.parameters model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Model.parameters model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="parm_id"></param>
        /// <returns></returns>
        bool Delete(int parm_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="parm_id"></param>
        /// <returns></returns>
        Model.parameters GetModel(int parm_id);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="map"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        DataSet GetList(Dictionary<string, object> map, int pageIndex, out int total);

        /// <summary>
        /// row转model
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        Model.parameters DataRowToModel(DataRow row);

    }
}
