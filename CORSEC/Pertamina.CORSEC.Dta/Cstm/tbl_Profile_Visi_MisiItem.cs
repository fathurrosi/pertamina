using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Profile_Visi_MisiItem
    {
        public static tbl_Profile_Visi_Misi GetByTab(string tab_text)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT * FROM tbl_Profile_Visi_Misi
            WHERE tab_text  = @tab_text";
            context.AddParameter("@tab_text", tab_text);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Visi_Misi>(context, new tbl_Profile_Visi_Misi()).FirstOrDefault();
        }
    }
}
