using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using System.Data;
using WSH.CodeBuilder.Entity;

namespace WSH.CodeBuilder.Manager
{
    public class DictManager : BaseManager
    {
        public DataTable GetDataTable(string dictCode)
        {
            string sql = string.Format("select * from [Dict] where DictCode='" + dictCode+"'");
            return db.GetDataTable(sql);
        }
        public DictEntity GetByID(string id)
        {
            string sql = string.Format("select * from [Dict] where ID={0}", id);
            return ConvertHelper.ToList<DictEntity>(db.GetDataTable(sql))[0];
        }
        public List<DictEntity> GetList(string dictCode)
        {
            return ConvertHelper.ToList<DictEntity>(GetDataTable(dictCode));
        }

        public DictEntity GetByCode(string dictCode)
        {
            List<DictEntity> list = GetList(dictCode);
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            return null;
        }
        public DictEntity GetByType(DictType dictType)
        {
            if (dictType != DictType.None)
            {
                return GetByCode(dictType.ToString());
            }
            return null;
        }
    }
}
