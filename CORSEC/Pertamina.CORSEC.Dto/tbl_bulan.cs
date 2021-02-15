
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_bulan : IDataMapper<tbl_bulan>
    {
        #region tbl_bulan Properties
        public string nama { get; set; }
        public Int32 id { get; set; }
        #endregion    
        public tbl_bulan Map(System.Data.IDataReader reader)
        {
            tbl_bulan obj = new tbl_bulan();   
            obj.nama = reader["nama"] == DBNull.Value ? null : reader["nama"].ToString();
            obj.id = Convert.ToInt32(reader["id"]);
            return obj;
        }
    }
}