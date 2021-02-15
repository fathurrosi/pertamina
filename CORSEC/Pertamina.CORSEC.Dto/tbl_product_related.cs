
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_product_related : IDataMapper<tbl_product_related>
    {
        #region tbl_product_related Properties
        public Int64 id { get; set; }
        public Int64? product_id { get; set; }
        public Int64? product_parent_id { get; set; }
        #endregion    
        public tbl_product_related Map(System.Data.IDataReader reader)
        {
            tbl_product_related obj = new tbl_product_related();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.product_id = reader["product_id"] == DBNull.Value ? (Int64?) null : Convert.ToInt64(reader["product_id"]);
            obj.product_parent_id = reader["product_parent_id"] == DBNull.Value ? (Int64?) null : Convert.ToInt64(reader["product_parent_id"]);
            return obj;
        }
    }
}