
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_MonitoringEvaluasi_Media : IDataMapper<tbl_MonitoringEvaluasi_Media>
    {
        #region tbl_MonitoringEvaluasi_Media Properties
        public Int64 id { get; set; }
        public string Monitoring_Type { get; set; }
        public string Title { get; set; }
        public string Media_Type { get; set; }
        public string Tone { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public Int32? TotalArticle { get; set; }
        #endregion    
        public tbl_MonitoringEvaluasi_Media Map(System.Data.IDataReader reader)
        {
            tbl_MonitoringEvaluasi_Media obj = new tbl_MonitoringEvaluasi_Media();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.Monitoring_Type = reader["Monitoring_Type"] == DBNull.Value ? null : reader["Monitoring_Type"].ToString();
            obj.Title = reader["Title"] == DBNull.Value ? null : reader["Title"].ToString();
            obj.Media_Type = reader["Media_Type"] == DBNull.Value ? null : reader["Media_Type"].ToString();
            obj.Tone = reader["Tone"] == DBNull.Value ? null : reader["Tone"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.TotalArticle = reader["TotalArticle"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["TotalArticle"]);
            return obj;
        }
    }
}