using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Collateral_Corporate_DetailItem
    {
        /// <summary>
        /// Get a single record of TABLE [tbl_Collateral_Corporate_Detail] by Primary Key
        /// </summary>        
        //public static List< tbl_Collateral_Corporate_Detail> GetByFK(Int32 id)
        //{
        //    IDBHelper context = new DBHelper();
        //    string sqlQuery = @"SELECT * FROM tbl_Collateral_Corporate_Detail
        //    WHERE [collateral_corporate_id]  = @id";
        //    context.AddParameter("@id", id);
        //    context.CommandText = sqlQuery;
        //    context.CommandType = System.Data.CommandType.Text;
        //    return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Detail>(context, new tbl_Collateral_Corporate_Detail());
        //}

        public static List<tbl_Collateral_Corporate_Detail> GetTOP3()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
select * from (
SELECT top  1 * FROM tbl_Collateral_Corporate_Detail where category='Kalender'
order by created desc, updated desc
) as T1
union all
select * from (
SELECT top  1 * FROM tbl_Collateral_Corporate_Detail where category='Agenda'
order by created desc, updated desc
) as T2
union all
select * from (

SELECT top  1 * FROM tbl_Collateral_Corporate_Detail where category='Kartu Ucapan'
order by created desc, updated desc

) as T3
                ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Collateral_Corporate_Detail>(context, new tbl_Collateral_Corporate_Detail());
        }
    }
}
