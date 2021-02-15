using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Dta
{
    public partial class tbl_File_TemplateItem
    {
        public static tbl_File_Template GetByTemplateType(int tempType)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"	
            SELECT top 1 *  FROM [tbl_File_Template]
            WHERE [template_type] =@template_type

            ";
            context.CommandType = System.Data.CommandType.Text;
            context.AddParameter("@template_type", tempType);
            return DBUtil.ExecuteMapper(context, new tbl_File_Template()).FirstOrDefault();
        }
        public static tbl_File_Template GetByReff(string ReferenceTable, string ReferenceID)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"	
            SELECT top 1 *  FROM [tbl_File_Template]
            WHERE [ref_name] =@ReferenceTable and [ref_id] =@ReferenceID

            ";
            context.CommandType = System.Data.CommandType.Text;
            context.AddParameter("@ReferenceTable", ReferenceTable);
            context.AddParameter("@ReferenceID", ReferenceID);
            return DBUtil.ExecuteMapper(context, new tbl_File_Template()).FirstOrDefault();
        }

    }
}
