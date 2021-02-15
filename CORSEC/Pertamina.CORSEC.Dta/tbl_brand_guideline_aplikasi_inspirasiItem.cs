
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_brand_guideline_aplikasi_inspirasi]
    /// </summary>    
    public partial class tbl_brand_guideline_aplikasi_inspirasiItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_brand_guideline_aplikasi_inspirasi]
        /// </summary>        
        public static tbl_brand_guideline_aplikasi_inspirasi Insert(tbl_brand_guideline_aplikasi_inspirasi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_brand_guideline_aplikasi_inspirasi]([title], [body], [logo_type], [created], [created_by]) 
VALUES      (@title, @body, @logo_type, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, logo_type, created, created_by, updated, updated_by
FROM    [tbl_brand_guideline_aplikasi_inspirasi]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@logo_type", obj.logo_type);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_guideline_aplikasi_inspirasi>(context, new tbl_brand_guideline_aplikasi_inspirasi()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_brand_guideline_aplikasi_inspirasi]
        /// </summary>        
        public static tbl_brand_guideline_aplikasi_inspirasi Update(tbl_brand_guideline_aplikasi_inspirasi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_brand_guideline_aplikasi_inspirasi]
SET         [title] = @title,
            [body] = @body,
            [logo_type] = @logo_type,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, logo_type, created, created_by, updated, updated_by 
FROM    [tbl_brand_guideline_aplikasi_inspirasi]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@logo_type", obj.logo_type);
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_guideline_aplikasi_inspirasi>(context, new tbl_brand_guideline_aplikasi_inspirasi()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_brand_guideline_aplikasi_inspirasi]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_brand_guideline_aplikasi_inspirasi 
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
        /// Get Total records from [tbl_brand_guideline_aplikasi_inspirasi]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_brand_guideline_aplikasi_inspirasi";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_guideline_aplikasi_inspirasi]
        /// </summary>        
        public static List<tbl_brand_guideline_aplikasi_inspirasi> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, logo_type, created, created_by, updated, updated_by FROM tbl_brand_guideline_aplikasi_inspirasi";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_guideline_aplikasi_inspirasi>(context, new tbl_brand_guideline_aplikasi_inspirasi());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_guideline_aplikasi_inspirasi]
        /// </summary>        
        public static List<tbl_brand_guideline_aplikasi_inspirasi> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_brand_guideline_aplikasi_inspirasi] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_guideline_aplikasi_inspirasi].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_brand_guideline_aplikasi_inspirasi].*
                FROM    [tbl_brand_guideline_aplikasi_inspirasi]
            )

            SELECT      [Paging_tbl_brand_guideline_aplikasi_inspirasi].*
            FROM        [Paging_tbl_brand_guideline_aplikasi_inspirasi]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_brand_guideline_aplikasi_inspirasi>(context, new tbl_brand_guideline_aplikasi_inspirasi());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_brand_guideline_aplikasi_inspirasi] by Primary Key
        /// </summary>        
        public static tbl_brand_guideline_aplikasi_inspirasi GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, logo_type, created, created_by, updated, updated_by FROM tbl_brand_guideline_aplikasi_inspirasi
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_guideline_aplikasi_inspirasi>(context, new tbl_brand_guideline_aplikasi_inspirasi()).FirstOrDefault();
        }

        #endregion

    }
}