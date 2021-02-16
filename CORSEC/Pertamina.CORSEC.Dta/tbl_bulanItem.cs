
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_bulan]
    /// </summary>    
    public partial class tbl_bulanItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_bulan]
        /// </summary>        
        public static tbl_bulan Insert(tbl_bulan obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_bulan]([nama], [id]) 
VALUES      (@nama, @id)

SET @Err = @@Error

SELECT  nama, id
FROM    [tbl_bulan]
WHERE   [id]  = @id";
            context.AddParameter("@nama", string.Format("{0}", obj.nama));
            context.AddParameter("@id", obj.id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_bulan>(context, new tbl_bulan()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_bulan]
        /// </summary>        
        public static tbl_bulan Update(tbl_bulan obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_bulan]
SET         [nama] = @nama
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  nama, id 
FROM    [tbl_bulan]
WHERE   [id]  = @id";
            context.AddParameter("@nama", string.Format("{0}", obj.nama));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_bulan>(context, new tbl_bulan()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_bulan]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_bulan 
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
        /// Get Total records from [tbl_bulan]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_bulan";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_bulan]
        /// </summary>        
        public static List<tbl_bulan> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT nama, id FROM tbl_bulan";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_bulan>(context, new tbl_bulan());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_bulan]
        /// </summary>        
        public static List<tbl_bulan> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_bulan] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_bulan].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_bulan].*
                FROM    [tbl_bulan]
            )

            SELECT      [Paging_tbl_bulan].*
            FROM        [Paging_tbl_bulan]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_bulan>(context, new tbl_bulan());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_bulan] by Primary Key
        /// </summary>        
        public static tbl_bulan GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT nama, id FROM tbl_bulan
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_bulan>(context, new tbl_bulan()).FirstOrDefault();
        }

        #endregion

    }
}