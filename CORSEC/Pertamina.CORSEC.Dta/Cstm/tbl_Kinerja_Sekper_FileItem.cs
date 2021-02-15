using System.Linq;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Kinerja_Sekper_FileItem
    {
        public static tbl_Kinerja_Sekper_File GetByReff(string ReferenceTable, string ReferenceID)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"	
            SELECT top 1 *  FROM [tbl_Kinerja_Sekper_File]
            WHERE [ref_name] =@ReferenceTable and [ref_id] =@ReferenceID

            ";
            context.CommandType = System.Data.CommandType.Text;
            context.AddParameter("@ReferenceTable", ReferenceTable);
            context.AddParameter("@ReferenceID", ReferenceID);
            return DBUtil.ExecuteMapper(context, new tbl_Kinerja_Sekper_File()).FirstOrDefault();
        }
    }
}
