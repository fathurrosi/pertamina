
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Struktur_Organisasi : IDataMapper<tbl_Struktur_Organisasi>
    {
        #region tbl_Struktur_Organisasi Properties
        public Int32 id { get; set; }
        public string title { get; set; }
        public string sub_title { get; set; }
        public string body { get; set; }
        public string root_text { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_Struktur_Organisasi Map(System.Data.IDataReader reader)
        {
            tbl_Struktur_Organisasi obj = new tbl_Struktur_Organisasi();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.sub_title = reader["sub_title"] == DBNull.Value ? null : reader["sub_title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.root_text = reader["root_text"] == DBNull.Value ? null : reader["root_text"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}