
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_product_wishlist : IDataMapper<tbl_product_wishlist>
    {
        #region tbl_product_wishlist Properties
        public Int64 id { get; set; }
        public Int32? product_id { get; set; }
        public string Username { get; set; }
        public DateTime? Created { get; set; }
        #endregion    
        public tbl_product_wishlist Map(System.Data.IDataReader reader)
        {
            tbl_product_wishlist obj = new tbl_product_wishlist();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.product_id = reader["product_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["product_id"]);
            obj.Username = reader["Username"] == DBNull.Value ? null : reader["Username"].ToString();
            obj.Created = reader["Created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["Created"]);
            return obj;
        }
    }
}