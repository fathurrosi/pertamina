using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto.Cstm;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Board_Speech_PresentationItem
    {
        public static List<Pertamina.CORSEC.Dto.Cstm.tbl_Board_Speech_Presentation> GetDataBoardSpeechPaging(int PageIndex, int PageSize, int data_type, int data_year_start, int data_year_end, out int totalRecords)
        {

            totalRecords = 0;

            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Board_Speech_Presentation].[id] DESC) AS PAGING_ROW_NUMBER,
            [tbl_Board_Speech_Presentation].*, f.[file_id], f.[file_ext], f.file_size, f.file_blob   
			into	#temp
            FROM    [tbl_Board_Speech_Presentation]
            LEFT JOIN [tbl_Board_Speech_Presentation_File] f on f.ref_id = [tbl_Board_Speech_Presentation].id AND f.ref_name ='tbl_Board_Speech_Presentation_Image'

            Where (data_type=@data_type OR @data_type is null)            
            AND ( data_year >=@data_year_start OR @data_year_start is null)
            AND ( data_year <=@data_year_end OR @data_year_end is null)
    

            SELECT @totalRecords = COUNT(*)    
            FROM        #temp ;  

            SELECT      *
            FROM        #temp            
            WHERE PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

			drop table #temp    
          
";


            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.AddParameter("@totalRecords", 0, System.Data.ParameterDirection.Output);

            if (data_type <= 0) context.AddParameter("@data_type", DBNull.Value);
            else context.AddParameter("@data_type", data_type);

            if (data_year_start <= 1900) context.AddParameter("@data_year_start", DBNull.Value);
            else context.AddParameter("@data_year_start", data_year_start);

            if (data_year_start <= 1900) context.AddParameter("@data_year_end", DBNull.Value);
            else context.AddParameter("@data_year_end", data_year_end);


            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Pertamina.CORSEC.Dto.Cstm.tbl_Board_Speech_Presentation>(context, new Pertamina.CORSEC.Dto.Cstm.tbl_Board_Speech_Presentation(), out totalRecords);
        }




        public static List<Pertamina.CORSEC.Dto.Cstm.tbl_Board_Speech_Presentation> GetDataPaging(int PageIndex, int PageSize, int data_type, int data_year_start, int data_year_end, out int totalRecords)
        {

            totalRecords = 0;

            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Board_Speech_Presentation].[id] DESC) AS PAGING_ROW_NUMBER,
            [tbl_Board_Speech_Presentation].*, f.[file_id], f.[file_ext], f.file_size, null file_blob   
			into	#temp
            FROM    [tbl_Board_Speech_Presentation]
            LEFT JOIN [tbl_Board_Speech_Presentation_File] f on f.ref_id = [tbl_Board_Speech_Presentation].id AND f.ref_name ='tbl_Board_Speech_Presentation'

            Where (data_type=@data_type OR @data_type is null)            
            AND ( data_year >=@data_year_start OR @data_year_start is null)
            AND ( data_year <=@data_year_end OR @data_year_end is null)
    

            SELECT @totalRecords = COUNT(*)    
            FROM        #temp ;  

            SELECT      *
            FROM        #temp            
            WHERE PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow

			drop table #temp    
          
";


            context.AddParameter("@FirstRow", FirstRow);
            context.AddParameter("@LastRow", LastRow);
            context.AddParameter("@totalRecords", 0, System.Data.ParameterDirection.Output);

            if (data_type <= 0) context.AddParameter("@data_type", DBNull.Value);
            else context.AddParameter("@data_type", data_type);

            if (data_year_start <= 1900) context.AddParameter("@data_year_start", DBNull.Value);
            else context.AddParameter("@data_year_start", data_year_start);

            if (data_year_start <= 1900) context.AddParameter("@data_year_end", DBNull.Value);
            else context.AddParameter("@data_year_end", data_year_end);


            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Pertamina.CORSEC.Dto.Cstm.tbl_Board_Speech_Presentation>(context, new Pertamina.CORSEC.Dto.Cstm.tbl_Board_Speech_Presentation(), out totalRecords);
        }







        public static int GetCountByTipe(int StartRowIndex, int PageSize, int data_type)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Count(*) as Total FROM tbl_Board_Speech_Presentation
                Where data_type = @data_type OR @data_type is null


                ";
            context.CommandText = sqlQuery;
            if (data_type <= 0) { context.AddParameter("@data_type", DBNull.Value); }
            else context.AddParameter("@data_type", data_type);

            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Board_Speech_Presentation]
        /// </summary>        
        public static List<tbl_Board_Speech_Presentation> GetPagingByTipe(int StartRowIndex, int PageSize, int data_type)
        {


            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Board_Speech_Presentation] AS
            (
              SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Board_Speech_Presentation].[id] DESC) AS PAGING_ROW_NUMBER,
        [tbl_Board_Speech_Presentation].*, f.[file_id], f.[file_ext], f.[file_size], null file_blob
        FROM    [tbl_Board_Speech_Presentation]
        LEFT JOIN [tbl_Board_Speech_Presentation_File] f on f.ref_id = [tbl_Board_Speech_Presentation].id AND f.ref_name ='tbl_Board_Speech_Presentation'
                Where data_type=@data_type OR @data_type is null
            )

            SELECT      [Paging_tbl_Board_Speech_Presentation].*
            FROM        [Paging_tbl_Board_Speech_Presentation]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @startRowIndex ROWS 
            FETCH Next @pageSize ROWS ONLY    
";

            context.AddParameter("@startRowIndex", StartRowIndex);
            context.AddParameter("@pageSize", PageSize);

            if (data_type <= 0) { context.AddParameter("@data_type", DBNull.Value); }
            else context.AddParameter("@data_type", data_type);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            List<tbl_Board_Speech_Presentation> result = DBUtil.ExecuteMapper<tbl_Board_Speech_Presentation>(context, new tbl_Board_Speech_Presentation());

            return result;
        }

    }
}
