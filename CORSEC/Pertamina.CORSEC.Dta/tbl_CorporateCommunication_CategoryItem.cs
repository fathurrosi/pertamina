
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_CorporateCommunication_Category]
    /// </summary>    
    public partial class tbl_CorporateCommunication_CategoryItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_CorporateCommunication_Category]
        /// </summary>        
        public static tbl_CorporateCommunication_Category Insert(tbl_CorporateCommunication_Category obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_CorporateCommunication_Category]([created], [created_by], [Name], [Deleted], [Sequence]) 
VALUES      (@created, @created_by, @Name, @Deleted, @Sequence)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, created, created_by, updated, updated_by, Name, Deleted, Sequence
FROM    [tbl_CorporateCommunication_Category]
WHERE   [id]  = @_id";
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Deleted", obj.Deleted);
            context.AddParameter("@Sequence", obj.Sequence);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Category>(context, new tbl_CorporateCommunication_Category()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_CorporateCommunication_Category]
        /// </summary>        
        public static tbl_CorporateCommunication_Category Update(tbl_CorporateCommunication_Category obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_CorporateCommunication_Category]
SET         [updated] = @updated,
            [updated_by] = @updated_by,
            [Name] = @Name,
            [Deleted] = @Deleted,
            [Sequence] = @Sequence
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, created, created_by, updated, updated_by, Name, Deleted, Sequence 
FROM    [tbl_CorporateCommunication_Category]
WHERE   [id]  = @id";
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Deleted", obj.Deleted);
            context.AddParameter("@Sequence", obj.Sequence);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Category>(context, new tbl_CorporateCommunication_Category()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_CorporateCommunication_Category]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_CorporateCommunication_Category 
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
        /// Get Total records from [tbl_CorporateCommunication_Category]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_CorporateCommunication_Category";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CorporateCommunication_Category]
        /// </summary>        
        public static List<tbl_CorporateCommunication_Category> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, created, created_by, updated, updated_by, Name, Deleted, Sequence FROM tbl_CorporateCommunication_Category";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Category>(context, new tbl_CorporateCommunication_Category());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CorporateCommunication_Category]
        /// </summary>        
        public static List<tbl_CorporateCommunication_Category> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_CorporateCommunication_Category] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CorporateCommunication_Category].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_CorporateCommunication_Category].*
                FROM    [tbl_CorporateCommunication_Category]
            )

            SELECT      [Paging_tbl_CorporateCommunication_Category].*
            FROM        [Paging_tbl_CorporateCommunication_Category]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Category>(context, new tbl_CorporateCommunication_Category());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_CorporateCommunication_Category] by Primary Key
        /// </summary>        
        public static tbl_CorporateCommunication_Category GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, created, created_by, updated, updated_by, Name, Deleted, Sequence FROM tbl_CorporateCommunication_Category
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Category>(context, new tbl_CorporateCommunication_Category()).FirstOrDefault();
        }

        #endregion

    }
}