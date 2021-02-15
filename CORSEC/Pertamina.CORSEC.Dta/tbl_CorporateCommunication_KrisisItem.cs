
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_CorporateCommunication_Krisis]
    /// </summary>    
    public partial class tbl_CorporateCommunication_KrisisItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_CorporateCommunication_Krisis]
        /// </summary>        
        public static tbl_CorporateCommunication_Krisis Insert(tbl_CorporateCommunication_Krisis obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_CorporateCommunication_Krisis]([created], [created_by], [file_type], [file_path], [file_name], [file_ext], [file_size], [file_blob], [downloaded], [title], [body], [SubCategory], [Jenis_Documen], [Tahun]) 
VALUES      (@created, @created_by, @file_type, @file_path, @file_name, @file_ext, @file_size, @file_blob, @downloaded, @title, @body, @SubCategory, @Jenis_Documen, @Tahun)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, downloaded, title, body, SubCategory, Jenis_Documen, Tahun
FROM    [tbl_CorporateCommunication_Krisis]
WHERE   [id]  = @_id";
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@downloaded", obj.downloaded);
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@SubCategory", obj.SubCategory);
            context.AddParameter("@Jenis_Documen", obj.Jenis_Documen);
            context.AddParameter("@Tahun", obj.Tahun);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Krisis>(context, new tbl_CorporateCommunication_Krisis()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_CorporateCommunication_Krisis]
        /// </summary>        
        public static tbl_CorporateCommunication_Krisis Update(tbl_CorporateCommunication_Krisis obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_CorporateCommunication_Krisis]
SET         [updated] = @updated,
            [updated_by] = @updated_by,
            [file_type] = @file_type,
            [file_path] = @file_path,
            [file_name] = @file_name,
            [file_ext] = @file_ext,
            [file_size] = @file_size,
            [file_blob] = @file_blob,
            [downloaded] = @downloaded,
            [title] = @title,
            [body] = @body,
            [SubCategory] = @SubCategory,
            [Jenis_Documen] = @Jenis_Documen,
            [Tahun] = @Tahun
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, downloaded, title, body, SubCategory, Jenis_Documen, Tahun 
FROM    [tbl_CorporateCommunication_Krisis]
WHERE   [id]  = @id";
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_size", string.Format("{0}", obj.file_size));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@downloaded", obj.downloaded);
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@SubCategory", obj.SubCategory);
            context.AddParameter("@Jenis_Documen", obj.Jenis_Documen);
            context.AddParameter("@Tahun", obj.Tahun);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Krisis>(context, new tbl_CorporateCommunication_Krisis()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_CorporateCommunication_Krisis]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_CorporateCommunication_Krisis 
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
        /// Get Total records from [tbl_CorporateCommunication_Krisis]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_CorporateCommunication_Krisis";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CorporateCommunication_Krisis]
        /// </summary>        
        public static List<tbl_CorporateCommunication_Krisis> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, downloaded, title, body, SubCategory, Jenis_Documen, Tahun FROM tbl_CorporateCommunication_Krisis";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Krisis>(context, new tbl_CorporateCommunication_Krisis());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CorporateCommunication_Krisis]
        /// </summary>        
        public static List<tbl_CorporateCommunication_Krisis> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_CorporateCommunication_Krisis] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CorporateCommunication_Krisis].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_CorporateCommunication_Krisis].*
                FROM    [tbl_CorporateCommunication_Krisis]
            )

            SELECT      [Paging_tbl_CorporateCommunication_Krisis].*
            FROM        [Paging_tbl_CorporateCommunication_Krisis]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Krisis>(context, new tbl_CorporateCommunication_Krisis());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_CorporateCommunication_Krisis] by Primary Key
        /// </summary>        
        public static tbl_CorporateCommunication_Krisis GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, downloaded, title, body, SubCategory, Jenis_Documen, Tahun FROM tbl_CorporateCommunication_Krisis
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Krisis>(context, new tbl_CorporateCommunication_Krisis()).FirstOrDefault();
        }

        #endregion

    }
}