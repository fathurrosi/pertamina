using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_brand_Mitra_binaan_FileItem
    {
        public static List<tbl_brand_Mitra_binaan_File> GetByFK(Int32 Mitra_binaan_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT * FROM tbl_brand_Mitra_binaan_File
            WHERE [Mitra_binaan_id]  = @Mitra_binaan_id";
            context.AddParameter("@Mitra_binaan_id", Mitra_binaan_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper(context, new tbl_brand_Mitra_binaan_File());
        }
    }
}
