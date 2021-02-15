
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_brand_guideline : IDataMapper<tbl_brand_guideline>
    {
        #region tbl_brand_guideline Properties
        public Int32 id { get; set; }
        public string logo_name { get; set; }
        public string file_type { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public byte[] file_blob { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public string file_size { get; set; }
        public Int32? logo_type { get; set; }
        #endregion    
        public tbl_brand_guideline Map(System.Data.IDataReader reader)
        {
            tbl_brand_guideline obj = new tbl_brand_guideline();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.logo_name = reader["logo_name"] == DBNull.Value ? null : reader["logo_name"].ToString();
            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["file_blob"];
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.file_size = reader["file_size"] == DBNull.Value ? null : reader["file_size"].ToString();
            obj.logo_type = reader["logo_type"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["logo_type"]);
            return obj;
        }
    }
}