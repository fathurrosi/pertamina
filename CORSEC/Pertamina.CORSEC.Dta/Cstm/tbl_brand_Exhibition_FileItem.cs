using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_brand_Exhibition_FileItem
    {
        public static List<tbl_brand_Exhibition_File> GetByFK(Int32 exhibition_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT * FROM tbl_brand_Exhibition_File
            WHERE [exhibition_id]  = @exhibition_id";
            context.AddParameter("@exhibition_id", exhibition_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Exhibition_File>(context, new tbl_brand_Exhibition_File());
        }

        public static List<tbl_brand_Exhibition_File> GetGalery(Int32 exhibition_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT * FROM tbl_brand_Exhibition_File
            WHERE [exhibition_id]  = @exhibition_id and exhibition_type=1";
            context.AddParameter("@exhibition_id", exhibition_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_Exhibition_File>(context, new tbl_brand_Exhibition_File());
        }

        /// <summary>
        /// Get Total records from [tbl_brand_Exhibition_File]
        /// </summary>        
        public static int GetCountFile(int PageSize, int PageIndex)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_brand_Exhibition_File where exhibition_type=2";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }


        /// <summary>
        /// Get All records from TABLE [tbl_brand_Exhibition_File]
        /// </summary>        
        public static List<tbl_brand_Exhibition_File> GetPagingFile(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_brand_Exhibition_File] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Exhibition_File].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_brand_Exhibition_File].*
                FROM    [tbl_brand_Exhibition_File]
                WHERE exhibition_type=2
            )

            SELECT      [Paging_tbl_brand_Exhibition_File].*
            FROM        [Paging_tbl_brand_Exhibition_File]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_brand_Exhibition_File>(context, new tbl_brand_Exhibition_File());
        }
        public static List<tbl_brand_Exhibition_File> GetDataPaging(int exhibition_id, int PageIndex, int PageSize, out int totalRecords)
        {
            totalRecords = 0;


            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_Exhibition_File].[id]) AS PAGING_ROW_NUMBER,
                    [tbl_brand_Exhibition_File].*
            into	#temp
            FROM    [tbl_brand_Exhibition_File]
            WHERE exhibition_type=2 AND  [exhibition_id]  = @exhibition_id;


            SELECT @totalRecords = COUNT(*)    
            FROM        #temp ;  


            SELECT      *
            FROM        #temp            
            WHERE PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

			drop table #temp  
";

            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.AddParameter("@exhibition_id", exhibition_id);
            context.AddParameter("@totalRecords", 0, System.Data.ParameterDirection.Output);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_brand_Exhibition_File>(context, new tbl_brand_Exhibition_File(), out totalRecords);
        }

    }
}
