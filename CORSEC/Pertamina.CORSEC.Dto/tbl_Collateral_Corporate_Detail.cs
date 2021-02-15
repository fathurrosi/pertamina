
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Collateral_Corporate_Detail : IDataMapper<tbl_Collateral_Corporate_Detail>
    {
        #region tbl_Collateral_Corporate_Detail Properties
        public Int32 id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public Int32? seq { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public string category { get; set; }
        #endregion    
        public tbl_Collateral_Corporate_Detail Map(System.Data.IDataReader reader)
        {
            tbl_Collateral_Corporate_Detail obj = new tbl_Collateral_Corporate_Detail();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.title = string.Format("{0}",reader["title"]);
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.seq = reader["seq"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["seq"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.category = reader["category"] == DBNull.Value ? null : reader["category"].ToString();
            return obj;
        }
    }
}