
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Media_Video : IDataMapper<tbl_Media_Video>
    {
        #region tbl_Media_Video Properties
        public Int64 id { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public Int64? infographic_id { get; set; }
        public string file_type { get; set; }
        public string file_physical_path { get; set; }
        public string file_virtual_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public byte[] file_blob { get; set; }
        public string file_size { get; set; }
        public string file_duration { get; set; }
        #endregion    
        public tbl_Media_Video Map(System.Data.IDataReader reader)
        {
            tbl_Media_Video obj = new tbl_Media_Video();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.infographic_id = reader["infographic_id"] == DBNull.Value ? (Int64?) null : Convert.ToInt64(reader["infographic_id"]);
            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_physical_path = reader["file_physical_path"] == DBNull.Value ? null : reader["file_physical_path"].ToString();
            obj.file_virtual_path = reader["file_virtual_path"] == DBNull.Value ? null : reader["file_virtual_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["file_blob"];
            obj.file_size = reader["file_size"] == DBNull.Value ? null : reader["file_size"].ToString();
            obj.file_duration = reader["file_duration"] == DBNull.Value ? null : reader["file_duration"].ToString();
            return obj;
        }
    }
}