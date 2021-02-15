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
    public partial class visi_misi : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<tbl_Combo_Detail> list = tbl_Combo_DetailItem.GetByHeader("Profile");
                ddlTipe.DataTextField = "name";
                ddlTipe.DataValueField = "name";
                ddlTipe.DataSource = list;
                ddlTipe.DataBind();

                tbl_Profile_Visi_Misi item = tbl_Profile_Visi_MisiItem.GetAll().FirstOrDefault();
                if (item != null)
                {
                    lblMisi.Text = item.Misi;
                    lblVisi.Text = item.Visi;
                    lblOverview_Content.Value = item.Contents;
                    lblSubTitle.Text = item.SubTitle;
                    lblTitle.Text = item.Title;

                    lblVisi_Content.Value = item.Visi_Content;
                    lblMisi_Content.Value = item.Misi_Content;

                    ddlTipe.SelectedValue = item.tab_text;
                }
            }
        }

        void LoadData(string tab_text)
        {
            lblMisi.Text = "";
            lblVisi.Text = "";
            lblOverview_Content.Value = "";
            lblSubTitle.Text = "";
            lblTitle.Text = "";

            lblVisi_Content.Value = "";
            lblMisi_Content.Value = "";

            tbl_Profile_Visi_Misi item = tbl_Profile_Visi_MisiItem.GetByTab(tab_text);
            if (item != null)
            {
                lblMisi.Text = item.Misi;
                lblVisi.Text = item.Visi;
                lblOverview_Content.Value = item.Contents;
                lblSubTitle.Text = item.SubTitle;
                lblTitle.Text = item.Title;

                lblVisi_Content.Value = item.Visi_Content;
                lblMisi_Content.Value = item.Misi_Content;

                ddlTipe.SelectedValue = item.tab_text;
                //ddlTipe.SelectedValue = item.tab_text;
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
            tbl_Profile_Visi_Misi item = tbl_Profile_Visi_MisiItem.GetByTab(ddlTipe.SelectedValue);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Profile_Visi_Misi();
                item.created = DateTime.Now;
                item.created_by = username;
                item.tab_text = ddlTipe.SelectedValue;

            }
            item.Misi = lblMisi.Text;
            item.Visi = lblVisi.Text;
            item.Contents = lblOverview_Content.Value;
            item.SubTitle = lblSubTitle.Text;
            item.Title = lblTitle.Text;

            item.Misi_Content = lblMisi_Content.Value;
            item.Visi_Content = lblVisi_Content.Value;
            item.updated = DateTime.Now;
            item.updated_by = username;

            tbl_Profile_Visi_Misi result = null;
            if (!isEdit)
            {
                result = tbl_Profile_Visi_MisiItem.Insert(item);
            }
            else
            {
                result = tbl_Profile_Visi_MisiItem.Update(item);
            }

            if (result != null)
            {
                lblMessage.Text = GetSucceedMessage();
            }
        }
    }
}