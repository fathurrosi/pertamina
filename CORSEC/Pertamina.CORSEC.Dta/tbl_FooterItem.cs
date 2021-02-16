
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Footer]
    /// </summary>    
    public partial class tbl_FooterItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Footer]
        /// </summary>        
        public static tbl_Footer Insert(tbl_Footer obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Footer]([footer], [created], [created_by]) 
VALUES      (@footer, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, footer, created, created_by, updated, updated_by
FROM    [tbl_Footer]
WHERE   [id]  = @_id";
            context.AddParameter("@footer", string.Format("{0}", obj.footer));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Footer>(context, new tbl_Footer()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Footer]
        /// </summary>        
        public static tbl_Footer Update(tbl_Footer obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Footer]
SET         [footer] = @footer,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, footer, created, created_by, updated, updated_by 
FROM    [tbl_Footer]
WHERE   [id]  = @id";
            context.AddParameter("@footer", string.Format("{0}", obj.footer));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Footer>(context, new tbl_Footer()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Footer]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Footer 
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
        /// Get Total records from [tbl_Footer]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Footer";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Footer]
        /// </summary>        
        public static List<tbl_Footer> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, footer, created, created_by, updated, updated_by FROM tbl_Footer";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Footer>(context, new tbl_Footer());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Footer]
        /// </summary>        
        public static List<tbl_Footer> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Footer] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Footer].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Footer].*
                FROM    [tbl_Footer]
            )

            SELECT      [Paging_tbl_Footer].*
            FROM        [Paging_tbl_Footer]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Footer>(context, new tbl_Footer());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Footer] by Primary Key
        /// </summary>        
        public static tbl_Footer GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, footer, created, created_by, updated, updated_by FROM tbl_Footer
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Footer>(context, new tbl_Footer()).FirstOrDefault();
        }

        #endregion

    }
}