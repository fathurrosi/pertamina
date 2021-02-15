using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.ProfilCorsec
{
    public partial class strategic_partner : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<tbl_Combo_Detail> list = tbl_Combo_DetailItem.GetByHeader("Strategic Partner");
                ddlTipe.DataTextField = "name";
                ddlTipe.DataValueField = "name";
                ddlTipe.DataSource = list;
                ddlTipe.DataBind();

                tbl_Profile_Strategic_Partner item = tbl_Profile_Strategic_PartnerItem.GetByTab(list.Select(t => t.name).FirstOrDefault());
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    lblContent.Value = item.body;
                }
            }
        }
        void LoadData(string tab_text)
        {
            lblTitle.Text = "";
            lblContent.Value = "";
            tbl_Profile_Strategic_Partner item = tbl_Profile_Strategic_PartnerItem.GetByTab(tab_text);
            if (item != null)
            {
                lblTitle.Text = item.title;
                lblContent.Value = item.body;
            }
        }

        protected void ddlTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            LoadData(ddl.SelectedValue);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Profile_Strategic_Partner item = tbl_Profile_Strategic_PartnerItem.GetByTab(ddlTipe.SelectedValue);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Profile_Strategic_Partner();
                item.created = DateTime.Now;
                item.created_by = username;
                item.tab_text = ddlTipe.SelectedValue;

            }

            item.body = lblContent.Value;
            item.title = lblTitle.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;
            tbl_Profile_Strategic_Partner result = null;
            if (!isEdit)
            {
                result = tbl_Profile_Strategic_PartnerItem.Insert(item);
            }
            else
            {
                result = tbl_Profile_Strategic_PartnerItem.Update(item);
            }

            if (result != null)
            {
                lblMessage.Text = GetSucceedMessage();
            }
        }
    }
}