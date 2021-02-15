using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;

namespace Pertamina.CORSEC._2019.Admin.DesignGrafis
{
    public partial class Print_Ad : AuthorizeAdminPage
    {
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            int data_type = 0;
            int.TryParse(ddldata_type.SelectedValue, out data_type);
            if (data_type <= 0)
            {
                lblMessage.Text = GetValidationMessage("Silahkan pilih kategori terlebih dahulu");
            }
            else if (data_type == (int)Design_Grafis_Desain_Type.TVC)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/details/TVC.aspx{0}&t={1}", PrevUrl, data_type)));
            }
            else
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/details/Print-Ad.aspx{0}&t={1}", PrevUrl, data_type)));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<DataItem> data_typeList = Utilities.GetDataSource<Design_Grafis_Desain_Type>();
                data_typeList.Insert(0, new DataItem("0", "--Please Select--"));
                ddldata_type.DataSource = data_typeList;
                ddldata_type.DataValueField = "Code";
                ddldata_type.DataTextField = "Text";
                ddldata_type.DataBind();
            }
        }

        protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdndata_type = e.Row.FindControl("hdndata_type") as HiddenField;
                HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                HyperLink hlEdit = e.Row.FindControl("hlEdit") as HyperLink;
                if (hdndata_type.Value == string.Format("{0}", (int)Design_Grafis_Desain_Type.TVC))
                {
                    hlEdit.NavigateUrl = string.Format("~/Admin/DesignGrafis/details/TVC.aspx{0}&id={1}&t={2}", PrevUrl, hiddenField.Value, hdndata_type.Value);
                    //Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/details/Video-Add.aspx{0}&t={1}", PrevUrl, hdndata_type.Value)));
                }
                else
                {
                    hlEdit.NavigateUrl = string.Format("~/Admin/DesignGrafis/details/Print-Ad.aspx{0}&id={1}&t={2}", PrevUrl, hiddenField.Value, hdndata_type.Value);
                    //Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/details/Print-Ad.aspx{0}&t={1}", PrevUrl, hdndata_type.Value)));
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
            tbl_Design_GrafisItem.Delete(_id);

            grid.DataBind();
        }

        protected void ddlTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid.DataBind();
        }
    }
}