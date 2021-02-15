
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_brand_Exhibition]
    /// </summary>    
    public partial class tbl_brand_ExhibitionItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_brand_Exhibition]
        /// </summary>        
        public static tbl_brand_Exhibition Insert(tbl_brand_Exhibition obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_brand_Exhibition]([title], [body], [location], [award], [created], [created_by]) 
VALUES      (@title, @body, @location, @award, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, location, award, created, created_by, updated, updated_by
FROM    [tbl_brand_Exhibition]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@location", string.Format("{0}", obj.location));
            context.AddParameter("@award", string.Format("{0}", obj.award));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Exhibition>(context, new tbl_brand_Exhibition()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_brand_Exhibition]
        /// </summary>        
        public static tbl_brand_Exhibition Update(tbl_brand_Exhibition obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_brand_Exhibition]
SET         [title] = @title,
            [body] = @body,
            [location] = @location,
            [award] = @award,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, location, award, created, created_by, updated, updated_by 
FROM    [tbl_brand_Exhibition]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@location", string.Format("{0}", obj.location));
            context.AddParameter("@award", string.Format("{0}", obj.award));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Exhibition>(context, new tbl_brand_Exhibition()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_brand_Exhibition]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_brand_Exhibition 
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
        /// Get Total records from [tbl_brand_Exhibition]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_brand_Exhibition";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_Exhibition]
        /// </summary>        
        public static List<tbl_brand_Exhibition> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, location, award, created, created_by, updated, updated_by FROM tbl_brand_Exhibition";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Exhibition>(context, new tbl_brand_Exhibition());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_Exhibition]
        /// </summary>        
        public static List<tbl_brand_Exhibition> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_brand_Exhibition] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Exhibition].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_brand_Exhibition].*
                FROM    [tbl_brand_Exhibition]
            )

            SELECT      [Paging_tbl_brand_Exhibition].*
            FROM        [Paging_tbl_brand_Exhibition]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_brand_Exhibition>(context, new tbl_brand_Exhibition());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_brand_Exhibition] by Primary Key
        /// </summary>        
        public static tbl_brand_Exhibition GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, location, award, created, created_by, updated, updated_by FROM tbl_brand_Exhibition
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Exhibition>(context, new tbl_brand_Exhibition()).FirstOrDefault();
        }

        #endregion

    }
}