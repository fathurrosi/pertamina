using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_MediaItem
    {
        public static List<Pertamina.CORSEC.Dto.Cstm.tbl_Media> GetDataPaging(int PageIndex, int PageSize, int infographic_type, int year_start, int year_end, out int totalRecords)
        {

            totalRecords = 0;

            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Media].[id]) AS PAGING_ROW_NUMBER,
        [tbl_Media].*
INTO #temp
FROM    [tbl_Media]

Where (infographic_type=@infographic_type OR @infographic_type is null)            
AND ( infographic_year >=@year_start OR @year_start is null)
AND ( infographic_year <=@year_end OR @year_end is null)

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
        select fTemp.* from [tbl_Media_File] fTemp
        inner join (
        select MAX(created) as created, [infographic_id]  from [dbo].[tbl_Media_File]
        group by [infographic_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[infographic_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp     
          
";
            if(infographic_type==7) //tvc
            {
                sqlQuery = @"
SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Media].[id]) AS PAGING_ROW_NUMBER,
        [tbl_Media].*
INTO #temp
FROM    [tbl_Media]

Where (infographic_type=@infographic_type OR @infographic_type is null)            
AND ( infographic_year >=@year_start OR @year_start is null)
AND ( infographic_year <=@year_end OR @year_end is null)

   SELECT @totalRecords = COUNT(*)  FROM #temp ; 

   		select t.PAGING_ROW_NUMBER
      ,t.[id]
      ,t.[title]
      ,f.file_duration [body]
      ,t.[created]
      ,t.[created_by]
      ,t.[updated]
      ,t.[updated_by]
      ,t.[infographic_type]
      ,t.[infographic_year]
      ,t.[img_type]
      ,t.[img_path]
      ,t.[img_name]
      ,t.[img_ext]
      ,t.[img_blob]
      ,t.[img_size]
   		  ,f.[file_type]
   		  ,f.file_virtual_path as [file_path]
   		  ,f.[file_name]
   		  ,f.[file_ext]
   		  ,f.[file_blob]
   		  ,f.[file_size]
   		from #temp t
   		left join (
        select fTemp.* from [tbl_Media_Video] fTemp
        inner join (
        select MAX(created) as created, [infographic_id]  from [dbo].[tbl_Media_Video]
        group by [infographic_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[infographic_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp     
          
";
            }


            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.AddParameter("@totalRecords", 0, System.Data.ParameterDirection.Output);

            if (infographic_type <= 0) context.AddParameter("@infographic_type", DBNull.Value);
            else context.AddParameter("@infographic_type", infographic_type);

            if (year_start <= 1900) context.AddParameter("@year_start", DBNull.Value);
            else context.AddParameter("@year_start", year_start);

            if (year_start <= 1900) context.AddParameter("@year_end", DBNull.Value);
            else context.AddParameter("@year_end", year_end);


            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Pertamina.CORSEC.Dto.Cstm.tbl_Media>(context, new Pertamina.CORSEC.Dto.Cstm.tbl_Media(), out totalRecords);
        }

        public static int GetCount(int PageSize, int PageIndex,int infographic_type)
        {
            return GetTotalRecord(infographic_type);
        }
        /// <summary>
        /// Get Total records from [tbl_Media]
        /// </summary>        
        public static int GetTotalRecord(int infographic_type)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Media WHERE infographic_type =@infographic_type";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            context.AddParameter("@infographic_type", infographic_type);
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }

        /// <summary>
        /// Get All records from TABLE [tbl_Media]
        /// </summary>        
        public static List<Dto.tbl_Media> GetPaging(int PageSize, int PageIndex, int infographic_type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Media] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Media].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Media].*
                FROM    [tbl_Media]
            )

            SELECT      [Paging_tbl_Media].*
            FROM        [Paging_tbl_Media]
            WHERE infographic_type =@infographic_type
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.AddParameter("@infographic_type", infographic_type);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Dto.tbl_Media>(context, new Dto.tbl_Media());
        }



        /// <summary>
        /// Get All records from TABLE [tbl_Media]
        /// </summary>        
        public static List<Dto.tbl_Media> GetByType(int infographic_type, int year_start, int year_end )
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
        
SELECT * FROM [tbl_Media]

Where (infographic_type=@infographic_type OR @infographic_type is null)            
AND ( infographic_year >=@year_start OR @year_start is null)
AND ( infographic_year <=@year_end OR @year_end is null)
        
";


            if (infographic_type <= 0) context.AddParameter("@infographic_type", DBNull.Value);
            else context.AddParameter("@infographic_type", infographic_type);

            if (year_start <= 1900) context.AddParameter("@year_start", DBNull.Value);
            else context.AddParameter("@year_start", year_start);

            if (year_start <= 1900) context.AddParameter("@year_end", DBNull.Value);
            else context.AddParameter("@year_end", year_end);

            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Dto.tbl_Media>(context, new Dto.tbl_Media());
        }
    }
}
