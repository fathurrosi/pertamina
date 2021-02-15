
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Kinerja_Sekper : IDataMapper<tbl_Kinerja_Sekper>
    {
        #region tbl_Kinerja_Sekper Properties
        public Int32 id { get; set; }
        public Int32? semester { get; set; }
        public Int32? tahun { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_Kinerja_Sekper Map(System.Data.IDataReader reader)
        {
            tbl_Kinerja_Sekper obj = new tbl_Kinerja_Sekper();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.semester = reader["semester"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["semester"]);
            obj.tahun = reader["tahun"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["tahun"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}