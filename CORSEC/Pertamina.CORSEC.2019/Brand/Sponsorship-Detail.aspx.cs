using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Brand
{
    public partial class Sponsorship_Detail : CORSECPage
    {
        #region Event Paging
        protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdn = e.Row.FindControl("hdn") as HiddenField;
                HiddenField hdnFileExt = e.Row.FindControl("hdnFileExt") as HiddenField;


                HyperLink linkFile = e.Row.FindControl("linkFile") as HyperLink;
                if (!string.IsNullOrEmpty(hdn.Value))
                {
                    linkFile.ToolTip = "Download";
                    linkFile.NavigateUrl = ResolveUrl(string.Format("~/SponsorshipFileHandler.ashx?id={0}", hdn.Value));
                }

                Image img = e.Row.FindControl("imgFile") as Image;
                img.ImageUrl = ResolveUrl(string.Format("~/Content/assets/media/files/{0}.svg", hdnFileExt.Value.Replace(".", "").ToLower()));
                if (string.IsNullOrEmpty(hdnFileExt.Value))
                {
                    img.Visible = false;
                }
            }
        }

        protected void rptPager_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HtmlGenericControl li = e.Item.FindControl("li") as HtmlGenericControl;
            LinkButton lnkPage = e.Item.FindControl("lnkPage") as LinkButton;

            li.Attributes.Clear();
            li.Attributes.Add("class", Utilities.GetListItemClass(string.Format("{0}", lnkPage.Text)));
            if (!lnkPage.Enabled)
            {
                li.Attributes.Clear();
                li.Attributes.Add("class", "kt-pagination__link--active");
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnPageMateri_And_Poster.Value = "0";
            BindingDataMateri_And_Poster();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            string CommandName = (sender as LinkButton).CommandName;
            hdnPageMateri_And_Poster.Value = pageIndex.ToString();

            BindingDataMateri_And_Poster();
        }

        void BindingDataMateri_And_Poster()
        {
            int pageIndex = 0;
            string totalRecordInfoMateri_And_Poster = "";
            int totalRows = 0;
            int pageSizeMateri_And_Poster = 10;
            int.TryParse(ddlPageSizeMateri_And_Poster.SelectedValue, out pageSizeMateri_And_Poster);
            int.TryParse(hdnPageMateri_And_Poster.Value, out pageIndex);

            gridMateri_And_Poster.PageSize = pageSizeMateri_And_Poster;
            gridMateri_And_Poster.DataSource = tbl_brand_Sponsorship_FileItem.GetDataPaging(ItemID, pageIndex, pageSizeMateri_And_Poster, out totalRows);
            gridMateri_And_Poster.DataBind();

            pageIndex += 1;

            rptPagerMateri_And_Poster.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeMateri_And_Poster, out totalRecordInfoMateri_And_Poster);
            rptPagerMateri_And_Poster.DataBind();
            lblTotalInfoMateri_And_Poster.Text = totalRecordInfoMateri_And_Poster;

            rptPagerMateri_And_Poster.Visible = totalRows > 0;
        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DataItem> list = new List<DataItem>();
                list.Add(new DataItem("5"));
                list.Add(new DataItem("10"));
                list.Add(new DataItem("20"));
                list.Add(new DataItem("50"));
                list.Add(new DataItem("100"));
                ddlPageSizeMateri_And_Poster.DataSource = list;
                ddlPageSizeMateri_And_Poster.DataBind();


                #region Template Baru
                string header_template = @"
  	<div class=""kt-sc"" style=""background-image: url('{0}')"">
		<div class=""kt-container "">

			<div class=""kt-sc__bottom"">
				<h3 class=""kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium"">
					{1}
				</h3>
			</div>
		</div>
	</div>
";
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Sponsorship);
                if (item != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (item.file_blob != null)
                    {
                        imageUrl = Business.Utilities.ByteToString(item.file_blob);
                    }


                    lblHeader.Text = string.Format(header_template, imageUrl, item.template_header);
                    //lblTittle.Text = item.template_title;
                    //lblIsi.Text = item.template_desc;
                }
                #endregion

                tbl_brand_Sponsorship contentItem = tbl_brand_SponsorshipItem.GetByPK(ItemID);
                if (contentItem != null)
                {
                    lblAward.Text = contentItem.award;
                    lblIsi.Text = contentItem.body;
                    lblLokasi.Text = contentItem.location;
                    lblTanggal.Text = string.Format("{0:dd MMM yyyy}", contentItem.created);
                    lblTitle.Text = contentItem.title;

                    List<tbl_brand_Sponsorship_File> _files = tbl_brand_Sponsorship_FileItem.GetGalery(contentItem.id);
                    string imageTemplate = @"<li><img src=""{0}"" alt=""photo"" /></li>
";
                    foreach (tbl_brand_Sponsorship_File _file in _files)
                    {
                        lblImages.Text += string.Format(imageTemplate, Utilities.ByteToString(_file.file_blob));
                    }
                }


                BindingDataMateri_And_Poster();
            }
        }
    }
}