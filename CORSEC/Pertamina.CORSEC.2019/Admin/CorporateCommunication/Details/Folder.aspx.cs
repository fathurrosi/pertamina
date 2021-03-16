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
    public partial class Folder : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtName.Text = "";
                txtUrut.Text = "";
                tbl_CorporateCommunication_Sub_Category item = tbl_CorporateCommunication_Sub_CategoryItem.GetByPK(ItemID);
                if (item != null)
                {
                    txtName.Text = item.Name;
                    txtUrut.Text = string.Format("{0}", item.Sequence);
                    //txtTahun.Text = string.Format("{0}", item.Year);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_CorporateCommunication_Sub_Category item = tbl_CorporateCommunication_Sub_CategoryItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_CorporateCommunication_Sub_Category();
                item.created = DateTime.Now;
                item.created_by = username;
                item.Category = ParentItemID;

            }

            int _seq = 0;
            int.TryParse(txtUrut.Text, out _seq);


            //int _tahun = 0;
            //if (int.TryParse(txtTahun.Text, out _tahun))
            //{
            //    _tahun = DateTime.Now.Year;
            //}
         

            item.created = item.created.HasValue ? item.created : DateTime.Now;
            item.Sequence = _seq;
            item.Name = txtName.Text;
            //item.Year = _tahun;
            item.updated = DateTime.Now;
            item.updated_by = username;
            if (string.IsNullOrEmpty(item.Name))
            {
                lblMessage.Text = GetValidationMessage("Sub Kategori harus diisi");
                return;
            }
            tbl_CorporateCommunication_Sub_Category result = null;
            if (!isEdit)
            {
                result = tbl_CorporateCommunication_Sub_CategoryItem.Insert(item);
            }
            else
            {
                result = tbl_CorporateCommunication_Sub_CategoryItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/CorporateCommunication/Folder.aspx{0}&pid={1}", PrevUrl, ParentItemID)));
            }
        }
    }
}