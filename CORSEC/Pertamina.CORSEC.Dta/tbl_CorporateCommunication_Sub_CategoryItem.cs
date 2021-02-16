
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_CorporateCommunication_Sub_Category]
    /// </summary>    
    public partial class tbl_CorporateCommunication_Sub_CategoryItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_CorporateCommunication_Sub_Category]
        /// </summary>        
        public static tbl_CorporateCommunication_Sub_Category Insert(tbl_CorporateCommunication_Sub_Category obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_CorporateCommunication_Sub_Category]([Category], [created], [created_by], [Name], [Deleted], [Sequence], [Year]) 
VALUES      (@Category, @created, @created_by, @Name, @Deleted, @Sequence, @Year)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, Category, created, created_by, updated, updated_by, Name, Deleted, Sequence, Year
FROM    [tbl_CorporateCommunication_Sub_Category]
WHERE   [id]  = @_id";
            context.AddParameter("@Category", obj.Category);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Deleted", obj.Deleted);
            context.AddParameter("@Sequence", obj.Sequence);
            context.AddParameter("@Year", obj.Year);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Sub_Category>(context, new tbl_CorporateCommunication_Sub_Category()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_CorporateCommunication_Sub_Category]
        /// </summary>        
        public static tbl_CorporateCommunication_Sub_Category Update(tbl_CorporateCommunication_Sub_Category obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_CorporateCommunication_Sub_Category]
SET         [Category] = @Category,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [Name] = @Name,
            [Deleted] = @Deleted,
            [Sequence] = @Sequence,
            [Year] = @Year
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, Category, created, created_by, updated, updated_by, Name, Deleted, Sequence, Year 
FROM    [tbl_CorporateCommunication_Sub_Category]
WHERE   [id]  = @id";
            context.AddParameter("@Category", obj.Category);
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Deleted", obj.Deleted);
            context.AddParameter("@Sequence", obj.Sequence);
            context.AddParameter("@Year", obj.Year);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Sub_Category>(context, new tbl_CorporateCommunication_Sub_Category()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_CorporateCommunication_Sub_Category]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_CorporateCommunication_Sub_Category 
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
        /// Get Total records from [tbl_CorporateCommunication_Sub_Category]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_CorporateCommunication_Sub_Category";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CorporateCommunication_Sub_Category]
        /// </summary>        
        public static List<tbl_CorporateCommunication_Sub_Category> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, Category, created, created_by, updated, updated_by, Name, Deleted, Sequence, Year FROM tbl_CorporateCommunication_Sub_Category";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Sub_Category>(context, new tbl_CorporateCommunication_Sub_Category());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_CorporateCommunication_Sub_Category]
        /// </summary>        
        public static List<tbl_CorporateCommunication_Sub_Category> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_CorporateCommunication_Sub_Category] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CorporateCommunication_Sub_Category].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_CorporateCommunication_Sub_Category].*
                FROM    [tbl_CorporateCommunication_Sub_Category]
            )

            SELECT      [Paging_tbl_CorporateCommunication_Sub_Category].*
            FROM        [Paging_tbl_CorporateCommunication_Sub_Category]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Sub_Category>(context, new tbl_CorporateCommunication_Sub_Category());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_CorporateCommunication_Sub_Category] by Primary Key
        /// </summary>        
        public static tbl_CorporateCommunication_Sub_Category GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, Category, created, created_by, updated, updated_by, Name, Deleted, Sequence, Year FROM tbl_CorporateCommunication_Sub_Category
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Sub_Category>(context, new tbl_CorporateCommunication_Sub_Category()).FirstOrDefault();
        }

        #endregion

    }
}