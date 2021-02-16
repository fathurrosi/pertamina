using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto.Cstm;

namespace Pertamina.CORSEC.Dta
{
    partial class tbl_Stake_Holder_Management_Stake_Holder_DatabaseItem
    {
        public static int GetTotalRecord(int year, int data_type)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SELECT Count(*) as Total FROM tbl_Stake_Holder_Management_Stake_Holder_Database
WHERE ( data_type =@data_type  OR @data_type =0 )
AND ( year=@year OR @year =0 )
";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;

            context.AddParameter("@data_type", data_type);
            context.AddParameter("@year", year);
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }
        /// <summary>
        /// Get All records from TABLE [tbl_Stake_Holder_Management_Stake_Holder_Database]
        /// </summary>        
        public static List<tbl_Stake_Holder_Management_Stake_Holder_Database> GetPaging(int PageSize, int PageIndex, int year, int data_type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Stake_Holder_Management_Stake_Holder_Database] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Stake_Holder_Management_Stake_Holder_Database].[id] DESC) AS PAGING_ROW_NUMBER,
                        [tbl_Stake_Holder_Management_Stake_Holder_Database].*
                FROM    [tbl_Stake_Holder_Management_Stake_Holder_Database]
                WHERE ( data_type =@data_type  OR @data_type =0 )
                AND ( year=@year OR @year =0 )
            )

            SELECT      [Paging_tbl_Stake_Holder_Management_Stake_Holder_Database].*
            FROM        [Paging_tbl_Stake_Holder_Management_Stake_Holder_Database]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.AddParameter("@data_type", data_type);
            context.AddParameter("@year", year);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Stake_Holder_Database>(context, new tbl_Stake_Holder_Management_Stake_Holder_Database());
        }

        public static List<tbl_Stake_Holder_Management_Stake_Holder_Database> GetUncategorizedPaging()
        {
            int PageSize = 1000;
            int PageIndex = 1;
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Stake_Holder_Management_Stake_Holder_Database] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Stake_Holder_Management_Stake_Holder_Database].[id] DESC) AS PAGING_ROW_NUMBER,
                        [tbl_Stake_Holder_Management_Stake_Holder_Database].*
                FROM    [tbl_Stake_Holder_Management_Stake_Holder_Database]
                WHERE ( data_type = -1)                
            )

            SELECT      [Paging_tbl_Stake_Holder_Management_Stake_Holder_Database].*
            FROM        [Paging_tbl_Stake_Holder_Management_Stake_Holder_Database]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            //context.AddParameter("@data_type", data_type);
            //context.AddParameter("@year", year);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Stake_Holder_Management_Stake_Holder_Database>(context, new tbl_Stake_Holder_Management_Stake_Holder_Database());
        }
    }
}
