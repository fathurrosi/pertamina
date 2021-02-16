
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Profile_Visi_Misi]
    /// </summary>    
    public partial class tbl_Profile_Visi_MisiItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Profile_Visi_Misi]
        /// </summary>        
        public static tbl_Profile_Visi_Misi Insert(tbl_Profile_Visi_Misi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Profile_Visi_Misi]([Title], [SubTitle], [Contents], [Visi], [Misi], [created], [created_by], [tab_text], [Visi_Content], [Misi_Content]) 
VALUES      (@Title, @SubTitle, @Contents, @Visi, @Misi, @created, @created_by, @tab_text, @Visi_Content, @Misi_Content)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, Title, SubTitle, Contents, Visi, Misi, created, created_by, updated, updated_by, tab_text, Visi_Content, Misi_Content
FROM    [tbl_Profile_Visi_Misi]
WHERE   [id]  = @_id";
            context.AddParameter("@Title", string.Format("{0}", obj.Title));
            context.AddParameter("@SubTitle", string.Format("{0}", obj.SubTitle));
            context.AddParameter("@Contents", string.Format("{0}", obj.Contents));
            context.AddParameter("@Visi", string.Format("{0}", obj.Visi));
            context.AddParameter("@Misi", string.Format("{0}", obj.Misi));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.AddParameter("@tab_text", string.Format("{0}", obj.tab_text));
            context.AddParameter("@Visi_Content", string.Format("{0}", obj.Visi_Content));
            context.AddParameter("@Misi_Content", string.Format("{0}", obj.Misi_Content));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Visi_Misi>(context, new tbl_Profile_Visi_Misi()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Profile_Visi_Misi]
        /// </summary>        
        public static tbl_Profile_Visi_Misi Update(tbl_Profile_Visi_Misi obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Profile_Visi_Misi]
SET         [Title] = @Title,
            [SubTitle] = @SubTitle,
            [Contents] = @Contents,
            [Visi] = @Visi,
            [Misi] = @Misi,
            [updated] = @updated,
            [updated_by] = @updated_by,
            [tab_text] = @tab_text,
            [Visi_Content] = @Visi_Content,
            [Misi_Content] = @Misi_Content
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, Title, SubTitle, Contents, Visi, Misi, created, created_by, updated, updated_by, tab_text, Visi_Content, Misi_Content 
FROM    [tbl_Profile_Visi_Misi]
WHERE   [id]  = @id";
            context.AddParameter("@Title", string.Format("{0}", obj.Title));
            context.AddParameter("@SubTitle", string.Format("{0}", obj.SubTitle));
            context.AddParameter("@Contents", string.Format("{0}", obj.Contents));
            context.AddParameter("@Visi", string.Format("{0}", obj.Visi));
            context.AddParameter("@Misi", string.Format("{0}", obj.Misi));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updated_by", string.Format("{0}", obj.updated_by));
            context.AddParameter("@tab_text", string.Format("{0}", obj.tab_text));
            context.AddParameter("@Visi_Content", string.Format("{0}", obj.Visi_Content));
            context.AddParameter("@Misi_Content", string.Format("{0}", obj.Misi_Content));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Visi_Misi>(context, new tbl_Profile_Visi_Misi()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Profile_Visi_Misi]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Profile_Visi_Misi 
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
        /// Get Total records from [tbl_Profile_Visi_Misi]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Profile_Visi_Misi";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Profile_Visi_Misi]
        /// </summary>        
        public static List<tbl_Profile_Visi_Misi> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, Title, SubTitle, Contents, Visi, Misi, created, created_by, updated, updated_by, tab_text, Visi_Content, Misi_Content FROM tbl_Profile_Visi_Misi";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Visi_Misi>(context, new tbl_Profile_Visi_Misi());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Profile_Visi_Misi]
        /// </summary>        
        public static List<tbl_Profile_Visi_Misi> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Profile_Visi_Misi] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Profile_Visi_Misi].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Profile_Visi_Misi].*
                FROM    [tbl_Profile_Visi_Misi]
            )

            SELECT      [Paging_tbl_Profile_Visi_Misi].*
            FROM        [Paging_tbl_Profile_Visi_Misi]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Profile_Visi_Misi>(context, new tbl_Profile_Visi_Misi());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Profile_Visi_Misi] by Primary Key
        /// </summary>        
        public static tbl_Profile_Visi_Misi GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, Title, SubTitle, Contents, Visi, Misi, created, created_by, updated, updated_by, tab_text, Visi_Content, Misi_Content FROM tbl_Profile_Visi_Misi
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Visi_Misi>(context, new tbl_Profile_Visi_Misi()).FirstOrDefault();
        }

        #endregion

    }
}