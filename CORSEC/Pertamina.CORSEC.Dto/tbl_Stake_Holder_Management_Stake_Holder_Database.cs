
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Stake_Holder_Management_Stake_Holder_Database : IDataMapper<tbl_Stake_Holder_Management_Stake_Holder_Database>
    {
        #region tbl_Stake_Holder_Management_Stake_Holder_Database Properties
        public Int64 id { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public string file_type { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public string file_size { get; set; }
        public byte[] file_blob { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public Int32? data_type { get; set; }
        public Int32? year { get; set; }
        #endregion    
        public tbl_Stake_Holder_Management_Stake_Holder_Database Map(System.Data.IDataReader reader)
        {
            tbl_Stake_Holder_Management_Stake_Holder_Database obj = new tbl_Stake_Holder_Management_Stake_Holder_Database();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_size = reader["file_size"] == DBNull.Value ? null : reader["file_size"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["file_blob"];
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.data_type = reader["data_type"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["data_type"]);
            obj.year = reader["year"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["year"]);
            return obj;
        }
    }
}