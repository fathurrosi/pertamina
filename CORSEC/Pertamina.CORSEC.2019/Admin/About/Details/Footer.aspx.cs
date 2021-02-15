using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.About.Details
{
    public partial class Footer : AuthorizeAdminPage
    {
        //public string PrevUrl { get; set; }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/About/Details/UpdateFooter.aspx{0}&pid={1}", PrevUrl, ItemID)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                _details.Visible = false;
                tbl_Footer item = tbl_FooterItem.GetByPK(ItemID);
                if (item != null)
                {
                    _details.Visible = true;
                    lblFooter.Text = item.footer;                    
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
                hyperLink.NavigateUrl = string.Format("~/Admin/About/Details/UpdateFooter.aspx{0}&pid={1}&id={2}", PrevUrl, ItemID, hiddenField.Value);

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
            tbl_Footer_DetailItem.Delete(_id);

            grid.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            tbl_Footer item = tbl_FooterItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Footer();
                item.created = DateTime.Now;
                item.created_by = Utilities.Username;

            }

            item.created = item.created.HasValue ? item.created : DateTime.Now;
            item.footer = lblFooter.Text;
            item.updated = DateTime.Now;
            item.updated_by = Utilities.Username;
            tbl_Footer result = null;
            if (!isEdit)
            {
                result = tbl_FooterItem.Insert(item);
            }
            else
            {
                result = tbl_FooterItem.Update(item);
            }

            if (result != null)
            {
                _details.Visible = true;
            }

            Response.Redirect(ResolveUrl(string.Format("~/Admin/About/Footer.aspx{0}", PrevUrl)));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/About/Footer.aspx{0}", PrevUrl)));
        }
    }
}