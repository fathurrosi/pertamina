
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Guidelines_Doc : IDataMapper<tbl_Guidelines_Doc>
    {
        #region tbl_Guidelines_Doc Properties
        public Int64 id { get; set; }
        public string No_Dokumen { get; set; }
        public string Tipe_Dokumen { get; set; }
        public string Judul { get; set; }
        public Int32? Tahun { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_Guidelines_Doc Map(System.Data.IDataReader reader)
        {
            tbl_Guidelines_Doc obj = new tbl_Guidelines_Doc();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.No_Dokumen = reader["No_Dokumen"] == DBNull.Value ? null : reader["No_Dokumen"].ToString();
            obj.Tipe_Dokumen = reader["Tipe_Dokumen"] == DBNull.Value ? null : reader["Tipe_Dokumen"].ToString();
            obj.Judul = reader["Judul"] == DBNull.Value ? null : reader["Judul"].ToString();
            obj.Tahun = reader["Tahun"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Tahun"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}