using System;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto.Cstm;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_ProgramItem
    {

        public static int GetCountByTipeProgram(int StartRowIndex, int PageSize, string tipeProgram)
        {

            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Count(*) as Total FROM tbl_Program
                Where prog_type = @prog_type OR @prog_type is null


                ";
            context.CommandText = sqlQuery;
            if (string.IsNullOrEmpty(tipeProgram)) { context.AddParameter("@prog_type", DBNull.Value); }
            else context.AddParameter("@prog_type", tipeProgram);

            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Program]
        /// </summary>        
        public static List<tbl_Program> GetPagingByTipeProgram(int StartRowIndex, int PageSize, string tipeProgram)
        {


            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Program] AS
            (
              SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Program].[id]) AS PAGING_ROW_NUMBER,
        [tbl_Program].*, f.[file_id], f.[file_ext], null file_blob
        FROM    [tbl_Program]
        LEFT JOIN [tbl_File_Program] f on f.ref_id = [tbl_Program].id
                Where prog_type=@prog_type OR @prog_type is null
            )

            SELECT      [Paging_tbl_Program].*
            FROM        [Paging_tbl_Program]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @startRowIndex ROWS 
            FETCH Next @pageSize ROWS ONLY    
";

            context.AddParameter("@startRowIndex", StartRowIndex);
            context.AddParameter("@pageSize", PageSize);

            if (string.IsNullOrEmpty(tipeProgram)) { context.AddParameter("@prog_type", DBNull.Value); }
            else context.AddParameter("@prog_type", tipeProgram);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            List<tbl_Program> result = DBUtil.ExecuteMapper<tbl_Program>(context, new tbl_Program());

            return result;
        }


        public static List<tbl_Program> GetByTipeProgram(string tipeProgram)
        {


            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Program] AS
            (
              SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Program].[id]) AS PAGING_ROW_NUMBER,
        [tbl_Program].*, f.[file_id], f.[file_ext],f.file_blob
        FROM    [tbl_Program]
        LEFT JOIN [tbl_File_Program] f on f.ref_id = [tbl_Program].id
                Where prog_type=@prog_type OR @prog_type is null
            )

            SELECT      [Paging_tbl_Program].*
            FROM        [Paging_tbl_Program]          
";


            if (string.IsNullOrEmpty(tipeProgram)) { context.AddParameter("@prog_type", DBNull.Value); }
            else context.AddParameter("@prog_type", tipeProgram);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            List<tbl_Program> result = DBUtil.ExecuteMapper<tbl_Program>(context, new tbl_Program());

            return result;
        }

    }
}
