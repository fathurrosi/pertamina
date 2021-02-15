
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_brand_Communication_Campaign_logo : IDataMapper<tbl_brand_Communication_Campaign_logo>
    {
        #region tbl_brand_Communication_Campaign_logo Properties
        public Int32 id { get; set; }
        public string file_type { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public byte[] file_blob { get; set; }
        public string file_size { get; set; }
        public Int32? logo_type { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_brand_Communication_Campaign_logo Map(System.Data.IDataReader reader)
        {
            tbl_brand_Communication_Campaign_logo obj = new tbl_brand_Communication_Campaign_logo();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["file_blob"];
            obj.file_size = reader["file_size"] == DBNull.Value ? null : reader["file_size"].ToString();
            obj.logo_type = reader["logo_type"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["logo_type"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}