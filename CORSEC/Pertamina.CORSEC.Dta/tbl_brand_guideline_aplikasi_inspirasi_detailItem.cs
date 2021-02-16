
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_brand_guideline_aplikasi_inspirasi_detail]
    /// </summary>    
    public partial class tbl_brand_guideline_aplikasi_inspirasi_detailItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_brand_guideline_aplikasi_inspirasi_detail]
        /// </summary>        
        public static tbl_brand_guideline_aplikasi_inspirasi_detail Insert(tbl_brand_guideline_aplikasi_inspirasi_detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_brand_guideline_aplikasi_inspirasi_detail]([logo_type], [title], [body], [image_type], [image_path], [image_name], [image_ext], [image_blob], [image_size], [created], [created_by]) 
VALUES      (@logo_type, @title, @body, @image_type, @image_path, @image_name, @image_ext, @image_blob, @image_size, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, logo_type, title, body, image_type, image_path, image_name, image_ext, image_blob, image_size, created, created_by, updated, updated_by
FROM    [tbl_brand_guideline_aplikasi_inspirasi_detail]
WHERE   [id]  = @_id";
            context.AddParameter("@logo_type", obj.logo_type);
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@image_type", string.Format("{0}", obj.image_type));
            context.AddParameter("@image_path", string.Format("{0}", obj.image_path));
            context.AddParameter("@image_name", string.Format("{0}", obj.image_name));
            context.AddParameter("@image_ext", string.Format("{0}", obj.image_ext));
            context.AddParameter("@image_blob", obj.image_blob, System.Data.DbType.Binary);
            context.AddParameter("@image_size", string.Format("{0}", obj.image_size));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_guideline_aplikasi_inspirasi_detail>(context, new tbl_brand_guideline_aplikasi_inspirasi_detail()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_brand_guideline_aplikasi_inspirasi_detail]
        /// </summary>        
        public static tbl_brand_guideline_aplikasi_inspirasi_detail Update(tbl_brand_guideline_aplikasi_inspirasi_detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_brand_guideline_aplikasi_inspirasi_detail]
SET         [logo_type] = @logo_type,
            [title] = @title,
            [body] = @body,
            [image_type] = @image_type,
            [image_path] = @image_path,
            [image_name] = @image_name,
            [image_ext] = @image_ext,
            [image_blob] = @image_blob,
            [image_size] = @image_size,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, logo_type, title, body, image_type, image_path, image_name, image_ext, image_blob, image_size, created, created_by, updated, updated_by 
FROM    [tbl_brand_guideline_aplikasi_inspirasi_detail]
WHERE   [id]  = @id";
            context.AddParameter("@logo_type", obj.logo_type);
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@image_type", string.Format("{0}", obj.image_type));
            context.AddParameter("@image_path", string.Format("{0}", obj.image_path));
            context.AddParameter("@image_name", string.Format("{0}", obj.image_name));
            context.AddParameter("@image_ext", string.Format("{0}", obj.image_ext));
            context.AddParameter("@image_blob", obj.image_blob, System.Data.DbType.Binary);
            context.AddParameter("@image_size", string.Format("{0}", obj.image_size));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_guideline_aplikasi_inspirasi_detail>(context, new tbl_brand_guideline_aplikasi_inspirasi_detail()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_brand_guideline_aplikasi_inspirasi_detail]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_brand_guideline_aplikasi_inspirasi_detail 
WHERE   [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_brand_guideline_aplikasi_inspirasi_detail]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_brand_guideline_aplikasi_inspirasi_detail";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_guideline_aplikasi_inspirasi_detail]
        /// </summary>        
        public static List<tbl_brand_guideline_aplikasi_inspirasi_detail> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, logo_type, title, body, image_type, image_path, image_name, image_ext, image_blob, image_size, created, created_by, updated, updated_by FROM tbl_brand_guideline_aplikasi_inspirasi_detail";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_guideline_aplikasi_inspirasi_detail>(context, new tbl_brand_guideline_aplikasi_inspirasi_detail());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_brand_guideline_aplikasi_inspirasi_detail]
        /// </summary>        
        public static List<tbl_brand_guideline_aplikasi_inspirasi_detail> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_brand_guideline_aplikasi_inspirasi_detail] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_brand_guideline_aplikasi_inspirasi_detail].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_brand_guideline_aplikasi_inspirasi_detail].*
                FROM    [tbl_brand_guideline_aplikasi_inspirasi_detail]
            )

            SELECT      [Paging_tbl_brand_guideline_aplikasi_inspirasi_detail].*
            FROM        [Paging_tbl_brand_guideline_aplikasi_inspirasi_detail]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_brand_guideline_aplikasi_inspirasi_detail>(context, new tbl_brand_guideline_aplikasi_inspirasi_detail());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_brand_guideline_aplikasi_inspirasi_detail] by Primary Key
        /// </summary>        
        public static tbl_brand_guideline_aplikasi_inspirasi_detail GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, logo_type, title, body, image_type, image_path, image_name, image_ext, image_blob, image_size, created, created_by, updated, updated_by FROM tbl_brand_guideline_aplikasi_inspirasi_detail
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_brand_guideline_aplikasi_inspirasi_detail>(context, new tbl_brand_guideline_aplikasi_inspirasi_detail()).FirstOrDefault();
        }

        #endregion

    }
}