using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Pertamina.CORSEC.Dto.Cstm
{
    public class tbl_Board_Speech_Presentation : IDataMapper<tbl_Board_Speech_Presentation>
    {
        #region tbl_Board_Speech_Presentation Properties
        public Int32 id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public Int32? data_type { get; set; }
        public Int32? data_year { get; set; }

        public string file_id { get; set; }
        public string file_ext { get; set; }
        public string file_size { get; set; }
        public byte[] file_blob { get; set; }
        public string file_type
        {
            get
            {
                return string.Format("{0}", file_ext).Replace(".", "").ToUpper();
            }
        }

        public string file_desc
        {
            get
            {
                return string.IsNullOrEmpty(file_ext) ? "" : string.Format("{0} - {1}", string.Format("{0}", file_ext).Replace(".", "").ToUpper(), file_size);
            }
        }

        public Int64 PAGING_ROW_NUMBER { get; set; }
        #endregion    
        public tbl_Board_Speech_Presentation Map(System.Data.IDataReader reader)
        {
            tbl_Board_Speech_Presentation obj = new tbl_Board_Speech_Presentation();
            obj.id = Convert.ToInt32(reader["id"]);

            obj.file_id = string.Format("{0}", reader["file_id"]);
            obj.file_ext = string.Format("{0}", reader["file_ext"]);
            obj.file_size = string.Format("{0}", reader["file_size"]);
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[])null : (byte[])reader["file_blob"];
            obj.PAGING_ROW_NUMBER = Convert.ToInt64(reader["PAGING_ROW_NUMBER"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.data_type = reader["data_type"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["data_type"]);
            obj.data_year = reader["data_year"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["data_year"]);
            return obj;
        }
    }
}
