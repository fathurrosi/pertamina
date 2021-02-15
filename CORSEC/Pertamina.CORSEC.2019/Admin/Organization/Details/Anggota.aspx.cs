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
    public partial class Anggota : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlJabatan.DataSource = tbl_Struktur_Organisasi_JabatanItem.GetAll();
                ddlJabatan.DataValueField = "id";
                ddlJabatan.DataTextField = "name";
                ddlJabatan.DataBind();
                lblName.Text = "";
                tbl_Struktur_Organisasi_Anggota item = tbl_Struktur_Organisasi_AnggotaItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblName.Text = item.nama;
                    lblEmail.Text = item.email;
                    lblNip.Text = item.nip;
                    lblTelp.Text = item.telp;
                    ddlJabatan.SelectedValue = string.Format("{0}", item.jabatan_id);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int jabatan_id = 0;
            int.TryParse(ddlJabatan.SelectedValue, out jabatan_id);
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Struktur_Organisasi_Anggota item = tbl_Struktur_Organisasi_AnggotaItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Struktur_Organisasi_Anggota();
                item.created = DateTime.Now;
                item.created_by = username;
            }

            item.email = lblEmail.Text;
            item.nip = lblNip.Text;
            item.telp = lblTelp.Text;
            item.nama = lblName.Text;
            item.jabatan_id = jabatan_id;

            item.updated = DateTime.Now;
            item.updated_by = username;

            tbl_Struktur_Organisasi_Anggota result = null;
            if (!isEdit)
            {
                result = tbl_Struktur_Organisasi_AnggotaItem.Insert(item);
            }
            else
            {
                result = tbl_Struktur_Organisasi_AnggotaItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Organization/Anggota.aspx{0}", PrevUrl)));
            }
        }
    }
}