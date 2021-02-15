using System;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;

namespace Pertamina.CORSEC._2019.Admin.Guidelines
{
    public partial class Doc : AuthorizeAdminPage
    {
        //public string PrevUrl { get; set; }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string selectedDocType = ddlTipe_Dokumen.SelectedValue;
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Guidelines/Details/Doc.aspx{0}&tp={1}", PrevUrl, selectedDocType)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTipe_Dokumen.DataTextField = "name";
                ddlTipe_Dokumen.DataValueField = "name";
                ddlTipe_Dokumen.DataSource = tbl_Combo_DetailItem.GetByHeader("Tipe_Dokumen");
                ddlTipe_Dokumen.DataBind();
            }

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
                hlEdit.NavigateUrl = string.Format("~/Admin/Guidelines/Details/Doc.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);

                LinkButton lbtn = e.Row.FindControl("lbDel") as LinkButton;
                lbtn.OnClientClick = "return confirm('Anda yakin akan menghapus item ini?');";
                lbtn.CommandArgument = hiddenField.Value;

                HiddenField hdnFileID = e.Row.FindControl("hdnFileID") as HiddenField;

                HyperLink linkFile = e.Row.FindControl("linkFile") as HyperLink;
                if (!string.IsNullOrEmpty(hdnFileID.Value)) linkFile.NavigateUrl = ResolveUrl(string.Format("~/GuidelinesFileHandler.ashx?FileID={0}", hdnFileID.Value));
            }
        }

        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            int _id = 0;
            int.TryParse(lbtn.CommandArgument, out _id);
            tbl_Guidelines_DocItem.Delete(_id);

            grid.DataBind();
        }

        protected void ddlTipe_Dokumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid.DataBind();
        }
    }
}