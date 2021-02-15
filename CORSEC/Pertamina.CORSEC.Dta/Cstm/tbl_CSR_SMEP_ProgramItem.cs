using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_CSR_SMEP_ProgramItem
    {
        /*
 public enum BL_SMEPP_Data_Type
    {
        
        [Description("RKAP")]
        BL_RKAP = 3,
        [Description("REALISASI")]
        BL_REALISASI = 4
    }
         */

        public static int GetPagingKemitraanCount(int PageSize, int PageIndex)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_CSR_SMEP_Program  WHERE category in (1,2) AND  ISNULL( is_dynamic,0)  <> 1";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }

        public static List<tbl_CSR_SMEP_Program> GetPagingKemitraan(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_CSR_SMEP_Program] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CSR_SMEP_Program].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_CSR_SMEP_Program].*
                FROM    [tbl_CSR_SMEP_Program]
                WHERE category in (1,2) AND  ISNULL( is_dynamic,0)  <> 1
            )

            SELECT      [Paging_tbl_CSR_SMEP_Program].*
            FROM        [Paging_tbl_CSR_SMEP_Program]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program>(context, new tbl_CSR_SMEP_Program());
        }

        public static int GetPagingPengelolaanCSRBLCount(int PageSize, int PageIndex)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_CSR_SMEP_Program  WHERE category in (3,4) AND  ISNULL( is_dynamic,0)  <> 1";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }

        public static List<tbl_CSR_SMEP_Program> GetPagingPengelolaanCSRBL(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_CSR_SMEP_Program] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CSR_SMEP_Program].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_CSR_SMEP_Program].*
                FROM    [tbl_CSR_SMEP_Program]
                WHERE category in (3,4) AND  ISNULL( is_dynamic,0)  <> 1
            )

            SELECT      [Paging_tbl_CSR_SMEP_Program].*
            FROM        [Paging_tbl_CSR_SMEP_Program]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program>(context, new tbl_CSR_SMEP_Program());
        }

        public static int GetPagingStrategiPengelolaanCount(int PageSize, int PageIndex)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_CSR_SMEP_Program  WHERE data_type is null AND is_dynamic = 1";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }
        
        public static List<tbl_CSR_SMEP_Program> GetPagingStrategiPengelolaan(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_CSR_SMEP_Program] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CSR_SMEP_Program].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_CSR_SMEP_Program].*
                FROM    [tbl_CSR_SMEP_Program]
                WHERE data_type is null AND is_dynamic = 1
            )

            SELECT      [Paging_tbl_CSR_SMEP_Program].*
            FROM        [Paging_tbl_CSR_SMEP_Program]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program>(context, new tbl_CSR_SMEP_Program());
        }

        /// <summary>
        /// Get Total records from [tbl_CSR_SMEP_Program]
        /// </summary>        
        public static int GetCount(int data_type, int bulan, int related_document, int category)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SELECT Count(*) as Total FROM tbl_CSR_SMEP_Program
WHERE data_type =@data_type
and (bulan =@bulan OR @bulan =0 )
and (related_document =@related_document OR @related_document =0)
AND category =@category
AND is_dynamic <> 1
";
            context.CommandText = sqlQuery;
            context.AddParameter("@data_type", data_type);
            context.AddParameter("@bulan", bulan);
            context.AddParameter("@related_document", related_document);
            context.AddParameter("@category", category);
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }

        public static List<tbl_bulan> GetBulan(int data_type, int bulan, int related_document, int category)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SELECT distinct b.* FROM tbl_bulan b
inner join tbl_CSR_SMEP_Program a on a.bulan = b.id
WHERE data_type =@data_type

AND category =@category
AND is_dynamic <> 1
Order by b.id
";
            context.CommandText = sqlQuery;
            context.AddParameter("@data_type", data_type);
            //context.AddParameter("@bulan", bulan);
            //context.AddParameter("@related_document", related_document);
            context.AddParameter("@category", category);
            context.CommandType = System.Data.CommandType.Text;

            return DBUtil.ExecuteMapper<tbl_bulan>(context, new tbl_bulan());

        }

        /// <summary>
        /// Get All records from TABLE [tbl_CSR_SMEP_Program]
        /// </summary>        
        public static List<tbl_CSR_SMEP_Program> GetPaging(int PageSize, int PageIndex, int data_type, int bulan, int related_document, int category)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_CSR_SMEP_Program] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_CSR_SMEP_Program].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_CSR_SMEP_Program].*
                FROM    [tbl_CSR_SMEP_Program]

	            WHERE data_type =@data_type
				and (bulan =@bulan OR @bulan =0 )
and (related_document =@related_document OR @related_document =0)
                AND category =@category
 AND is_dynamic <> 1

            )

            SELECT     Paging_tbl_CSR_SMEP_Program.[id]
      ,Paging_tbl_CSR_SMEP_Program.[created]
      ,Paging_tbl_CSR_SMEP_Program.[created_by]
      ,Paging_tbl_CSR_SMEP_Program.[updated]
      ,Paging_tbl_CSR_SMEP_Program.[updated_by]
      ,Paging_tbl_CSR_SMEP_Program.[file_type]
      ,Paging_tbl_CSR_SMEP_Program.[file_path]
      ,Paging_tbl_CSR_SMEP_Program.[file_name]
      ,Paging_tbl_CSR_SMEP_Program.[file_ext]
      ,Paging_tbl_CSR_SMEP_Program.[file_size]
      ,Paging_tbl_CSR_SMEP_Program.[file_blob]
      ,Paging_tbl_CSR_SMEP_Program.[title]
      ,Paging_tbl_CSR_SMEP_Program.[body]
      ,Paging_tbl_CSR_SMEP_Program.[data_type]
      ,Paging_tbl_CSR_SMEP_Program.[year]
      ,Paging_tbl_CSR_SMEP_Program.[bulan]
      ,Paging_tbl_CSR_SMEP_Program.[related_document]
      ,Paging_tbl_CSR_SMEP_Program.[category]
      ,Paging_tbl_CSR_SMEP_Program.[is_dynamic]
      ,Paging_tbl_CSR_SMEP_Program.PAGING_ROW_NUMBER as [ROW_NUMBER]
            FROM        [Paging_tbl_CSR_SMEP_Program]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@data_type", data_type);
            context.AddParameter("@bulan", bulan);
            context.AddParameter("@related_document", related_document);
            context.AddParameter("@category", category);

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_CSR_SMEP_Program>(context, new tbl_CSR_SMEP_Program());
        }



        public static List<tbl_CSR_SMEP_Program> GetDynamicData(int category)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
          
                SELECT  *  FROM    [tbl_CSR_SMEP_Program]

	            WHERE category =@category
                AND is_dynamic = 1
                
                ORDER BY id Desc
";

            context.AddParameter("@category", category);

            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper(context, new tbl_CSR_SMEP_Program());
        }

        public static List<tbl_CSR_SMEP_Program> GetUncategorized(int category, int tahun)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
          
                SELECT  *  FROM    [tbl_CSR_SMEP_Program]

	            WHERE category =@category
                AND is_dynamic <> 1
                AND ([year]=@year OR @year=0 )
                
                ORDER BY id Desc
";

            context.AddParameter("@category", category);
            context.AddParameter("@year", tahun);

            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper(context, new tbl_CSR_SMEP_Program());
        }

        
    }
}
