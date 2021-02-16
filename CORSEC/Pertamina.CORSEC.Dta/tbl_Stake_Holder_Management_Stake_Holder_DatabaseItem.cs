
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Stake_Holder_Management_Stake_Holder_Database]
    /// </summary>    
    public partial class tbl_Stake_Holder_Management_Stake_Holder_DatabaseItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Stake_Holder_Management_Stake_Holder_Database]
        /// </summary>        
        public static tbl_Stake_Holder_Management_Stake_Holder_Database Insert(tbl_Stake_Holder_Management_Stake_Holder_Database obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Stake_Holder_Management_Stake_Holder_Database]([created], [created_by], [file_type], [file_path], [file_name], [file_ext], [file_size], [file_blob], [title], [body], [data_type], [year]) 
VALUES      (@created, @created_by, @file_type, @file_path, @file_name, @file_ext, @file_size, @file_blob, @title, @body, @data_type, @year)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, title, body, data_type, year
FROM    [tbl_Stake_Holder_Management_Stake_Holder_Database]
WHERE   [id]  = @_id";
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@data_type", obj.data_type);
            context.AddParameter("@year", obj.year);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Stake_Holder_Database>(context, new tbl_Stake_Holder_Management_Stake_Holder_Database()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Stake_Holder_Management_Stake_Holder_Database]
        /// </summary>        
        public static tbl_Stake_Holder_Management_Stake_Holder_Database Update(tbl_Stake_Holder_Management_Stake_Holder_Database obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Stake_Holder_Management_Stake_Holder_Database]
SET         [updated] = @updated,
            [updated_by] = @updated_by,
            [file_type] = @file_type,
            [file_path] = @file_path,
            [file_name] = @file_name,
            [file_ext] = @file_ext,
            [file_size] = @file_size,
            [file_blob] = @file_blob,
            [title] = @title,
            [body] = @body,
            [data_type] = @data_type,
            [year] = @year
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, title, body, data_type, year 
FROM    [tbl_Stake_Holder_Management_Stake_Holder_Database]
WHERE   [id]  = @id";
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@data_type", obj.data_type);
            context.AddParameter("@year", obj.year);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Stake_Holder_Database>(context, new tbl_Stake_Holder_Management_Stake_Holder_Database()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Stake_Holder_Management_Stake_Holder_Database]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Stake_Holder_Management_Stake_Holder_Database 
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
        /// Get Total records from [tbl_Stake_Holder_Management_Stake_Holder_Database]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Stake_Holder_Management_Stake_Holder_Database";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Stake_Holder_Management_Stake_Holder_Database]
        /// </summary>        
        public static List<tbl_Stake_Holder_Management_Stake_Holder_Database> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, title, body, data_type, year FROM tbl_Stake_Holder_Management_Stake_Holder_Database";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Stake_Holder_Database>(context, new tbl_Stake_Holder_Management_Stake_Holder_Database());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Stake_Holder_Management_Stake_Holder_Database]
        /// </summary>        
        public static List<tbl_Stake_Holder_Management_Stake_Holder_Database> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Stake_Holder_Management_Stake_Holder_Database] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Stake_Holder_Management_Stake_Holder_Database].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Stake_Holder_Management_Stake_Holder_Database].*
                FROM    [tbl_Stake_Holder_Management_Stake_Holder_Database]
            )

            SELECT      [Paging_tbl_Stake_Holder_Management_Stake_Holder_Database].*
            FROM        [Paging_tbl_Stake_Holder_Management_Stake_Holder_Database]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Stake_Holder_Database>(context, new tbl_Stake_Holder_Management_Stake_Holder_Database());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Stake_Holder_Management_Stake_Holder_Database] by Primary Key
        /// </summary>        
        public static tbl_Stake_Holder_Management_Stake_Holder_Database GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, title, body, data_type, year FROM tbl_Stake_Holder_Management_Stake_Holder_Database
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Stake_Holder_Database>(context, new tbl_Stake_Holder_Management_Stake_Holder_Database()).FirstOrDefault();
        }

        #endregion

    }
}