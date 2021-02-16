using System;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto.Cstm;


namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Guidelines_DocItem
    {
        public static int GetCustomCount(int StartRowIndex, int PageSize, string tipeDocument, int tahun)
        {

            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Guidelines_Doc";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Guidelines_Doc]
        /// </summary>        
        public static List<tbl_Guidelines_Doc> GetCustomPaging(int StartRowIndex, int PageSize, string tipeDocument, int tahun)
        {
            //if (PageIndex > 0) PageIndex = PageIndex - PageSize;

            int StartRow = StartRowIndex + 1;
            int EndRow = (StartRow + PageSize);

            IDBHelper context = new DBHelper();
            string sqlQuery = @"



            WITH [Paging_tbl_Guidelines_Doc] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Guidelines_Doc].[id] DESC) AS PAGING_ROW_NUMBER,
[tbl_Guidelines_Doc].*, f.[file_id], f.[file_ext], f.[file_ext]
                FROM    [tbl_Guidelines_Doc]
                LEFT JOIN [tbl_Guidelines_File] f on f.ref_id = [tbl_Guidelines_Doc].id
            )

            SELECT      [Paging_tbl_Guidelines_Doc].*
            FROM        [Paging_tbl_Guidelines_Doc]  
            WHERE PAGING_ROW_NUMBER BETWEEN @StartRow AND @EndRow
";

            context.AddParameter("@StartRow", StartRow);
            context.AddParameter("@EndRow", EndRow);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Guidelines_Doc>(context, new tbl_Guidelines_Doc());
        }

        public static List<Pertamina.CORSEC.Dto.Cstm.tbl_Guidelines_Doc> GetDataPaging(int PageIndex, int PageSize, string tipeDocument, string judul, int tahun, out int totalRecords)
        {

            totalRecords = 0;

            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;

            IDBHelper context = new DBHelper();
            string sqlQuery = @"
SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Guidelines_Doc].[id] DESC) AS PAGING_ROW_NUMBER,
    [tbl_Guidelines_Doc].*, f.[file_id], f.[file_ext]
			into	#temp
            FROM    [tbl_Guidelines_Doc]
            LEFT JOIN [tbl_Guidelines_File] f on f.ref_id = [tbl_Guidelines_Doc].id

            Where (Tipe_Dokumen=@Tipe_Dokumen OR @Tipe_Dokumen is null)
            AND (Judul like '%' + @Judul + '%' OR @Judul is null)
            AND (Tahun =@Tahun OR @Tahun is null)
    

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

            if (string.IsNullOrEmpty(tipeDocument)) context.AddParameter("@Tipe_Dokumen", DBNull.Value);
            else context.AddParameter("@Tipe_Dokumen", tipeDocument);

            if (string.IsNullOrEmpty(judul)) context.AddParameter("@Judul", DBNull.Value);
            else context.AddParameter("@Judul", judul);
            if (tahun <= 1900) context.AddParameter("@Tahun", DBNull.Value);
            else context.AddParameter("@Tahun", tahun);

            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<Pertamina.CORSEC.Dto.Cstm.tbl_Guidelines_Doc>(context, new Pertamina.CORSEC.Dto.Cstm.tbl_Guidelines_Doc(), out totalRecords);
        }





        public static int GetCountByTipeDoucment(int StartRowIndex, int PageSize, string tipeDocument)
        {

            //int idTipeDoc = 0;
            //int.TryParse(tipeDocument, out idTipeDoc);
            //Pertamina.CORSEC.Dto.tbl_Combo_Detail tipeDocItem = tbl_Combo_DetailItem.GetByPK(idTipeDoc);
            //tipeDocument = tipeDocItem == null ? "" : tipeDocItem.name;

            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Count(*) as Total FROM tbl_Guidelines_Doc
                Where Tipe_Dokumen = @Tipe_Dokumen OR @Tipe_Dokumen is null


                ";
            context.CommandText = sqlQuery;
            if (tipeDocument == "Jenis Dokumen") { context.AddParameter("@Tipe_Dokumen", DBNull.Value); }
            else context.AddParameter("@Tipe_Dokumen", tipeDocument);

            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Guidelines_Doc]
        /// </summary>        
        public static List<tbl_Guidelines_Doc> GetPagingByTipeDoucment(int StartRowIndex, int PageSize, string tipeDocument)
        {

            //int idTipeDoc = 0;
            //int.TryParse(tipeDocument, out idTipeDoc);
            //Pertamina.CORSEC.Dto.tbl_Combo_Detail tipeDocItem = tbl_Combo_DetailItem.GetByPK(idTipeDoc);
            //tipeDocument = tipeDocItem == null ? "" : tipeDocItem.name;


            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Guidelines_Doc] AS
            (
              SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Guidelines_Doc].[id] DESC) AS PAGING_ROW_NUMBER,
        [tbl_Guidelines_Doc].*, f.[file_id], f.[file_ext]
        FROM    [tbl_Guidelines_Doc]
        LEFT JOIN [tbl_Guidelines_File] f on f.ref_id = [tbl_Guidelines_Doc].id
                Where Tipe_Dokumen=@Tipe_Dokumen OR @Tipe_Dokumen is null
            )

            SELECT      [Paging_tbl_Guidelines_Doc].*
            FROM        [Paging_tbl_Guidelines_Doc]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @startRowIndex ROWS 
            FETCH Next @pageSize ROWS ONLY    
";

            context.AddParameter("@startRowIndex", StartRowIndex);
            context.AddParameter("@pageSize", PageSize);

            if (tipeDocument == "Jenis Dokumen") { context.AddParameter("@Tipe_Dokumen", DBNull.Value); }
            else context.AddParameter("@Tipe_Dokumen", tipeDocument);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            List<tbl_Guidelines_Doc> result = DBUtil.ExecuteMapper<tbl_Guidelines_Doc>(context, new tbl_Guidelines_Doc());

            return result;
        }

    }
}
