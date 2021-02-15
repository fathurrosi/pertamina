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
    public partial class StrukturCorsec : AuthorizeAdminPage
    {
        public string ItemType
        {
            get
            {
                return string.Format("{0}", Request.QueryString["t"]);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                List<tbl_Struktur_Organisasi_Jabatan> list = tbl_Struktur_Organisasi_JabatanItem.GetAll();
                //ddlJabatanParent.DataSource = tbl_Struktur_Organisasi_JabatanItem.GetAll();
                //ddlJabatanParent.DataValueField = "id";
                //ddlJabatanParent.DataTextField = "name";
                //ddlJabatanParent.DataBind();
                //lblName.Text = "";

                if (ItemType == "a")
                {
                    tbl_Struktur_Organisasi_Diagram_Corsec item = tbl_Struktur_Organisasi_Diagram_CorsecItem.GetByPK(ParentItemID);
                    if (item != null)
                    {
                        ddlJabatan.DataSource = list.Where(t => t.id != item.jabatan_id).ToList();
                        ddlJabatan.DataValueField = "id";
                        ddlJabatan.DataTextField = "name";
                        ddlJabatan.DataBind();

                        tbl_Struktur_Organisasi_Jabatan jabatan = list.Where(t => t.id == item.jabatan_id).FirstOrDefault();
                        lblRootName.Text = (jabatan == null) ? "" : jabatan.name;
                        hdnParentJabatanID.Value = string.Format("{0}", item.jabatan_id);
                        hdnParentID.Value = item.id.ToString();
                        lblUrut.Text = string.Format("{0}", item.seq);
                    }
                }
                else
                {
                    ddlJabatan.DataSource = list;
                    ddlJabatan.DataValueField = "id";
                    ddlJabatan.DataTextField = "name";
                    ddlJabatan.DataBind();
                    tbl_Struktur_Organisasi_Diagram_Corsec item = tbl_Struktur_Organisasi_Diagram_CorsecItem.GetByPK(ItemID);
                    if (item != null)
                    {
                        //lblName.Text = item.name;
                        ddlJabatan.SelectedValue = string.Format("{0}", item.jabatan_id);
                        hdnParentID.Value = string.Format("{0}", item.parent_id);

                        tbl_Struktur_Organisasi_Jabatan jabatan = list.Where(t => t.id == item.parent_jabatan_id).FirstOrDefault();

                        lblRootName.Text = (jabatan == null) ? "" : jabatan.name;
                        lblUrut.Text = string.Format("{0}", item.seq);
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            List<tbl_Struktur_Organisasi_Diagram_Corsec> list = tbl_Struktur_Organisasi_Diagram_CorsecItem.GetAll();

            int jabatan_id = 0;
            int.TryParse(ddlJabatan.SelectedValue, out jabatan_id);


            int seq = 0;
            int.TryParse(lblUrut.Text, out seq);
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Struktur_Organisasi_Diagram_Corsec item = tbl_Struktur_Organisasi_Diagram_CorsecItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Struktur_Organisasi_Diagram_Corsec();
                item.created = DateTime.Now;
                item.created_by = username;
                item.group_id = 0;
            }

            item.jabatan_id = jabatan_id;



            int parent_id = 0;
            int.TryParse(hdnParentID.Value, out parent_id);
            tbl_Struktur_Organisasi_Diagram_Corsec parent = list.Where(t => t.id == parent_id).FirstOrDefault();
            item.parent_id = parent == null ? 0 : parent.id;
            item.parent_jabatan_id = parent == null ? 0 : parent.jabatan_id;
            item.seq = seq;
            item.updated = DateTime.Now;
            item.updated_by = username;

            tbl_Struktur_Organisasi_Diagram_Corsec result = null;
            if (!isEdit)
            {
                result = tbl_Struktur_Organisasi_Diagram_CorsecItem.Insert(item);
                if (result != null) tbl_Struktur_Organisasi_Diagram_CorsecItem.UpdateGroup(result.id);
            }
            else
            {
                result = tbl_Struktur_Organisasi_Diagram_CorsecItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Organization/StrukturCorsec.aspx{0}", PrevUrl)));
            }
        }
    }
}