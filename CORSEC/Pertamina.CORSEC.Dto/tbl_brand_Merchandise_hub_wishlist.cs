
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_brand_Merchandise_hub_wishlist : IDataMapper<tbl_brand_Merchandise_hub_wishlist>
    {
        #region tbl_brand_Merchandise_hub_wishlist Properties
        public Int64 id { get; set; }
        public Int32? Merchandise_hub_id { get; set; }
        public string Username { get; set; }
        public DateTime? Created { get; set; }
        #endregion    
        public tbl_brand_Merchandise_hub_wishlist Map(System.Data.IDataReader reader)
        {
            tbl_brand_Merchandise_hub_wishlist obj = new tbl_brand_Merchandise_hub_wishlist();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.Merchandise_hub_id = reader["Merchandise_hub_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Merchandise_hub_id"]);
            obj.Username = reader["Username"] == DBNull.Value ? null : reader["Username"].ToString();
            obj.Created = reader["Created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["Created"]);
            return obj;
        }
    }
}