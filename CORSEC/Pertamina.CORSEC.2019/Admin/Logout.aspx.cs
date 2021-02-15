using System;
using System.Web.Security;
using Pertamina.CORSEC.Business.Helper;

namespace Pertamina.CORSEC._2019.Admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.ClearUserLogin();
            FormsAuthentication.SignOut();
            Response.Redirect(ResolveUrl("~/Admin/Login.aspx"));
        }
    }
}