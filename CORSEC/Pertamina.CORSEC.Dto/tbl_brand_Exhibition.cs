
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_brand_Exhibition : IDataMapper<tbl_brand_Exhibition>
    {
        #region tbl_brand_Exhibition Properties
        public Int32 id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string location { get; set; }
        public string award { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_brand_Exhibition Map(System.Data.IDataReader reader)
        {
            tbl_brand_Exhibition obj = new tbl_brand_Exhibition();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.location = reader["location"] == DBNull.Value ? null : reader["location"].ToString();
            obj.award = reader["award"] == DBNull.Value ? null : reader["award"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}