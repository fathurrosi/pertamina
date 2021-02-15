
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Design_Grafis]
    /// </summary>    
    public partial class tbl_Design_GrafisItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Design_Grafis]
        /// </summary>        
        public static tbl_Design_Grafis Insert(tbl_Design_Grafis obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Design_Grafis]([title], [body], [created], [created_by], [data_type], [img_type], [img_path], [img_name], [img_ext], [img_blob], [img_size], [data_year]) 
VALUES      (@title, @body, @created, @created_by, @data_type, @img_type, @img_path, @img_name, @img_ext, @img_blob, @img_size, @data_year)

SET @Err = @@Error

DECLARE @_id BigInt
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, title, body, created, created_by, updated, updated_by, data_type, img_type, img_path, img_name, img_ext, img_blob, img_size, data_year
FROM    [tbl_Design_Grafis]
WHERE   [id]  = @_id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@data_type", obj.data_type);
            context.AddParameter("@img_type", string.Format("{0}", obj.img_type));
            context.AddParameter("@img_path", string.Format("{0}", obj.img_path));
            context.AddParameter("@img_name", string.Format("{0}", obj.img_name));
            context.AddParameter("@img_ext", string.Format("{0}", obj.img_ext));
            context.AddParameter("@img_blob", obj.img_blob, System.Data.DbType.Binary);
            context.AddParameter("@img_size", string.Format("{0}", obj.img_size));
            context.AddParameter("@data_year", obj.data_year);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis>(context, new tbl_Design_Grafis()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Design_Grafis]
        /// </summary>        
        public static tbl_Design_Grafis Update(tbl_Design_Grafis obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Design_Grafis]
SET         [title] = @title,
            [body] = @body,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [data_type] = @data_type,
            [img_type] = @img_type,
            [img_path] = @img_path,
            [img_name] = @img_name,
            [img_ext] = @img_ext,
            [img_blob] = @img_blob,
            [img_size] = @img_size,
            [data_year] = @data_year
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, title, body, created, created_by, updated, updated_by, data_type, img_type, img_path, img_name, img_ext, img_blob, img_size, data_year 
FROM    [tbl_Design_Grafis]
WHERE   [id]  = @id";
            context.AddParameter("@title", string.Format("{0}", obj.title));
            context.AddParameter("@body", string.Format("{0}", obj.body));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@data_type", obj.data_type);
            context.AddParameter("@img_type", string.Format("{0}", obj.img_type));
            context.AddParameter("@img_path", string.Format("{0}", obj.img_path));
            context.AddParameter("@img_name", string.Format("{0}", obj.img_name));
            context.AddParameter("@img_ext", string.Format("{0}", obj.img_ext));
            context.AddParameter("@img_blob", obj.img_blob, System.Data.DbType.Binary);
            context.AddParameter("@img_size", string.Format("{0}", obj.img_size));
            context.AddParameter("@data_year", obj.data_year);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis>(context, new tbl_Design_Grafis()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Design_Grafis]
        /// </summary>        
        public static int Delete(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Design_Grafis 
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
        /// Get Total records from [tbl_Design_Grafis]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Design_Grafis";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Design_Grafis]
        /// </summary>        
        public static List<tbl_Design_Grafis> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, title, body, created, created_by, updated, updated_by, data_type, img_type, img_path, img_name, img_ext, img_blob, img_size, data_year FROM tbl_Design_Grafis";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis>(context, new tbl_Design_Grafis());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Design_Grafis]
        /// </summary>        
        public static List<tbl_Design_Grafis> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Design_Grafis] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Design_Grafis].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_Design_Grafis].*
                FROM    [tbl_Design_Grafis]
            )

            SELECT      [Paging_tbl_Design_Grafis].*
            FROM        [Paging_tbl_Design_Grafis]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis>(context, new tbl_Design_Grafis());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Design_Grafis] by Primary Key
        /// </summary>        
        public static tbl_Design_Grafis GetByPK(Int64 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, created, created_by, updated, updated_by, data_type, img_type, img_path, img_name, img_ext, img_blob, img_size, data_year FROM tbl_Design_Grafis
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Design_Grafis>(context, new tbl_Design_Grafis()).FirstOrDefault();
        }

        #endregion

    }
}