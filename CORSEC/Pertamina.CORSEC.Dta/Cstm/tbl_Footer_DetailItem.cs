using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Footer_DetailItem
    {

        public static int GetCount(int PageSize, int PageIndex, int Footer)
        {
            return GetTotalRecord(Footer);
        }

        /// <summary>
        /// Get Total records from [tbl_Footer_Detail]
        /// </summary>        
        public static int GetTotalRecord(int Footer)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = " SELECT Count(*) as Total FROM tbl_Footer_Detail Where Footer=@Footer ";
            context.CommandText = sqlQuery;
            context.AddParameter("@Footer", Footer);
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }


        /// <summary>
        /// Get All records from TABLE [tbl_Footer_Detail]
        /// </summary>        
        public static List<tbl_Footer_Detail> GetPaging(int PageSize, int PageIndex, int Footer)
        {
            IDBHelper context = new DBHelper();
            //long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            //long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            string sqlQuery = @"
            WITH [Paging_tbl_Footer_Detail] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Footer_Detail].[id] DESC) AS PAGING_ROW_NUMBER,
                        [tbl_Footer_Detail].*
                FROM    [tbl_Footer_Detail]
                WHERE   Footer=@Footer
            )

            SELECT      [Paging_tbl_Footer_Detail].*
            FROM        [Paging_tbl_Footer_Detail]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
            
";

            //context.AddParameter("@FirstRow", FirstRow);
            //context.AddParameter("@LastRow", LastRow);

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.AddParameter("@Footer", Footer);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Footer_Detail>(context, new tbl_Footer_Detail());
        }

        public static int DeleteByParent(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
DELETE FROM tbl_Footer_Detail 
WHERE   [Footer]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
    }
}
