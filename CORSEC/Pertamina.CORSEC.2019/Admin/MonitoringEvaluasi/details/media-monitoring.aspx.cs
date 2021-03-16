using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;
namespace Pertamina.CORSEC._2019.Admin.MonitoringEvaluasi.details
{
    public partial class media_monitoring : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbl_MonitoringEvaluasi_Media item = tbl_MonitoringEvaluasi_MediaItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.Title;
                    ddlTone.SelectedValue = item.Tone;
                    ddlMonitoring_Type.SelectedValue = item.Monitoring_Type;
                    ddlMedia_Type.SelectedValue = item.Media_Type;

                    lblTotalArticle.Text = string.Format("{0}", item.TotalArticle);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            tbl_MonitoringEvaluasi_Media item = tbl_MonitoringEvaluasi_MediaItem.GetByPK(ItemID);
            bool newFile = false;
            if (item == null)
            {
                newFile = true;
                item = new tbl_MonitoringEvaluasi_Media();
                item.created = DateTime.Now;
                item.created_by = username;
            }
            else
            {
                item.updated = DateTime.Now;
                item.updated_by = username;
            }

            if (string.Format("{0}", lblTitle.Text).Length <= 0)
            {
                lblMessage.Text = GetValidationMessage("Judul berita harus diisi!");
                return;
            }

            int total = 0;
            int.TryParse(lblTotalArticle.Text, out total);
            if (total <= 0)
            {
                lblMessage.Text = GetValidationMessage("Total artikel harus lebih besar dari nol!");
                return;
            }

            if (string.Format("{0}", ddlMonitoring_Type.SelectedValue).Length <= 0)
            {
                lblMessage.Text = GetValidationMessage("Tipe Monitoring harus diisi!");
                return;
            }

            if (string.Format("{0}", ddlMedia_Type.SelectedValue).Length <= 0)
            {
                lblMessage.Text = GetValidationMessage("Tipe Media harus diisi!");
                return;
            }


            if (string.Format("{0}", ddlTone.SelectedValue).Length <= 0)
            {
                lblMessage.Text = GetValidationMessage("Nada Berita harus diisi!");
                return;
            }
            item.TotalArticle = total;
            item.Tone = ddlTone.SelectedValue;
            item.Title = lblTitle.Text;
            item.Monitoring_Type = ddlMonitoring_Type.SelectedValue;
            item.Media_Type = ddlMedia_Type.SelectedValue;


            if (!newFile) { tbl_MonitoringEvaluasi_MediaItem.Update(item); }
            else { tbl_MonitoringEvaluasi_MediaItem.Insert(item); }

            Response.Redirect(ResolveUrl(string.Format("~/Admin/MonitoringEvaluasi/media-monitoring.aspx{0}", PrevUrl)));

        }

    }
}