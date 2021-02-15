
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Program : IDataMapper<tbl_Program>
    {
        #region tbl_Program Properties
        public Int32 id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public Int32? prog_type { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public Int32? img_position { get; set; }
        #endregion    
        public tbl_Program Map(System.Data.IDataReader reader)
        {
            tbl_Program obj = new tbl_Program();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.prog_type = reader["prog_type"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["prog_type"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.img_position = reader["img_position"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["img_position"]);
            return obj;
        }
    }
}