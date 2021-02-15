
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_product_contact_person : IDataMapper<tbl_product_contact_person>
    {
        #region tbl_product_contact_person Properties
        public Int32 id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        #endregion    
        public tbl_product_contact_person Map(System.Data.IDataReader reader)
        {
            tbl_product_contact_person obj = new tbl_product_contact_person();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.name = reader["name"] == DBNull.Value ? null : reader["name"].ToString();
            obj.phone = reader["phone"] == DBNull.Value ? null : reader["phone"].ToString();
            obj.email = reader["email"] == DBNull.Value ? null : reader["email"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            return obj;
        }
    }
}