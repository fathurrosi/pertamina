using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;

namespace Pertamina.CORSEC._2019.Controls
{
    public partial class ctlUserInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string template = @"
<a href=""{0}""><span class=""kt-header__topbar-username kt-hidden-mobile"">{1}</span></a>";
            litLogin.Text = "";
            string username = Utilities.Username;

            if (username != string.Format("{0}", UserType.Anonymous))
            {
                if (Utilities.IsUser) litLogin.Text = string.Format(template, ResolveUrl("~/Logout.aspx"), "Logout");
                else litLogin.Text = string.Format(template, ResolveUrl("~/Admin/Logout.aspx"), "Logout");

            }
            else
            {
                template = @"
<a href=""{0}""><span class=""kt-header__topbar-username kt-hidden-mobile"">Login to Sekper</span></a>
<img class=""kt-hidden"" alt=""Pic"" src=""{1}"" />
<div class=""kt-widget3__user-img"">
    <img class=""kt-widget3__img"" src=""{2}"" alt="""">
</div>
";
                /*
                            <a href="<%: ResolveUrl("~/Login.aspx") %>"><span class="kt-header__topbar-username kt-hidden-mobile">Login to Sekper</span></a>
                            <img class="kt-hidden" alt="Pic" src="<%: ResolveUrl("~/Content/assets/media/users/default.jpg") %>" />
                            <div class="kt-widget3__user-img">
                                <img class="kt-widget3__img" src="<%: ResolveUrl("~/Content/assets/media/users/img_avatar2.png") %>" alt="">
                            </div>
                 */

                litLogin.Text = string.Format(template, ResolveUrl("~/Login.aspx"), ResolveUrl("~/Content/assets/media/users/default.jpg"), ResolveUrl("~/Content/assets/media/users/img_avatar2.png"));
            }
        }
    }
}