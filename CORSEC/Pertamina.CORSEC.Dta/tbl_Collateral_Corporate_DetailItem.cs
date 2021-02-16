
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Collateral_Corporate_Detail]
    /// </summary>    
    public partial class tbl_Collateral_Corporate_DetailItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Collateral_Corporate_Detail]
        /// </summary>        
        public static tbl_Collateral_Corporate_Detail Insert(tbl_Collateral_Corporate_Detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Collateral_Corporate_Detail]([title], [body], [seq], [created], [created_by], [category]) 
VALUES      (@title, @body, @seq, @created, @created_by, @category)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, seq, created, created_by, updated, updated_by, category
FROM    [tbl_Collateral_Corporate_Detail]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@seq", obj.seq);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@category", string.Format("{0}", obj.category));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Detail>(context, new tbl_Collateral_Corporate_Detail()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Collateral_Corporate_Detail]
        /// </summary>        
        public static tbl_Collateral_Corporate_Detail Update(tbl_Collateral_Corporate_Detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Collateral_Corporate_Detail]
SET         [title] = @title,
            [body] = @body,
            [seq] = @seq,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [category] = @category
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, seq, created, created_by, updated, updated_by, category 
FROM    [tbl_Collateral_Corporate_Detail]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@seq", obj.seq);
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@category", string.Format("{0}", obj.category));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Detail>(context, new tbl_Collateral_Corporate_Detail()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Collateral_Corporate_Detail]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Collateral_Corporate_Detail 
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
        /// Get Total records from [tbl_Collateral_Corporate_Detail]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Collateral_Corporate_Detail";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Collateral_Corporate_Detail]
        /// </summary>        
        public static List<tbl_Collateral_Corporate_Detail> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, seq, created, created_by, updated, updated_by, category FROM tbl_Collateral_Corporate_Detail";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Detail>(context, new tbl_Collateral_Corporate_Detail());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Collateral_Corporate_Detail]
        /// </summary>        
        public static List<tbl_Collateral_Corporate_Detail> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Collateral_Corporate_Detail] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Collateral_Corporate_Detail].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Collateral_Corporate_Detail].*
                FROM    [tbl_Collateral_Corporate_Detail]
            )

            SELECT      [Paging_tbl_Collateral_Corporate_Detail].*
            FROM        [Paging_tbl_Collateral_Corporate_Detail]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Detail>(context, new tbl_Collateral_Corporate_Detail());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Collateral_Corporate_Detail] by Primary Key
        /// </summary>        
        public static tbl_Collateral_Corporate_Detail GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, seq, created, created_by, updated, updated_by, category FROM tbl_Collateral_Corporate_Detail
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Detail>(context, new tbl_Collateral_Corporate_Detail()).FirstOrDefault();
        }

        #endregion

    }
}