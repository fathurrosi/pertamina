using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.About.Details
{
    public partial class UpdateFooter : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbl_Footer_Detail item = tbl_Footer_DetailItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblLink.Text = item.footer_link;
                    lblText.Text = item.footer_text;
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            tbl_Footer_Detail item = tbl_Footer_DetailItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Footer_Detail();
                item.created = DateTime.Now;
                item.created_by = Utilities.Username;
                item.footer = ParentItemID;

            }

            item.created = item.created.HasValue ? item.created : DateTime.Now;
            item.footer_text = lblText.Text;
            item.footer_link = lblLink.Text;

            item.updated = DateTime.Now;
            item.updated_by = Utilities.Username;
            if (!isEdit)
            {
                tbl_Footer_DetailItem.Insert(item);
            }
            else
            {
                tbl_Footer_DetailItem.Update(item);
            }
            Response.Redirect(ResolveUrl(string.Format("~/Admin/About/Details/Footer.aspx{0}&id={1}", PrevUrl, ParentItemID)));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/About/Details/Footer.aspx{0}&id={1}", PrevUrl, ParentItemID)));
        }
    }
}