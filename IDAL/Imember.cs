using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IDAL
{
    public interface Imember
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add(Model.member model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Model.member model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="mem_id"></param>
        /// <returns></returns>
        bool Delete(int mem_id);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="mem_id"></param>
        /// <returns></returns>
        Model.member GetModel(int mem_id);

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
        Model.member DataRowToModel(DataRow row);

        /// <summary>
        /// 根据用户名获取人员
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Model.member GetMemberByName(string username);
    }
}
