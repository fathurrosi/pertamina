
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Email_Template]
    /// </summary>    
    public partial class tbl_Email_TemplateItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Email_Template]
        /// </summary>        
        public static tbl_Email_Template Insert(tbl_Email_Template obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Email_Template]([code], [subject], [body], [body_backup]) 
VALUES      (@code, @subject, @body, @body_backup)

SET @Err = @@Error

SELECT  code, subject, body, body_backup
FROM    [tbl_Email_Template]
WHERE   [code]  = @code";
            context.AddParameter("@code", string.Format("{0}", obj.code));
            context.AddParameter("@subject", string.Format("{0}", obj.subject));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@body_backup", string.Format("{0}", obj.body_backup));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Email_Template>(context, new tbl_Email_Template()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Email_Template]
        /// </summary>        
        public static tbl_Email_Template Update(tbl_Email_Template obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Email_Template]
SET         [subject] = @subject,
            [body] = @body,
            [body_backup] = @body_backup
WHERE       [code]  = @code

SET @Err = @@Error

SELECT  code, subject, body, body_backup 
FROM    [tbl_Email_Template]
WHERE   [code]  = @code";
            context.AddParameter("@subject", string.Format("{0}", obj.subject));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@body_backup", string.Format("{0}", obj.body_backup));
            context.AddParameter("@code", string.Format("{0}", obj.code));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Email_Template>(context, new tbl_Email_Template()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Email_Template]
        /// </summary>        
        public static int Delete(string code)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Email_Template 
WHERE   [code]  = @code";
            context.AddParameter("@code",  string.Format("{0}", code));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_Email_Template]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Email_Template";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Email_Template]
        /// </summary>        
        public static List<tbl_Email_Template> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT code, subject, body, body_backup FROM tbl_Email_Template";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Email_Template>(context, new tbl_Email_Template());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Email_Template]
        /// </summary>        
        public static List<tbl_Email_Template> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Email_Template] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Email_Template].[code]) AS PAGING_ROW_NUMBER,
                        [tbl_Email_Template].*
                FROM    [tbl_Email_Template]
            )

            SELECT      [Paging_tbl_Email_Template].*
            FROM        [Paging_tbl_Email_Template]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Email_Template>(context, new tbl_Email_Template());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Email_Template] by Primary Key
        /// </summary>        
        public static tbl_Email_Template GetByPK(string code)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT code, subject, body, body_backup FROM tbl_Email_Template
            WHERE [code]  = @code";
            context.AddParameter("@code", code);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Email_Template>(context, new tbl_Email_Template()).FirstOrDefault();
        }

        #endregion

    }
}