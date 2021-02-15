
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Footer_Detail : IDataMapper<tbl_Footer_Detail>
    {
        #region tbl_Footer_Detail Properties
        public Int32 id { get; set; }
        public Int32? footer { get; set; }
        public string footer_text { get; set; }
        public string footer_link { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_Footer_Detail Map(System.Data.IDataReader reader)
        {
            tbl_Footer_Detail obj = new tbl_Footer_Detail();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.footer = reader["footer"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["footer"]);
            obj.footer_text = reader["footer_text"] == DBNull.Value ? null : reader["footer_text"].ToString();
            obj.footer_link = reader["footer_link"] == DBNull.Value ? null : reader["footer_link"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}