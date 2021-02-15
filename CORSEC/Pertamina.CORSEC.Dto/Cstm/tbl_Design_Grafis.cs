using System;
using DataAccessLayer;

namespace Pertamina.CORSEC.Dto.Cstm
{
    public class tbl_Design_Grafis : IDataMapper<tbl_Design_Grafis>
    {
        #region tbl_Design_Grafis Properties
        public Int64 id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public Int32? data_type { get; set; }
        public string img_type { get; set; }
        public string img_path { get; set; }
        public string img_name { get; set; }
        public string img_ext { get; set; }
        public byte[] img_blob { get; set; }
        public string img_size { get; set; }

        public string file_type { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public byte[] file_blob { get; set; }
        public string file_size { get; set; }
        #endregion    
        public tbl_Design_Grafis Map(System.Data.IDataReader reader)
        {
            tbl_Design_Grafis obj = new tbl_Design_Grafis();
            obj.id = Convert.ToInt64(reader["id"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.data_type = reader["data_type"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["data_type"]);
            obj.img_type = reader["img_type"] == DBNull.Value ? null : reader["img_type"].ToString();
            obj.img_path = reader["img_path"] == DBNull.Value ? null : reader["img_path"].ToString();
            obj.img_name = reader["img_name"] == DBNull.Value ? null : reader["img_name"].ToString();
            obj.img_ext = reader["img_ext"] == DBNull.Value ? null : reader["img_ext"].ToString();
            obj.img_blob = reader["img_blob"] == DBNull.Value ? (byte[])null : (byte[])reader["img_blob"];
            obj.img_size = reader["img_size"] == DBNull.Value ? null : reader["img_size"].ToString();

            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[])null : (byte[])reader["file_blob"];
            obj.file_size = reader["file_size"] == DBNull.Value ? null : reader["file_size"].ToString();
            return obj;
        }
    }
}
