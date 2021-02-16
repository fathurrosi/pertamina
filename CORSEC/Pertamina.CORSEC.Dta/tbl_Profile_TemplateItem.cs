
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Profile_Template]
    /// </summary>    
    public partial class tbl_Profile_TemplateItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Profile_Template]
        /// </summary>        
        public static tbl_Profile_Template Insert(tbl_Profile_Template obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Profile_Template]([header], [created], [created_by], [header_type]) 
VALUES      (@header, @created, @created_by, @header_type)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, header, created, created_by, updated, updated_by, header_type
FROM    [tbl_Profile_Template]
WHERE   [id]  = @_id";
            context.AddParameter("@header", string.Format("{0}", obj.header));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@header_type", string.Format("{0}", obj.header_type));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Template>(context, new tbl_Profile_Template()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Profile_Template]
        /// </summary>        
        public static tbl_Profile_Template Update(tbl_Profile_Template obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Profile_Template]
SET         [header] = @header,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [header_type] = @header_type
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, header, created, created_by, updated, updated_by, header_type 
FROM    [tbl_Profile_Template]
WHERE   [id]  = @id";
            context.AddParameter("@header", string.Format("{0}", obj.header));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@header_type", string.Format("{0}", obj.header_type));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Template>(context, new tbl_Profile_Template()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Profile_Template]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Profile_Template 
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
        /// Get Total records from [tbl_Profile_Template]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Profile_Template";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Profile_Template]
        /// </summary>        
        public static List<tbl_Profile_Template> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, header, created, created_by, updated, updated_by, header_type FROM tbl_Profile_Template";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Template>(context, new tbl_Profile_Template());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Profile_Template]
        /// </summary>        
        public static List<tbl_Profile_Template> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Profile_Template] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Profile_Template].[id] DESC) AS PAGING_ROW_NUMBER,
                        [tbl_Profile_Template].*
                FROM    [tbl_Profile_Template]
            )

            SELECT      [Paging_tbl_Profile_Template].*
            FROM        [Paging_tbl_Profile_Template]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Profile_Template>(context, new tbl_Profile_Template());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Profile_Template] by Primary Key
        /// </summary>        
        public static tbl_Profile_Template GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, header, created, created_by, updated, updated_by, header_type FROM tbl_Profile_Template
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Template>(context, new tbl_Profile_Template()).FirstOrDefault();
        }

        #endregion

    }
}