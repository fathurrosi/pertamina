using System.Linq;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_File_ProgramItem
    {
        public static tbl_File_Program GetByReff(string ReferenceTable, string ReferenceID)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"	
            SELECT top 1 *  FROM [tbl_File_Program]
            WHERE [ref_name] =@ReferenceTable and [ref_id] =@ReferenceID

            ";
            context.CommandType = System.Data.CommandType.Text;
            context.AddParameter("@ReferenceTable", ReferenceTable);
            context.AddParameter("@ReferenceID", ReferenceID);
            return DBUtil.ExecuteMapper(context, new tbl_File_Program()).FirstOrDefault();
        }
    }
}
