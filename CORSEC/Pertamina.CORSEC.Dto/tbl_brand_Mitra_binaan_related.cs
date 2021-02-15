
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_brand_Mitra_binaan_related : IDataMapper<tbl_brand_Mitra_binaan_related>
    {
        #region tbl_brand_Mitra_binaan_related Properties
        public Int64 id { get; set; }
        public Int64? Mitra_binaan_id { get; set; }
        public Int64? Mitra_binaan_parent_id { get; set; }
        #endregion    
        public tbl_brand_Mitra_binaan_related Map(System.Data.IDataReader reader)
        {
            tbl_brand_Mitra_binaan_related obj = new tbl_brand_Mitra_binaan_related();   
            obj.id = Convert.ToInt64(reader["id"]);
            obj.Mitra_binaan_id = reader["Mitra_binaan_id"] == DBNull.Value ? (Int64?) null : Convert.ToInt64(reader["Mitra_binaan_id"]);
            obj.Mitra_binaan_parent_id = reader["Mitra_binaan_parent_id"] == DBNull.Value ? (Int64?) null : Convert.ToInt64(reader["Mitra_binaan_parent_id"]);
            return obj;
        }
    }
}