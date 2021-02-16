
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Kinerja_Sekper_Info]
    /// </summary>    
    public partial class tbl_Kinerja_Sekper_InfoItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Kinerja_Sekper_Info]
        /// </summary>        
        public static tbl_Kinerja_Sekper_Info Insert(tbl_Kinerja_Sekper_Info obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Kinerja_Sekper_Info]([header], [title], [body], [created], [created_by]) 
VALUES      (@header, @title, @body, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, header, title, body, created, created_by, updated, updated_by
FROM    [tbl_Kinerja_Sekper_Info]
WHERE   [id]  = @_id";
            context.AddParameter("@header", string.Format("{0}", obj.header));
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper_Info>(context, new tbl_Kinerja_Sekper_Info()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Kinerja_Sekper_Info]
        /// </summary>        
        public static tbl_Kinerja_Sekper_Info Update(tbl_Kinerja_Sekper_Info obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Kinerja_Sekper_Info]
SET         [header] = @header,
            [title] = @title,
            [body] = @body,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, header, title, body, created, created_by, updated, updated_by 
FROM    [tbl_Kinerja_Sekper_Info]
WHERE   [id]  = @id";
            context.AddParameter("@header", string.Format("{0}", obj.header));
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper_Info>(context, new tbl_Kinerja_Sekper_Info()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Kinerja_Sekper_Info]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Kinerja_Sekper_Info 
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
        /// Get Total records from [tbl_Kinerja_Sekper_Info]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Kinerja_Sekper_Info";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Kinerja_Sekper_Info]
        /// </summary>        
        public static List<tbl_Kinerja_Sekper_Info> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, header, title, body, created, created_by, updated, updated_by FROM tbl_Kinerja_Sekper_Info";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper_Info>(context, new tbl_Kinerja_Sekper_Info());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Kinerja_Sekper_Info]
        /// </summary>        
        public static List<tbl_Kinerja_Sekper_Info> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Kinerja_Sekper_Info] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Kinerja_Sekper_Info].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Kinerja_Sekper_Info].*
                FROM    [tbl_Kinerja_Sekper_Info]
            )

            SELECT      [Paging_tbl_Kinerja_Sekper_Info].*
            FROM        [Paging_tbl_Kinerja_Sekper_Info]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper_Info>(context, new tbl_Kinerja_Sekper_Info());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Kinerja_Sekper_Info] by Primary Key
        /// </summary>        
        public static tbl_Kinerja_Sekper_Info GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, header, title, body, created, created_by, updated, updated_by FROM tbl_Kinerja_Sekper_Info
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper_Info>(context, new tbl_Kinerja_Sekper_Info()).FirstOrDefault();
        }

        #endregion

    }
}