using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_CorporateCommunication_Sub_CategoryItem
    {
        public static int GetByFKCount(int PageSize, int PageIndex, Int64 CategoryID)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_CorporateCommunication_Sub_Category          where Category=@Category";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            context.AddParameter("@Category", CategoryID);
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }


        /// <summary>
        /// Get All records from TABLE [tbl_CorporateCommunication_Sub_Category]
        /// </summary>        
        public static List<tbl_CorporateCommunication_Sub_Category> GetByFKPaging(int PageSize, int PageIndex, Int64 CategoryID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_CorporateCommunication_Sub_Category] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CorporateCommunication_Sub_Category].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_CorporateCommunication_Sub_Category].*
                FROM    [tbl_CorporateCommunication_Sub_Category]
                where Category=@Category
            )

            SELECT      [Paging_tbl_CorporateCommunication_Sub_Category].*
            FROM        [Paging_tbl_CorporateCommunication_Sub_Category]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";


            context.AddParameter("@Category", CategoryID);
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Sub_Category>(context, new tbl_CorporateCommunication_Sub_Category());
        }


        public static List<tbl_CorporateCommunication_Sub_Category> GetByFK(Int64 Category)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT * FROM tbl_CorporateCommunication_Sub_Category
            WHERE [Category]  = @Category";
            context.AddParameter("@Category", Category);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Sub_Category>(context, new tbl_CorporateCommunication_Sub_Category());
        }

//        public static List<tbl_CorporateCommunication_Sub_Category> GetByFK(Int64 Category, int Year)
//        {
//            IDBHelper context = new DBHelper();
//            string sqlQuery = @"SELECT * FROM tbl_CorporateCommunication_Sub_Category
//            WHERE [Category]  = @Category
//            AND [Year]  = @Year
//";
//            context.AddParameter("@Category", Category);
//            context.AddParameter("@Year", Year);
//            context.CommandText = sqlQuery;
//            context.CommandType = System.Data.CommandType.Text;
//            return DBUtil.ExecuteMapper<tbl_CorporateCommunication_Sub_Category>(context, new tbl_CorporateCommunication_Sub_Category());
//        }
    }
}
