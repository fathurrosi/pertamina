
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_product_File : IDataMapper<tbl_product_File>
    {
        #region tbl_product_File Properties
        public Int32 id { get; set; }
        public string file_type { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public byte[] file_blob { get; set; }
        public string file_size { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public Int32? product_id { get; set; }
        public string file_desc { get; set; }
        public Int32? Merchandise_Type { get; set; }
        #endregion    
        public tbl_product_File Map(System.Data.IDataReader reader)
        {
            tbl_product_File obj = new tbl_product_File();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["file_blob"];
            obj.file_size = reader["file_size"] == DBNull.Value ? null : reader["file_size"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.product_id = reader["product_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["product_id"]);
            obj.file_desc = reader["file_desc"] == DBNull.Value ? null : reader["file_desc"].ToString();
            obj.Merchandise_Type = reader["Merchandise_Type"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Merchandise_Type"]);
            return obj;
        }
    }
}