
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_brand_Mitra_binaan_related]
    /// </summary>    
    public partial class tbl_brand_Mitra_binaan_relatedItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_brand_Mitra_binaan_related]
        /// </summary>        
        public static tbl_brand_Mitra_binaan_related Insert(tbl_brand_Mitra_binaan_related obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_brand_Mitra_binaan_related]([Mitra_binaan_id], [Mitra_binaan_parent_id]) 
VALUES      (@Mitra_binaan_id, @Mitra_binaan_parent_id)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, Mitra_binaan_id, Mitra_binaan_parent_id
FROM    [tbl_brand_Mitra_binaan_related]
WHERE   [id]  = @_id";
            context.AddParameter("@Mitra_binaan_id", obj.Mitra_binaan_id);
            context.AddParameter("@Mitra_binaan_parent_id", obj.Mitra_binaan_parent_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Mitra_binaan_related>(context, new tbl_brand_Mitra_binaan_related()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_brand_Mitra_binaan_related]
        /// </summary>        
        public static tbl_brand_Mitra_binaan_related Update(tbl_brand_Mitra_binaan_related obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_brand_Mitra_binaan_related]
SET         [Mitra_binaan_id] = @Mitra_binaan_id,
            [Mitra_binaan_parent_id] = @Mitra_binaan_parent_id
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, Mitra_binaan_id, Mitra_binaan_parent_id 
FROM    [tbl_brand_Mitra_binaan_related]
WHERE   [id]  = @id";
            context.AddParameter("@Mitra_binaan_id", obj.Mitra_binaan_id);
            context.AddParameter("@Mitra_binaan_parent_id", obj.Mitra_binaan_parent_id);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Mitra_binaan_related>(context, new tbl_brand_Mitra_binaan_related()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_brand_Mitra_binaan_related]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_brand_Mitra_binaan_related 
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
        /// Get Total records from [tbl_brand_Mitra_binaan_related]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_brand_Mitra_binaan_related";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_Mitra_binaan_related]
        /// </summary>        
        public static List<tbl_brand_Mitra_binaan_related> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, Mitra_binaan_id, Mitra_binaan_parent_id FROM tbl_brand_Mitra_binaan_related";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Mitra_binaan_related>(context, new tbl_brand_Mitra_binaan_related());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_Mitra_binaan_related]
        /// </summary>        
        public static List<tbl_brand_Mitra_binaan_related> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_brand_Mitra_binaan_related] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Mitra_binaan_related].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_brand_Mitra_binaan_related].*
                FROM    [tbl_brand_Mitra_binaan_related]
            )

            SELECT      [Paging_tbl_brand_Mitra_binaan_related].*
            FROM        [Paging_tbl_brand_Mitra_binaan_related]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_brand_Mitra_binaan_related>(context, new tbl_brand_Mitra_binaan_related());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_brand_Mitra_binaan_related] by Primary Key
        /// </summary>        
        public static tbl_brand_Mitra_binaan_related GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, Mitra_binaan_id, Mitra_binaan_parent_id FROM tbl_brand_Mitra_binaan_related
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Mitra_binaan_related>(context, new tbl_brand_Mitra_binaan_related()).FirstOrDefault();
        }

        #endregion

    }
}