using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Design_Grafis_VideoItem
    {
        public static List<tbl_Design_Grafis_Video> GetByFK(Int64 design_grafis_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT * FROM tbl_Design_Grafis_Video
            WHERE [design_grafis_id]  = @design_grafis_id";
            context.AddParameter("@design_grafis_id", design_grafis_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_Video>(context, new tbl_Design_Grafis_Video());
        }
    }
}
