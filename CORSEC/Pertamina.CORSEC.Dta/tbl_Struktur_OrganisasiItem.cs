
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Struktur_Organisasi]
    /// </summary>    
    public partial class tbl_Struktur_OrganisasiItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Struktur_Organisasi]
        /// </summary>        
        public static tbl_Struktur_Organisasi Insert(tbl_Struktur_Organisasi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Struktur_Organisasi]([title], [sub_title], [body], [root_text], [created], [created_by]) 
VALUES      (@title, @sub_title, @body, @root_text, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, sub_title, body, root_text, created, created_by, updated, updated_by
FROM    [tbl_Struktur_Organisasi]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@sub_title", string.Format("{0}", obj.sub_title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@root_text", string.Format("{0}", obj.root_text));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi>(context, new tbl_Struktur_Organisasi()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Struktur_Organisasi]
        /// </summary>        
        public static tbl_Struktur_Organisasi Update(tbl_Struktur_Organisasi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Struktur_Organisasi]
SET         [title] = @title,
            [sub_title] = @sub_title,
            [body] = @body,
            [root_text] = @root_text,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, sub_title, body, root_text, created, created_by, updated, updated_by 
FROM    [tbl_Struktur_Organisasi]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@sub_title", string.Format("{0}", obj.sub_title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@root_text", string.Format("{0}", obj.root_text));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi>(context, new tbl_Struktur_Organisasi()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Struktur_Organisasi]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Struktur_Organisasi 
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
        /// Get Total records from [tbl_Struktur_Organisasi]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Struktur_Organisasi";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Struktur_Organisasi]
        /// </summary>        
        public static List<tbl_Struktur_Organisasi> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, sub_title, body, root_text, created, created_by, updated, updated_by FROM tbl_Struktur_Organisasi";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi>(context, new tbl_Struktur_Organisasi());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Struktur_Organisasi]
        /// </summary>        
        public static List<tbl_Struktur_Organisasi> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Struktur_Organisasi] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Struktur_Organisasi].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Struktur_Organisasi].*
                FROM    [tbl_Struktur_Organisasi]
            )

            SELECT      [Paging_tbl_Struktur_Organisasi].*
            FROM        [Paging_tbl_Struktur_Organisasi]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi>(context, new tbl_Struktur_Organisasi());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Struktur_Organisasi] by Primary Key
        /// </summary>        
        public static tbl_Struktur_Organisasi GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, sub_title, body, root_text, created, created_by, updated, updated_by FROM tbl_Struktur_Organisasi
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi>(context, new tbl_Struktur_Organisasi()).FirstOrDefault();
        }

        #endregion

    }
}