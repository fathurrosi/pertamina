
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_brand_Mitra_binaan_wishlist : IDataMapper<tbl_brand_Mitra_binaan_wishlist>
    {
        #region tbl_brand_Mitra_binaan_wishlist Properties
        public Int64 id { get; set; }
        public Int32? Mitra_binaan_id { get; set; }
        public string Username { get; set; }
        public DateTime? Created { get; set; }
        #endregion    
        public tbl_brand_Mitra_binaan_wishlist Map(System.Data.IDataReader reader)
        {
            tbl_brand_Mitra_binaan_wishlist obj = new tbl_brand_Mitra_binaan_wishlist();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.Mitra_binaan_id = reader["Mitra_binaan_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Mitra_binaan_id"]);
            obj.Username = reader["Username"] == DBNull.Value ? null : reader["Username"].ToString();
            obj.Created = reader["Created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["Created"]);
            return obj;
        }
    }
}