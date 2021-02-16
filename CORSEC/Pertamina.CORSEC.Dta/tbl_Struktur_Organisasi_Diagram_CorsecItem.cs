
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Struktur_Organisasi_Diagram_Corsec]
    /// </summary>    
    public partial class tbl_Struktur_Organisasi_Diagram_CorsecItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Struktur_Organisasi_Diagram_Corsec]
        /// </summary>        
        public static tbl_Struktur_Organisasi_Diagram_Corsec Insert(tbl_Struktur_Organisasi_Diagram_Corsec obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Struktur_Organisasi_Diagram_Corsec]([jabatan_id], [jabatan_nama], [parent_id], [parent_jabatan_id], [parent_jabatan_nama], [seq], [created], [created_by], [group_id]) 
VALUES      (@jabatan_id, @jabatan_nama, @parent_id, @parent_jabatan_id, @parent_jabatan_nama, @seq, @created, @created_by, @group_id)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, jabatan_id, jabatan_nama, parent_id, parent_jabatan_id, parent_jabatan_nama, seq, created, created_by, updated, updated_by, group_id
FROM    [tbl_Struktur_Organisasi_Diagram_Corsec]
WHERE   [id]  = @_id";
            context.AddParameter("@jabatan_id", obj.jabatan_id);
            context.AddParameter("@jabatan_nama", string.Format("{0}", obj.jabatan_nama));
            context.AddParameter("@parent_id", obj.parent_id);
            context.AddParameter("@parent_jabatan_id", obj.parent_jabatan_id);
            context.AddParameter("@parent_jabatan_nama", string.Format("{0}", obj.parent_jabatan_nama));
            context.AddParameter("@seq", obj.seq);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@group_id", obj.group_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Diagram_Corsec>(context, new tbl_Struktur_Organisasi_Diagram_Corsec()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Struktur_Organisasi_Diagram_Corsec]
        /// </summary>        
        public static tbl_Struktur_Organisasi_Diagram_Corsec Update(tbl_Struktur_Organisasi_Diagram_Corsec obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Struktur_Organisasi_Diagram_Corsec]
SET         [jabatan_id] = @jabatan_id,
            [jabatan_nama] = @jabatan_nama,
            [parent_id] = @parent_id,
            [parent_jabatan_id] = @parent_jabatan_id,
            [parent_jabatan_nama] = @parent_jabatan_nama,
            [seq] = @seq,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [group_id] = @group_id
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, jabatan_id, jabatan_nama, parent_id, parent_jabatan_id, parent_jabatan_nama, seq, created, created_by, updated, updated_by, group_id 
FROM    [tbl_Struktur_Organisasi_Diagram_Corsec]
WHERE   [id]  = @id";
            context.AddParameter("@jabatan_id", obj.jabatan_id);
            context.AddParameter("@jabatan_nama", string.Format("{0}", obj.jabatan_nama));
            context.AddParameter("@parent_id", obj.parent_id);
            context.AddParameter("@parent_jabatan_id", obj.parent_jabatan_id);
            context.AddParameter("@parent_jabatan_nama", string.Format("{0}", obj.parent_jabatan_nama));
            context.AddParameter("@seq", obj.seq);
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@group_id", obj.group_id);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Diagram_Corsec>(context, new tbl_Struktur_Organisasi_Diagram_Corsec()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Struktur_Organisasi_Diagram_Corsec]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Struktur_Organisasi_Diagram_Corsec 
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
        /// Get Total records from [tbl_Struktur_Organisasi_Diagram_Corsec]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Struktur_Organisasi_Diagram_Corsec";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Struktur_Organisasi_Diagram_Corsec]
        /// </summary>        
        public static List<tbl_Struktur_Organisasi_Diagram_Corsec> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, jabatan_id, jabatan_nama, parent_id, parent_jabatan_id, parent_jabatan_nama, seq, created, created_by, updated, updated_by, group_id FROM tbl_Struktur_Organisasi_Diagram_Corsec";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Diagram_Corsec>(context, new tbl_Struktur_Organisasi_Diagram_Corsec());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Struktur_Organisasi_Diagram_Corsec]
        /// </summary>        
        public static List<tbl_Struktur_Organisasi_Diagram_Corsec> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Struktur_Organisasi_Diagram_Corsec] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Struktur_Organisasi_Diagram_Corsec].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Struktur_Organisasi_Diagram_Corsec].*
                FROM    [tbl_Struktur_Organisasi_Diagram_Corsec]
            )

            SELECT      [Paging_tbl_Struktur_Organisasi_Diagram_Corsec].*
            FROM        [Paging_tbl_Struktur_Organisasi_Diagram_Corsec]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Diagram_Corsec>(context, new tbl_Struktur_Organisasi_Diagram_Corsec());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Struktur_Organisasi_Diagram_Corsec] by Primary Key
        /// </summary>        
        public static tbl_Struktur_Organisasi_Diagram_Corsec GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, jabatan_id, jabatan_nama, parent_id, parent_jabatan_id, parent_jabatan_nama, seq, created, created_by, updated, updated_by, group_id FROM tbl_Struktur_Organisasi_Diagram_Corsec
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Diagram_Corsec>(context, new tbl_Struktur_Organisasi_Diagram_Corsec()).FirstOrDefault();
        }

        #endregion

    }
}