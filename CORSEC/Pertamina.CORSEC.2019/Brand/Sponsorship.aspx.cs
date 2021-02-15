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
    public partial class Sponsorship : CORSECPage
    {
        public int Year
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["y"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public string Crop(object text)
        {

            return string.Format("{0}..", Utilities.Crop(string.Format("{0}", text), 66));
        }
        public string ConvertUrl(object blob)
        {
            if (blob == null) return "";
            byte[] file_blob = (byte[])blob;
            return Utilities.ByteToString(file_blob);
        }

        void BindingDataSponsorship()
        {
            int pageIndex = 0;
            string totalRecordInfoSponsorship = "";
            int totalRows = 0;
            int pageSizeSponsorship = 6;
            int.TryParse(ddlPageSizeSponsorship.SelectedValue, out pageSizeSponsorship);
            int.TryParse(hdnPageSponsorship.Value, out pageIndex);

            //gridSponsorship.PageSize = pageSizeSponsorship;
            //gridSponsorship.DataSource = tbl_brand_SponsorshipItem.GetDataPaging(pageIndex, pageSizeSponsorship, (int)Speech_Report_Type.Sponsorship, tahunAwal, tahunAkhir, out totalRows);
            //gridSponsorship.DataBind();

            List<Dto.Cstm.tbl_brand_Sponsorship> results = tbl_brand_SponsorshipItem.GetPagingCustom(Year, pageSizeSponsorship, pageIndex, out totalRows);
            listViewSponsorship.DataSource = results;
            listViewSponsorship.DataBind();

            pageIndex += 1;

            rptPagerSponsorship.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeSponsorship, out totalRecordInfoSponsorship);
            rptPagerSponsorship.DataBind();
            lblTotalInfoSponsorship.Text = totalRecordInfoSponsorship;

            rptPagerSponsorship.Visible = totalRows > 0;



            string templateCarousel = @"
<div class=""carousel-item{0}"">
    <a href=""{5}"">             
         <img src=""{2}"" class=""center-block h-100"" alt=""..."" />
    </a>
    <div class=""carousel-caption d-none d-md-block"" id=""black-light-caption"">
        <h5>{1}<span class=""pull-right btn btn-sm btn-label-brand btn-bold download""><a href=""{3}"">Selengkapnya...</a></span>
        </h5>
        {4}
    </div>
</div> ";

            string carousel = "";
            List<Dto.Cstm.tbl_brand_Sponsorship> itemList = results;
            for (int i = 0; i < itemList.Count; i++)
            {
                Dto.Cstm.tbl_brand_Sponsorship sItem = itemList[i];
                string urlDetail = ResolveUrl(string.Format("~/Brand/Sponsorship-Detail.aspx{0}&id={1}", PrevUrl, sItem.id));
                ResolveUrl(string.Format("~/SponsorshipFileHandler.ashx?id={0}", sItem.id));
                string url = ResolveUrl(string.Format("~/Sponsorship.aspx{0}&y={1}", PrevUrl, Year));
                carousel += string.Format(templateCarousel, i == 0 ? " active" : "", Utilities.Crop(sItem.title, 66), Business.Utilities.ByteToString(sItem.file_blob), url, Utilities.Crop(sItem.body, 200), urlDetail);
            }

            lbllCarousel.Text = carousel;
        }


        protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                //HiddenField hdnFileID = e.Row.FindControl("hdnFileID") as HiddenField;
                HiddenField hdnFileExt = e.Row.FindControl("hdnFileExt") as HiddenField;


                //HyperLink linkFile = e.Row.FindControl("linkFile") as HyperLink;
                //if (!string.IsNullOrEmpty(hdnFileID.Value))
                //{
                //    linkFile.ToolTip = "Download";
                //    linkFile.NavigateUrl = ResolveUrl(string.Format("~/SpeechReportHandler.ashx?FileID={0}", hdnFileID.Value));
                //}

                //Image img = e.Row.FindControl("imgFile") as Image;
                //img.ImageUrl = ResolveUrl(string.Format("~/Content/assets/media/files/{0}.svg", hdnFileExt.Value.Replace(".", "").ToLower()));
                //if (string.IsNullOrEmpty(hdnFileExt.Value))
                //{
                //    img.Visible = false;
                //}
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
            //hdnPageMateriPresentasi.Value = "0";
            //hdnPageEmailBroadcast.Value = "0";
            //hdnPagePresentasiCorporate.Value = "0";
            hdnPageSponsorship.Value = "0";
            BindingDataSponsorship();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            string tipeDocument = (sender as LinkButton).CommandName;

            hdnPageSponsorship.Value = pageIndex.ToString();


            BindingDataSponsorship();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DataItem> list = new List<DataItem>();
                list.Add(new DataItem("4"));
                list.Add(new DataItem("8"));
                list.Add(new DataItem("12"));
                list.Add(new DataItem("24"));
                list.Add(new DataItem("40"));
                list.Add(new DataItem("80"));

                ddlPageSizeSponsorship.DataSource = list;
                ddlPageSizeSponsorship.DataBind();

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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Sponsorship);
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



                string templateFilter = @"
<button id=""btnGroupDrop"" type=""button"" class=""btn btn-secondary dropdown-toggle""
    data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
    {0}
</button>
<div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop"">
    {1}
</div>
";
                string years = "";
                int currentYear = DateTime.Now.Year;
                for (int i = 0; i < 5; i++)
                {
                    string url = string.Format("Sponsorship.aspx{0}&y={1}", PrevUrl, currentYear);
                    years += string.Format(@"    <a class=""dropdown-item"" href=""{0}"">{1}</a>", url, currentYear);
                    currentYear--;
                }
                lblFilter.Text = string.Format(templateFilter, Year <= 1900 ? "Tahun" : Year.ToString(), years);
                BindingDataSponsorship();
            }

        }
    }
}