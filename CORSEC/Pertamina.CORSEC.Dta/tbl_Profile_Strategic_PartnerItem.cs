
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Profile_Strategic_Partner]
    /// </summary>    
    public partial class tbl_Profile_Strategic_PartnerItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Profile_Strategic_Partner]
        /// </summary>        
        public static tbl_Profile_Strategic_Partner Insert(tbl_Profile_Strategic_Partner obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Profile_Strategic_Partner]([title], [body], [created], [created_by], [tab_text]) 
VALUES      (@title, @body, @created, @created_by, @tab_text)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, created, created_by, updated, updated_by, tab_text
FROM    [tbl_Profile_Strategic_Partner]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@tab_text", string.Format("{0}", obj.tab_text));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Strategic_Partner>(context, new tbl_Profile_Strategic_Partner()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Profile_Strategic_Partner]
        /// </summary>        
        public static tbl_Profile_Strategic_Partner Update(tbl_Profile_Strategic_Partner obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Profile_Strategic_Partner]
SET         [title] = @title,
            [body] = @body,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [tab_text] = @tab_text
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, created, created_by, updated, updated_by, tab_text 
FROM    [tbl_Profile_Strategic_Partner]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@tab_text", string.Format("{0}", obj.tab_text));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Strategic_Partner>(context, new tbl_Profile_Strategic_Partner()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Profile_Strategic_Partner]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Profile_Strategic_Partner 
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
        /// Get Total records from [tbl_Profile_Strategic_Partner]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Profile_Strategic_Partner";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Profile_Strategic_Partner]
        /// </summary>        
        public static List<tbl_Profile_Strategic_Partner> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, created, created_by, updated, updated_by, tab_text FROM tbl_Profile_Strategic_Partner";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Strategic_Partner>(context, new tbl_Profile_Strategic_Partner());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Profile_Strategic_Partner]
        /// </summary>        
        public static List<tbl_Profile_Strategic_Partner> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Profile_Strategic_Partner] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Profile_Strategic_Partner].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Profile_Strategic_Partner].*
                FROM    [tbl_Profile_Strategic_Partner]
            )

            SELECT      [Paging_tbl_Profile_Strategic_Partner].*
            FROM        [Paging_tbl_Profile_Strategic_Partner]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Profile_Strategic_Partner>(context, new tbl_Profile_Strategic_Partner());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Profile_Strategic_Partner] by Primary Key
        /// </summary>        
        public static tbl_Profile_Strategic_Partner GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, created, created_by, updated, updated_by, tab_text FROM tbl_Profile_Strategic_Partner
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Strategic_Partner>(context, new tbl_Profile_Strategic_Partner()).FirstOrDefault();
        }

        #endregion

    }
}