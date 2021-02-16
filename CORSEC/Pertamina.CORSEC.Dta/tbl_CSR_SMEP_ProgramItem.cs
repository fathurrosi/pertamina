
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_CSR_SMEP_Program]
    /// </summary>    
    public partial class tbl_CSR_SMEP_ProgramItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_CSR_SMEP_Program]
        /// </summary>        
        public static tbl_CSR_SMEP_Program Insert(tbl_CSR_SMEP_Program obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_CSR_SMEP_Program]([title], [body], [data_type], [year], [bulan], [related_document], [category], [created], [created_by], [file_type], [file_path], [file_name], [file_ext], [file_size], [file_blob], [is_dynamic], [ROW_NUMBER]) 
VALUES      (@title, @body, @data_type, @year, @bulan, @related_document, @category, @created, @created_by, @file_type, @file_path, @file_name, @file_ext, @file_size, @file_blob, @is_dynamic, @ROW_NUMBER)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, data_type, year, bulan, related_document, category, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, is_dynamic, ROW_NUMBER
FROM    [tbl_CSR_SMEP_Program]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@data_type", obj.data_type);
            context.AddParameter("@year", obj.year);
            context.AddParameter("@bulan", obj.bulan);
            context.AddParameter("@related_document", obj.related_document);
            context.AddParameter("@category", obj.category);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@is_dynamic", obj.is_dynamic);
            context.AddParameter("@ROW_NUMBER", obj.ROW_NUMBER);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program>(context, new tbl_CSR_SMEP_Program()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_CSR_SMEP_Program]
        /// </summary>        
        public static tbl_CSR_SMEP_Program Update(tbl_CSR_SMEP_Program obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_CSR_SMEP_Program]
SET         [title] = @title,
            [body] = @body,
            [data_type] = @data_type,
            [year] = @year,
            [bulan] = @bulan,
            [related_document] = @related_document,
            [category] = @category,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [file_type] = @file_type,
            [file_path] = @file_path,
            [file_name] = @file_name,
            [file_ext] = @file_ext,
            [file_size] = @file_size,
            [file_blob] = @file_blob,
            [is_dynamic] = @is_dynamic,
            [ROW_NUMBER] = @ROW_NUMBER
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, data_type, year, bulan, related_document, category, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, is_dynamic, ROW_NUMBER 
FROM    [tbl_CSR_SMEP_Program]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@data_type", obj.data_type);
            context.AddParameter("@year", obj.year);
            context.AddParameter("@bulan", obj.bulan);
            context.AddParameter("@related_document", obj.related_document);
            context.AddParameter("@category", obj.category);
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@is_dynamic", obj.is_dynamic);
            context.AddParameter("@ROW_NUMBER", obj.ROW_NUMBER);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program>(context, new tbl_CSR_SMEP_Program()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_CSR_SMEP_Program]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_CSR_SMEP_Program 
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
        /// Get Total records from [tbl_CSR_SMEP_Program]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_CSR_SMEP_Program";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CSR_SMEP_Program]
        /// </summary>        
        public static List<tbl_CSR_SMEP_Program> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, data_type, year, bulan, related_document, category, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, is_dynamic, ROW_NUMBER FROM tbl_CSR_SMEP_Program";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program>(context, new tbl_CSR_SMEP_Program());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CSR_SMEP_Program]
        /// </summary>        
        public static List<tbl_CSR_SMEP_Program> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_CSR_SMEP_Program] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CSR_SMEP_Program].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_CSR_SMEP_Program].*
                FROM    [tbl_CSR_SMEP_Program]
            )

            SELECT      [Paging_tbl_CSR_SMEP_Program].*
            FROM        [Paging_tbl_CSR_SMEP_Program]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program>(context, new tbl_CSR_SMEP_Program());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_CSR_SMEP_Program] by Primary Key
        /// </summary>        
        public static tbl_CSR_SMEP_Program GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, data_type, year, bulan, related_document, category, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, is_dynamic, ROW_NUMBER FROM tbl_CSR_SMEP_Program
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program>(context, new tbl_CSR_SMEP_Program()).FirstOrDefault();
        }

        #endregion

    }
}