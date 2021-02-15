
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_brand_Merchandise_hub_wishlist]
    /// </summary>    
    public partial class tbl_brand_Merchandise_hub_wishlistItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_brand_Merchandise_hub_wishlist]
        /// </summary>        
        public static tbl_brand_Merchandise_hub_wishlist Insert(tbl_brand_Merchandise_hub_wishlist obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_brand_Merchandise_hub_wishlist]([Merchandise_hub_id], [Username], [Created]) 
VALUES      (@Merchandise_hub_id, @Username, @Created)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, Merchandise_hub_id, Username, Created
FROM    [tbl_brand_Merchandise_hub_wishlist]
WHERE   [id]  = @_id";
            context.AddParameter("@Merchandise_hub_id", obj.Merchandise_hub_id);
            context.AddParameter("@Username", string.Format("{0}", obj.Username));
            context.AddParameter("@Created", obj.Created);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Merchandise_hub_wishlist>(context, new tbl_brand_Merchandise_hub_wishlist()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_brand_Merchandise_hub_wishlist]
        /// </summary>        
        public static tbl_brand_Merchandise_hub_wishlist Update(tbl_brand_Merchandise_hub_wishlist obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_brand_Merchandise_hub_wishlist]
SET         [Merchandise_hub_id] = @Merchandise_hub_id,
            [Username] = @Username,
            [Created] = @Created
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, Merchandise_hub_id, Username, Created 
FROM    [tbl_brand_Merchandise_hub_wishlist]
WHERE   [id]  = @id";
            context.AddParameter("@Merchandise_hub_id", obj.Merchandise_hub_id);
            context.AddParameter("@Username", string.Format("{0}", obj.Username));
            context.AddParameter("@Created", obj.Created);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Merchandise_hub_wishlist>(context, new tbl_brand_Merchandise_hub_wishlist()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_brand_Merchandise_hub_wishlist]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_brand_Merchandise_hub_wishlist 
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
        /// Get Total records from [tbl_brand_Merchandise_hub_wishlist]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_brand_Merchandise_hub_wishlist";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_Merchandise_hub_wishlist]
        /// </summary>        
        public static List<tbl_brand_Merchandise_hub_wishlist> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, Merchandise_hub_id, Username, Created FROM tbl_brand_Merchandise_hub_wishlist";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Merchandise_hub_wishlist>(context, new tbl_brand_Merchandise_hub_wishlist());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_Merchandise_hub_wishlist]
        /// </summary>        
        public static List<tbl_brand_Merchandise_hub_wishlist> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_brand_Merchandise_hub_wishlist] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Merchandise_hub_wishlist].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_brand_Merchandise_hub_wishlist].*
                FROM    [tbl_brand_Merchandise_hub_wishlist]
            )

            SELECT      [Paging_tbl_brand_Merchandise_hub_wishlist].*
            FROM        [Paging_tbl_brand_Merchandise_hub_wishlist]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_brand_Merchandise_hub_wishlist>(context, new tbl_brand_Merchandise_hub_wishlist());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_brand_Merchandise_hub_wishlist] by Primary Key
        /// </summary>        
        public static tbl_brand_Merchandise_hub_wishlist GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, Merchandise_hub_id, Username, Created FROM tbl_brand_Merchandise_hub_wishlist
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Merchandise_hub_wishlist>(context, new tbl_brand_Merchandise_hub_wishlist()).FirstOrDefault();
        }

        #endregion

    }
}