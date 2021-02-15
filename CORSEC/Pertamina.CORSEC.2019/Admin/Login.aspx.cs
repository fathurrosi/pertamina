using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Business.Helper;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
#if DEBUG
                txtPassword.Text = "admin";
                txtUsername.Text = "user";
#endif
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            SessionHelper.Clear();
            bool rememberMe = remember.Checked;
            string usernname = txtUsername.Text.Trim();
            string password = Business.Security.MD5Hash(txtPassword.Text.Trim());
            Log.Info(string.Format("User :{0}-{1} try to log in", usernname, password));
            Dto.Cstm.tbl_User Item = tbl_UserItem.GetUser(usernname);
            if (Item != null && Item.Password == password &&
                Item.Roles.Where(t => string.Format("{0}", t.Name).ToLower() == string.Format("{0}", UserType.Administrator).ToLower()).Count() > 0)
            {
                SessionHelper.ClearUserLogin();
                Business.Login.Update(usernname);

                if (rememberMe)
                {
                    // Clear any other tickets that are already in the response
                    Response.Cookies.Clear();

                    // Set the new expiry date - to thirty days from now
                    DateTime expiryDate = DateTime.Now.AddDays(1);

                    // Create a new forms auth ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, usernname, DateTime.Now, expiryDate, true, String.Empty);

                    // Encrypt the ticket
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    // Create a new authentication cookie - and set its expiration date
                    HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    authenticationCookie.Expires = ticket.Expiration;
                    // Add the cookie to the response.
                    Response.Cookies.Add(authenticationCookie);
                    Response.Redirect(ResolveUrl("~/Admin/Default.aspx"));
                }
                else
                {
                    //FormsAuthentication.SetAuthCookie(txtUsername.Value, true);
                    FormsAuthentication.SetAuthCookie(Item.Username, rememberMe);
                    Response.Redirect(ResolveUrl("~/Admin/Default.aspx"));
                }
            }
        }

    }
}