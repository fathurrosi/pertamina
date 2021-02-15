
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Berita_Artikel]
    /// </summary>    
    public partial class tbl_Berita_ArtikelItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Berita_Artikel]
        /// </summary>        
        public static tbl_Berita_Artikel Insert(tbl_Berita_Artikel obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Berita_Artikel]([title], [body], [created], [created_by]) 
VALUES      (@title, @body, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, created, created_by, updated, updated_by
FROM    [tbl_Berita_Artikel]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Berita_Artikel>(context, new tbl_Berita_Artikel()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Berita_Artikel]
        /// </summary>        
        public static tbl_Berita_Artikel Update(tbl_Berita_Artikel obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Berita_Artikel]
SET         [title] = @title,
            [body] = @body,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, created, created_by, updated, updated_by 
FROM    [tbl_Berita_Artikel]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Berita_Artikel>(context, new tbl_Berita_Artikel()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Berita_Artikel]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Berita_Artikel 
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
        /// Get Total records from [tbl_Berita_Artikel]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Berita_Artikel";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Berita_Artikel]
        /// </summary>        
        public static List<tbl_Berita_Artikel> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, created, created_by, updated, updated_by FROM tbl_Berita_Artikel";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Berita_Artikel>(context, new tbl_Berita_Artikel());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Berita_Artikel]
        /// </summary>        
        public static List<tbl_Berita_Artikel> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Berita_Artikel] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Berita_Artikel].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Berita_Artikel].*
                FROM    [tbl_Berita_Artikel]
            )

            SELECT      [Paging_tbl_Berita_Artikel].*
            FROM        [Paging_tbl_Berita_Artikel]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Berita_Artikel>(context, new tbl_Berita_Artikel());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Berita_Artikel] by Primary Key
        /// </summary>        
        public static tbl_Berita_Artikel GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, created, created_by, updated, updated_by FROM tbl_Berita_Artikel
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Berita_Artikel>(context, new tbl_Berita_Artikel()).FirstOrDefault();
        }

        #endregion

    }
}