using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IDAL
{
    public interface Itools
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(Model.tools model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Model.tools model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="tool_id"></param>
        /// <returns></returns>
        bool Delete(int tool_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="tool_id"></param>
        /// <returns></returns>
        Model.tools GetModel(int tool_id);

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
        Model.tools DataRowToModel(DataRow row);

        /// <summary>
        /// 获得刀具-刀具详细列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetToolDetaList(string strWhere);

        /// <summary>
        /// row转model
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        Common.ToolDetail ToolDetaRowToModel(DataRow row);

    }
}
