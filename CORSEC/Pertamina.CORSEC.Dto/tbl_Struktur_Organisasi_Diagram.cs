
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Struktur_Organisasi_Diagram : IDataMapper<tbl_Struktur_Organisasi_Diagram>
    {
        #region tbl_Struktur_Organisasi_Diagram Properties
        public Int32 id { get; set; }
        public Int32? jabatan_id { get; set; }
        public string jabatan_nama { get; set; }
        public Int32? parent_id { get; set; }
        public Int32? parent_jabatan_id { get; set; }
        public string parent_jabatan_nama { get; set; }
        public Int32? seq { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public Int32? group_id { get; set; }
        #endregion    
        public tbl_Struktur_Organisasi_Diagram Map(System.Data.IDataReader reader)
        {
            tbl_Struktur_Organisasi_Diagram obj = new tbl_Struktur_Organisasi_Diagram();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.jabatan_id = reader["jabatan_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["jabatan_id"]);
            obj.jabatan_nama = reader["jabatan_nama"] == DBNull.Value ? null : reader["jabatan_nama"].ToString();
            obj.parent_id = reader["parent_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["parent_id"]);
            obj.parent_jabatan_id = reader["parent_jabatan_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["parent_jabatan_id"]);
            obj.parent_jabatan_nama = reader["parent_jabatan_nama"] == DBNull.Value ? null : reader["parent_jabatan_nama"].ToString();
            obj.seq = reader["seq"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["seq"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.group_id = reader["group_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["group_id"]);
            return obj;
        }
    }
}