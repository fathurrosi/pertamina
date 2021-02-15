
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Featured_Article]
    /// </summary>    
    public partial class tbl_Featured_ArticleItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Featured_Article]
        /// </summary>        
        public static tbl_Featured_Article Insert(tbl_Featured_Article obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Featured_Article]([title], [body], [created], [created_by], [youtube_code]) 
VALUES      (@title, @body, @created, @created_by, @youtube_code)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, created, created_by, updated, updated_by, youtube_code
FROM    [tbl_Featured_Article]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@youtube_code", string.Format("{0}", obj.youtube_code));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Featured_Article>(context, new tbl_Featured_Article()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Featured_Article]
        /// </summary>        
        public static tbl_Featured_Article Update(tbl_Featured_Article obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Featured_Article]
SET         [title] = @title,
            [body] = @body,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [youtube_code] = @youtube_code
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, created, created_by, updated, updated_by, youtube_code 
FROM    [tbl_Featured_Article]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@youtube_code", string.Format("{0}", obj.youtube_code));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Featured_Article>(context, new tbl_Featured_Article()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Featured_Article]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Featured_Article 
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
        /// Get Total records from [tbl_Featured_Article]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Featured_Article";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Featured_Article]
        /// </summary>        
        public static List<tbl_Featured_Article> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, created, created_by, updated, updated_by, youtube_code FROM tbl_Featured_Article";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Featured_Article>(context, new tbl_Featured_Article());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Featured_Article]
        /// </summary>        
        public static List<tbl_Featured_Article> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Featured_Article] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Featured_Article].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Featured_Article].*
                FROM    [tbl_Featured_Article]
            )

            SELECT      [Paging_tbl_Featured_Article].*
            FROM        [Paging_tbl_Featured_Article]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Featured_Article>(context, new tbl_Featured_Article());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Featured_Article] by Primary Key
        /// </summary>        
        public static tbl_Featured_Article GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, created, created_by, updated, updated_by, youtube_code FROM tbl_Featured_Article
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Featured_Article>(context, new tbl_Featured_Article()).FirstOrDefault();
        }

        #endregion

    }
}