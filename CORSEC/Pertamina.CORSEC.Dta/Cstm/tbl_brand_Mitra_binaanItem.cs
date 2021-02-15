using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_brand_Mitra_binaanItem
    {
        public static List<Dto.Cstm.tbl_brand_Mitra_binaan> GetPagingCustom(int PageIndex, int PageSize, string category, int sort, out int totalRecords)
        {
            totalRecords = 0;

            //[Description("Last Added")]
            //LastAdded = 1,
            //[Description("Sort A-Z")]
            //Sort_A_Z = 2,
            //[Description("Sort Z-A")]
            //Sort_Z_A = 3

            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Mitra_binaan].[id]) AS PAGING_ROW_NUMBER,
                    [tbl_brand_Mitra_binaan].*
            into	#temp
            FROM    [tbl_brand_Mitra_binaan]
            where ( Kategori=@Kategori OR @Kategori is null )

           SELECT @totalRecords = COUNT(*)  FROM #temp ; 

        			select t.PAGING_ROW_NUMBER
        			  , t.[id]
      ,t.[title]
      ,t.[body]
      ,t.[created]
      ,t.[created_by]
      ,t.[updated]
      ,t.[updated_by]
      ,t.[SKU]
      ,t.[Estimasi_Harga_Mulai]
      ,t.[Estimasi_Harga_Hingga]
      ,t.[Min_Quantity]
      ,t.[Kategori]
        			  ,f.[file_type]
        			  ,f.[file_path]
        			  ,f.[file_name]
        			  ,f.[file_ext]
        			  ,f.[file_blob]
        			  ,f.[file_size]
        			from #temp t
        			left join (
        select fTemp.* from [tbl_brand_Mitra_binaan_File] fTemp
        inner join (
        select MAX(created) as created, [Mitra_binaan_id]  from [dbo].[tbl_brand_Mitra_binaan_File]
        group by [Mitra_binaan_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[Mitra_binaan_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp  
";
            if (sort == 2)
            {
                sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Mitra_binaan].[title] asc) AS PAGING_ROW_NUMBER,
                    [tbl_brand_Mitra_binaan].*
            into	#temp
            FROM    [tbl_brand_Mitra_binaan]
            where ( Kategori=@Kategori OR @Kategori is null )

            SELECT @totalRecords = COUNT(*)  FROM #temp ; 

        			select t.PAGING_ROW_NUMBER
        			  , t.[id]
      ,t.[title]
      ,t.[body]
      ,t.[created]
      ,t.[created_by]
      ,t.[updated]
      ,t.[updated_by]
      ,t.[SKU]
      ,t.[Estimasi_Harga_Mulai]
      ,t.[Estimasi_Harga_Hingga]
      ,t.[Min_Quantity]
      ,t.[Kategori]
        			  ,f.[file_type]
        			  ,f.[file_path]
        			  ,f.[file_name]
        			  ,f.[file_ext]
        			  ,f.[file_blob]
        			  ,f.[file_size]
        			from #temp t
        			left join (
        select fTemp.* from [tbl_brand_Mitra_binaan_File] fTemp
        inner join (
        select MAX(created) as created, [Mitra_binaan_id]  from [dbo].[tbl_brand_Mitra_binaan_File]
        group by [Mitra_binaan_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[Mitra_binaan_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp  
";

            }
            else if (sort == 3)
            {
                sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Mitra_binaan].[title] desc) AS PAGING_ROW_NUMBER,
                    [tbl_brand_Mitra_binaan].*
            into	#temp
            FROM    [tbl_brand_Mitra_binaan]
            where ( Kategori=@Kategori OR @Kategori is null )

            SELECT @totalRecords = COUNT(*)  FROM #temp ; 

        			select t.PAGING_ROW_NUMBER
        			  , t.[id]
      ,t.[title]
      ,t.[body]
      ,t.[created]
      ,t.[created_by]
      ,t.[updated]
      ,t.[updated_by]
      ,t.[SKU]
      ,t.[Estimasi_Harga_Mulai]
      ,t.[Estimasi_Harga_Hingga]
      ,t.[Min_Quantity]
      ,t.[Kategori]
        			  ,f.[file_type]
        			  ,f.[file_path]
        			  ,f.[file_name]
        			  ,f.[file_ext]
        			  ,f.[file_blob]
        			  ,f.[file_size]
        			from #temp t
        			left join (
        select fTemp.* from [tbl_brand_Mitra_binaan_File] fTemp
        inner join (
        select MAX(created) as created, [Mitra_binaan_id]  from [dbo].[tbl_brand_Mitra_binaan_File]
        group by [Mitra_binaan_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[Mitra_binaan_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp  
";

            }

            context.AddParameter("@Kategori", category.Length == 0 ? null : category);
            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.AddParameter("@totalRecords", 0, System.Data.ParameterDirection.Output);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Dto.Cstm.tbl_brand_Mitra_binaan>(context, new Dto.Cstm.tbl_brand_Mitra_binaan(), out totalRecords);
        }

    }
}
