using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_product_FileItem
    {
        public static List<tbl_product_File> GetByFK(Int32 product_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT * FROM tbl_product_File
            WHERE [product_id]  = @product_id";
            context.AddParameter("@product_id", product_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper(context, new tbl_product_File());
        }
    }
}
