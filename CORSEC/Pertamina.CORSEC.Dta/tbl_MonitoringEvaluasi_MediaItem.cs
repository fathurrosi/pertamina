
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_MonitoringEvaluasi_Media]
    /// </summary>    
    public partial class tbl_MonitoringEvaluasi_MediaItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_MonitoringEvaluasi_Media]
        /// </summary>        
        public static tbl_MonitoringEvaluasi_Media Insert(tbl_MonitoringEvaluasi_Media obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_MonitoringEvaluasi_Media]([Monitoring_Type], [Title], [Media_Type], [Tone], [created], [created_by], [TotalArticle]) 
VALUES      (@Monitoring_Type, @Title, @Media_Type, @Tone, @created, @created_by, @TotalArticle)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, Monitoring_Type, Title, Media_Type, Tone, created, created_by, updated, updated_by, TotalArticle
FROM    [tbl_MonitoringEvaluasi_Media]
WHERE   [id]  = @_id";
            context.AddParameter("@Monitoring_Type", string.Format("{0}", obj.Monitoring_Type));
            context.AddParameter("@Title", string.Format("{0}", obj.Title));
            context.AddParameter("@Media_Type", string.Format("{0}", obj.Media_Type));
            context.AddParameter("@Tone", string.Format("{0}", obj.Tone));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@TotalArticle", obj.TotalArticle);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_MonitoringEvaluasi_Media>(context, new tbl_MonitoringEvaluasi_Media()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_MonitoringEvaluasi_Media]
        /// </summary>        
        public static tbl_MonitoringEvaluasi_Media Update(tbl_MonitoringEvaluasi_Media obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_MonitoringEvaluasi_Media]
SET         [Monitoring_Type] = @Monitoring_Type,
            [Title] = @Title,
            [Media_Type] = @Media_Type,
            [Tone] = @Tone,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [TotalArticle] = @TotalArticle
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, Monitoring_Type, Title, Media_Type, Tone, created, created_by, updated, updated_by, TotalArticle 
FROM    [tbl_MonitoringEvaluasi_Media]
WHERE   [id]  = @id";
            context.AddParameter("@Monitoring_Type", string.Format("{0}", obj.Monitoring_Type));
            context.AddParameter("@Title", string.Format("{0}", obj.Title));
            context.AddParameter("@Media_Type", string.Format("{0}", obj.Media_Type));
            context.AddParameter("@Tone", string.Format("{0}", obj.Tone));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@TotalArticle", obj.TotalArticle);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_MonitoringEvaluasi_Media>(context, new tbl_MonitoringEvaluasi_Media()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_MonitoringEvaluasi_Media]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_MonitoringEvaluasi_Media 
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
        /// Get Total records from [tbl_MonitoringEvaluasi_Media]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_MonitoringEvaluasi_Media";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_MonitoringEvaluasi_Media]
        /// </summary>        
        public static List<tbl_MonitoringEvaluasi_Media> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, Monitoring_Type, Title, Media_Type, Tone, created, created_by, updated, updated_by, TotalArticle FROM tbl_MonitoringEvaluasi_Media";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_MonitoringEvaluasi_Media>(context, new tbl_MonitoringEvaluasi_Media());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_MonitoringEvaluasi_Media]
        /// </summary>        
        public static List<tbl_MonitoringEvaluasi_Media> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_MonitoringEvaluasi_Media] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_MonitoringEvaluasi_Media].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_MonitoringEvaluasi_Media].*
                FROM    [tbl_MonitoringEvaluasi_Media]
            )

            SELECT      [Paging_tbl_MonitoringEvaluasi_Media].*
            FROM        [Paging_tbl_MonitoringEvaluasi_Media]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_MonitoringEvaluasi_Media>(context, new tbl_MonitoringEvaluasi_Media());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_MonitoringEvaluasi_Media] by Primary Key
        /// </summary>        
        public static tbl_MonitoringEvaluasi_Media GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, Monitoring_Type, Title, Media_Type, Tone, created, created_by, updated, updated_by, TotalArticle FROM tbl_MonitoringEvaluasi_Media
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_MonitoringEvaluasi_Media>(context, new tbl_MonitoringEvaluasi_Media()).FirstOrDefault();
        }

        #endregion

    }
}