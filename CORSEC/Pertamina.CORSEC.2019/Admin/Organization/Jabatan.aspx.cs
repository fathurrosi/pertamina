using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Organization
{
    public partial class Jabatan : AuthorizeAdminPage
    {
        //public string PrevUrl { get; set; }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Organization/Details/Jabatan.aspx{0}", PrevUrl)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Display the company name in italics.
                //e.Row.Cells[1].Text = "<i>" + e.Row.Cells[1].Text + "</i>";
                HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                //HyperLink hyperLink = e.Row.FindControl("hl") as HyperLink;
                //hyperLink.NavigateUrl = string.Format("~/Admin/Details/Question.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);

                HyperLink hlEdit = e.Row.FindControl("hlEdit") as HyperLink;
                hlEdit.NavigateUrl = string.Format("~/Admin/Organization/Details/Jabatan.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);

                LinkButton lbtn = e.Row.FindControl("lbDel") as LinkButton;
                lbtn.OnClientClick = "return confirm('Anda yakin akan menghapus item ini?');";
                lbtn.CommandArgument = hiddenField.Value;
            }
        }

        protected void lb_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = sender as LinkButton;
                int _id = 0;
                int.TryParse(lbtn.CommandArgument, out _id);

                tbl_Struktur_Organisasi_Jabatan item = tbl_Struktur_Organisasi_JabatanItem.GetByPK(_id);
                if (item != null)
                {
                    bool usedInCorsec = tbl_Struktur_Organisasi_Diagram_CorsecItem.IsExistByJabatan(_id);
                    bool usedInCorcom = tbl_Struktur_Organisasi_Diagram_CorcomItem.IsExistByJabatan(_id);

                    if (usedInCorsec)
                    {
                        lblMessage.Text = GetValidationMessage(string.Format("Jabatan '{0}' ini tidak bisa dihapus. Karena masih digunakan diagram Corsec", item.name));
                        return;
                    }


                    if (usedInCorcom)
                    {
                        lblMessage.Text = GetValidationMessage(string.Format("Jabatan '{0}' ini tidak bisa dihapus. Karena masih digunakan diagram Corcom", item.name));
                        return;
                    }

                    tbl_Struktur_Organisasi_JabatanItem.Delete(_id);
                }
                grid.DataBind();

            }
            catch (Exception ex)
            {
                Log.Error(ex);

                grid.DataBind();
            }
        }
    }
}