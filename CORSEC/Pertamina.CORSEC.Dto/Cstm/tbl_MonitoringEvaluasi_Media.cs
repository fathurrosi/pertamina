using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Pertamina.CORSEC.Dto.Cstm
{
    public class tbl_MonitoringEvaluasi_Media_Type: IDataMapper<tbl_MonitoringEvaluasi_Media_Type>
    {
        #region tbl_MonitoringEvaluasi_Media Properties
        public string Media_Type { get; set; }
        public string Tone { get; set; }
        public decimal TotalArticle { get; set; }
        #endregion    
        public tbl_MonitoringEvaluasi_Media_Type Map(System.Data.IDataReader reader)
        {
            tbl_MonitoringEvaluasi_Media_Type obj = new tbl_MonitoringEvaluasi_Media_Type();
            obj.Media_Type = string.Format("{0}", reader["Media_Type"]);
            obj.TotalArticle = Convert.ToDecimal(reader["TotalArticle"]);
            obj.Tone = string.Format("{0}", reader["Tone"]);
            return obj;
        }
    }

    public class tbl_MonitoringEvaluasi_Media_Persentage : IDataMapper<tbl_MonitoringEvaluasi_Media_Persentage>
    {
        #region tbl_MonitoringEvaluasi_Media Properties
        public decimal Percentage { get; set; }
        public string Tone { get; set; }
        public decimal TotalArticle { get; set; }
        #endregion    
        public tbl_MonitoringEvaluasi_Media_Persentage Map(System.Data.IDataReader reader)
        {
            tbl_MonitoringEvaluasi_Media_Persentage obj = new tbl_MonitoringEvaluasi_Media_Persentage();
            obj.Percentage = Convert.ToDecimal(reader["Percentage"]);
            obj.TotalArticle = Convert.ToDecimal(reader["TotalArticle"]);
            obj.Tone = string.Format("{0}", reader["Tone"]);
            return obj;
        }
    }

    public class tbl_MonitoringEvaluasi_Media : IDataMapper<tbl_MonitoringEvaluasi_Media>
    {
        #region tbl_MonitoringEvaluasi_Media Properties
        public int PAGING_ROW_NUMBER { get; set; }
        public string Monitoring_Type { get; set; }
        public string Title { get; set; }
        public string Media_Type { get; set; }
        public string Tone { get; set; }
        //public DateTime? created { get; set; }
        //public string created_by { get; set; }
        //public DateTime? updated { get; set; }
        //public string updated_by { get; set; }
        public Int32? TotalArticle { get; set; }
        #endregion    
        public tbl_MonitoringEvaluasi_Media Map(System.Data.IDataReader reader)
        {
            tbl_MonitoringEvaluasi_Media obj = new tbl_MonitoringEvaluasi_Media();
            obj.PAGING_ROW_NUMBER = Convert.ToInt32(reader["PAGING_ROW_NUMBER"]);
            obj.Monitoring_Type = reader["Monitoring_Type"] == DBNull.Value ? null : reader["Monitoring_Type"].ToString();
            obj.Title = reader["Title"] == DBNull.Value ? null : reader["Title"].ToString();
            obj.Media_Type = reader["Media_Type"] == DBNull.Value ? null : reader["Media_Type"].ToString();
            obj.Tone = reader["Tone"] == DBNull.Value ? null : reader["Tone"].ToString();
            //obj.created = reader["created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["created"]);
            //obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            //obj.updated = reader["updated"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["updated"]);
            //obj.updated_by = reader["updated_by"] == DBNull.Value ? null : reader["updated_by"].ToString();
            obj.TotalArticle = reader["TotalArticle"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["TotalArticle"]);
            return obj;
        }
    }
}
