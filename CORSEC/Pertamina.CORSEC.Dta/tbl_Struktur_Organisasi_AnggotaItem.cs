
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Struktur_Organisasi_Anggota]
    /// </summary>    
    public partial class tbl_Struktur_Organisasi_AnggotaItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Struktur_Organisasi_Anggota]
        /// </summary>        
        public static tbl_Struktur_Organisasi_Anggota Insert(tbl_Struktur_Organisasi_Anggota obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Struktur_Organisasi_Anggota]([nama], [nip], [telp], [email], [jabatan_id], [jabatan_nama], [created], [created_by]) 
VALUES      (@nama, @nip, @telp, @email, @jabatan_id, @jabatan_nama, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, nama, nip, telp, email, jabatan_id, jabatan_nama, created, created_by, updated, updated_by
FROM    [tbl_Struktur_Organisasi_Anggota]
WHERE   [id]  = @_id";
            context.AddParameter("@nama", string.Format("{0}", obj.nama));
            context.AddParameter("@nip", string.Format("{0}", obj.nip));
            context.AddParameter("@telp", string.Format("{0}", obj.telp));
            context.AddParameter("@email", string.Format("{0}", obj.email));
            context.AddParameter("@jabatan_id", obj.jabatan_id);
            context.AddParameter("@jabatan_nama", string.Format("{0}", obj.jabatan_nama));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Anggota>(context, new tbl_Struktur_Organisasi_Anggota()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Struktur_Organisasi_Anggota]
        /// </summary>        
        public static tbl_Struktur_Organisasi_Anggota Update(tbl_Struktur_Organisasi_Anggota obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Struktur_Organisasi_Anggota]
SET         [nama] = @nama,
            [nip] = @nip,
            [telp] = @telp,
            [email] = @email,
            [jabatan_id] = @jabatan_id,
            [jabatan_nama] = @jabatan_nama,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, nama, nip, telp, email, jabatan_id, jabatan_nama, created, created_by, updated, updated_by 
FROM    [tbl_Struktur_Organisasi_Anggota]
WHERE   [id]  = @id";
            context.AddParameter("@nama", string.Format("{0}", obj.nama));
            context.AddParameter("@nip", string.Format("{0}", obj.nip));
            context.AddParameter("@telp", string.Format("{0}", obj.telp));
            context.AddParameter("@email", string.Format("{0}", obj.email));
            context.AddParameter("@jabatan_id", obj.jabatan_id);
            context.AddParameter("@jabatan_nama", string.Format("{0}", obj.jabatan_nama));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Anggota>(context, new tbl_Struktur_Organisasi_Anggota()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Struktur_Organisasi_Anggota]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Struktur_Organisasi_Anggota 
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
        /// Get Total records from [tbl_Struktur_Organisasi_Anggota]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Struktur_Organisasi_Anggota";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Struktur_Organisasi_Anggota]
        /// </summary>        
        public static List<tbl_Struktur_Organisasi_Anggota> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, nama, nip, telp, email, jabatan_id, jabatan_nama, created, created_by, updated, updated_by FROM tbl_Struktur_Organisasi_Anggota";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Anggota>(context, new tbl_Struktur_Organisasi_Anggota());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Struktur_Organisasi_Anggota]
        /// </summary>        
        public static List<tbl_Struktur_Organisasi_Anggota> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Struktur_Organisasi_Anggota] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Struktur_Organisasi_Anggota].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Struktur_Organisasi_Anggota].*
                FROM    [tbl_Struktur_Organisasi_Anggota]
            )

            SELECT      [Paging_tbl_Struktur_Organisasi_Anggota].*
            FROM        [Paging_tbl_Struktur_Organisasi_Anggota]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Anggota>(context, new tbl_Struktur_Organisasi_Anggota());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Struktur_Organisasi_Anggota] by Primary Key
        /// </summary>        
        public static tbl_Struktur_Organisasi_Anggota GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, nama, nip, telp, email, jabatan_id, jabatan_nama, created, created_by, updated, updated_by FROM tbl_Struktur_Organisasi_Anggota
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Anggota>(context, new tbl_Struktur_Organisasi_Anggota()).FirstOrDefault();
        }

        #endregion

    }
}