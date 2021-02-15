
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_CorporateCommunication_Corporate : IDataMapper<tbl_CorporateCommunication_Corporate>
    {
        #region tbl_CorporateCommunication_Corporate Properties
        public Int64 id { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public string file_type { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public string file_size { get; set; }
        public byte[] file_blob { get; set; }
        public Int32? downloaded { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string Jenis_Laporan { get; set; }
        public Int32? Laporan_Bulanan_Fungsi { get; set; }
        public Int32? Laporan_Bulanan_Unit { get; set; }
        public Int32? Laporan_Bulanan_Region { get; set; }
        public Int32? Laporan_Triwulan_QPI_Fungsi { get; set; }
        public Int32? Laporan_Triwulan_QPI_Unit { get; set; }
        public Int32? Laporan_Triwulan_QPI_Region { get; set; }
        public DateTime? last_downloaded { get; set; }
        #endregion    
        public tbl_CorporateCommunication_Corporate Map(System.Data.IDataReader reader)
        {
            tbl_CorporateCommunication_Corporate obj = new tbl_CorporateCommunication_Corporate();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_size = reader["file_size"] == DBNull.Value ? null : reader["file_size"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["file_blob"];
            obj.downloaded = reader["downloaded"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["downloaded"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.Jenis_Laporan = reader["Jenis_Laporan"] == DBNull.Value ? null : reader["Jenis_Laporan"].ToString();
            obj.Laporan_Bulanan_Fungsi = reader["Laporan_Bulanan_Fungsi"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Laporan_Bulanan_Fungsi"]);
            obj.Laporan_Bulanan_Unit = reader["Laporan_Bulanan_Unit"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Laporan_Bulanan_Unit"]);
            obj.Laporan_Bulanan_Region = reader["Laporan_Bulanan_Region"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Laporan_Bulanan_Region"]);
            obj.Laporan_Triwulan_QPI_Fungsi = reader["Laporan_Triwulan_QPI_Fungsi"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Laporan_Triwulan_QPI_Fungsi"]);
            obj.Laporan_Triwulan_QPI_Unit = reader["Laporan_Triwulan_QPI_Unit"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Laporan_Triwulan_QPI_Unit"]);
            obj.Laporan_Triwulan_QPI_Region = reader["Laporan_Triwulan_QPI_Region"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Laporan_Triwulan_QPI_Region"]);
            obj.last_downloaded = reader["last_downloaded"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["last_downloaded"]);
            return obj;
        }
    }
}