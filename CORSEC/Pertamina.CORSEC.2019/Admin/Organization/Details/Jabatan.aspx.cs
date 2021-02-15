using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Organization.Details
{
    public partial class Jabatan : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblName.Text = "";
                tbl_Struktur_Organisasi_Jabatan item = tbl_Struktur_Organisasi_JabatanItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblName.Text = item.name;

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Struktur_Organisasi_Jabatan item = tbl_Struktur_Organisasi_JabatanItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Struktur_Organisasi_Jabatan();
                item.created = DateTime.Now;
                item.created_by = username;
            }

            item.name = lblName.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;

            tbl_Struktur_Organisasi_Jabatan result = null;
            if (!isEdit)
            {
                result = tbl_Struktur_Organisasi_JabatanItem.Insert(item);
            }
            else
            {
                result = tbl_Struktur_Organisasi_JabatanItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Organization/Jabatan.aspx{0}", PrevUrl)));
            }
        }
    }
}