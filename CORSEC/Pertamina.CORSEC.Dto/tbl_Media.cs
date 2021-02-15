
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Media : IDataMapper<tbl_Media>
    {
        #region tbl_Media Properties
        public Int64 id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public Int32? infographic_type { get; set; }
        public Int32? infographic_year { get; set; }
        public string img_type { get; set; }
        public string img_path { get; set; }
        public string img_name { get; set; }
        public string img_ext { get; set; }
        public byte[] img_blob { get; set; }
        public string img_size { get; set; }
        #endregion    
        public tbl_Media Map(System.Data.IDataReader reader)
        {
            tbl_Media obj = new tbl_Media();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.infographic_type = reader["infographic_type"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["infographic_type"]);
            obj.infographic_year = reader["infographic_year"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["infographic_year"]);
            obj.img_type = reader["img_type"] == DBNull.Value ? null : reader["img_type"].ToString();
            obj.img_path = reader["img_path"] == DBNull.Value ? null : reader["img_path"].ToString();
            obj.img_name = reader["img_name"] == DBNull.Value ? null : reader["img_name"].ToString();
            obj.img_ext = reader["img_ext"] == DBNull.Value ? null : reader["img_ext"].ToString();
            obj.img_blob = reader["img_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["img_blob"];
            obj.img_size = reader["img_size"] == DBNull.Value ? null : reader["img_size"].ToString();
            return obj;
        }
    }
}