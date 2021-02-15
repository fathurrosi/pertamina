
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Footer : IDataMapper<tbl_Footer>
    {
        #region tbl_Footer Properties
        public Int32 id { get; set; }
        public string footer { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_Footer Map(System.Data.IDataReader reader)
        {
            tbl_Footer obj = new tbl_Footer();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.footer = reader["footer"] == DBNull.Value ? null : reader["footer"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}