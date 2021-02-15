using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_brand_guidelineItem
    {
        public static tbl_brand_guideline GetByLogoType(Int32 logo_type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT top 1 id, logo_name, file_type, file_path, file_name, file_ext, file_blob, created, created_by, file_size, logo_type FROM tbl_brand_guideline
            WHERE [logo_type]  = @logo_type
            ORDER By id desc
";
            context.AddParameter("@logo_type", logo_type);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_guideline>(context, new tbl_brand_guideline()).FirstOrDefault();
        }

    }
}
