
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Design_Grafis_Video]
    /// </summary>    
    public partial class tbl_Design_Grafis_VideoItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Design_Grafis_Video]
        /// </summary>        
        public static tbl_Design_Grafis_Video Insert(tbl_Design_Grafis_Video obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Design_Grafis_Video]([created], [created_by], [design_grafis_id], [file_type], [file_physical_path], [file_virtual_path], [file_name], [file_ext], [file_blob], [file_size], [file_duration]) 
VALUES      (@created, @created_by, @design_grafis_id, @file_type, @file_physical_path, @file_virtual_path, @file_name, @file_ext, @file_blob, @file_size, @file_duration)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, created, created_by, updated, updated_by, design_grafis_id, file_type, file_physical_path, file_virtual_path, file_name, file_ext, file_blob, file_size, file_duration
FROM    [tbl_Design_Grafis_Video]
WHERE   [id]  = @_id";
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@design_grafis_id", obj.design_grafis_id);
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_physical_path", string.Format("{0}", obj.file_physical_path));
            context.AddParameter("@file_virtual_path", string.Format("{0}", obj.file_virtual_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@file_duration", string.Format("{0}", obj.file_duration));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_Video>(context, new tbl_Design_Grafis_Video()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Design_Grafis_Video]
        /// </summary>        
        public static tbl_Design_Grafis_Video Update(tbl_Design_Grafis_Video obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Design_Grafis_Video]
SET         [updated] = @updated,
            [updated_by] = @updated_by,
            [design_grafis_id] = @design_grafis_id,
            [file_type] = @file_type,
            [file_physical_path] = @file_physical_path,
            [file_virtual_path] = @file_virtual_path,
            [file_name] = @file_name,
            [file_ext] = @file_ext,
            [file_blob] = @file_blob,
            [file_size] = @file_size,
            [file_duration] = @file_duration
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, created, created_by, updated, updated_by, design_grafis_id, file_type, file_physical_path, file_virtual_path, file_name, file_ext, file_blob, file_size, file_duration 
FROM    [tbl_Design_Grafis_Video]
WHERE   [id]  = @id";
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@design_grafis_id", obj.design_grafis_id);
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_physical_path", string.Format("{0}", obj.file_physical_path));
            context.AddParameter("@file_virtual_path", string.Format("{0}", obj.file_virtual_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@file_duration", string.Format("{0}", obj.file_duration));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_Video>(context, new tbl_Design_Grafis_Video()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Design_Grafis_Video]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Design_Grafis_Video 
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
        /// Get Total records from [tbl_Design_Grafis_Video]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Design_Grafis_Video";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Design_Grafis_Video]
        /// </summary>        
        public static List<tbl_Design_Grafis_Video> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, created, created_by, updated, updated_by, design_grafis_id, file_type, file_physical_path, file_virtual_path, file_name, file_ext, file_blob, file_size, file_duration FROM tbl_Design_Grafis_Video";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_Video>(context, new tbl_Design_Grafis_Video());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Design_Grafis_Video]
        /// </summary>        
        public static List<tbl_Design_Grafis_Video> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Design_Grafis_Video] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Design_Grafis_Video].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Design_Grafis_Video].*
                FROM    [tbl_Design_Grafis_Video]
            )

            SELECT      [Paging_tbl_Design_Grafis_Video].*
            FROM        [Paging_tbl_Design_Grafis_Video]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_Video>(context, new tbl_Design_Grafis_Video());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Design_Grafis_Video] by Primary Key
        /// </summary>        
        public static tbl_Design_Grafis_Video GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, created, created_by, updated, updated_by, design_grafis_id, file_type, file_physical_path, file_virtual_path, file_name, file_ext, file_blob, file_size, file_duration FROM tbl_Design_Grafis_Video
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis_Video>(context, new tbl_Design_Grafis_Video()).FirstOrDefault();
        }

        #endregion

    }
}