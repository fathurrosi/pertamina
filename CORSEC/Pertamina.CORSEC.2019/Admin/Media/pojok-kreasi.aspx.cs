using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;

namespace Pertamina.CORSEC._2019.Admin.Media
{
    public partial class pojok_kreasi : AuthorizeAdminPage
    {
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            int _infographic_type = 0;
            int.TryParse(ddldata_type.SelectedValue, out _infographic_type);
            if (_infographic_type <= 0)
            {
                lblMessage.Text = GetValidationMessage("Silahkan pilih kategori terlebih dahulu");
            }
            else if (_infographic_type == (int)Infographic_Type.Print_Ad)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/details/Print-Ad.aspx{0}&t={1}", PrevUrl, _infographic_type)));
            }
            else if (_infographic_type == (int)Infographic_Type.Stock_Photo)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/details/Stock-Photo.aspx{0}&t={1}", PrevUrl, _infographic_type)));
            }
            else if (_infographic_type == (int)Infographic_Type.TVC)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/details/TVC.aspx{0}&t={1}", PrevUrl, _infographic_type)));
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                List<DataItem> data_typeList = Utilities.GetDataSource<Infographic_Type>().Where(t =>
                t.Code == string.Format("{0}", (int)Infographic_Type.Print_Ad) ||
                t.Code == string.Format("{0}", (int)Infographic_Type.Stock_Photo) ||
                t.Code == string.Format("{0}", (int)Infographic_Type.TVC)).ToList();
                data_typeList.Insert(0, new DataItem("0", "--Please Select--"));
                ddldata_type.DataSource = data_typeList;
                ddldata_type.DataValueField = "Code";
                ddldata_type.DataTextField = "Text";
                ddldata_type.DataBind();
            }
        }


        protected void ddlTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid.DataBind();
        }

        protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                /*
Print Ad
Stock Photo
TVC

           ~/Admin/Media/Print-Ad.aspx
~/Admin/Media/Stock-Photo.aspx
~/Admin/Media/TVC.aspx

                */

                HyperLink hlEdit = e.Row.FindControl("hlEdit") as HyperLink;
                HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                HiddenField hdn_infographic_type = e.Row.FindControl("hdn_infographic_type") as HiddenField;
                int _infographic_type = 0;
                int.TryParse(hdn_infographic_type.Value, out _infographic_type);
                if (_infographic_type == (int)Infographic_Type.Print_Ad)
                {
                    hlEdit.NavigateUrl = string.Format("~/Admin/Media/details/Print-Ad.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);
                }
                else if (_infographic_type == (int)Infographic_Type.Stock_Photo)
                {
                    hlEdit.NavigateUrl = string.Format("~/Admin/Media/details/Stock-Photo.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);
                }
                else if (_infographic_type == (int)Infographic_Type.TVC)
                {
                    hlEdit.NavigateUrl = string.Format("~/Admin/Media/details/TVC.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);
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
            tbl_MediaItem.Delete(_id);

            grid.DataBind();
        }

    }
}