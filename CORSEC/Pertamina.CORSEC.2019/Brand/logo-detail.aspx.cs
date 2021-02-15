using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Brand
{
    public partial class logo_detail : CORSECPage
    {
        public string GetPeriodAgo(object objDate)
        {

            string result = "";
            if (objDate.GetType() != typeof(DateTime))
            {
                return "";
            }

            DateTime date = Convert.ToDateTime(objDate);
            double daysToMonths = 30.4368499;
            int minute = (DateTime.Now - date).Minutes;
            int hour = (DateTime.Now - date).Hours;
            int day = (DateTime.Now - date).Days;
            int month = (int)decimal.Ceiling(Convert.ToDecimal(day) / (decimal)daysToMonths);
            int year = month / 12;
            if (year > 0)
                result = year == 1 ? string.Format("{0} year ago", year) : string.Format("{0} years ago", year);
            else if (month > 0)
                result = month == 1 ? string.Format("{0} month ago", month) : string.Format("{0} months ago", month);
            else if (day > 0)
                result = day == 1 ? string.Format("{0} day ago", day) : string.Format("{0} days ago", day);
            else if (hour > 0)
                result = hour == 1 ? string.Format("{0} hour ago", hour) : string.Format("{0} hours ago", hour);
            else if (minute > 0)
                result = minute == 1 ? string.Format("{0} minute ago", minute) : string.Format("{0} minutes ago", minute);

            /*
i want show lastlogin stored in sql server in datetime. as
n years ago, if less 1 year than
n months ago, if less 1 month than
n days ago, if less 1 day than
n hours ago, if less 1 hour than
n minutes ago, if less 1 minutes than
n seconds ago
             */

            return result;
        }
        protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                //HiddenField hdnFileID = e.Row.FindControl("hdnFileID") as HiddenField;
                //HiddenField hdnFileExt = e.Row.FindControl("hdnFileExt") as HiddenField;


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
            hdnPageAplikasi_Inspirasi.Value = "0";
            BindingDataAplikasi_Inspirasi();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            string tipeDocument = (sender as LinkButton).CommandName;
            hdnPageAplikasi_Inspirasi.Value = pageIndex.ToString();

            BindingDataAplikasi_Inspirasi();
        }


        void BindingDataAplikasi_Inspirasi()
        {
            int pageIndex = 0;
            string totalRecordInfoAplikasi_Inspirasi = "";
            int totalRows = 0;
            int pageSizeAplikasi_Inspirasi = 4;
            int.TryParse(ddlPageSizeAplikasi_Inspirasi.SelectedValue, out pageSizeAplikasi_Inspirasi);
            int.TryParse(hdnPageAplikasi_Inspirasi.Value, out pageIndex);

            listViewAplikasi_Inspirasi.DataSource = tbl_brand_guideline_aplikasi_inspirasi_detailItem.GetDataPaging(pageIndex, pageSizeAplikasi_Inspirasi, out totalRows);
            listViewAplikasi_Inspirasi.DataBind();

            pageIndex += 1;

            rptPagerAplikasi_Inspirasi.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeAplikasi_Inspirasi, out totalRecordInfoAplikasi_Inspirasi);
            rptPagerAplikasi_Inspirasi.DataBind();
            lblTotalInfoAplikasi_Inspirasi.Text = totalRecordInfoAplikasi_Inspirasi;

            rptPagerAplikasi_Inspirasi.Visible = totalRows > 0;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Brand_Guideline);
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

                #region CONTENT PANDUAN
                string templatePanduan = @"
<div class=""kt-portlet kt-callout"">
    <div class=""kt-portlet__body"">
        <div class=""kt-callout__body"">
            <div class=""kt-callout__content"">
{0}
{1}
            </div>
            {2}
        </div>
    </div>
</div>
                    ";
                string templateContent = @"
                <h3 class=""kt-callout__title"">{0}</h3>
                <p class=""kt-callout__desc text-justify"">
                    {1}
                </p>
";
                string templateDownload = @"
                <span class=""kt-media kt-media--sm"">
                    <img src=""{0}"" class=""float-left mr-2"" alt="" image"">
                    <a href=""{1}"" class=""kt-link kt-font-boldest mt-2"" data-toggle=""kt-tooltip"" data-skin=""dark""
                        data-placement=""right"" title=""Download"">{2}
                    </a>
                </span>
";

                string templateGambar = @"
            <div class=""kt-callout__action"">
                <div class=""thumbnail"">
                    <div class=""media"">
                        <span class=""meta bottom darken"">
                            <p class=""m-0 semibold"">
                                {0}
                            </p>
                        </span>
                        <img src=""{1}"" alt=""Photo"" width=""100%"">
                    </div>
                </div>
            </div>

";
                lblContent.Text = "";
                List<tbl_brand_guideline_user_manual> list = tbl_brand_guideline_user_manualItem.GetAll();
                foreach (tbl_brand_guideline_user_manual _item in list)
                {
                    string content = string.Format(templateContent, _item.title, _item.body);
                    string download = _item.file_blob == null ? "" : string.Format(templateDownload,
                        ResolveUrl(string.Format("~/Content/assets/media/files/{0}.svg", string.Format("{0}", _item.file_ext).Replace(".", "").ToLower())),
                         ResolveUrl(string.Format("~/LogoGuidanceHandler.ashx?id={0}", _item.id)), _item.file_name);
                    string gambar = _item.image_blob == null ? "" : string.Format(templateGambar, _item.image_desc, Utilities.ByteToString(_item.image_blob));
                    lblContent.Text += string.Format(templatePanduan, content, download, gambar);
                }

                #endregion

                #region CONTENT LOGO
                List<tbl_brand_guideline_logo> logoList = tbl_brand_guideline_logoItem.GetAll();
                string templateLogos = @"
 <div class=""kt-widget4__item p-3"">
     <img class=""kt-mr-10"" src=""{0}"" height=""75"" alt="""">
     <small class=""kt-widget4__number fsize-11 kt-mr-20"">{1}</small>
     <span class=""kt-widget3__number kt-font-info"">
         <a href=""{2}"" class=""btn-label-brand btn btn-sm btn-bold"">Download</a>
     </span>
 </div>
";
                lblLogos.Text = "";
                foreach (tbl_brand_guideline_logo _logos in logoList)
                {
                    lblLogos.Text += string.Format(templateLogos, Utilities.ByteToString(_logos.file_blob),
                        string.Format("{0} - {1}", _logos.file_ext.Replace(".", "").ToUpper(), _logos.file_size),
                         ResolveUrl(string.Format("~/GuidelinesLogoHandler.ashx?id={0}", _logos.id)));
                }

                #endregion

                #region JUDUL APLIKASI INSPIRASI
                string templateAPLIKASI = @"
<div class=""kt-infobox__header"">
    <h2 class=""kt-infobox__title"">{0}</h2>
</div>
<div class=""kt-infobox__body"">
    <div class=""kt-infobox__section"">
        <div class=""kt-infobox__content text-justify"">
            {1}
        </div>
    </div>
</div>
";
                tbl_brand_guideline_aplikasi_inspirasi aiItem = tbl_brand_guideline_aplikasi_inspirasiItem.GetAll().FirstOrDefault();
                if (aiItem != null)
                {
                    lbl_Aplikasi_Inspirasi.Text = string.Format(templateAPLIKASI, aiItem.title, aiItem.body);
                }

                List<DataItem> dataSources = new List<DataItem>();
                dataSources.Add(new DataItem("3"));
                dataSources.Add(new DataItem("6"));
                dataSources.Add(new DataItem("12"));
                dataSources.Add(new DataItem("24"));
                dataSources.Add(new DataItem("30"));
                dataSources.Add(new DataItem("60"));
                dataSources.Add(new DataItem("90"));

                ddlPageSizeAplikasi_Inspirasi.DataSource = dataSources;
                ddlPageSizeAplikasi_Inspirasi.DataBind();

                BindingDataAplikasi_Inspirasi();
                #endregion
            }
        }
    }
}