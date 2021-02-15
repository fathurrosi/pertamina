using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;


namespace Pertamina.CORSEC._2019.Admin.CollateralCorporate
{
    public partial class detail : AuthorizeAdminPage
    {
        //public string PrevUrl { get; set; }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/CollateralCorporate/Details/detail.aspx{0}", PrevUrl)));
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
                HiddenField hdnCategory = e.Row.FindControl("hdnCategory") as HiddenField;

                //HyperLink hyperLink = e.Row.FindControl("hl") as HyperLink;
                //hyperLink.NavigateUrl = string.Format("~/Admin/Details/Question.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);

                HyperLink hlEdit = e.Row.FindControl("hlEdit") as HyperLink;
                hlEdit.NavigateUrl = string.Format("~/Admin/CollateralCorporate/Details/detail.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);

                HyperLink hlAddFile = e.Row.FindControl("hlAddFile") as HyperLink;
                if (hdnCategory.Value == "Kalender")
                {
                    hlAddFile.NavigateUrl = string.Format("~/Admin/CollateralCorporate/Kalender.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);
                }
                else if (hdnCategory.Value == "Agenda")
                {
                    hlAddFile.NavigateUrl = string.Format("~/Admin/CollateralCorporate/Agenda.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);
                }
                else if (hdnCategory.Value == "Kartu Ucapan")
                {
                    hlAddFile.NavigateUrl = string.Format("~/Admin/CollateralCorporate/Kartu.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);
                }
                else
                {
                    hlAddFile.NavigateUrl = "#";
                }

                LinkButton lbtn = e.Row.FindControl("lbDel") as LinkButton;
                lbtn.OnClientClick = "return confirm('Anda yakin akan menghapus item ini?');";
                lbtn.CommandArgument = hiddenField.Value;
            }
        }

        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            int _id = 0;
            int.TryParse(lbtn.CommandArgument, out _id);
            tbl_Collateral_Corporate_DetailItem.Delete(_id);

            grid.DataBind();
        }
    }
}
