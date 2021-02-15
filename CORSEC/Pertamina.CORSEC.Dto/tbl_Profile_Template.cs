
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Profile_Template : IDataMapper<tbl_Profile_Template>
    {
        #region tbl_Profile_Template Properties
        public Int32 id { get; set; }
        public string header { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public string header_type { get; set; }
        #endregion    
        public tbl_Profile_Template Map(System.Data.IDataReader reader)
        {
            tbl_Profile_Template obj = new tbl_Profile_Template();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.header = reader["header"] == DBNull.Value ? null : reader["header"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.header_type = reader["header_type"] == DBNull.Value ? null : reader["header_type"].ToString();
            return obj;
        }
    }
}