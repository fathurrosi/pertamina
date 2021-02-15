using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_brand_ExhibitionItem
    {
        /// <summary>
        /// Get All records from TABLE [tbl_brand_Exhibition]
        /// </summary>        
        public static List<Dto.Cstm.tbl_brand_Exhibition> GetPagingCustom(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Exhibition].[id]) AS PAGING_ROW_NUMBER,
                    [tbl_brand_Exhibition].*
            INTO #temp
            FROM    [tbl_brand_Exhibition]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY

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
select fTemp.* from [tbl_brand_Exhibition_File] fTemp
inner join (
select MAX(created) as created, [exhibition_id]  from [dbo].[tbl_brand_Exhibition_File]
group by [exhibition_id]) tTemp on fTemp.created = tTemp.created 
) f on f.[exhibition_id]= t.id

			drop table #temp
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper(context, new Dto.Cstm.tbl_brand_Exhibition());
        }

        /// <summary>
    }
}
