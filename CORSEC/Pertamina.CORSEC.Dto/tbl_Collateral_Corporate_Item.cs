
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Collateral_Corporate_Item : IDataMapper<tbl_Collateral_Corporate_Item>
    {
        #region tbl_Collateral_Corporate_Item Properties
        public Int32 id { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public Int32? year { get; set; }
        public Int32? seq { get; set; }
        public string calender_type { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_Collateral_Corporate_Item Map(System.Data.IDataReader reader)
        {
            tbl_Collateral_Corporate_Item obj = new tbl_Collateral_Corporate_Item();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.category = reader["category"] == DBNull.Value ? null : reader["category"].ToString();
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.year = reader["year"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["year"]);
            obj.seq = reader["seq"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["seq"]);
            obj.calender_type = reader["calender_type"] == DBNull.Value ? null : reader["calender_type"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}