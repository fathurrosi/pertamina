using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                if (int.TryParse(string.Format("{0}", Request.QueryString["id"]), out id))
                {
                    tbl_Log log = tbl_LogItem.GetByPK(id);
                    if (log != null)
                    {
                        lblMessage.Text = log.ShortMessage;
                    }
                    //Response.Write(log.ShortMessage);
                }
            }
        }
    }
}