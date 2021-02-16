
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Media]
    /// </summary>    
    public partial class tbl_MediaItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Media]
        /// </summary>        
        public static tbl_Media Insert(tbl_Media obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Media]([title], [body], [created], [created_by], [infographic_type], [infographic_year], [img_type], [img_path], [img_name], [img_ext], [img_blob], [img_size]) 
VALUES      (@title, @body, @created, @created_by, @infographic_type, @infographic_year, @img_type, @img_path, @img_name, @img_ext, @img_blob, @img_size)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, created, created_by, updated, updated_by, infographic_type, infographic_year, img_type, img_path, img_name, img_ext, img_blob, img_size
FROM    [tbl_Media]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@infographic_type", obj.infographic_type);
            context.AddParameter("@infographic_year", obj.infographic_year);
            context.AddParameter("@img_type", string.Format("{0}", obj.img_type));
            context.AddParameter("@img_path", string.Format("{0}", obj.img_path));
            context.AddParameter("@img_name", string.Format("{0}", obj.img_name));
            context.AddParameter("@img_ext", string.Format("{0}", obj.img_ext));
            context.AddParameter("@img_blob", obj.img_blob, System.Data.DbType.Binary);
            context.AddParameter("@img_size", string.Format("{0}", obj.img_size));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Media>(context, new tbl_Media()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Media]
        /// </summary>        
        public static tbl_Media Update(tbl_Media obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Media]
SET         [title] = @title,
            [body] = @body,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [infographic_type] = @infographic_type,
            [infographic_year] = @infographic_year,
            [img_type] = @img_type,
            [img_path] = @img_path,
            [img_name] = @img_name,
            [img_ext] = @img_ext,
            [img_blob] = @img_blob,
            [img_size] = @img_size
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, created, created_by, updated, updated_by, infographic_type, infographic_year, img_type, img_path, img_name, img_ext, img_blob, img_size 
FROM    [tbl_Media]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@infographic_type", obj.infographic_type);
            context.AddParameter("@infographic_year", obj.infographic_year);
            context.AddParameter("@img_type", string.Format("{0}", obj.img_type));
            context.AddParameter("@img_path", string.Format("{0}", obj.img_path));
            context.AddParameter("@img_name", string.Format("{0}", obj.img_name));
            context.AddParameter("@img_ext", string.Format("{0}", obj.img_ext));
            context.AddParameter("@img_blob", obj.img_blob, System.Data.DbType.Binary);
            context.AddParameter("@img_size", string.Format("{0}", obj.img_size));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Media>(context, new tbl_Media()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Media]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Media 
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
        /// Get Total records from [tbl_Media]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Media";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Media]
        /// </summary>        
        public static List<tbl_Media> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, created, created_by, updated, updated_by, infographic_type, infographic_year, img_type, img_path, img_name, img_ext, img_blob, img_size FROM tbl_Media";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Media>(context, new tbl_Media());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Media]
        /// </summary>        
        public static List<tbl_Media> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Media] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Media].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Media].*
                FROM    [tbl_Media]
            )

            SELECT      [Paging_tbl_Media].*
            FROM        [Paging_tbl_Media]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Media>(context, new tbl_Media());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Media] by Primary Key
        /// </summary>        
        public static tbl_Media GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, created, created_by, updated, updated_by, infographic_type, infographic_year, img_type, img_path, img_name, img_ext, img_blob, img_size FROM tbl_Media
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Media>(context, new tbl_Media()).FirstOrDefault();
        }

        #endregion

    }
}