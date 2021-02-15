using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_brand_Merchandise_hub_FileItem
    {
      
        public static List<tbl_brand_Merchandise_hub_File> GetByFK(Int32 Merchandise_hub_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT * FROM tbl_brand_Merchandise_hub_File
            WHERE [Merchandise_hub_id]  = @Merchandise_hub_id";
            context.AddParameter("@Merchandise_hub_id", Merchandise_hub_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper(context, new tbl_brand_Merchandise_hub_File());
        }
    }
}
