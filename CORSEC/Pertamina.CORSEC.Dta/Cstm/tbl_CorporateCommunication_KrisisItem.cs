using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_CorporateCommunication_KrisisItem
    {
        public static int GetTotalRecord(int SubCategory, int Year, int Jenis_Documen)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SELECT Count(*) as Total FROM tbl_CorporateCommunication_Krisis
WHERE ([SubCategory]  = @SubCategory OR @SubCategory=0)
AND ( [Tahun]  = @Year OR @Year<=1900)
AND  (Jenis_Documen =@Jenis_Documen OR @Jenis_Documen =0)
                
                ";
            context.CommandText = sqlQuery;
            context.AddParameter("@SubCategory", SubCategory);
            context.AddParameter("@Year", Year);
            context.AddParameter("@Jenis_Documen", Jenis_Documen);
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }

        public static List<tbl_CorporateCommunication_Krisis> GetPaging(int PageSize, int PageIndex,int SubCategory, int Year, int Jenis_Documen)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"


            WITH [Paging_tbl_CorporateCommunication_Krisis] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CorporateCommunication_Krisis].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_CorporateCommunication_Krisis].*
                FROM    [tbl_CorporateCommunication_Krisis]
                WHERE ([SubCategory]  = @SubCategory OR @SubCategory=0)
                AND ( [Tahun]  = @Year OR @Year<=1900)
                AND  (Jenis_Documen =@Jenis_Documen OR @Jenis_Documen =0)

            )

            SELECT      [Paging_tbl_CorporateCommunication_Krisis].*
            FROM        [Paging_tbl_CorporateCommunication_Krisis]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY

";
            context.AddParameter("@SubCategory", SubCategory);
            context.AddParameter("@Year", Year);
            context.AddParameter("@Jenis_Documen", Jenis_Documen);

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Krisis>(context, new tbl_CorporateCommunication_Krisis());
        }
    }
}
