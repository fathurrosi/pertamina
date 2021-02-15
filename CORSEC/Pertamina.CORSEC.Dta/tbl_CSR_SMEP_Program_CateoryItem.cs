
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_CSR_SMEP_Program_Cateory]
    /// </summary>    
    public partial class tbl_CSR_SMEP_Program_CateoryItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_CSR_SMEP_Program_Cateory]
        /// </summary>        
        public static tbl_CSR_SMEP_Program_Cateory Insert(tbl_CSR_SMEP_Program_Cateory obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_CSR_SMEP_Program_Cateory]([created], [created_by], [Name], [Deleted], [Sequence]) 
VALUES      (@created, @created_by, @Name, @Deleted, @Sequence)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, created, created_by, updated, updated_by, Name, Deleted, Sequence
FROM    [tbl_CSR_SMEP_Program_Cateory]
WHERE   [id]  = @_id";
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Deleted", obj.Deleted);
            context.AddParameter("@Sequence", obj.Sequence);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program_Cateory>(context, new tbl_CSR_SMEP_Program_Cateory()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_CSR_SMEP_Program_Cateory]
        /// </summary>        
        public static tbl_CSR_SMEP_Program_Cateory Update(tbl_CSR_SMEP_Program_Cateory obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_CSR_SMEP_Program_Cateory]
SET         [updated] = @updated,
            [updated_by] = @updated_by,
            [Name] = @Name,
            [Deleted] = @Deleted,
            [Sequence] = @Sequence
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, created, created_by, updated, updated_by, Name, Deleted, Sequence 
FROM    [tbl_CSR_SMEP_Program_Cateory]
WHERE   [id]  = @id";
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Deleted", obj.Deleted);
            context.AddParameter("@Sequence", obj.Sequence);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program_Cateory>(context, new tbl_CSR_SMEP_Program_Cateory()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_CSR_SMEP_Program_Cateory]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_CSR_SMEP_Program_Cateory 
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
        /// Get Total records from [tbl_CSR_SMEP_Program_Cateory]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_CSR_SMEP_Program_Cateory";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CSR_SMEP_Program_Cateory]
        /// </summary>        
        public static List<tbl_CSR_SMEP_Program_Cateory> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, created, created_by, updated, updated_by, Name, Deleted, Sequence FROM tbl_CSR_SMEP_Program_Cateory";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program_Cateory>(context, new tbl_CSR_SMEP_Program_Cateory());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CSR_SMEP_Program_Cateory]
        /// </summary>        
        public static List<tbl_CSR_SMEP_Program_Cateory> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_CSR_SMEP_Program_Cateory] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CSR_SMEP_Program_Cateory].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_CSR_SMEP_Program_Cateory].*
                FROM    [tbl_CSR_SMEP_Program_Cateory]
            )

            SELECT      [Paging_tbl_CSR_SMEP_Program_Cateory].*
            FROM        [Paging_tbl_CSR_SMEP_Program_Cateory]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program_Cateory>(context, new tbl_CSR_SMEP_Program_Cateory());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_CSR_SMEP_Program_Cateory] by Primary Key
        /// </summary>        
        public static tbl_CSR_SMEP_Program_Cateory GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, created, created_by, updated, updated_by, Name, Deleted, Sequence FROM tbl_CSR_SMEP_Program_Cateory
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program_Cateory>(context, new tbl_CSR_SMEP_Program_Cateory()).FirstOrDefault();
        }

        #endregion

    }
}