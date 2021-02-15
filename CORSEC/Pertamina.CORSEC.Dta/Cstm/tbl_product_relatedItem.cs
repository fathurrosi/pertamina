using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_product_relatedItem
    {
        public static void InsertAll(int parentId, List<int> children)
        {
            IDBHelper context = new DBHelper();
            try
            {
                context.BeginTransaction();

                string sqlQuery = @"
         
Delete from [tbl_product_related]
           Where product_parent_id=@product_parent_id

 
";
                context.AddParameter("@product_parent_id", parentId);
                context.CommandType = System.Data.CommandType.Text;
                context.CommandText = sqlQuery;
                DBUtil.ExecuteNonQuery(context);

                foreach (int child in children)
                {
                    sqlQuery = @"
         
INSERT INTO [tbl_product_related]
           ([product_id]
           ,[product_parent_id])
     VALUES
           (@product_id
           ,@product_parent_id)

 
";
                    context.Clear();
                    context.AddParameter("@product_id", child);
                    context.AddParameter("@product_parent_id", parentId);
                    context.CommandType = System.Data.CommandType.Text;
                    context.CommandText = sqlQuery;
                    DBUtil.ExecuteNonQuery(context);
                }

                context.CommitTransaction();
            }
            catch (Exception)
            {
                context.RollbackTransaction();
            }

        }


        public static List<Dto.Cstm.tbl_product_related> GetMerchandiseHub_ByRelated(int product_parent_id)
        {

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
         
 SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_product].[id]) AS PAGING_ROW_NUMBER
      ,[tbl_product_related].[id]
      ,[tbl_product].[title]
      ,[tbl_product].[body]
      ,[tbl_product].[created]
      ,[tbl_product].[created_by]
      ,[tbl_product].[updated]
      ,[tbl_product].[updated_by]
      ,[tbl_product].[SKU]
      ,[tbl_product].[Estimasi_Harga_Mulai]
      ,[tbl_product].[Estimasi_Harga_Hingga]
      ,[tbl_product].[Min_Quantity]
      ,[tbl_product].[Kategori]
      ,tbl_product_related.product_parent_id
      ,tbl_product_related.product_id
            into	#temp
            FROM    tbl_product_related
			inner join tbl_product on tbl_product.id =tbl_product_related.product_id
            where product_parent_id = @product_parent_id
            
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
      ,t.[Kategori], t.product_parent_id , t.product_id
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
        ) f on f.[product_id]= t.product_id
        
        

		drop table #temp  
";


            context.AddParameter("@product_parent_id", product_parent_id);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Dto.Cstm.tbl_product_related>(context, new Dto.Cstm.tbl_product_related());
        }

    }
}
