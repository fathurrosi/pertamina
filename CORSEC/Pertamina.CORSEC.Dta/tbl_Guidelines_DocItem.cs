
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Guidelines_Doc]
    /// </summary>    
    public partial class tbl_Guidelines_DocItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Guidelines_Doc]
        /// </summary>        
        public static tbl_Guidelines_Doc Insert(tbl_Guidelines_Doc obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Guidelines_Doc]([No_Dokumen], [Tipe_Dokumen], [Judul], [Tahun], [created], [created_by]) 
VALUES      (@No_Dokumen, @Tipe_Dokumen, @Judul, @Tahun, @created, @created_by)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, No_Dokumen, Tipe_Dokumen, Judul, Tahun, created, created_by, updated, updated_by
FROM    [tbl_Guidelines_Doc]
WHERE   [id]  = @_id";
            context.AddParameter("@No_Dokumen", string.Format("{0}", obj.No_Dokumen));
            context.AddParameter("@Tipe_Dokumen", string.Format("{0}", obj.Tipe_Dokumen));
            context.AddParameter("@Judul", string.Format("{0}", obj.Judul));
            context.AddParameter("@Tahun", obj.Tahun);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Guidelines_Doc>(context, new tbl_Guidelines_Doc()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Guidelines_Doc]
        /// </summary>        
        public static tbl_Guidelines_Doc Update(tbl_Guidelines_Doc obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Guidelines_Doc]
SET         [No_Dokumen] = @No_Dokumen,
            [Tipe_Dokumen] = @Tipe_Dokumen,
            [Judul] = @Judul,
            [Tahun] = @Tahun,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, No_Dokumen, Tipe_Dokumen, Judul, Tahun, created, created_by, updated, updated_by 
FROM    [tbl_Guidelines_Doc]
WHERE   [id]  = @id";
            context.AddParameter("@No_Dokumen", string.Format("{0}", obj.No_Dokumen));
            context.AddParameter("@Tipe_Dokumen", string.Format("{0}", obj.Tipe_Dokumen));
            context.AddParameter("@Judul", string.Format("{0}", obj.Judul));
            context.AddParameter("@Tahun", obj.Tahun);
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Guidelines_Doc>(context, new tbl_Guidelines_Doc()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Guidelines_Doc]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Guidelines_Doc 
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
        /// Get Total records from [tbl_Guidelines_Doc]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Guidelines_Doc";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Guidelines_Doc]
        /// </summary>        
        public static List<tbl_Guidelines_Doc> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, No_Dokumen, Tipe_Dokumen, Judul, Tahun, created, created_by, updated, updated_by FROM tbl_Guidelines_Doc";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Guidelines_Doc>(context, new tbl_Guidelines_Doc());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Guidelines_Doc]
        /// </summary>        
        public static List<tbl_Guidelines_Doc> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Guidelines_Doc] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Guidelines_Doc].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Guidelines_Doc].*
                FROM    [tbl_Guidelines_Doc]
            )

            SELECT      [Paging_tbl_Guidelines_Doc].*
            FROM        [Paging_tbl_Guidelines_Doc]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Guidelines_Doc>(context, new tbl_Guidelines_Doc());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Guidelines_Doc] by Primary Key
        /// </summary>        
        public static tbl_Guidelines_Doc GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, No_Dokumen, Tipe_Dokumen, Judul, Tahun, created, created_by, updated, updated_by FROM tbl_Guidelines_Doc
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Guidelines_Doc>(context, new tbl_Guidelines_Doc()).FirstOrDefault();
        }

        #endregion

    }
}