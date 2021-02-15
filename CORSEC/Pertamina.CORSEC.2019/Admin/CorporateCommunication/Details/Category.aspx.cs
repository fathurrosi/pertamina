using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.CorporateCommunication.Details
{
    public partial class Category : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtName.Text = "";
                txtUrut.Text = "";
                tbl_CorporateCommunication_Category item = tbl_CorporateCommunication_CategoryItem.GetByPK(ItemID);
                if (item != null)
                {
                    txtName.Text = item.Name;
                    txtUrut.Text = string.Format("{0}", item.Sequence);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_CorporateCommunication_Category item = tbl_CorporateCommunication_CategoryItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_CorporateCommunication_Category();
                item.created = DateTime.Now;
                item.created_by = username;

            }

            int _seq = 0;
            int.TryParse(txtUrut.Text, out _seq);
            item.created = item.created.HasValue ? item.created : DateTime.Now;
            item.Sequence = _seq;
            item.Name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(item.Name))
            {
                lblMessage.Text = GetValidationMessage("Nama Kategori harus diisi");
                return;
            }
            item.updated = DateTime.Now;
            item.updated_by = username;

            tbl_CorporateCommunication_Category result = null;
            if (!isEdit)
            {
                result = tbl_CorporateCommunication_CategoryItem.Insert(item);
            }
            else
            {
                result = tbl_CorporateCommunication_CategoryItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/CorporateCommunication/Category.aspx{0}", PrevUrl)));
            }
        }
    }
}