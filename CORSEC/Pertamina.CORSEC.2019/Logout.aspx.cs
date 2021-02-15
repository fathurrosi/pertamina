using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business.Helper;

namespace Pertamina.CORSEC._2019
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.ClearUserLogin();
            SessionHelper.ClearCart();
            FormsAuthentication.SignOut();
            Response.Redirect(FormsAuthentication.DefaultUrl);
        }
    }
}