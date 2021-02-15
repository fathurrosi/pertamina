
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace Pertamina.CORSEC.Dto
{
    public class tbl_Profile_Visi_Misi : IDataMapper<tbl_Profile_Visi_Misi>
    {
        #region tbl_Profile_Visi_Misi Properties
        public Int32 id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Contents { get; set; }
        public string Visi { get; set; }
        public string Misi { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public DateTime? updated { get; set; }
        public string updated_by { get; set; }
        public string tab_text { get; set; }
        public string Visi_Content { get; set; }
        public string Misi_Content { get; set; }
        #endregion    
        public tbl_Profile_Visi_Misi Map(System.Data.IDataReader reader)
        {
            tbl_Profile_Visi_Misi obj = new tbl_Profile_Visi_Misi();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.Title = reader["Title"] == DBNull.Value ? null : reader["Title"].ToString();
            obj.SubTitle = reader["SubTitle"] == DBNull.Value ? null : reader["SubTitle"].ToString();
            obj.Contents = reader["Contents"] == DBNull.Value ? null : reader["Contents"].ToString();
            obj.Visi = reader["Visi"] == DBNull.Value ? null : reader["Visi"].ToString();
            obj.Misi = reader["Misi"] == DBNull.Value ? null : reader["Misi"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.tab_text = reader["tab_text"] == DBNull.Value ? null : reader["tab_text"].ToString();
            obj.Visi_Content = reader["Visi_Content"] == DBNull.Value ? null : reader["Visi_Content"].ToString();
            obj.Misi_Content = reader["Misi_Content"] == DBNull.Value ? null : reader["Misi_Content"].ToString();
            return obj;
        }
    }
}