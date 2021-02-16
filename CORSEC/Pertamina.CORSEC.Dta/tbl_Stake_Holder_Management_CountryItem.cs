
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Stake_Holder_Management_Country]
    /// </summary>    
    public partial class tbl_Stake_Holder_Management_CountryItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Stake_Holder_Management_Country]
        /// </summary>        
        public static tbl_Stake_Holder_Management_Country Insert(tbl_Stake_Holder_Management_Country obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Stake_Holder_Management_Country]([country], [sequence], [deleted], [created], [created_by]) 
VALUES      (@country, @sequence, @deleted, @created, @created_by)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, country, sequence, deleted, created, created_by, updated, updated_by
FROM    [tbl_Stake_Holder_Management_Country]
WHERE   [id]  = @_id";
            context.AddParameter("@country", string.Format("{0}", obj.country));
            context.AddParameter("@sequence", obj.sequence);
            context.AddParameter("@deleted", obj.deleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Country>(context, new tbl_Stake_Holder_Management_Country()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Stake_Holder_Management_Country]
        /// </summary>        
        public static tbl_Stake_Holder_Management_Country Update(tbl_Stake_Holder_Management_Country obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Stake_Holder_Management_Country]
SET         [country] = @country,
            [sequence] = @sequence,
            [deleted] = @deleted,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, country, sequence, deleted, created, created_by, updated, updated_by 
FROM    [tbl_Stake_Holder_Management_Country]
WHERE   [id]  = @id";
            context.AddParameter("@country", string.Format("{0}", obj.country));
            context.AddParameter("@sequence", obj.sequence);
            context.AddParameter("@deleted", obj.deleted);
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Country>(context, new tbl_Stake_Holder_Management_Country()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Stake_Holder_Management_Country]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Stake_Holder_Management_Country 
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
        /// Get Total records from [tbl_Stake_Holder_Management_Country]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Stake_Holder_Management_Country";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Stake_Holder_Management_Country]
        /// </summary>        
        public static List<tbl_Stake_Holder_Management_Country> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, country, sequence, deleted, created, created_by, updated, updated_by FROM tbl_Stake_Holder_Management_Country";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Country>(context, new tbl_Stake_Holder_Management_Country());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Stake_Holder_Management_Country]
        /// </summary>        
        public static List<tbl_Stake_Holder_Management_Country> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Stake_Holder_Management_Country] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Stake_Holder_Management_Country].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Stake_Holder_Management_Country].*
                FROM    [tbl_Stake_Holder_Management_Country]
            )

            SELECT      [Paging_tbl_Stake_Holder_Management_Country].*
            FROM        [Paging_tbl_Stake_Holder_Management_Country]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Country>(context, new tbl_Stake_Holder_Management_Country());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Stake_Holder_Management_Country] by Primary Key
        /// </summary>        
        public static tbl_Stake_Holder_Management_Country GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, country, sequence, deleted, created, created_by, updated, updated_by FROM tbl_Stake_Holder_Management_Country
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Country>(context, new tbl_Stake_Holder_Management_Country()).FirstOrDefault();
        }

        #endregion

    }
}