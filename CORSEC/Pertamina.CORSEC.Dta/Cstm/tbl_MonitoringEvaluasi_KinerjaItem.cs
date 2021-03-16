using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_MonitoringEvaluasi_KinerjaItem
    {
        public static int GetTotalRecord(int Monitoring_Type, int tahun, int bulan)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SELECT Count(*) as Total FROM tbl_MonitoringEvaluasi_Kinerja
    WHERE ( Monitoring_Type =@Monitoring_Type )
    AND ( Bulan=@Bulan OR @Bulan=0 )
	AND ( Tahun=@Tahun OR @Tahun=0 )
";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;

            context.AddParameter("@Monitoring_Type", Monitoring_Type);
            context.AddParameter("@Bulan", bulan);
            context.AddParameter("@Tahun", tahun);

            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }

        public static List<Dto.Cstm.tbl_MonitoringEvaluasi_Kinerja> GetPaging(int PageSize, int PageIndex, int Monitoring_Type, int tahun, int bulan)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
WITH [Paging_tbl_MonitoringEvaluasi_Kinerja] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_MonitoringEvaluasi_Kinerja].[id] DESC) AS PAGING_ROW_NUMBER,
            [tbl_MonitoringEvaluasi_Kinerja].*
    FROM    [tbl_MonitoringEvaluasi_Kinerja]
    WHERE ( Monitoring_Type =@Monitoring_Type )
    AND ( Bulan=@Bulan OR @Bulan=0 )
	AND ( Tahun=@Tahun OR @Tahun=0 )
)

SELECT      [Paging_tbl_MonitoringEvaluasi_Kinerja].*
FROM        [Paging_tbl_MonitoringEvaluasi_Kinerja]
ORDER BY PAGING_ROW_NUMBER       
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.AddParameter("@Monitoring_Type", Monitoring_Type);
            context.AddParameter("@Bulan", bulan);
            context.AddParameter("@Tahun", tahun);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Dto.Cstm.tbl_MonitoringEvaluasi_Kinerja>(context, new Dto.Cstm.tbl_MonitoringEvaluasi_Kinerja());
        }
    }
}
