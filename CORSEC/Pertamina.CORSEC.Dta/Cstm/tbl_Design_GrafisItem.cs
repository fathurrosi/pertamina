using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Design_GrafisItem
    {
        /// <summary>
        /// Get Total records from [tbl_Design_Grafis]
        /// </summary>        
        public static int GetCount(int PageSize, int PageIndex, int data_type)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Design_Grafis  WHERE data_type =@data_type";
            context.CommandText = sqlQuery;
            context.AddParameter("@data_type", data_type);
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }

        /// <summary>
        /// Get All records from TABLE [tbl_Design_Grafis]
        /// </summary>        
        public static List<tbl_Design_Grafis> GetPaging(int PageSize, int PageIndex, int data_type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Design_Grafis] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Design_Grafis].[id] DESC) AS PAGING_ROW_NUMBER,
                        [tbl_Design_Grafis].*
                FROM    [tbl_Design_Grafis]
                WHERE data_type =@data_type
            )

            SELECT      [Paging_tbl_Design_Grafis].*
            FROM        [Paging_tbl_Design_Grafis]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.AddParameter("@data_type", data_type);
            
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis>(context, new tbl_Design_Grafis());
        }

        public static List<Dto.Cstm. tbl_Design_Grafis> GetDataPaging(int PageIndex, int PageSize, int data_type, out int totalRecords)
        {

            totalRecords = 0;

            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Design_Grafis].[id] DESC) AS PAGING_ROW_NUMBER,
        [tbl_Design_Grafis].*
INTO #temp
FROM    [tbl_Design_Grafis]

Where (data_type=@data_type OR @data_type is null)   

   SELECT @totalRecords = COUNT(*)  FROM #temp ; 

   		select  t.*
   		  ,f.[file_type]
   		  ,f.[file_path]
   		  ,f.[file_name]
   		  ,f.[file_ext]
   		  ,f.[file_blob]
   		  ,f.[file_size]
   		from #temp t
   		left join (
        select fTemp.* from [tbl_Design_Grafis_File] fTemp
        inner join (
        select MAX(created) as created, [design_grafis_id]  from [dbo].[tbl_Design_Grafis_File]
        group by [design_grafis_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[design_grafis_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp     
          
";
            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.AddParameter("@totalRecords", 0, System.Data.ParameterDirection.Output);

            if (data_type <= 0) context.AddParameter("@data_type", DBNull.Value);
            else context.AddParameter("@data_type", data_type);
            
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper< Dto.Cstm.tbl_Design_Grafis>(context, new Dto.Cstm.tbl_Design_Grafis(), out totalRecords);
        }

    }
}
