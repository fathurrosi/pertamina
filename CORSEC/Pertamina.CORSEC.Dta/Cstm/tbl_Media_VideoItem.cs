using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Media_VideoItem
    {
        public static List<tbl_Media_Video> GetByFK(Int64 infographic_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT * FROM tbl_Media_Video
            WHERE [infographic_id]  = @infographic_id";
            context.AddParameter("@infographic_id", infographic_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Media_Video>(context, new tbl_Media_Video());
        }
    }
}
