
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Collateral_Corporate]
    /// </summary>    
    public partial class tbl_Collateral_CorporateItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Collateral_Corporate]
        /// </summary>        
        public static tbl_Collateral_Corporate Insert(tbl_Collateral_Corporate obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Collateral_Corporate]([title], [sub_title], [body], [created], [created_by]) 
VALUES      (@title, @sub_title, @body, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, sub_title, body, created, created_by, updated, updated_by
FROM    [tbl_Collateral_Corporate]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@sub_title", string.Format("{0}", obj.sub_title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate>(context, new tbl_Collateral_Corporate()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Collateral_Corporate]
        /// </summary>        
        public static tbl_Collateral_Corporate Update(tbl_Collateral_Corporate obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Collateral_Corporate]
SET         [title] = @title,
            [sub_title] = @sub_title,
            [body] = @body,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, sub_title, body, created, created_by, updated, updated_by 
FROM    [tbl_Collateral_Corporate]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@sub_title", string.Format("{0}", obj.sub_title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate>(context, new tbl_Collateral_Corporate()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Collateral_Corporate]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Collateral_Corporate 
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
        /// Get Total records from [tbl_Collateral_Corporate]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Collateral_Corporate";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Collateral_Corporate]
        /// </summary>        
        public static List<tbl_Collateral_Corporate> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, sub_title, body, created, created_by, updated, updated_by FROM tbl_Collateral_Corporate";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate>(context, new tbl_Collateral_Corporate());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Collateral_Corporate]
        /// </summary>        
        public static List<tbl_Collateral_Corporate> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Collateral_Corporate] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Collateral_Corporate].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Collateral_Corporate].*
                FROM    [tbl_Collateral_Corporate]
            )

            SELECT      [Paging_tbl_Collateral_Corporate].*
            FROM        [Paging_tbl_Collateral_Corporate]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate>(context, new tbl_Collateral_Corporate());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Collateral_Corporate] by Primary Key
        /// </summary>        
        public static tbl_Collateral_Corporate GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, sub_title, body, created, created_by, updated, updated_by FROM tbl_Collateral_Corporate
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate>(context, new tbl_Collateral_Corporate()).FirstOrDefault();
        }

        #endregion

    }
}