using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Pertamina.CORSEC.Dto.Cstm
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

        public string file_id{ get; set; }
        //public string file_path { get; set; }
        //public string file_name { get; set; }
        public string file_ext { get; set; }
        public byte[] file_blob { get; set; }

        public tbl_Kinerja_Sekper Map(System.Data.IDataReader reader)
        {
            tbl_Kinerja_Sekper obj = new tbl_Kinerja_Sekper();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.semester = reader["semester"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["semester"]);
            obj.tahun = reader["tahun"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["tahun"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();

            obj.file_id= reader["file_id"] == DBNull.Value ? null : reader["file_id"].ToString();
            //obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            //obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[])null : (byte[])reader["file_blob"];
            return obj;
        }
    }
}
