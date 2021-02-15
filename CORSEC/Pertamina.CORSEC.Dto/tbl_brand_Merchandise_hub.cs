
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_brand_Merchandise_hub : IDataMapper<tbl_brand_Merchandise_hub>
    {
        #region tbl_brand_Merchandise_hub Properties
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
        #endregion    
        public tbl_brand_Merchandise_hub Map(System.Data.IDataReader reader)
        {
            tbl_brand_Merchandise_hub obj = new tbl_brand_Merchandise_hub();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.title = reader["title"] == DBNull.Value ? null : reader["title"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.SKU = reader["SKU"] == DBNull.Value ? null : reader["SKU"].ToString();
            obj.Estimasi_Harga_Mulai = reader["Estimasi_Harga_Mulai"] == DBNull.Value ? (decimal?) null : Convert.ToDecimal(reader["Estimasi_Harga_Mulai"]);
            obj.Estimasi_Harga_Hingga = reader["Estimasi_Harga_Hingga"] == DBNull.Value ? (decimal?) null : Convert.ToDecimal(reader["Estimasi_Harga_Hingga"]);
            obj.Min_Quantity = reader["Min_Quantity"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Min_Quantity"]);
            obj.Kategori = reader["Kategori"] == DBNull.Value ? null : reader["Kategori"].ToString();
            return obj;
        }
    }
}