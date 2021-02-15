using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.DesignGrafis
{
    public partial class infografis_photo : CORSECPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                #region Template Baru
                string header_template = @"
<div class=""kt-sc"" style=""background-image: url('{0}');"">
    <div class=""kt-container"">
        <div class=""kt-sc__bottom"">
            <h3 class=""kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium"">{1}
            </h3>
        </div>
    </div>
</div>
";
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Infografis);
                if (item != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (item.file_blob != null)
                    {
                        imageUrl = Business.Utilities.ByteToString(item.file_blob);
                    }
                    lblHeader.Text = string.Format(header_template, imageUrl, item.template_header);
                }
                #endregion


                List<DataItem> list = new List<DataItem>();
                list.Add(new DataItem("16"));
                list.Add(new DataItem("32"));
                list.Add(new DataItem("40"));
                list.Add(new DataItem("80"));
                list.Add(new DataItem("120"));
                ddlPageSizePrint_Ad.DataSource = list;
                ddlPageSizePrint_Ad.DataBind();


                BindingData();
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
            hdnPagePrint_Ad.Value = "0";
            //hdnPageStock_Photo.Value = "0";
            //hdnPageTVC.Value = "0";
            BindingData();
        }

        /*

        [Description("Infografis corporate")]
        Print_Ad = 1,
        [Description("Stock_Photo")]
        Stock_Photo,
        [Description("Konten social media")]
        TVC,
        [Description("Media external")]
        Media_external
         */
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            string tipeDocument = (sender as LinkButton).CommandName;
            if (tipeDocument == Infographic_Type.Print_Ad.ToString())
            {
                hdnPagePrint_Ad.Value = pageIndex.ToString();
            }



            BindingData();
        }

        void BindingData()
        {
            BindingDataPrint_Ad("");
        }

        void BindingDataPrint_Ad(string judul)
        {
            int pageIndex = 0;
            string totalRecordInfoPrint_Ad = "";
            int totalRows = 0;
            int pageSizePrint_Ad = 10;
            int.TryParse(ddlPageSizePrint_Ad.SelectedValue, out pageSizePrint_Ad);
            int.TryParse(hdnPagePrint_Ad.Value, out pageIndex);


            //listViewPrint_Ad.PageSize = pageSizePrint_Ad;
            List<tbl_Design_Grafis_File> files = tbl_Design_Grafis_FileItem.GetDataPaging(pageIndex, pageSizePrint_Ad, ItemID, out totalRows);
            listViewPrint_Ad.DataSource = files;
            listViewPrint_Ad.DataBind();


            string template = @"<img id=""expandedImg"" src=""{0}"" style=""width: 100%""> ";
            tbl_Design_Grafis_File file = files.FirstOrDefault();
            lblExpandedImg.Text = file == null ? "" : string.Format(template, file.file_blob != null ? Business.Utilities.ByteToString(file.file_blob) : "#");

            pageIndex += 1;

            rptPagerPrint_Ad.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizePrint_Ad, out totalRecordInfoPrint_Ad);
            rptPagerPrint_Ad.DataBind();
            lblTotalInfoPrint_Ad.Text = totalRecordInfoPrint_Ad;

            rptPagerPrint_Ad.Visible = totalRows > 0;
            ddlPageSizePrint_Ad.Visible = totalRows > 0;
        }
    }
}