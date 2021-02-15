using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Controls
{
    public partial class ctlBreadCrumb : System.Web.UI.UserControl
    {

        public int MenuID
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["m"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public int ParentID
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["p"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public int ItemID
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["id"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //            string template = @"
            //<h3 class=""kt-subheader__title"">Brand Management</h3>
            //<span class=""kt-subheader__separator kt-hidden""></span>
            //<div class=""kt-subheader__breadcrumbs"">
            //    <span class=""kt-subheader__separator kt-subheader__separator--v""></span>
            //    <a href=""logos.html"" class=""kt-subheader__breadcrumbs-link"">Merchandise hub</a>
            //    <span class=""kt-subheader__separator kt-subheader__separator--v ml-2""></span>
            //    <a href=""#"" class=""kt-subheader__breadcrumbs-link kt-subheader__breadcrumbs-link--activ"">Detail </a>
            //</div>
            //";
            string parentTample = @"<h3 class=""kt-subheader__title"">{0}</h3>";
            string template = @"

    <span class=""kt-subheader__separator kt-subheader__separator--v""></span>
    <a href=""{1}"" class=""kt-subheader__breadcrumbs-link"">{0}</a>
";

            string detailTemplate = @"
  <span class=""kt-subheader__separator kt-subheader__separator--v ml-2""></span>
  <a href=""#"" class=""kt-subheader__breadcrumbs-link kt-subheader__breadcrumbs-link--activ"">Detail </a>
";
            List<tbl_Menu> list = Utilities.GetALL_MENU();
            tbl_Menu item = list.Where(t => t.ID == MenuID).FirstOrDefault();
            if (item != null)
            {
                if (item.ParentID > 0)
                {

                    tbl_Menu parentItem = list.Where(t => t.ID == ParentID).FirstOrDefault();
                    lit.Text = string.Format(parentTample, parentItem.Name);
                    lit.Text += @"<span class=""kt-subheader__separator kt-hidden""></span>";
                    lit.Text += @"<div class=""kt-subheader__breadcrumbs"">";
                    lit.Text += string.Format(template, item.Name, ResolveUrl(string.Format("{0}?p={1}&m={2}", item.Url, ParentID, MenuID)));
                    if (ItemID > 0)
                    {
                        lit.Text += detailTemplate;
                    }

                    lit.Text += @"</div>";
                }
                else
                {
                    lit.Text = string.Format(parentTample, item.Name);
                }
            }

        }
    }
}