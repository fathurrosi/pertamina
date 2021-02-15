using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_brand_Mitra_binaan_relatedItem
    {
        public static void InsertAll(int parentId, List<int> children)
        {
            IDBHelper context = new DBHelper();
            try
            {
                context.BeginTransaction();

                string sqlQuery = @"
         
Delete from [tbl_brand_Mitra_binaan_related]
           Where Mitra_binaan_parent_id=@Mitra_binaan_parent_id

 
";
                context.AddParameter("@Mitra_binaan_parent_id", parentId);
                context.CommandType = System.Data.CommandType.Text;
                context.CommandText = sqlQuery;
                DBUtil.ExecuteNonQuery(context);

                foreach (int child in children)
                {
                    sqlQuery = @"
         
INSERT INTO [tbl_brand_Mitra_binaan_related]
           ([Mitra_binaan_id]
           ,[Mitra_binaan_parent_id])
     VALUES
           (@Mitra_binaan_id
           ,@Mitra_binaan_parent_id)

 
";
                    context.Clear();
                    context.AddParameter("@Mitra_binaan_id", child);
                    context.AddParameter("@Mitra_binaan_parent_id", parentId);
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
        public static List<Dto.Cstm.tbl_brand_Mitra_binaan_related> GetMerchandiseHub_ByRelated(int Mitra_binaan_parent_id)
        {

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
         
 SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Mitra_binaan].[id]) AS PAGING_ROW_NUMBER
      ,[tbl_brand_Mitra_binaan_related].[id]
      ,[tbl_brand_Mitra_binaan].[title]
      ,[tbl_brand_Mitra_binaan].[body]
      ,[tbl_brand_Mitra_binaan].[created]
      ,[tbl_brand_Mitra_binaan].[created_by]
      ,[tbl_brand_Mitra_binaan].[updated]
      ,[tbl_brand_Mitra_binaan].[updated_by]
      ,[tbl_brand_Mitra_binaan].[SKU]
      ,[tbl_brand_Mitra_binaan].[Estimasi_Harga_Mulai]
      ,[tbl_brand_Mitra_binaan].[Estimasi_Harga_Hingga]
      ,[tbl_brand_Mitra_binaan].[Min_Quantity]
      ,[tbl_brand_Mitra_binaan].[Kategori]
      ,tbl_brand_Mitra_binaan_related.Mitra_binaan_parent_id
      ,tbl_brand_Mitra_binaan_related.Mitra_binaan_id
            into	#temp
            FROM    tbl_brand_Mitra_binaan_related
			inner join tbl_brand_Mitra_binaan on tbl_brand_Mitra_binaan.id =tbl_brand_Mitra_binaan_related.Mitra_binaan_id
            where Mitra_binaan_parent_id = @Mitra_binaan_parent_id
            
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
      ,t.[Kategori], t.Mitra_binaan_parent_id , t.Mitra_binaan_id
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
        ) f on f.[Mitra_binaan_id]= t.Mitra_binaan_id
        
        

		drop table #temp  
";


            context.AddParameter("@Mitra_binaan_parent_id", Mitra_binaan_parent_id);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Dto.Cstm.tbl_brand_Mitra_binaan_related>(context, new Dto.Cstm.tbl_brand_Mitra_binaan_related());
        }

    }
}
