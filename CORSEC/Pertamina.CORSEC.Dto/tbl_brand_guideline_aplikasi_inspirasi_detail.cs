
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_brand_guideline_aplikasi_inspirasi_detail : IDataMapper<tbl_brand_guideline_aplikasi_inspirasi_detail>
    {
        #region tbl_brand_guideline_aplikasi_inspirasi_detail Properties
        public Int32 id { get; set; }
        public Int32? logo_type { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string image_type { get; set; }
        public string image_path { get; set; }
        public string image_name { get; set; }
        public string image_ext { get; set; }
        public byte[] image_blob { get; set; }
        public string image_size { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_brand_guideline_aplikasi_inspirasi_detail Map(System.Data.IDataReader reader)
        {
            tbl_brand_guideline_aplikasi_inspirasi_detail obj = new tbl_brand_guideline_aplikasi_inspirasi_detail();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.logo_type = reader["logo_type"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["logo_type"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.image_type = reader["image_type"] == DBNull.Value ? null : reader["image_type"].ToString();
            obj.image_path = reader["image_path"] == DBNull.Value ? null : reader["image_path"].ToString();
            obj.image_name = reader["image_name"] == DBNull.Value ? null : reader["image_name"].ToString();
            obj.image_ext = reader["image_ext"] == DBNull.Value ? null : reader["image_ext"].ToString();
            obj.image_blob = reader["image_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["image_blob"];
            obj.image_size = reader["image_size"] == DBNull.Value ? null : reader["image_size"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}