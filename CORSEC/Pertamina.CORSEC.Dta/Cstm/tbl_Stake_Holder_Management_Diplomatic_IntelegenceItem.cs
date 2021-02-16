using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto.Cstm;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Stake_Holder_Management_Diplomatic_IntelegenceItem
    {
        /// <summary>
        /// Get Total records from [tbl_Stake_Holder_Management_Diplomatic_Intelegence]
        /// </summary>        
        public static int GetTotalRecord(int country, int data_type)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SELECT Count(*) as Total FROM tbl_Stake_Holder_Management_Diplomatic_Intelegence
WHERE ( data_type =@data_type  OR @data_type =0 )
AND ( country=@country OR @country =0 )
";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;

            context.AddParameter("@data_type", data_type);
            context.AddParameter("@country", country);
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }
        /// <summary>
        /// Get All records from TABLE [tbl_Stake_Holder_Management_Diplomatic_Intelegence]
        /// </summary>        
        public static List<tbl_Stake_Holder_Management_Diplomatic_Intelegence> GetPaging(int PageSize, int PageIndex, int country, int data_type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Stake_Holder_Management_Diplomatic_Intelegence] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Stake_Holder_Management_Diplomatic_Intelegence].[id] DESC) AS PAGING_ROW_NUMBER,
                        [tbl_Stake_Holder_Management_Diplomatic_Intelegence].*
                FROM    [tbl_Stake_Holder_Management_Diplomatic_Intelegence]
                WHERE ( data_type =@data_type  OR @data_type =0 )
                AND ( country=@country OR @country =0 )
            )

            SELECT      [Paging_tbl_Stake_Holder_Management_Diplomatic_Intelegence].*
            FROM        [Paging_tbl_Stake_Holder_Management_Diplomatic_Intelegence]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.AddParameter("@data_type", data_type);
            context.AddParameter("@country", country);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Diplomatic_Intelegence>(context, new tbl_Stake_Holder_Management_Diplomatic_Intelegence());
        }

    }
}
