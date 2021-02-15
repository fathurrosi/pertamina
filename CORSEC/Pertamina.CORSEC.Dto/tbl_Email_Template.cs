
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Email_Template : IDataMapper<tbl_Email_Template>
    {
        #region tbl_Email_Template Properties
        public string code { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public string body_backup { get; set; }
        #endregion    
        public tbl_Email_Template Map(System.Data.IDataReader reader)
        {
            tbl_Email_Template obj = new tbl_Email_Template();   
            obj.code = string.Format("{0}",reader["code"]);
            obj.subject = reader["subject"] == DBNull.Value ? null : reader["subject"].ToString();
            obj.body = reader["body"] == DBNull.Value ? null : reader["body"].ToString();
            obj.body_backup = reader["body_backup"] == DBNull.Value ? null : reader["body_backup"].ToString();
            return obj;
        }
    }
}