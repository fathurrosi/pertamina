
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_brand_Mitra_binaan]
    /// </summary>    
    public partial class tbl_brand_Mitra_binaanItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_brand_Mitra_binaan]
        /// </summary>        
        public static tbl_brand_Mitra_binaan Insert(tbl_brand_Mitra_binaan obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_brand_Mitra_binaan]([title], [body], [created], [created_by], [SKU], [Estimasi_Harga_Mulai], [Estimasi_Harga_Hingga], [Min_Quantity], [Kategori]) 
VALUES      (@title, @body, @created, @created_by, @SKU, @Estimasi_Harga_Mulai, @Estimasi_Harga_Hingga, @Min_Quantity, @Kategori)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, created, created_by, updated, updated_by, SKU, Estimasi_Harga_Mulai, Estimasi_Harga_Hingga, Min_Quantity, Kategori
FROM    [tbl_brand_Mitra_binaan]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@SKU", string.Format("{0}", obj.SKU));
            context.AddParameter("@Estimasi_Harga_Mulai", obj.Estimasi_Harga_Mulai);
            context.AddParameter("@Estimasi_Harga_Hingga", obj.Estimasi_Harga_Hingga);
            context.AddParameter("@Min_Quantity", obj.Min_Quantity);
            context.AddParameter("@Kategori", string.Format("{0}", obj.Kategori));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Mitra_binaan>(context, new tbl_brand_Mitra_binaan()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_brand_Mitra_binaan]
        /// </summary>        
        public static tbl_brand_Mitra_binaan Update(tbl_brand_Mitra_binaan obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_brand_Mitra_binaan]
SET         [title] = @title,
            [body] = @body,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [SKU] = @SKU,
            [Estimasi_Harga_Mulai] = @Estimasi_Harga_Mulai,
            [Estimasi_Harga_Hingga] = @Estimasi_Harga_Hingga,
            [Min_Quantity] = @Min_Quantity,
            [Kategori] = @Kategori
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, created, created_by, updated, updated_by, SKU, Estimasi_Harga_Mulai, Estimasi_Harga_Hingga, Min_Quantity, Kategori 
FROM    [tbl_brand_Mitra_binaan]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@SKU", string.Format("{0}", obj.SKU));
            context.AddParameter("@Estimasi_Harga_Mulai", obj.Estimasi_Harga_Mulai);
            context.AddParameter("@Estimasi_Harga_Hingga", obj.Estimasi_Harga_Hingga);
            context.AddParameter("@Min_Quantity", obj.Min_Quantity);
            context.AddParameter("@Kategori", string.Format("{0}", obj.Kategori));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Mitra_binaan>(context, new tbl_brand_Mitra_binaan()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_brand_Mitra_binaan]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_brand_Mitra_binaan 
WHERE   [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_brand_Mitra_binaan]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_brand_Mitra_binaan";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_Mitra_binaan]
        /// </summary>        
        public static List<tbl_brand_Mitra_binaan> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, created, created_by, updated, updated_by, SKU, Estimasi_Harga_Mulai, Estimasi_Harga_Hingga, Min_Quantity, Kategori FROM tbl_brand_Mitra_binaan";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Mitra_binaan>(context, new tbl_brand_Mitra_binaan());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_Mitra_binaan]
        /// </summary>        
        public static List<tbl_brand_Mitra_binaan> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_brand_Mitra_binaan] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Mitra_binaan].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_brand_Mitra_binaan].*
                FROM    [tbl_brand_Mitra_binaan]
            )

            SELECT      [Paging_tbl_brand_Mitra_binaan].*
            FROM        [Paging_tbl_brand_Mitra_binaan]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_brand_Mitra_binaan>(context, new tbl_brand_Mitra_binaan());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_brand_Mitra_binaan] by Primary Key
        /// </summary>        
        public static tbl_brand_Mitra_binaan GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, created, created_by, updated, updated_by, SKU, Estimasi_Harga_Mulai, Estimasi_Harga_Hingga, Min_Quantity, Kategori FROM tbl_brand_Mitra_binaan
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Mitra_binaan>(context, new tbl_brand_Mitra_binaan()).FirstOrDefault();
        }

        #endregion

    }
}