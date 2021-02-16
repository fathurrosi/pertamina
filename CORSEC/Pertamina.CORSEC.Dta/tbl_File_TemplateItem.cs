
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_File_Template]
    /// </summary>    
    public partial class tbl_File_TemplateItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_File_Template]
        /// </summary>        
        public static tbl_File_Template Insert(tbl_File_Template obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_File_Template]([file_id], [ref_name], [ref_id], [file_type], [file_path], [file_name], [file_ext], [file_blob], [created], [created_by], [template_header], [template_title], [template_desc], [template_type], [file_size]) 
VALUES      (@file_id, @ref_name, @ref_id, @file_type, @file_path, @file_name, @file_ext, @file_blob, @created, @created_by, @template_header, @template_title, @template_desc, @template_type, @file_size)

SET @Err = @@Error

SELECT  file_id, ref_name, ref_id, file_type, file_path, file_name, file_ext, file_blob, created, created_by, template_header, template_title, template_desc, template_type, file_size
FROM    [tbl_File_Template]
WHERE   [file_id]  = @file_id";
            context.AddParameter("@file_id", string.Format("{0}", obj.file_id));
            context.AddParameter("@ref_name", string.Format("{0}", obj.ref_name));
            context.AddParameter("@ref_id", string.Format("{0}", obj.ref_id));
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@template_header", string.Format("{0}", obj.template_header));
            context.AddParameter("@template_title", string.Format("{0}", obj.template_title));
            context.AddParameter("@template_desc", string.Format("{0}", obj.template_desc));
            context.AddParameter("@template_type", obj.template_type);
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_File_Template>(context, new tbl_File_Template()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_File_Template]
        /// </summary>        
        public static tbl_File_Template Update(tbl_File_Template obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_File_Template]
SET         [ref_name] = @ref_name,
            [ref_id] = @ref_id,
            [file_type] = @file_type,
            [file_path] = @file_path,
            [file_name] = @file_name,
            [file_ext] = @file_ext,
            [file_blob] = @file_blob,
            [template_header] = @template_header,
            [template_title] = @template_title,
            [template_desc] = @template_desc,
            [template_type] = @template_type,
            [file_size] = @file_size
WHERE       [file_id]  = @file_id

SET @Err = @@Error

SELECT  file_id, ref_name, ref_id, file_type, file_path, file_name, file_ext, file_blob, created, created_by, template_header, template_title, template_desc, template_type, file_size 
FROM    [tbl_File_Template]
WHERE   [file_id]  = @file_id";
            context.AddParameter("@ref_name", string.Format("{0}", obj.ref_name));
            context.AddParameter("@ref_id", string.Format("{0}", obj.ref_id));
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@template_header", string.Format("{0}", obj.template_header));
            context.AddParameter("@template_title", string.Format("{0}", obj.template_title));
            context.AddParameter("@template_desc", string.Format("{0}", obj.template_desc));
            context.AddParameter("@template_type", obj.template_type);
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@file_id", string.Format("{0}", obj.file_id));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_File_Template>(context, new tbl_File_Template()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_File_Template]
        /// </summary>        
        public static int Delete(string file_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_File_Template 
WHERE   [file_id]  = @file_id";
            context.AddParameter("@file_id",  string.Format("{0}", file_id));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_File_Template]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_File_Template";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_File_Template]
        /// </summary>        
        public static List<tbl_File_Template> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT file_id, ref_name, ref_id, file_type, file_path, file_name, file_ext, file_blob, created, created_by, template_header, template_title, template_desc, template_type, file_size FROM tbl_File_Template";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_File_Template>(context, new tbl_File_Template());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_File_Template]
        /// </summary>        
        public static List<tbl_File_Template> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_File_Template] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_File_Template].[file_id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_File_Template].*
                FROM    [tbl_File_Template]
            )

            SELECT      [Paging_tbl_File_Template].*
            FROM        [Paging_tbl_File_Template]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_File_Template>(context, new tbl_File_Template());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_File_Template] by Primary Key
        /// </summary>        
        public static tbl_File_Template GetByPK(string file_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT file_id, ref_name, ref_id, file_type, file_path, file_name, file_ext, file_blob, created, created_by, template_header, template_title, template_desc, template_type, file_size FROM tbl_File_Template
            WHERE [file_id]  = @file_id";
            context.AddParameter("@file_id", file_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_File_Template>(context, new tbl_File_Template()).FirstOrDefault();
        }

        #endregion

    }
}