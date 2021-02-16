
using System.Collections.Generic;
using DataAccessLayer;
using System.Linq;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_productItem
    {
        public static List<Dto.Cstm.tbl_product> GetWishlist(string username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"

select  ROW_NUMBER() OVER (ORDER BY t1.[id] DESC) AS PAGING_ROW_NUMBER, t1.*
,t3.[file_type]
,t3.[file_path]
,t3.[file_name]
,t3.[file_ext]
,t3.[file_blob]
,t3.[file_size] 
 from tbl_product_wishlist wl
inner join  [tbl_product] t1 on t1.id = wl.product_id
left join tbl_product_File t3 on t1.id= t3.product_id
inner join (
select max(created) created, product_id hub_id from tbl_product_File
group by product_id
) t2 on t2.hub_id = t1.id and t2.created = t3.created

where wl.Username =@Username 
";
            context.AddParameter("@Username", username);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper(context, new Dto.Cstm.tbl_product());
        }


        public static Dto.Cstm.tbl_product GetByID(int id)
        {

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
        
select  ROW_NUMBER() OVER (ORDER BY t1.[id] DESC) AS PAGING_ROW_NUMBER, t1.*
,t3.[file_type]
,t3.[file_path]
,t3.[file_name]
,t3.[file_ext]
,t3.[file_blob]
,t3.[file_size] from tbl_product t1
left join tbl_product_File t3 on t1.id= t3.product_id
inner join (
select max(created) created, product_id hub_id from tbl_product_File
group by product_id
) t2 on t2.hub_id = t1.id and t2.created = t3.created

where t1.id=@id
";



            context.AddParameter("@id", id);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper(context, new Dto.Cstm.tbl_product()).FirstOrDefault();
        }


        public static List<Dto.Cstm.tbl_product> GetPagingCustom(int PageIndex, int PageSize, string category, int product_type, int sort, out int totalRecords)
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
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_product].[id] DESC) AS PAGING_ROW_NUMBER,
                    [tbl_product].*
            into	#temp
            FROM    [tbl_product]
            where product_type=@product_type AND ( Kategori=@Kategori OR @Kategori is null )
            

           SELECT @totalRecords = COUNT(*)  FROM #temp ; 

        			select t.*
        			  ,f.[file_type]
        			  ,f.[file_path]
        			  ,f.[file_name]
        			  ,f.[file_ext]
        			  ,f.[file_blob]
        			  ,f.[file_size]
        			from #temp t
        			left join (
        select fTemp.* from [tbl_product_File] fTemp
        inner join (
        select MAX(created) as created, [product_id]  from [dbo].[tbl_product_File]
        group by [product_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[product_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp  
";
            if (sort == 2)
            {
                sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_product].[title]  DESC) AS PAGING_ROW_NUMBER,
                    [tbl_product].*
            into	#temp
            FROM    [tbl_product]
            where product_type=@product_type AND ( Kategori=@Kategori OR @Kategori is null )

            SELECT @totalRecords = COUNT(*)  FROM #temp ; 

        			select t.*
        			  ,f.[file_type]
        			  ,f.[file_path]
        			  ,f.[file_name]
        			  ,f.[file_ext]
        			  ,f.[file_blob]
        			  ,f.[file_size]
        			from #temp t
        			left join (
        select fTemp.* from [tbl_product_File] fTemp
        inner join (
        select MAX(created) as created, [product_id]  from [dbo].[tbl_product_File]
        group by [product_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[product_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp  
";

            }
            else if (sort == 3)
            {
                sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_product].[title]  DESC) AS PAGING_ROW_NUMBER,
                    [tbl_product].*
            into	#temp
            FROM    [tbl_product]
            where product_type=@product_type AND ( Kategori=@Kategori OR @Kategori is null )

            SELECT @totalRecords = COUNT(*)  FROM #temp ; 

        			select t.*
        			  ,f.[file_type]
        			  ,f.[file_path]
        			  ,f.[file_name]
        			  ,f.[file_ext]
        			  ,f.[file_blob]
        			  ,f.[file_size]
        			from #temp t
        			left join (
        select fTemp.* from [tbl_product_File] fTemp
        inner join (
        select MAX(created) as created, [product_id]  from [dbo].[tbl_product_File]
        group by [product_id]) tTemp on fTemp.created = tTemp.created 
        ) f on f.[product_id]= t.id
        
        WHERE t.PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

		drop table #temp  
";

            }

            context.AddParameter("@Kategori", category.Length == 0 ? null : category);
            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.AddParameter("@product_type", product_type);
            context.AddParameter("@totalRecords", 0, System.Data.ParameterDirection.Output);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Dto.Cstm.tbl_product>(context, new Dto.Cstm.tbl_product(), out totalRecords);
        }


        /// <summary>
        /// Get All records from TABLE [tbl_product]
        /// </summary>        
        public static List<tbl_product> GetByProduct_Type(int product_type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT * FROM tbl_product where product_type=@product_type";
            context.CommandText = sqlQuery;
            context.AddParameter("@product_type", product_type);
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_product>(context, new tbl_product());
        }


        public static int GetCount(int PageSize, int PageIndex, int product_type)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_product where product_type=@product_type";
            context.CommandText = sqlQuery;

            context.AddParameter("@product_type", product_type);
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
        }

        /// Get All records from TABLE [tbl_product]
        /// </summary>        
        public static List<tbl_product> GetPaging(int PageSize, int PageIndex, int product_type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_product] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_product].[id] DESC) AS PAGING_ROW_NUMBER,
                        [tbl_product].*
                FROM    [tbl_product]
                WHERE product_type=@product_type
            )

            SELECT      [Paging_tbl_product].*
            FROM        [Paging_tbl_product]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.AddParameter("@product_type", product_type);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_product>(context, new tbl_product());
        }

    }
}
