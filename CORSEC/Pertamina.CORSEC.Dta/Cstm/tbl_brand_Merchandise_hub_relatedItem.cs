using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_brand_Merchandise_hub_relatedItem
    {
        public static void InsertAll(int parentId, List<int> children)
        {
            IDBHelper context = new DBHelper();
            try
            {
                context.BeginTransaction();

                string sqlQuery = @"
         
Delete from [tbl_brand_Merchandise_hub_related]
           Where Merchandise_hub_parent_id=@Merchandise_hub_parent_id

 
";
                context.AddParameter("@Merchandise_hub_parent_id", parentId);
                context.CommandType = System.Data.CommandType.Text;
                context.CommandText = sqlQuery;
                DBUtil.ExecuteNonQuery(context);

                foreach (int child in children)
                {
                    sqlQuery = @"
         
INSERT INTO [tbl_brand_Merchandise_hub_related]
           ([Merchandise_hub_id]
           ,[Merchandise_hub_parent_id])
     VALUES
           (@Merchandise_hub_id
           ,@Merchandise_hub_parent_id)

 
";
                    context.Clear();
                    context.AddParameter("@Merchandise_hub_id", child);
                    context.AddParameter("@Merchandise_hub_parent_id", parentId);
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
        public static List<Dto.Cstm.tbl_brand_Merchandise_hub_related> GetMerchandiseHub_ByRelated(int Merchandise_hub_parent_id)
        {

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
         
 SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Merchandise_hub].[id]) AS PAGING_ROW_NUMBER
      ,[tbl_brand_Merchandise_hub_related].[id]
      ,[tbl_brand_Merchandise_hub].[title]
      ,[tbl_brand_Merchandise_hub].[body]
      ,[tbl_brand_Merchandise_hub].[created]
      ,[tbl_brand_Merchandise_hub].[created_by]
      ,[tbl_brand_Merchandise_hub].[updated]
      ,[tbl_brand_Merchandise_hub].[updated_by]
      ,[tbl_brand_Merchandise_hub].[SKU]
      ,[tbl_brand_Merchandise_hub].[Estimasi_Harga_Mulai]
      ,[tbl_brand_Merchandise_hub].[Estimasi_Harga_Hingga]
      ,[tbl_brand_Merchandise_hub].[Min_Quantity]
      ,[tbl_brand_Merchandise_hub].[Kategori]
      ,tbl_brand_Merchandise_hub_related.Merchandise_hub_parent_id
      ,tbl_brand_Merchandise_hub_related.Merchandise_hub_id
            into	#temp
            FROM    tbl_brand_Merchandise_hub_related
			inner join tbl_brand_Merchandise_hub on tbl_brand_Merchandise_hub.id =tbl_brand_Merchandise_hub_related.Merchandise_hub_id
            where Merchandise_hub_parent_id = @Merchandise_hub_parent_id
            
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
      ,t.[Kategori], t.Merchandise_hub_parent_id , t.Merchandise_hub_id
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
        ) f on f.[Merchandise_hub_id]= t.Merchandise_hub_id
        
        

		drop table #temp  
";


            context.AddParameter("@Merchandise_hub_parent_id", Merchandise_hub_parent_id);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Dto.Cstm.tbl_brand_Merchandise_hub_related>(context, new Dto.Cstm.tbl_brand_Merchandise_hub_related());
        }

    }
}
