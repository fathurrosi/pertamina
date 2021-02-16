
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Design_Grafis_File]
    /// </summary>    
    public partial class tbl_Design_Grafis_FileItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Design_Grafis_File]
        /// </summary>        
        public static tbl_Design_Grafis_File Insert(tbl_Design_Grafis_File obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Design_Grafis_File]([title], [body], [created], [created_by], [design_grafis_id], [file_type], [file_path], [file_name], [file_ext], [file_blob], [file_size]) 
VALUES      (@title, @body, @created, @created_by, @design_grafis_id, @file_type, @file_path, @file_name, @file_ext, @file_blob, @file_size)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, created, created_by, updated, updated_by, design_grafis_id, file_type, file_path, file_name, file_ext, file_blob, file_size
FROM    [tbl_Design_Grafis_File]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@design_grafis_id", obj.design_grafis_id);
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_File>(context, new tbl_Design_Grafis_File()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Design_Grafis_File]
        /// </summary>        
        public static tbl_Design_Grafis_File Update(tbl_Design_Grafis_File obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Design_Grafis_File]
SET         [title] = @title,
            [body] = @body,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [design_grafis_id] = @design_grafis_id,
            [file_type] = @file_type,
            [file_path] = @file_path,
            [file_name] = @file_name,
            [file_ext] = @file_ext,
            [file_blob] = @file_blob,
            [file_size] = @file_size
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, created, created_by, updated, updated_by, design_grafis_id, file_type, file_path, file_name, file_ext, file_blob, file_size 
FROM    [tbl_Design_Grafis_File]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@design_grafis_id", obj.design_grafis_id);
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_File>(context, new tbl_Design_Grafis_File()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Design_Grafis_File]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Design_Grafis_File 
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
        /// Get Total records from [tbl_Design_Grafis_File]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Design_Grafis_File";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Design_Grafis_File]
        /// </summary>        
        public static List<tbl_Design_Grafis_File> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, created, created_by, updated, updated_by, design_grafis_id, file_type, file_path, file_name, file_ext, file_blob, file_size FROM tbl_Design_Grafis_File";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_File>(context, new tbl_Design_Grafis_File());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Design_Grafis_File]
        /// </summary>        
        public static List<tbl_Design_Grafis_File> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Design_Grafis_File] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Design_Grafis_File].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Design_Grafis_File].*
                FROM    [tbl_Design_Grafis_File]
            )

            SELECT      [Paging_tbl_Design_Grafis_File].*
            FROM        [Paging_tbl_Design_Grafis_File]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_File>(context, new tbl_Design_Grafis_File());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Design_Grafis_File] by Primary Key
        /// </summary>        
        public static tbl_Design_Grafis_File GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, created, created_by, updated, updated_by, design_grafis_id, file_type, file_path, file_name, file_ext, file_blob, file_size FROM tbl_Design_Grafis_File
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_File>(context, new tbl_Design_Grafis_File()).FirstOrDefault();
        }

        #endregion

    }
}