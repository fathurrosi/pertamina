
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_brand_Sponsorship_File]
    /// </summary>    
    public partial class tbl_brand_Sponsorship_FileItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_brand_Sponsorship_File]
        /// </summary>        
        public static tbl_brand_Sponsorship_File Insert(tbl_brand_Sponsorship_File obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_brand_Sponsorship_File]([file_type], [file_path], [file_name], [file_ext], [file_blob], [file_size], [created], [created_by], [sponsorship_id], [file_desc], [sponsorship_type]) 
VALUES      (@file_type, @file_path, @file_name, @file_ext, @file_blob, @file_size, @created, @created_by, @sponsorship_id, @file_desc, @sponsorship_type)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, file_type, file_path, file_name, file_ext, file_blob, file_size, created, created_by, sponsorship_id, file_desc, sponsorship_type
FROM    [tbl_brand_Sponsorship_File]
WHERE   [id]  = @_id";
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@sponsorship_id", obj.sponsorship_id);
            context.AddParameter("@file_desc", string.Format("{0}", obj.file_desc));
            context.AddParameter("@sponsorship_type", obj.sponsorship_type);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Sponsorship_File>(context, new tbl_brand_Sponsorship_File()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_brand_Sponsorship_File]
        /// </summary>        
        public static tbl_brand_Sponsorship_File Update(tbl_brand_Sponsorship_File obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_brand_Sponsorship_File]
SET         [file_type] = @file_type,
            [file_path] = @file_path,
            [file_name] = @file_name,
            [file_ext] = @file_ext,
            [file_blob] = @file_blob,
            [file_size] = @file_size,
            [sponsorship_id] = @sponsorship_id,
            [file_desc] = @file_desc,
            [sponsorship_type] = @sponsorship_type
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, file_type, file_path, file_name, file_ext, file_blob, file_size, created, created_by, sponsorship_id, file_desc, sponsorship_type 
FROM    [tbl_brand_Sponsorship_File]
WHERE   [id]  = @id";
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@sponsorship_id", obj.sponsorship_id);
            context.AddParameter("@file_desc", string.Format("{0}", obj.file_desc));
            context.AddParameter("@sponsorship_type", obj.sponsorship_type);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Sponsorship_File>(context, new tbl_brand_Sponsorship_File()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_brand_Sponsorship_File]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_brand_Sponsorship_File 
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
        /// Get Total records from [tbl_brand_Sponsorship_File]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_brand_Sponsorship_File";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_Sponsorship_File]
        /// </summary>        
        public static List<tbl_brand_Sponsorship_File> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, file_type, file_path, file_name, file_ext, file_blob, file_size, created, created_by, sponsorship_id, file_desc, sponsorship_type FROM tbl_brand_Sponsorship_File";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Sponsorship_File>(context, new tbl_brand_Sponsorship_File());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_Sponsorship_File]
        /// </summary>        
        public static List<tbl_brand_Sponsorship_File> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_brand_Sponsorship_File] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Sponsorship_File].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_brand_Sponsorship_File].*
                FROM    [tbl_brand_Sponsorship_File]
            )

            SELECT      [Paging_tbl_brand_Sponsorship_File].*
            FROM        [Paging_tbl_brand_Sponsorship_File]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_brand_Sponsorship_File>(context, new tbl_brand_Sponsorship_File());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_brand_Sponsorship_File] by Primary Key
        /// </summary>        
        public static tbl_brand_Sponsorship_File GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, file_type, file_path, file_name, file_ext, file_blob, file_size, created, created_by, sponsorship_id, file_desc, sponsorship_type FROM tbl_brand_Sponsorship_File
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Sponsorship_File>(context, new tbl_brand_Sponsorship_File()).FirstOrDefault();
        }

        #endregion

    }
}