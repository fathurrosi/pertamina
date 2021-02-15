using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Pertamina.CORSEC.Dto.Cstm
{
    public class tbl_brand_Mitra_binaan_related : IDataMapper<tbl_brand_Mitra_binaan_related>
    {
        #region tbl_brand_Mitra_binaan Properties
        public Int32 id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public string SKU { get; set; }
        public decimal? Estimasi_Harga_Mulai { get; set; }
        public decimal? Estimasi_Harga_Hingga { get; set; }
        public Int32? Min_Quantity { get; set; }
        public string Kategori { get; set; }

        public string file_type { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public byte[] file_blob { get; set; }
        public string file_size { get; set; }

        public int Mitra_binaan_parent_id { get; set; }
        public int Mitra_binaan_id { get; set; }
        #endregion    
        public tbl_brand_Mitra_binaan_related Map(System.Data.IDataReader reader)
        {
            tbl_brand_Mitra_binaan_related obj = new tbl_brand_Mitra_binaan_related();
            obj.id = Convert.ToInt32(reader["id"]);
            obj.Mitra_binaan_parent_id = reader["Mitra_binaan_parent_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Mitra_binaan_parent_id"]);
            obj.Mitra_binaan_id = reader["Mitra_binaan_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Mitra_binaan_id"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.SKU = reader["SKU"] == DBNull.Value ? null : reader["SKU"].ToString();
            obj.Estimasi_Harga_Mulai = reader["Estimasi_Harga_Mulai"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Estimasi_Harga_Mulai"]);
            obj.Estimasi_Harga_Hingga = reader["Estimasi_Harga_Hingga"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Estimasi_Harga_Hingga"]);
            obj.Min_Quantity = reader["Min_Quantity"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["Min_Quantity"]);
            obj.Kategori = reader["Kategori"] == DBNull.Value ? null : reader["Kategori"].ToString();
            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[])null : (byte[])reader["file_blob"];
            obj.file_size = reader["file_size"] == DBNull.Value ? null : reader["file_size"].ToString();
            return obj;
        }
    }
}
