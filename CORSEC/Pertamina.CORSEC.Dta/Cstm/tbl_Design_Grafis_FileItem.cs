using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Design_Grafis_FileItem
    {
     
        public static List<tbl_Design_Grafis_File> GetDataPaging(int PageIndex, int PageSize, int design_grafis_id, out int totalRecords)
        {

            totalRecords = 0;

            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Design_Grafis_File].[id] DESC) AS PAGING_ROW_NUMBER,
        [tbl_Design_Grafis_File].*
INTO #temp
FROM    [tbl_Design_Grafis_File]
Where design_grafis_id=@design_grafis_id 

SELECT @totalRecords = COUNT(*)  FROM #temp ; 

select t.*
from #temp t   		
WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

drop table #temp     
          
";


            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.AddParameter("@totalRecords", 0, System.Data.ParameterDirection.Output);

            if (design_grafis_id <= 0) context.AddParameter("@design_grafis_id", DBNull.Value);
            else context.AddParameter("@design_grafis_id", design_grafis_id);

            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper(context, new tbl_Design_Grafis_File(), out totalRecords);
        }

        public static List<tbl_Design_Grafis_File> GetByFK(Int64 design_grafis_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT 
* FROM tbl_Design_Grafis_File
            WHERE [design_grafis_id]  = @design_grafis_id";
            context.AddParameter("@design_grafis_id", design_grafis_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_File>(context, new tbl_Design_Grafis_File());
        }

    }
}
