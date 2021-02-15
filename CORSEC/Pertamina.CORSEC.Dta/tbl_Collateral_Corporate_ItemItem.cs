
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Collateral_Corporate_Item]
    /// </summary>    
    public partial class tbl_Collateral_Corporate_ItemItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Collateral_Corporate_Item]
        /// </summary>        
        public static tbl_Collateral_Corporate_Item Insert(tbl_Collateral_Corporate_Item obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Collateral_Corporate_Item]([category], [title], [body], [year], [seq], [calender_type], [created], [created_by]) 
VALUES      (@category, @title, @body, @year, @seq, @calender_type, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, category, title, body, year, seq, calender_type, created, created_by, updated, updated_by
FROM    [tbl_Collateral_Corporate_Item]
WHERE   [id]  = @_id";
            context.AddParameter("@category", string.Format("{0}", obj.category));
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@year", obj.year);
            context.AddParameter("@seq", obj.seq);
            context.AddParameter("@calender_type", string.Format("{0}", obj.calender_type));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Item>(context, new tbl_Collateral_Corporate_Item()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Collateral_Corporate_Item]
        /// </summary>        
        public static tbl_Collateral_Corporate_Item Update(tbl_Collateral_Corporate_Item obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Collateral_Corporate_Item]
SET         [category] = @category,
            [title] = @title,
            [body] = @body,
            [year] = @year,
            [seq] = @seq,
            [calender_type] = @calender_type,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, category, title, body, year, seq, calender_type, created, created_by, updated, updated_by 
FROM    [tbl_Collateral_Corporate_Item]
WHERE   [id]  = @id";
            context.AddParameter("@category", string.Format("{0}", obj.category));
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@year", obj.year);
            context.AddParameter("@seq", obj.seq);
            context.AddParameter("@calender_type", string.Format("{0}", obj.calender_type));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Item>(context, new tbl_Collateral_Corporate_Item()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Collateral_Corporate_Item]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Collateral_Corporate_Item 
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
        /// Get Total records from [tbl_Collateral_Corporate_Item]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Collateral_Corporate_Item";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Collateral_Corporate_Item]
        /// </summary>        
        public static List<tbl_Collateral_Corporate_Item> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, category, title, body, year, seq, calender_type, created, created_by, updated, updated_by FROM tbl_Collateral_Corporate_Item";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Item>(context, new tbl_Collateral_Corporate_Item());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Collateral_Corporate_Item]
        /// </summary>        
        public static List<tbl_Collateral_Corporate_Item> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Collateral_Corporate_Item] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Collateral_Corporate_Item].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Collateral_Corporate_Item].*
                FROM    [tbl_Collateral_Corporate_Item]
            )

            SELECT      [Paging_tbl_Collateral_Corporate_Item].*
            FROM        [Paging_tbl_Collateral_Corporate_Item]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Item>(context, new tbl_Collateral_Corporate_Item());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Collateral_Corporate_Item] by Primary Key
        /// </summary>        
        public static tbl_Collateral_Corporate_Item GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, category, title, body, year, seq, calender_type, created, created_by, updated, updated_by FROM tbl_Collateral_Corporate_Item
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Item>(context, new tbl_Collateral_Corporate_Item()).FirstOrDefault();
        }

        #endregion

    }
}