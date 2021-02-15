
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_product_contact_person]
    /// </summary>    
    public partial class tbl_product_contact_personItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_product_contact_person]
        /// </summary>        
        public static tbl_product_contact_person Insert(tbl_product_contact_person obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_product_contact_person]([name], [phone], [email], [created], [created_by]) 
VALUES      (@name, @phone, @email, @created, @created_by)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, name, phone, email, created, created_by, updated, updated_by
FROM    [tbl_product_contact_person]
WHERE   [id]  = @_id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@phone", string.Format("{0}", obj.phone));
            context.AddParameter("@email", string.Format("{0}", obj.email));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_product_contact_person>(context, new tbl_product_contact_person()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_product_contact_person]
        /// </summary>        
        public static tbl_product_contact_person Update(tbl_product_contact_person obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_product_contact_person]
SET         [name] = @name,
            [phone] = @phone,
            [email] = @email,
            [updated] = @updated,
            [updated_by] = @updated_by
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, name, phone, email, created, created_by, updated, updated_by 
FROM    [tbl_product_contact_person]
WHERE   [id]  = @id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@phone", string.Format("{0}", obj.phone));
            context.AddParameter("@email", string.Format("{0}", obj.email));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_product_contact_person>(context, new tbl_product_contact_person()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_product_contact_person]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_product_contact_person 
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
        /// Get Total records from [tbl_product_contact_person]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_product_contact_person";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_product_contact_person]
        /// </summary>        
        public static List<tbl_product_contact_person> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, name, phone, email, created, created_by, updated, updated_by FROM tbl_product_contact_person";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_product_contact_person>(context, new tbl_product_contact_person());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_product_contact_person]
        /// </summary>        
        public static List<tbl_product_contact_person> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_product_contact_person] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_product_contact_person].[id]) AS PAGING_ROW_NUMBER,
                        [tbl_product_contact_person].*
                FROM    [tbl_product_contact_person]
            )

            SELECT      [Paging_tbl_product_contact_person].*
            FROM        [Paging_tbl_product_contact_person]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_product_contact_person>(context, new tbl_product_contact_person());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_product_contact_person] by Primary Key
        /// </summary>        
        public static tbl_product_contact_person GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, name, phone, email, created, created_by, updated, updated_by FROM tbl_product_contact_person
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_product_contact_person>(context, new tbl_product_contact_person()).FirstOrDefault();
        }

        #endregion

    }
}