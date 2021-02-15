
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Profile_Strategic_Partner : IDataMapper<tbl_Profile_Strategic_Partner>
    {
        #region tbl_Profile_Strategic_Partner Properties
        public Int32 id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public string tab_text { get; set; }
        #endregion    
        public tbl_Profile_Strategic_Partner Map(System.Data.IDataReader reader)
        {
            tbl_Profile_Strategic_Partner obj = new tbl_Profile_Strategic_Partner();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.tab_text = reader["tab_text"] == DBNull.Value ? null : reader["tab_text"].ToString();
            return obj;
        }
    }
}