using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_MonitoringEvaluasi_MediaItem
    {
        public static List<Dto.Cstm.tbl_MonitoringEvaluasi_Media_Type> GetMediaType(string Monitoring_Type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"

select sum( TotalArticle) TotalArticle, Media_Type, Tone from [tbl_MonitoringEvaluasi_Media]
where  Monitoring_Type =@Monitoring_Type
group by Media_Type,Tone


";
            context.AddParameter("@Monitoring_Type", Monitoring_Type);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Dto.Cstm.tbl_MonitoringEvaluasi_Media_Type>(context, new Dto.Cstm.tbl_MonitoringEvaluasi_Media_Type());
        }

        public static List<Dto.Cstm.tbl_MonitoringEvaluasi_Media_Persentage> GetPersentage(string Monitoring_Type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
declare @TotalArticle decimal;
select @TotalArticle = sum( TotalArticle) from [tbl_MonitoringEvaluasi_Media]
where Media_Type ='Internet'
and  Monitoring_Type =@Monitoring_Type
--print @TotalArticle 


select cast(sum( TotalArticle) / @TotalArticle  * 100 as decimal(10,2)) as Percentage  , Tone,  @TotalArticle TotalArticle from [tbl_MonitoringEvaluasi_Media]
where Media_Type ='Internet'
and  Monitoring_Type =@Monitoring_Type
group by Tone


";
            context.AddParameter("@Monitoring_Type", Monitoring_Type);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Dto.Cstm.tbl_MonitoringEvaluasi_Media_Persentage>(context, new Dto.Cstm.tbl_MonitoringEvaluasi_Media_Persentage());
        }

        public static List<Dto.Cstm.tbl_MonitoringEvaluasi_Media> GetTop10(string Monitoring_Type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"


select  top 10  ROW_NUMBER() OVER (ORDER BY TotalArticle DESC) AS PAGING_ROW_NUMBER,* from (

SELECT 
sum(TotalArticle) as TotalArticle ,Title, Monitoring_Type, Media_Type, Tone
FROM tbl_MonitoringEvaluasi_Media
where Monitoring_Type =@Monitoring_Type
group by Monitoring_Type, Title, Media_Type, Tone
--order by TotalArticle desc
) as t


";
            context.AddParameter("@Monitoring_Type", Monitoring_Type);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<Dto.Cstm.tbl_MonitoringEvaluasi_Media>(context, new Dto.Cstm.tbl_MonitoringEvaluasi_Media());
        }
    }
}
