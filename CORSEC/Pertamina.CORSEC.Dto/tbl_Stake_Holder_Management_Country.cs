
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Stake_Holder_Management_Country : IDataMapper<tbl_Stake_Holder_Management_Country>
    {
        #region tbl_Stake_Holder_Management_Country Properties
        public Int64 id { get; set; }
        public string country { get; set; }
        public Int32? sequence { get; set; }
        public Int32? deleted { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_Stake_Holder_Management_Country Map(System.Data.IDataReader reader)
        {
            tbl_Stake_Holder_Management_Country obj = new tbl_Stake_Holder_Management_Country();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.country = reader["country"] == DBNull.Value ? null : reader["country"].ToString();
            obj.sequence = reader["sequence"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["sequence"]);
            obj.deleted = reader["deleted"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["deleted"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}