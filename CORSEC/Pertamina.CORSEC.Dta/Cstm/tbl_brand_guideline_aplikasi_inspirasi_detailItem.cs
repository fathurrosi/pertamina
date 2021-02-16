using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_brand_guideline_aplikasi_inspirasi_detailItem
    {
        public static List<tbl_brand_guideline_aplikasi_inspirasi_detail> GetDataPaging(int PageIndex, int PageSize, out int totalRecords)
        {

            totalRecords = 0;

            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_guideline_aplikasi_inspirasi_detail].[id] DESC) AS PAGING_ROW_NUMBER,
            [tbl_brand_guideline_aplikasi_inspirasi_detail].*
			into	#temp
            FROM    [tbl_brand_guideline_aplikasi_inspirasi_detail]

            SELECT @totalRecords = COUNT(*)    
            FROM        #temp ;  

            SELECT      *
            FROM        #temp            
            WHERE PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

			drop table #temp    
          
";


            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.AddParameter("@totalRecords", 0, System.Data.ParameterDirection.Output);

            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_brand_guideline_aplikasi_inspirasi_detail>(context, new tbl_brand_guideline_aplikasi_inspirasi_detail(), out totalRecords);
        }


    }
}
