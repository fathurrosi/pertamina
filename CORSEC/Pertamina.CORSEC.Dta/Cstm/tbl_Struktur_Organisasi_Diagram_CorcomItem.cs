
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Struktur_Organisasi_Diagram_CorcomItem
    {

        /// <summary>
        /// Execute Insert to TABLE [tbl_Struktur_Organisasi_Diagram_Corcom]
        /// </summary>        
        public static int UpdateGroup(int id)
        {

            tbl_Struktur_Organisasi_Diagram_Corcom item = GetByPK(id);
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
UPDATE [tbl_Struktur_Organisasi_Diagram_Corcom]
   SET [group_id] = @group_id
 WHERE id=@id";
            context.AddParameter("@id", id);
            context.AddParameter("@group_id", group_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }


        /// <summary>
        /// Get All records from TABLE [tbl_Struktur_Organisasi_Diagram_Corcom]
        /// </summary>        
        public static List<tbl_Struktur_Organisasi_Diagram_Corcom> GetDiagram(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            //long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            //long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            string sqlQuery = @"
            WITH [Paging_tbl_Struktur_Organisasi_Diagram_Corcom] AS
            (
SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Struktur_Organisasi_Diagram_Corcom].[group_id] DESC) AS PAGING_ROW_NUMBER,        
       [tbl_Struktur_Organisasi_Diagram_Corcom].[id]
      ,[tbl_Struktur_Organisasi_Diagram_Corcom].[jabatan_id]
      ,jabatan.name as [jabatan_nama]
      ,[tbl_Struktur_Organisasi_Diagram_Corcom].[parent_id]
	  ,[tbl_Struktur_Organisasi_Diagram_Corcom].[parent_jabatan_id]
      ,parent.name as [parent_jabatan_nama]
      ,[tbl_Struktur_Organisasi_Diagram_Corcom].[seq]
      ,[tbl_Struktur_Organisasi_Diagram_Corcom].[created]
      ,[tbl_Struktur_Organisasi_Diagram_Corcom].[created_by]
      ,[tbl_Struktur_Organisasi_Diagram_Corcom].[updated]
      ,[tbl_Struktur_Organisasi_Diagram_Corcom].[updated_by]
      ,[tbl_Struktur_Organisasi_Diagram_Corcom].[group_id]
  FROM [tbl_Struktur_Organisasi_Diagram_Corcom]
left join tbl_Struktur_Organisasi_Jabatan parent on parent.id = [tbl_Struktur_Organisasi_Diagram_Corcom].parent_jabatan_id
left join tbl_Struktur_Organisasi_Jabatan jabatan on jabatan.id = [tbl_Struktur_Organisasi_Diagram_Corcom].jabatan_id
            )

            SELECT      [Paging_tbl_Struktur_Organisasi_Diagram_Corcom].*
            FROM        [Paging_tbl_Struktur_Organisasi_Diagram_Corcom]
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
            return DBUtil.ExecuteMapper<tbl_Struktur_Organisasi_Diagram_Corcom>(context, new tbl_Struktur_Organisasi_Diagram_Corcom());
        }
    }
}
