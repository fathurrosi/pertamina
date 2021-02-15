using System;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;

namespace Pertamina.CORSEC._2019.Admin.Mitra
{
    public partial class Items : AuthorizeAdminPage
    {
        //public string PrevUrl { get; set; }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Mitra/Details/Item.aspx{0}", PrevUrl)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                HyperLink hlEdit = e.Row.FindControl("hlEdit") as HyperLink;
                hlEdit.NavigateUrl = string.Format("~/Admin/Mitra/Details/Item.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);

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
            tbl_productItem.Delete(_id);

            grid.DataBind();
        }

        protected void ddlTipe_SelectedIndexChanged(object sender, EventArgs e)
        {            
            grid.DataBind();
        }
    }
}