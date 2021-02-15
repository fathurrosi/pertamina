
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Footer_Detail]
    /// </summary>    
    public partial class tbl_Footer_DetailItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Footer_Detail]
        /// </summary>        
        public static tbl_Footer_Detail Insert(tbl_Footer_Detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Footer_Detail]([footer], [footer_text], [footer_link], [created], [created_by]) 
VALUES      (@footer, @footer_text, @footer_link, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, footer, footer_text, footer_link, created, created_by, updated, updated_by
FROM    [tbl_Footer_Detail]
WHERE   [id]  = @_id";
            context.AddParameter("@footer", obj.footer);
            context.AddParameter("@footer_text", string.Format("{0}", obj.footer_text));
            context.AddParameter("@footer_link", string.Format("{0}", obj.footer_link));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Footer_Detail>(context, new tbl_Footer_Detail()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Footer_Detail]
        /// </summary>        
        public static tbl_Footer_Detail Update(tbl_Footer_Detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Footer_Detail]
SET         [footer] = @footer,
            [footer_text] = @footer_text,
            [footer_link] = @footer_link,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, footer, footer_text, footer_link, created, created_by, updated, updated_by 
FROM    [tbl_Footer_Detail]
WHERE   [id]  = @id";
            context.AddParameter("@footer", obj.footer);
            context.AddParameter("@footer_text", string.Format("{0}", obj.footer_text));
            context.AddParameter("@footer_link", string.Format("{0}", obj.footer_link));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Footer_Detail>(context, new tbl_Footer_Detail()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Footer_Detail]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Footer_Detail 
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
        /// Get Total records from [tbl_Footer_Detail]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Footer_Detail";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Footer_Detail]
        /// </summary>        
        public static List<tbl_Footer_Detail> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, footer, footer_text, footer_link, created, created_by, updated, updated_by FROM tbl_Footer_Detail";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Footer_Detail>(context, new tbl_Footer_Detail());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Footer_Detail]
        /// </summary>        
        public static List<tbl_Footer_Detail> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Footer_Detail] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Footer_Detail].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Footer_Detail].*
                FROM    [tbl_Footer_Detail]
            )

            SELECT      [Paging_tbl_Footer_Detail].*
            FROM        [Paging_tbl_Footer_Detail]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Footer_Detail>(context, new tbl_Footer_Detail());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Footer_Detail] by Primary Key
        /// </summary>        
        public static tbl_Footer_Detail GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, footer, footer_text, footer_link, created, created_by, updated, updated_by FROM tbl_Footer_Detail
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Footer_Detail>(context, new tbl_Footer_Detail()).FirstOrDefault();
        }

        #endregion

    }
}