
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_brand_Communication_Campaign_user_manual : IDataMapper<tbl_brand_Communication_Campaign_user_manual>
    {
        #region tbl_brand_Communication_Campaign_user_manual Properties
        public Int32 id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public Int32? logo_type { get; set; }
        public string file_type { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public byte[] file_blob { get; set; }
        public string file_size { get; set; }
        public string image_type { get; set; }
        public string image_path { get; set; }
        public string image_name { get; set; }
        public string image_ext { get; set; }
        public byte[] image_blob { get; set; }
        public string image_size { get; set; }
        public string image_desc { get; set; }
        #endregion    
        public tbl_brand_Communication_Campaign_user_manual Map(System.Data.IDataReader reader)
        {
            tbl_brand_Communication_Campaign_user_manual obj = new tbl_brand_Communication_Campaign_user_manual();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.logo_type = reader["logo_type"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["logo_type"]);
            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["file_blob"];
            obj.file_size = reader["file_size"] == DBNull.Value ? null : reader["file_size"].ToString();
            obj.image_type = reader["image_type"] == DBNull.Value ? null : reader["image_type"].ToString();
            obj.image_path = reader["image_path"] == DBNull.Value ? null : reader["image_path"].ToString();
            obj.image_name = reader["image_name"] == DBNull.Value ? null : reader["image_name"].ToString();
            obj.image_ext = reader["image_ext"] == DBNull.Value ? null : reader["image_ext"].ToString();
            obj.image_blob = reader["image_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["image_blob"];
            obj.image_size = reader["image_size"] == DBNull.Value ? null : reader["image_size"].ToString();
            obj.image_desc = reader["image_desc"] == DBNull.Value ? null : reader["image_desc"].ToString();
            return obj;
        }
    }
}