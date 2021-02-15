using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Profile_Strategic_PartnerItem
    {
        public static tbl_Profile_Strategic_Partner GetByTab(string tab_text)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, title, body, created, created_by, updated, updated_by, tab_text FROM tbl_Profile_Strategic_Partner
            WHERE [tab_text]  = @tab_text";
            context.AddParameter("@tab_text", tab_text);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Strategic_Partner>(context, new tbl_Profile_Strategic_Partner()).FirstOrDefault();
        }
    }
}
