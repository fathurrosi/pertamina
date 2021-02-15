using System;

using System.Linq;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_Profile_TemplateItem
    {
        public static tbl_Profile_Template GetByType(string header_type)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT * FROM tbl_Profile_Template
            WHERE [header_type]  = @header_type";
            context.AddParameter("@header_type", header_type);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Profile_Template>(context, new tbl_Profile_Template()).FirstOrDefault();
        }
    }
}
