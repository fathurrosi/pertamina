
using System.Collections.Generic;
using DataAccessLayer;
using System.Linq;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_brand_Merchandise_hubItem
    {
        public static List<Dto.Cstm.tbl_brand_Merchandise_hub> GetWishlist(string username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"

select  ROW_NUMBER() OVER (ORDER BY t1.[id]) AS PAGING_ROW_NUMBER, t1.*
,t3.[file_type]
,t3.[file_path]
,t3.[file_name]
,t3.[file_ext]
,t3.[file_blob]
,t3.[file_size] 
 from tbl_brand_Merchandise_hub_wishlist wl
inner join  [tbl_brand_Merchandise_hub] t1 on t1.id = wl.Merchandise_hub_id
left join tbl_brand_Merchandise_hub_File t3 on t1.id= t3.Merchandise_hub_id
inner join (
select max(created) created, Merchandise_hub_id hub_id from tbl_brand_Merchandise_hub_File
group by Merchandise_hub_id
) t2 on t2.hub_id = t1.id and t2.created = t3.created

where wl.Username =@Username 
";
            context.AddParameter("@Username", username);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper(context, new Dto.Cstm.tbl_brand_Merchandise_hub());
        }


        public static Dto.Cstm.tbl_brand_Merchandise_hub GetByID(int id)
        {

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
        
select  ROW_NUMBER() OVER (ORDER BY t1.[id]) AS PAGING_ROW_NUMBER, t1.*
,t3.[file_type]
,t3.[file_path]
,t3.[file_name]
,t3.[file_ext]
,t3.[file_blob]
,t3.[file_size] from tbl_brand_Merchandise_hub t1
left join tbl_brand_Merchandise_hub_File t3 on t1.id= t3.Merchandise_hub_id
inner join (
select max(created) created, Merchandise_hub_id hub_id from tbl_brand_Merchandise_hub_File
group by Merchandise_hub_id
) t2 on t2.hub_id = t1.id and t2.created = t3.created

where t1.id=@id
";



            context.AddParameter("@id", id);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper(context, new Dto.Cstm.tbl_brand_Merchandise_hub()).FirstOrDefault();
        }


        public static List<Dto.Cstm.tbl_brand_Merchandise_hub> GetPagingCustom(int PageIndex, int PageSize, string category, int sort, out int totalRecords)
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
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Merchandise_hub].[id]) AS PAGING_ROW_NUMBER,
                    [tbl_brand_Merchandise_hub].*
            into	#temp
            FROM    [tbl_brand_Merchandise_hub]
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
        select fTemp.* from [tbl_brand_Merchandise_hub_File] fTemp
        inner join (
        select MAX(created) as created, [Merchandise_hub_id]  from [dbo].[tbl_brand_Merchandise_hub_File]
        group by [Merchandise_hub_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[Merchandise_hub_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp  
";
            if (sort == 2)
            {
                sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Merchandise_hub].[title] asc) AS PAGING_ROW_NUMBER,
                    [tbl_brand_Merchandise_hub].*
            into	#temp
            FROM    [tbl_brand_Merchandise_hub]
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
        select fTemp.* from [tbl_brand_Merchandise_hub_File] fTemp
        inner join (
        select MAX(created) as created, [Merchandise_hub_id]  from [dbo].[tbl_brand_Merchandise_hub_File]
        group by [Merchandise_hub_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[Merchandise_hub_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp  
";

            }
            else if (sort == 3)
            {
                sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Merchandise_hub].[title] desc) AS PAGING_ROW_NUMBER,
                    [tbl_brand_Merchandise_hub].*
            into	#temp
            FROM    [tbl_brand_Merchandise_hub]
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
        select fTemp.* from [tbl_brand_Merchandise_hub_File] fTemp
        inner join (
        select MAX(created) as created, [Merchandise_hub_id]  from [dbo].[tbl_brand_Merchandise_hub_File]
        group by [Merchandise_hub_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[Merchandise_hub_id]= t.id
        
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
            return DBUtil.ExecuteMapper<Dto.Cstm.tbl_brand_Merchandise_hub>(context, new Dto.Cstm.tbl_brand_Merchandise_hub(), out totalRecords);
        }

    }
}
