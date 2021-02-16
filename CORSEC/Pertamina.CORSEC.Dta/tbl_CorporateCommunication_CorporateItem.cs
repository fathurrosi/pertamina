
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_CorporateCommunication_Corporate]
    /// </summary>    
    public partial class tbl_CorporateCommunication_CorporateItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_CorporateCommunication_Corporate]
        /// </summary>        
        public static tbl_CorporateCommunication_Corporate Insert(tbl_CorporateCommunication_Corporate obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_CorporateCommunication_Corporate]([created], [created_by], [file_type], [file_path], [file_name], [file_ext], [file_size], [file_blob], [downloaded], [title], [body], [Jenis_Laporan], [Laporan_Bulanan_Fungsi], [Laporan_Bulanan_Unit], [Laporan_Bulanan_Region], [Laporan_Triwulan_QPI_Fungsi], [Laporan_Triwulan_QPI_Unit], [Laporan_Triwulan_QPI_Region], [last_downloaded]) 
VALUES      (@created, @created_by, @file_type, @file_path, @file_name, @file_ext, @file_size, @file_blob, @downloaded, @title, @body, @Jenis_Laporan, @Laporan_Bulanan_Fungsi, @Laporan_Bulanan_Unit, @Laporan_Bulanan_Region, @Laporan_Triwulan_QPI_Fungsi, @Laporan_Triwulan_QPI_Unit, @Laporan_Triwulan_QPI_Region, @last_downloaded)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, downloaded, title, body, Jenis_Laporan, Laporan_Bulanan_Fungsi, Laporan_Bulanan_Unit, Laporan_Bulanan_Region, Laporan_Triwulan_QPI_Fungsi, Laporan_Triwulan_QPI_Unit, Laporan_Triwulan_QPI_Region, last_downloaded
FROM    [tbl_CorporateCommunication_Corporate]
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
            context.AddParameter("@Jenis_Laporan", string.Format("{0}", obj.Jenis_Laporan));
            context.AddParameter("@Laporan_Bulanan_Fungsi", obj.Laporan_Bulanan_Fungsi);
            context.AddParameter("@Laporan_Bulanan_Unit", obj.Laporan_Bulanan_Unit);
            context.AddParameter("@Laporan_Bulanan_Region", obj.Laporan_Bulanan_Region);
            context.AddParameter("@Laporan_Triwulan_QPI_Fungsi", obj.Laporan_Triwulan_QPI_Fungsi);
            context.AddParameter("@Laporan_Triwulan_QPI_Unit", obj.Laporan_Triwulan_QPI_Unit);
            context.AddParameter("@Laporan_Triwulan_QPI_Region", obj.Laporan_Triwulan_QPI_Region);
            context.AddParameter("@last_downloaded", obj.last_downloaded);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Corporate>(context, new tbl_CorporateCommunication_Corporate()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_CorporateCommunication_Corporate]
        /// </summary>        
        public static tbl_CorporateCommunication_Corporate Update(tbl_CorporateCommunication_Corporate obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_CorporateCommunication_Corporate]
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
            [Jenis_Laporan] = @Jenis_Laporan,
            [Laporan_Bulanan_Fungsi] = @Laporan_Bulanan_Fungsi,
            [Laporan_Bulanan_Unit] = @Laporan_Bulanan_Unit,
            [Laporan_Bulanan_Region] = @Laporan_Bulanan_Region,
            [Laporan_Triwulan_QPI_Fungsi] = @Laporan_Triwulan_QPI_Fungsi,
            [Laporan_Triwulan_QPI_Unit] = @Laporan_Triwulan_QPI_Unit,
            [Laporan_Triwulan_QPI_Region] = @Laporan_Triwulan_QPI_Region,
            [last_downloaded] = @last_downloaded
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, downloaded, title, body, Jenis_Laporan, Laporan_Bulanan_Fungsi, Laporan_Bulanan_Unit, Laporan_Bulanan_Region, Laporan_Triwulan_QPI_Fungsi, Laporan_Triwulan_QPI_Unit, Laporan_Triwulan_QPI_Region, last_downloaded 
FROM    [tbl_CorporateCommunication_Corporate]
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
            context.AddParameter("@Jenis_Laporan", string.Format("{0}", obj.Jenis_Laporan));
            context.AddParameter("@Laporan_Bulanan_Fungsi", obj.Laporan_Bulanan_Fungsi);
            context.AddParameter("@Laporan_Bulanan_Unit", obj.Laporan_Bulanan_Unit);
            context.AddParameter("@Laporan_Bulanan_Region", obj.Laporan_Bulanan_Region);
            context.AddParameter("@Laporan_Triwulan_QPI_Fungsi", obj.Laporan_Triwulan_QPI_Fungsi);
            context.AddParameter("@Laporan_Triwulan_QPI_Unit", obj.Laporan_Triwulan_QPI_Unit);
            context.AddParameter("@Laporan_Triwulan_QPI_Region", obj.Laporan_Triwulan_QPI_Region);
            context.AddParameter("@last_downloaded", obj.last_downloaded);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Corporate>(context, new tbl_CorporateCommunication_Corporate()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_CorporateCommunication_Corporate]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_CorporateCommunication_Corporate 
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
        /// Get Total records from [tbl_CorporateCommunication_Corporate]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_CorporateCommunication_Corporate";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CorporateCommunication_Corporate]
        /// </summary>        
        public static List<tbl_CorporateCommunication_Corporate> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, downloaded, title, body, Jenis_Laporan, Laporan_Bulanan_Fungsi, Laporan_Bulanan_Unit, Laporan_Bulanan_Region, Laporan_Triwulan_QPI_Fungsi, Laporan_Triwulan_QPI_Unit, Laporan_Triwulan_QPI_Region, last_downloaded FROM tbl_CorporateCommunication_Corporate";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Corporate>(context, new tbl_CorporateCommunication_Corporate());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CorporateCommunication_Corporate]
        /// </summary>        
        public static List<tbl_CorporateCommunication_Corporate> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_CorporateCommunication_Corporate] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CorporateCommunication_Corporate].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_CorporateCommunication_Corporate].*
                FROM    [tbl_CorporateCommunication_Corporate]
            )

            SELECT      [Paging_tbl_CorporateCommunication_Corporate].*
            FROM        [Paging_tbl_CorporateCommunication_Corporate]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Corporate>(context, new tbl_CorporateCommunication_Corporate());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_CorporateCommunication_Corporate] by Primary Key
        /// </summary>        
        public static tbl_CorporateCommunication_Corporate GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, created, created_by, updated, updated_by, file_type, file_path, file_name, file_ext, file_size, file_blob, downloaded, title, body, Jenis_Laporan, Laporan_Bulanan_Fungsi, Laporan_Bulanan_Unit, Laporan_Bulanan_Region, Laporan_Triwulan_QPI_Fungsi, Laporan_Triwulan_QPI_Unit, Laporan_Triwulan_QPI_Region, last_downloaded FROM tbl_CorporateCommunication_Corporate
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Corporate>(context, new tbl_CorporateCommunication_Corporate()).FirstOrDefault();
        }

        #endregion

    }
}