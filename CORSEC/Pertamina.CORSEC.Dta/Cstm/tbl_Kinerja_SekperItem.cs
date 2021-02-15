using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto.Cstm;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Kinerja_SekperItem
    {
        public static int Get_Count(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
    

        /// <summary>
        /// Get All records from TABLE [tbl_Kinerja_Sekper]
        /// </summary>        
        public static List<tbl_Kinerja_Sekper> Get_Paging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Kinerja_Sekper] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Kinerja_Sekper].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Kinerja_Sekper].*
                FROM    [tbl_Kinerja_Sekper]
            )

            SELECT      [Paging_tbl_Kinerja_Sekper].*, f.file_id, f.file_ext, f.file_blob, f.file_size
            FROM        [Paging_tbl_Kinerja_Sekper]
			left join tbl_Kinerja_Sekper_File f on [Paging_tbl_Kinerja_Sekper].id = f.ref_id and f.ref_name ='tbl_Kinerja_Sekper'
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper>(context, new tbl_Kinerja_Sekper());
        }


        public static tbl_Kinerja_Sekper GetByTahunSemester(int tahun, int semester)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            SELECT      [tbl_Kinerja_Sekper].*, f.file_id, f.file_ext, f.file_blob, f.file_size
            FROM        [tbl_Kinerja_Sekper]
			left join tbl_Kinerja_Sekper_File f on [tbl_Kinerja_Sekper].id = f.ref_id and f.ref_name ='tbl_Kinerja_Sekper'            
            Where semester = @semester AND  tahun = @tahun
";

            context.AddParameter("@tahun", tahun);
            context.AddParameter("@semester", semester);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Kinerja_Sekper>(context, new tbl_Kinerja_Sekper()).FirstOrDefault();
        }
    }
}

