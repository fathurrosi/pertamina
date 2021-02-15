
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Design_Grafis_File : IDataMapper<tbl_Design_Grafis_File>
    {
        #region tbl_Design_Grafis_File Properties
        public Int64 id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public Int64? design_grafis_id { get; set; }
        public string file_type { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public byte[] file_blob { get; set; }
        public string file_size { get; set; }
        #endregion    
        public tbl_Design_Grafis_File Map(System.Data.IDataReader reader)
        {
            tbl_Design_Grafis_File obj = new tbl_Design_Grafis_File();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.design_grafis_id = reader["design_grafis_id"] == DBNull.Value ? (Int64?) null : Convert.ToInt64(reader["design_grafis_id"]);
            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["file_blob"];
            obj.file_size = reader["file_size"] == DBNull.Value ? null : reader["file_size"].ToString();
            return obj;
        }
    }
}