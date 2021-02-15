using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_MenuItem
    {
        /// <summary>
        /// Get All records from TABLE [tbl_Menu]
        /// </summary>        
        public static List<tbl_Menu> GetAllActive()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "select * from tbl_Menu where ISNULL( Deleted, 0)  <> 1";
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Menu>(context, new tbl_Menu());
        }

        public static List<tbl_Menu> GetByType(string type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "select * from tbl_Menu where ISNULL( Deleted, 0)  <> 1 AND MenuType =@MenuType";
            context.AddParameter("@MenuType", type);
            context.CommandText = sqlQuery;
            context.CommandType = CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Menu>(context, new tbl_Menu());
        }
    }
}
