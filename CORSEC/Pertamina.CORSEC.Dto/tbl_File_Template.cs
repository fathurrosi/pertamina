
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_File_Template : IDataMapper<tbl_File_Template>
    {
        #region tbl_File_Template Properties
        public string file_id { get; set; }
        public string ref_name { get; set; }
        public string ref_id { get; set; }
        public string file_type { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public byte[] file_blob { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public string template_header { get; set; }
        public string template_title { get; set; }
        public string template_desc { get; set; }
        public Int32? template_type { get; set; }
        public string file_size { get; set; }
        #endregion    
        public tbl_File_Template Map(System.Data.IDataReader reader)
        {
            tbl_File_Template obj = new tbl_File_Template();   
            obj.file_id = string.Format("{0}",reader["file_id"]);
            obj.ref_name = reader["ref_name"] == DBNull.Value ? null : reader["ref_name"].ToString();
            obj.ref_id = reader["ref_id"] == DBNull.Value ? null : reader["ref_id"].ToString();
            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["file_blob"];
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.template_header = reader["template_header"] == DBNull.Value ? null : reader["template_header"].ToString();
            obj.template_title = reader["template_title"] == DBNull.Value ? null : reader["template_title"].ToString();
            obj.template_desc = reader["template_desc"] == DBNull.Value ? null : reader["template_desc"].ToString();
            obj.template_type = reader["template_type"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["template_type"]);
            obj.file_size = reader["file_size"] == DBNull.Value ? null : reader["file_size"].ToString();
            return obj;
        }
    }
}