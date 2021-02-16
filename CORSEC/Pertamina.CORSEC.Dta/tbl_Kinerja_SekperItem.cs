
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Kinerja_Sekper]
    /// </summary>    
    public partial class tbl_Kinerja_SekperItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Kinerja_Sekper]
        /// </summary>        
        public static tbl_Kinerja_Sekper Insert(tbl_Kinerja_Sekper obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Kinerja_Sekper]([semester], [tahun], [created], [created_by]) 
VALUES      (@semester, @tahun, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, semester, tahun, created, created_by, updated, updated_by
FROM    [tbl_Kinerja_Sekper]
WHERE   [id]  = @_id";
            context.AddParameter("@semester", obj.semester);
            context.AddParameter("@tahun", obj.tahun);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper>(context, new tbl_Kinerja_Sekper()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Kinerja_Sekper]
        /// </summary>        
        public static tbl_Kinerja_Sekper Update(tbl_Kinerja_Sekper obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Kinerja_Sekper]
SET         [semester] = @semester,
            [tahun] = @tahun,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, semester, tahun, created, created_by, updated, updated_by 
FROM    [tbl_Kinerja_Sekper]
WHERE   [id]  = @id";
            context.AddParameter("@semester", obj.semester);
            context.AddParameter("@tahun", obj.tahun);
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper>(context, new tbl_Kinerja_Sekper()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Kinerja_Sekper]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Kinerja_Sekper 
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
        /// Get Total records from [tbl_Kinerja_Sekper]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Kinerja_Sekper";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Kinerja_Sekper]
        /// </summary>        
        public static List<tbl_Kinerja_Sekper> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, semester, tahun, created, created_by, updated, updated_by FROM tbl_Kinerja_Sekper";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper>(context, new tbl_Kinerja_Sekper());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Kinerja_Sekper]
        /// </summary>        
        public static List<tbl_Kinerja_Sekper> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Kinerja_Sekper] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Kinerja_Sekper].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Kinerja_Sekper].*
                FROM    [tbl_Kinerja_Sekper]
            )

            SELECT      [Paging_tbl_Kinerja_Sekper].*
            FROM        [Paging_tbl_Kinerja_Sekper]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper>(context, new tbl_Kinerja_Sekper());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Kinerja_Sekper] by Primary Key
        /// </summary>        
        public static tbl_Kinerja_Sekper GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, semester, tahun, created, created_by, updated, updated_by FROM tbl_Kinerja_Sekper
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper>(context, new tbl_Kinerja_Sekper()).FirstOrDefault();
        }

        #endregion

    }
}