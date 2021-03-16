using System;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.MonitoringEvaluasi.details
{
    public partial class kinerja_sekper_monitoring : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbl_MonitoringEvaluasi_Kinerja item = tbl_MonitoringEvaluasi_KinerjaItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.Title;
                    ddlKineja.SelectedValue = item.Monitoring_Type;
                    //item.Bulan = 5;
                    //item.Tahun = 20210;
                    txtMonth.Text = string.Format("{0}-{1:00}", item.Tahun, item.Bulan);
                    ddlPeriode.SelectedValue = item.Priode;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            tbl_MonitoringEvaluasi_Kinerja item = tbl_MonitoringEvaluasi_KinerjaItem.GetByPK(ItemID);
            bool newFile = false;
            if (item == null)
            {
                newFile = true;
                item = new tbl_MonitoringEvaluasi_Kinerja();
                item.created = DateTime.Now;
                item.created_by = username;
            }
            else
            {
                item.updated = DateTime.Now;
                item.updated_by = username;
            }


            if (string.IsNullOrEmpty(ddlKineja.SelectedValue))
            {
                lblMessage.Text = GetValidationMessage("Tipe Kinerja harus diisi!");
                return;
            }

            if (string.Format("{0}", lblTitle.Text).Length <= 0)
            {
                lblMessage.Text = GetValidationMessage("Laporan harus diisi!");
                return;
            }


            if (string.Format("{0}", txtMonth.Text).Length <= 0)
            {
                lblMessage.Text = GetValidationMessage("Bulan harus diisi!");
                return;
            }

            DateTime _bulan;
            if (!DateTime.TryParse(txtMonth.Text, out _bulan))
            {
                lblMessage.Text = GetValidationMessage("isi Bulan dengan data yang valid!");
                return;
            }
            else if (_bulan.Year <= 1900)
            {
                lblMessage.Text = GetValidationMessage("isi Bulan dengan data yang valid!");
                return;
            }


            if (string.IsNullOrEmpty(ddlPeriode.SelectedValue))
            {
                lblMessage.Text = GetValidationMessage("Periode harus diisi!");
                return;
            }

            int bulan = _bulan.Month;
            int tahun = _bulan.Year;
            //string[] month = txtMonth.Text.Split('-');
            //int.TryParse(month[0], out tahun);
            //int.TryParse(month[1], out bulan);

            item.Monitoring_Type = ddlKineja.SelectedValue;
            item.Bulan = bulan;
            item.Tahun = tahun;
            item.Title = lblTitle.Text;
            item.Priode = ddlPeriode.SelectedValue;


            if (!newFile) { tbl_MonitoringEvaluasi_KinerjaItem.Update(item); }
            else { tbl_MonitoringEvaluasi_KinerjaItem.Insert(item); }

            Response.Redirect(ResolveUrl(string.Format("~/Admin/MonitoringEvaluasi/kinerja-sekper-monitoring.aspx{0}", PrevUrl)));

        }

    }
}