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
    public partial class Exhibition : CORSECPage
    {
        void BindingDataExhibition()
        {
            int pageIndex = 0;
            string totalRecordInfoExhibition = "";
            int totalRows = 0;
            int pageSizeExhibition = 6;
            int.TryParse(ddlPageSizeExhibition.SelectedValue, out pageSizeExhibition);
            int.TryParse(hdnPageExhibition.Value, out pageIndex);


            //gridExhibition.PageSize = pageSizeExhibition;
            //gridExhibition.DataSource = tbl_brand_ExhibitionItem.GetDataPaging(pageIndex, pageSizeExhibition, (int)Speech_Report_Type.Exhibition, tahunAwal, tahunAkhir, out totalRows);
            //gridExhibition.DataBind();
            totalRows = tbl_brand_ExhibitionItem.GetCount(pageSizeExhibition, pageIndex);
            listViewExhibition.DataSource = tbl_brand_ExhibitionItem.GetPagingCustom(pageSizeExhibition, pageIndex);
            listViewExhibition.DataBind();

            pageIndex += 1;

            rptPagerExhibition.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeExhibition, out totalRecordInfoExhibition);
            rptPagerExhibition.DataBind();
            lblTotalInfoExhibition.Text = totalRecordInfoExhibition;

            rptPagerExhibition.Visible = totalRows > 0;
        }


        protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
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
            hdnPageExhibition.Value = "0";
            BindingDataExhibition();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            string tipeDocument = (sender as LinkButton).CommandName;

            hdnPageExhibition.Value = pageIndex.ToString();


            BindingDataExhibition();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DataItem> list = new List<DataItem>();
                list.Add(new DataItem("6"));
                list.Add(new DataItem("12"));
                list.Add(new DataItem("24"));
                list.Add(new DataItem("40"));
                list.Add(new DataItem("80"));

                ddlPageSizeExhibition.DataSource = list;
                ddlPageSizeExhibition.DataBind();

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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Exhibition);
                if (item != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (item.file_blob != null)
                    {
                        imageUrl = Business.Utilities.ByteToString(item.file_blob);
                    }


                    lblHeader.Text = string.Format(header_template, imageUrl, item.template_header);
                    lblTittle.Text = item.template_title;
                    lblIsi.Text = item.template_desc;
                }
                #endregion

                BindingDataExhibition();
            }
        }
    }
}