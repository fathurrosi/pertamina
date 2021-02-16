using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_brand_SponsorshipItem
    {
        /// <summary>
        /// Get All records from TABLE [tbl_brand_Sponsorship]
        /// </summary>        
        public static List<Dto.Cstm.tbl_brand_Sponsorship> GetPagingCustom(int year, int PageSize, int PageIndex, out int totalRecords)
        {
            totalRecords = 0;


            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
                    WITH [Paging_tbl_brand_Sponsorship] AS
                    (
                        SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Sponsorship].[id] DESC) AS PAGING_ROW_NUMBER,
                                [tbl_brand_Sponsorship].*
                        FROM    [tbl_brand_Sponsorship]
                    )

                    SELECT      [Paging_tbl_brand_Sponsorship].*
        			INTO #temp
                    FROM        [Paging_tbl_brand_Sponsorship]
                    where ( ( YEAR(created) = @year ) or ( @year is null ) ) 
                    ORDER BY PAGING_ROW_NUMBER           


            SELECT @totalRecords = COUNT(*)  FROM #temp ; 

        			select t.PAGING_ROW_NUMBER
        			  ,t.[id]
        			  ,t.[title]
        			  ,t.[body]
        			  ,t.[location]
        			  ,t.[award]
        			  ,t.[created]
        			  ,t.[created_by]
        			  ,t.[updated]
        			  ,t.[updated_by]
        			  ,f.[file_type]
        			  ,f.[file_path]
        			  ,f.[file_name]
        			  ,f.[file_ext]
        			  ,f.[file_blob]
        			  ,f.[file_size]
        			from #temp t
        			left join (
        select fTemp.* from [tbl_brand_Sponsorship_File] fTemp
        inner join (
        select MAX(created) as created, [sponsorship_id]  from [dbo].[tbl_brand_Sponsorship_File]
        group by [sponsorship_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[sponsorship_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp  
        ";

            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            if (year <= 1900)
            {
                context.AddParameter("@year", DBNull.Value);
            }
            else
            {
                context.AddParameter("@year", year);
            }
            
            context.AddParameter("@totalRecords", 0, System.Data.ParameterDirection.Output);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper(context, new Dto.Cstm.tbl_brand_Sponsorship(), out totalRecords);
        }


        /// <summary>
        /// 
        /// <summary>
        /// Get All records from TABLE [tbl_brand_Sponsorship]
        /// </summary>        
        public static List<Dto.Cstm.tbl_brand_Sponsorship> GetTop4(int year)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_brand_Sponsorship] AS
            (
                SELECT  top 4 ROW_NUMBER() OVER (ORDER BY [tbl_brand_Sponsorship].[id] DESC) AS PAGING_ROW_NUMBER,
                        [tbl_brand_Sponsorship].*
                FROM    [tbl_brand_Sponsorship]
            )

            SELECT      [Paging_tbl_brand_Sponsorship].*
			INTO #temp
            FROM        [Paging_tbl_brand_Sponsorship]
     
			select t.PAGING_ROW_NUMBER
			  ,t.[id]
			  ,t.[title]
			  ,t.[body]
			  ,t.[location]
			  ,t.[award]
			  ,t.[created]
			  ,t.[created_by]
			  ,t.[updated]
			  ,t.[updated_by]
			  ,f.[file_type]
			  ,f.[file_path]
			  ,f.[file_name]
			  ,f.[file_ext]
			  ,f.[file_blob]
			  ,f.[file_size]
			from #temp t
			left join (
select fTemp.* from [tbl_brand_Sponsorship_File] fTemp
inner join (
select MAX(created) as created, [sponsorship_id]  from [dbo].[tbl_brand_Sponsorship_File]
group by [sponsorship_id]) tTemp on fTemp.created = tTemp.created 
) f on f.[sponsorship_id]= t.id

			drop table #temp
";

            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper(context, new Dto.Cstm.tbl_brand_Sponsorship());
        }

    }
}
