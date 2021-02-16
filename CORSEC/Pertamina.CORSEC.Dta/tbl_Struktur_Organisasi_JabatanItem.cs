
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Struktur_Organisasi_Jabatan]
    /// </summary>    
    public partial class tbl_Struktur_Organisasi_JabatanItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Struktur_Organisasi_Jabatan]
        /// </summary>        
        public static tbl_Struktur_Organisasi_Jabatan Insert(tbl_Struktur_Organisasi_Jabatan obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Struktur_Organisasi_Jabatan]([name], [created], [created_by]) 
VALUES      (@name, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, name, created, created_by, updated, updated_by
FROM    [tbl_Struktur_Organisasi_Jabatan]
WHERE   [id]  = @_id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Jabatan>(context, new tbl_Struktur_Organisasi_Jabatan()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Struktur_Organisasi_Jabatan]
        /// </summary>        
        public static tbl_Struktur_Organisasi_Jabatan Update(tbl_Struktur_Organisasi_Jabatan obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Struktur_Organisasi_Jabatan]
SET         [name] = @name,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, name, created, created_by, updated, updated_by 
FROM    [tbl_Struktur_Organisasi_Jabatan]
WHERE   [id]  = @id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Jabatan>(context, new tbl_Struktur_Organisasi_Jabatan()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Struktur_Organisasi_Jabatan]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Struktur_Organisasi_Jabatan 
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
        /// Get Total records from [tbl_Struktur_Organisasi_Jabatan]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Struktur_Organisasi_Jabatan";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Struktur_Organisasi_Jabatan]
        /// </summary>        
        public static List<tbl_Struktur_Organisasi_Jabatan> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, name, created, created_by, updated, updated_by FROM tbl_Struktur_Organisasi_Jabatan";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Jabatan>(context, new tbl_Struktur_Organisasi_Jabatan());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Struktur_Organisasi_Jabatan]
        /// </summary>        
        public static List<tbl_Struktur_Organisasi_Jabatan> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Struktur_Organisasi_Jabatan] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Struktur_Organisasi_Jabatan].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Struktur_Organisasi_Jabatan].*
                FROM    [tbl_Struktur_Organisasi_Jabatan]
            )

            SELECT      [Paging_tbl_Struktur_Organisasi_Jabatan].*
            FROM        [Paging_tbl_Struktur_Organisasi_Jabatan]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Jabatan>(context, new tbl_Struktur_Organisasi_Jabatan());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Struktur_Organisasi_Jabatan] by Primary Key
        /// </summary>        
        public static tbl_Struktur_Organisasi_Jabatan GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, name, created, created_by, updated, updated_by FROM tbl_Struktur_Organisasi_Jabatan
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Jabatan>(context, new tbl_Struktur_Organisasi_Jabatan()).FirstOrDefault();
        }

        #endregion

    }
}