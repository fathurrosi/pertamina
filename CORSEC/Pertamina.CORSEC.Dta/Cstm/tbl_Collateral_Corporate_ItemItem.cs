using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Collateral_Corporate_ItemItem
    {

     
        public static List<tbl_File> GetListByID(int id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
declare 
@year int,
@category varchar(50),
@calender_type varchar(50);

select @year = [year], @category=category, @calender_type= calender_type from [tbl_Collateral_Corporate_Item]
where [id] = @id;

select * into #tempFile from [tbl_File] 
where ref_name ='tbl_Collateral_Corporate_Item'

select * from #tempFile f
inner join tbl_Collateral_Corporate_Item c on c.id= f.ref_id 
where [year] = @year AND category = @category AND calender_type = @calender_type;

drop table #tempFile
        
";

            context.AddParameter("@id", id);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            List<tbl_File> result = DBUtil.ExecuteMapper<tbl_File>(context, new tbl_File());
            return result;
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Collateral_Corporate_Item]
        /// </summary>        
        public static List<tbl_Collateral_Corporate_Item> GetPagingByCategory(int PageSize, int PageIndex, string Category)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Collateral_Corporate_Item] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Collateral_Corporate_Item].[id] DESC) AS PAGING_ROW_NUMBER,
                        [tbl_Collateral_Corporate_Item].*
                FROM    [tbl_Collateral_Corporate_Item]
                
            )

            SELECT      [Paging_tbl_Collateral_Corporate_Item].*
            FROM        [Paging_tbl_Collateral_Corporate_Item]
            Where       category =@category
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";

            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.AddParameter("@category", Category);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            List<tbl_Collateral_Corporate_Item> result= DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Item>(context, new tbl_Collateral_Corporate_Item());
            return result;
        }

        public static List<tbl_Collateral_Corporate_Item> GetByCategory(string Category)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            SELECT      [tbl_Collateral_Corporate_Item].*
            FROM        [tbl_Collateral_Corporate_Item]
            Where       category =@category
        
";

            context.AddParameter("@category", Category);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            List<tbl_Collateral_Corporate_Item> result = DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Item>(context, new tbl_Collateral_Corporate_Item());
            return result;
        }

        /// <summary>
        /// Get Total records from [tbl_Collateral_Corporate_Item]
        /// </summary>        
        public static int GetCountByCategory(int PageSize, int PageIndex, string Category)
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Count(*) as Total FROM tbl_Collateral_Corporate_Item 
                                Where   category =@category ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            context.AddParameter("@category", Category);
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;

        }

    }
}
