using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Struktur_Organisasi_Diagram_CorsecItem
    {

        /// <summary>
        /// Execute Insert to TABLE [tbl_Struktur_Organisasi_Diagram_Corsec]
        /// </summary>        
        public static int UpdateGroup(int id)
        {

            tbl_Struktur_Organisasi_Diagram_Corsec item = GetByPK(id);
            if (item == null) return -1;
            int group_id = 0;
            if (item.parent_id.HasValue && item.parent_id.Value > 0)
            {
                group_id = item.group_id.Value;
            }
            else
            {
                group_id = id;
            }
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
UPDATE [tbl_Struktur_Organisasi_Diagram_Corsec]
   SET [group_id] = @group_id
 WHERE id=@id";
            context.AddParameter("@id", id);
            context.AddParameter("@group_id", group_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }


        /// <summary>
        /// Get All records from TABLE [tbl_Struktur_Organisasi_Diagram_Corsec]
        /// </summary>        
        public static List<tbl_Struktur_Organisasi_Diagram_Corsec> GetDiagram(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            //long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            //long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            string sqlQuery = @"
            WITH [Paging_tbl_Struktur_Organisasi_Diagram_Corsec] AS
            (
SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Struktur_Organisasi_Diagram_Corsec].[group_id]) AS PAGING_ROW_NUMBER,        
       [tbl_Struktur_Organisasi_Diagram_Corsec].[id]
      ,[tbl_Struktur_Organisasi_Diagram_Corsec].[jabatan_id]
      ,jabatan.name as [jabatan_nama]
      ,[tbl_Struktur_Organisasi_Diagram_Corsec].[parent_id]
	  ,[tbl_Struktur_Organisasi_Diagram_Corsec].[parent_jabatan_id]
      ,parent.name as [parent_jabatan_nama]
      ,[tbl_Struktur_Organisasi_Diagram_Corsec].[seq]
      ,[tbl_Struktur_Organisasi_Diagram_Corsec].[created]
      ,[tbl_Struktur_Organisasi_Diagram_Corsec].[created_by]
      ,[tbl_Struktur_Organisasi_Diagram_Corsec].[updated]
      ,[tbl_Struktur_Organisasi_Diagram_Corsec].[updated_by]
      ,[tbl_Struktur_Organisasi_Diagram_Corsec].[group_id]
  FROM [tbl_Struktur_Organisasi_Diagram_Corsec]
left join tbl_Struktur_Organisasi_Jabatan parent on parent.id = [tbl_Struktur_Organisasi_Diagram_Corsec].parent_jabatan_id
left join tbl_Struktur_Organisasi_Jabatan jabatan on jabatan.id = [tbl_Struktur_Organisasi_Diagram_Corsec].jabatan_id
            )

            SELECT      [Paging_tbl_Struktur_Organisasi_Diagram_Corsec].*
            FROM        [Paging_tbl_Struktur_Organisasi_Diagram_Corsec]
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
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Diagram_Corsec>(context, new tbl_Struktur_Organisasi_Diagram_Corsec());
        }
    }
}
