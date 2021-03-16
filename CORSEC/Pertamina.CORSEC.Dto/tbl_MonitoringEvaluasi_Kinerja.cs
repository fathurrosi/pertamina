
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_MonitoringEvaluasi_Kinerja : IDataMapper<tbl_MonitoringEvaluasi_Kinerja>
    {
        #region tbl_MonitoringEvaluasi_Kinerja Properties
        public Int64 id { get; set; }
        public string Monitoring_Type { get; set; }
        public string Title { get; set; }
        public Int32? Bulan { get; set; }
        public Int32? Tahun { get; set; }
        public string Priode { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_MonitoringEvaluasi_Kinerja Map(System.Data.IDataReader reader)
        {
            tbl_MonitoringEvaluasi_Kinerja obj = new tbl_MonitoringEvaluasi_Kinerja();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.Monitoring_Type = reader["Monitoring_Type"] == DBNull.Value ? null : reader["Monitoring_Type"].ToString();
            obj.Title = reader["Title"] == DBNull.Value ? null : reader["Title"].ToString();
            obj.Bulan = reader["Bulan"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Bulan"]);
            obj.Tahun = reader["Tahun"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Tahun"]);
            obj.Priode = reader["Priode"] == DBNull.Value ? null : reader["Priode"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}