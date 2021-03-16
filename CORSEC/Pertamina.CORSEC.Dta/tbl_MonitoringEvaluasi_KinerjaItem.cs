
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_MonitoringEvaluasi_Kinerja]
    /// </summary>    
    public partial class tbl_MonitoringEvaluasi_KinerjaItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_MonitoringEvaluasi_Kinerja]
        /// </summary>        
        public static tbl_MonitoringEvaluasi_Kinerja Insert(tbl_MonitoringEvaluasi_Kinerja obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_MonitoringEvaluasi_Kinerja]([Monitoring_Type], [Title], [Bulan], [Tahun], [Priode], [created], [created_by]) 
VALUES      (@Monitoring_Type, @Title, @Bulan, @Tahun, @Priode, @created, @created_by)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, Monitoring_Type, Title, Bulan, Tahun, Priode, created, created_by, updated, updated_by
FROM    [tbl_MonitoringEvaluasi_Kinerja]
WHERE   [id]  = @_id";
            context.AddParameter("@Monitoring_Type", string.Format("{0}", obj.Monitoring_Type));
            context.AddParameter("@Title", string.Format("{0}", obj.Title));
            context.AddParameter("@Bulan", obj.Bulan);
            context.AddParameter("@Tahun", obj.Tahun);
            context.AddParameter("@Priode", string.Format("{0}", obj.Priode));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_MonitoringEvaluasi_Kinerja>(context, new tbl_MonitoringEvaluasi_Kinerja()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_MonitoringEvaluasi_Kinerja]
        /// </summary>        
        public static tbl_MonitoringEvaluasi_Kinerja Update(tbl_MonitoringEvaluasi_Kinerja obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_MonitoringEvaluasi_Kinerja]
SET         [Monitoring_Type] = @Monitoring_Type,
            [Title] = @Title,
            [Bulan] = @Bulan,
            [Tahun] = @Tahun,
            [Priode] = @Priode,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, Monitoring_Type, Title, Bulan, Tahun, Priode, created, created_by, updated, updated_by 
FROM    [tbl_MonitoringEvaluasi_Kinerja]
WHERE   [id]  = @id";
            context.AddParameter("@Monitoring_Type", string.Format("{0}", obj.Monitoring_Type));
            context.AddParameter("@Title", string.Format("{0}", obj.Title));
            context.AddParameter("@Bulan", obj.Bulan);
            context.AddParameter("@Tahun", obj.Tahun);
            context.AddParameter("@Priode", string.Format("{0}", obj.Priode));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_MonitoringEvaluasi_Kinerja>(context, new tbl_MonitoringEvaluasi_Kinerja()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_MonitoringEvaluasi_Kinerja]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_MonitoringEvaluasi_Kinerja 
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
        /// Get Total records from [tbl_MonitoringEvaluasi_Kinerja]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_MonitoringEvaluasi_Kinerja";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_MonitoringEvaluasi_Kinerja]
        /// </summary>        
        public static List<tbl_MonitoringEvaluasi_Kinerja> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, Monitoring_Type, Title, Bulan, Tahun, Priode, created, created_by, updated, updated_by FROM tbl_MonitoringEvaluasi_Kinerja";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_MonitoringEvaluasi_Kinerja>(context, new tbl_MonitoringEvaluasi_Kinerja());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_MonitoringEvaluasi_Kinerja]
        /// </summary>        
        public static List<tbl_MonitoringEvaluasi_Kinerja> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_MonitoringEvaluasi_Kinerja] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_MonitoringEvaluasi_Kinerja].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_MonitoringEvaluasi_Kinerja].*
                FROM    [tbl_MonitoringEvaluasi_Kinerja]
            )

            SELECT      [Paging_tbl_MonitoringEvaluasi_Kinerja].*
            FROM        [Paging_tbl_MonitoringEvaluasi_Kinerja]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_MonitoringEvaluasi_Kinerja>(context, new tbl_MonitoringEvaluasi_Kinerja());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_MonitoringEvaluasi_Kinerja] by Primary Key
        /// </summary>        
        public static tbl_MonitoringEvaluasi_Kinerja GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, Monitoring_Type, Title, Bulan, Tahun, Priode, created, created_by, updated, updated_by FROM tbl_MonitoringEvaluasi_Kinerja
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_MonitoringEvaluasi_Kinerja>(context, new tbl_MonitoringEvaluasi_Kinerja()).FirstOrDefault();
        }

        #endregion

    }
}