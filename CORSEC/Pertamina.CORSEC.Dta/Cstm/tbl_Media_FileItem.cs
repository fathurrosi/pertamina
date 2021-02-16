using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Media_FileItem
    {
        public static List<tbl_Media_File> GetByFK(Int64 infographic_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT * FROM tbl_Media_File
            WHERE [infographic_id]  = @infographic_id";
            context.AddParameter("@infographic_id", infographic_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Media_File>(context, new tbl_Media_File());
        }


        public static List<tbl_Media_File> GetDataPaging(int PageIndex, int PageSize, int infographic_id, out int totalRecords)
        {

            totalRecords = 0;

            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Media_File].[id] DESC) AS PAGING_ROW_NUMBER,
        [tbl_Media_File].*
INTO #temp
FROM    [tbl_Media_File]
Where infographic_id=@infographic_id 

SELECT @totalRecords = COUNT(*)  FROM #temp ; 

select t.*
from #temp t   		
WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

drop table #temp     
          
";


            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.AddParameter("@totalRecords", 0, System.Data.ParameterDirection.Output);

            if (infographic_id <= 0) context.AddParameter("@infographic_id", DBNull.Value);
            else context.AddParameter("@infographic_id", infographic_id);

            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper(context, new tbl_Media_File(), out totalRecords);
        }
    }
}
