using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Struktur_Organisasi_AnggotaItem
    {
        /// <summary>
        /// Get All records from TABLE [tbl_Struktur_Organisasi_Anggota]
        /// </summary>        
        public static List<tbl_Struktur_Organisasi_Anggota> GetAnggota(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            //long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            //long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            string sqlQuery = @"
            WITH [Paging_tbl_Struktur_Organisasi_Anggota] AS
            (
  SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Struktur_Organisasi_Anggota].[id] DESC) AS PAGING_ROW_NUMBER,
	   [tbl_Struktur_Organisasi_Anggota].[id]
      ,[tbl_Struktur_Organisasi_Anggota].[nama]
      ,[tbl_Struktur_Organisasi_Anggota].[nip]
      ,[tbl_Struktur_Organisasi_Anggota].[telp]
      ,[tbl_Struktur_Organisasi_Anggota].[email]
      ,[tbl_Struktur_Organisasi_Anggota].[jabatan_id]
      ,[tbl_Struktur_Organisasi_Jabatan].[name] as [jabatan_nama]
      ,[tbl_Struktur_Organisasi_Anggota].[created]
      ,[tbl_Struktur_Organisasi_Anggota].[created_by]
      ,[tbl_Struktur_Organisasi_Anggota].[updated]
      ,[tbl_Struktur_Organisasi_Anggota].[updated_by]
    FROM    [tbl_Struktur_Organisasi_Anggota]
	left join [tbl_Struktur_Organisasi_Jabatan] on  [tbl_Struktur_Organisasi_Jabatan].[id] = [tbl_Struktur_Organisasi_Anggota].[jabatan_id]
            )

            SELECT      [Paging_tbl_Struktur_Organisasi_Anggota].*
            FROM        [Paging_tbl_Struktur_Organisasi_Anggota]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            //context.AddParameter("@FirstRow", FirstRow);
            //context.AddParameter("@LastRow", LastRow);

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Anggota>(context, new tbl_Struktur_Organisasi_Anggota());
        }

    }
}
