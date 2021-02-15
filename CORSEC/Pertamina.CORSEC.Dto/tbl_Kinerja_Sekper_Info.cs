
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Kinerja_Sekper_Info : IDataMapper<tbl_Kinerja_Sekper_Info>
    {
        #region tbl_Kinerja_Sekper_Info Properties
        public Int32 id { get; set; }
        public string header { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_Kinerja_Sekper_Info Map(System.Data.IDataReader reader)
        {
            tbl_Kinerja_Sekper_Info obj = new tbl_Kinerja_Sekper_Info();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.header = reader["header"] == DBNull.Value ? null : reader["header"].ToString();
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}