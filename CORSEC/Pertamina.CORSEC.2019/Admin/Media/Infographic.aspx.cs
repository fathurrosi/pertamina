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
    public partial class Infographic : AuthorizeAdminPage
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
            else if (_infographic_type == (int)Infographic_Type.Infografis_corporate)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/details/Infografis-corporate.aspx{0}&t={1}", PrevUrl, _infographic_type)));
            }
            else if (_infographic_type == (int)Infographic_Type.Pertapedia)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/details/Pertapedia.aspx{0}&t={1}", PrevUrl, _infographic_type)));
            }
            else if (_infographic_type == (int)Infographic_Type.Konten_social_media)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/details/Konten-social-media.aspx{0}&t={1}", PrevUrl, _infographic_type)));
            }
            else if (_infographic_type == (int)Infographic_Type.Media_external)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/details/Media-external.aspx{0}&t={1}", PrevUrl, _infographic_type)));
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //        Infografis_corporate = 1,
                //[Description("Pertapedia")]
                //Pertapedia = 2,
                //[Description("Konten social media")]
                //Konten_social_media = 3,
                //[Description("Media external")]
                //Media_external = 4,

                List<DataItem> data_typeList = Utilities.GetDataSource<Infographic_Type>().Where(t =>
                t.Code == string.Format("{0}", (int)Infographic_Type.Infografis_corporate) ||
                t.Code == string.Format("{0}", (int)Infographic_Type.Pertapedia) ||
                t.Code == string.Format("{0}", (int)Infographic_Type.Konten_social_media) ||
                t.Code == string.Format("{0}", (int)Infographic_Type.Media_external)).ToList();
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
                Infografis corporate
                Pertapedia
                Konten social media
                Media external

                ~/Admin/Media/Infografis-corporate.aspx
                ~/Admin/Media/Pertapedia.aspx
                ~/Admin/Media/Konten-social-media.aspx
                ~/Admin/Media/Media-external.aspx

                */

                HyperLink hlEdit = e.Row.FindControl("hlEdit") as HyperLink;
                HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                HiddenField hdn_infographic_type = e.Row.FindControl("hdn_infographic_type") as HiddenField;
                int _infographic_type = 0;
                int.TryParse(hdn_infographic_type.Value, out _infographic_type);
                if (_infographic_type == (int)Infographic_Type.Infografis_corporate)
                {
                    hlEdit.NavigateUrl = string.Format("~/Admin/Media/details/Infografis-corporate.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);
                }
                else if (_infographic_type == (int)Infographic_Type.Pertapedia)
                {
                    hlEdit.NavigateUrl = string.Format("~/Admin/Media/details/Pertapedia.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);
                }
                else if (_infographic_type == (int)Infographic_Type.Konten_social_media)
                {
                    hlEdit.NavigateUrl = string.Format("~/Admin/Media/details/Konten-social-media.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);
                }
                else if (_infographic_type == (int)Infographic_Type.Media_external)
                {
                    hlEdit.NavigateUrl = string.Format("~/Admin/Media/details/Media-external.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);
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