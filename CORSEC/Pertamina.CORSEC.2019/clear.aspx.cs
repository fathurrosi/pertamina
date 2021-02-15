using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;

namespace Pertamina.CORSEC._2019
{
    public partial class clear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Utilities.ClearAllManus();
                lblText.Text = string.Format("{0:dd MMM yyyy hh:mm:ss}", DateTime.Now);
            }

        }
    }
}