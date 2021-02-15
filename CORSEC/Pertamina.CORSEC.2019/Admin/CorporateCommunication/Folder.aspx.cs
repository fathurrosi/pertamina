using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;

namespace Pertamina.CORSEC._2019.Admin.CorporateCommunication
{
    public partial class Folder : AuthorizeAdminPage
    {
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/CorporateCommunication/Category.aspx{0}", PrevUrl)));
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/CorporateCommunication/Details/Folder.aspx{0}&pid={1}", PrevUrl, ParentItemID)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ParentItemID <= 0)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/CorporateCommunication/Category.aspx{0}", PrevUrl)));
                }
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

                HyperLink hyperLink = e.Row.FindControl("hlEdit") as HyperLink;
                hyperLink.NavigateUrl = string.Format("~/Admin/CorporateCommunication/Details/Folder.aspx{0}&id={1}&pid={2}&t=e", PrevUrl, hiddenField.Value, ParentItemID);

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
            tbl_CorporateCommunication_Sub_CategoryItem.Delete(_id);

            grid.DataBind();
        }
    }
}