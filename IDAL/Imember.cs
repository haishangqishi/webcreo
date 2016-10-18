using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IDAL
{
    public interface Imember
    {
        int Add(Model.member model);

        bool Update(Model.member model);

        bool Delete(int mem_id);

        Model.member GetModel(int mem_id);

        DataSet GetList(string strWhere);

        List<Model.member> GetModelList(string strWhere);

        Model.member DataRowToModel(DataRow row);

        Model.member GetMemberByName(string username);
    }
}
