
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Board_Speech_Presentation]
    /// </summary>    
    public partial class tbl_Board_Speech_PresentationItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Board_Speech_Presentation]
        /// </summary>        
        public static tbl_Board_Speech_Presentation Insert(tbl_Board_Speech_Presentation obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Board_Speech_Presentation]([title], [body], [created], [created_by], [data_type], [data_year]) 
VALUES      (@title, @body, @created, @created_by, @data_type, @data_year)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, created, created_by, updated, updated_by, data_type, data_year
FROM    [tbl_Board_Speech_Presentation]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@data_type", obj.data_type);
            context.AddParameter("@data_year", obj.data_year);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Board_Speech_Presentation>(context, new tbl_Board_Speech_Presentation()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Board_Speech_Presentation]
        /// </summary>        
        public static tbl_Board_Speech_Presentation Update(tbl_Board_Speech_Presentation obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Board_Speech_Presentation]
SET         [title] = @title,
            [body] = @body,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [data_type] = @data_type,
            [data_year] = @data_year
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, created, created_by, updated, updated_by, data_type, data_year 
FROM    [tbl_Board_Speech_Presentation]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@data_type", obj.data_type);
            context.AddParameter("@data_year", obj.data_year);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Board_Speech_Presentation>(context, new tbl_Board_Speech_Presentation()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Board_Speech_Presentation]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Board_Speech_Presentation 
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
        /// Get Total records from [tbl_Board_Speech_Presentation]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Board_Speech_Presentation";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Board_Speech_Presentation]
        /// </summary>        
        public static List<tbl_Board_Speech_Presentation> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, created, created_by, updated, updated_by, data_type, data_year FROM tbl_Board_Speech_Presentation";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Board_Speech_Presentation>(context, new tbl_Board_Speech_Presentation());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Board_Speech_Presentation]
        /// </summary>        
        public static List<tbl_Board_Speech_Presentation> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Board_Speech_Presentation] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Board_Speech_Presentation].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Board_Speech_Presentation].*
                FROM    [tbl_Board_Speech_Presentation]
            )

            SELECT      [Paging_tbl_Board_Speech_Presentation].*
            FROM        [Paging_tbl_Board_Speech_Presentation]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Board_Speech_Presentation>(context, new tbl_Board_Speech_Presentation());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Board_Speech_Presentation] by Primary Key
        /// </summary>        
        public static tbl_Board_Speech_Presentation GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, created, created_by, updated, updated_by, data_type, data_year FROM tbl_Board_Speech_Presentation
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Board_Speech_Presentation>(context, new tbl_Board_Speech_Presentation()).FirstOrDefault();
        }

        #endregion

    }
}