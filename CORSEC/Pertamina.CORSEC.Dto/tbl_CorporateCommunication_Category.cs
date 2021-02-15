
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_CorporateCommunication_Category : IDataMapper<tbl_CorporateCommunication_Category>
    {
        #region tbl_CorporateCommunication_Category Properties
        public Int64 id { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public string Name { get; set; }
        public Int32? Deleted { get; set; }
        public Int32? Sequence { get; set; }
        #endregion    
        public tbl_CorporateCommunication_Category Map(System.Data.IDataReader reader)
        {
            tbl_CorporateCommunication_Category obj = new tbl_CorporateCommunication_Category();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
            obj.Deleted = reader["Deleted"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Deleted"]);
            obj.Sequence = reader["Sequence"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Sequence"]);
            return obj;
        }
    }
}