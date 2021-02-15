
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Program]
    /// </summary>    
    public partial class tbl_ProgramItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Program]
        /// </summary>        
        public static tbl_Program Insert(tbl_Program obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Program]([title], [body], [prog_type], [created], [created_by], [img_position]) 
VALUES      (@title, @body, @prog_type, @created, @created_by, @img_position)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, prog_type, created, created_by, updated, updated_by, img_position
FROM    [tbl_Program]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@prog_type", obj.prog_type);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@img_position", obj.img_position);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Program>(context, new tbl_Program()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Program]
        /// </summary>        
        public static tbl_Program Update(tbl_Program obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Program]
SET         [title] = @title,
            [body] = @body,
            [prog_type] = @prog_type,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [img_position] = @img_position
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, prog_type, created, created_by, updated, updated_by, img_position 
FROM    [tbl_Program]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@prog_type", obj.prog_type);
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@img_position", obj.img_position);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Program>(context, new tbl_Program()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Program]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Program 
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
        /// Get Total records from [tbl_Program]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Program";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Program]
        /// </summary>        
        public static List<tbl_Program> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, prog_type, created, created_by, updated, updated_by, img_position FROM tbl_Program";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Program>(context, new tbl_Program());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Program]
        /// </summary>        
        public static List<tbl_Program> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Program] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Program].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Program].*
                FROM    [tbl_Program]
            )

            SELECT      [Paging_tbl_Program].*
            FROM        [Paging_tbl_Program]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Program>(context, new tbl_Program());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Program] by Primary Key
        /// </summary>        
        public static tbl_Program GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, prog_type, created, created_by, updated, updated_by, img_position FROM tbl_Program
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Program>(context, new tbl_Program()).FirstOrDefault();
        }

        #endregion

    }
}