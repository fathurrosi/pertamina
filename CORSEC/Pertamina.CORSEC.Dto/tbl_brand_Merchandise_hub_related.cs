
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_brand_Merchandise_hub_related : IDataMapper<tbl_brand_Merchandise_hub_related>
    {
        #region tbl_brand_Merchandise_hub_related Properties
        public Int64 id { get; set; }
        public Int64? Merchandise_hub_id { get; set; }
        public Int64? Merchandise_hub_parent_id { get; set; }
        #endregion    
        public tbl_brand_Merchandise_hub_related Map(System.Data.IDataReader reader)
        {
            tbl_brand_Merchandise_hub_related obj = new tbl_brand_Merchandise_hub_related();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.Merchandise_hub_id = reader["Merchandise_hub_id"] == DBNull.Value ? (Int64?) null : Convert.ToInt64(reader["Merchandise_hub_id"]);
            obj.Merchandise_hub_parent_id = reader["Merchandise_hub_parent_id"] == DBNull.Value ? (Int64?) null : Convert.ToInt64(reader["Merchandise_hub_parent_id"]);
            return obj;
        }
    }
}