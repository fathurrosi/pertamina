using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.MonitoringEvaluasi
{
    public partial class media_monitoring : CORSECPage
    {
        public int ActiveTab
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["tab"];
                int.TryParse(_id, out id);
                if (id == 0) return (int)Monitoring_Type.Mingguan;
                return id;
            }
        }
        void BindingData()
        {
            List<DataItem> list = Utilities.GetDataSource<Monitoring_Type>();
            DataItem item = list.Where(t => t.Code == string.Format("{0}", ActiveTab)).FirstOrDefault();
            string monitotingType = item == null ? "" : item.Text;
            if (!string.IsNullOrEmpty(monitotingType))
            {
                grid.PageSize = 10;
                grid.DataSource = tbl_MonitoringEvaluasi_MediaItem.GetTop10(monitotingType);
                grid.DataBind();
            }


            List<Dto.Cstm.tbl_MonitoringEvaluasi_Media_Persentage> persenList = tbl_MonitoringEvaluasi_MediaItem.GetPersentage(monitotingType);
            if (persenList != null)
            {
                hdnTotalArticle.Value = string.Format("{0}", persenList.Select(t => t.TotalArticle).FirstOrDefault());
                hdnTotalNegatif.Value = string.Format("{0}", persenList.Where(t => t.Tone == "Negatif").Select(t => decimal.Ceiling(t.Percentage)).FirstOrDefault());
                hdnTotalPositif.Value = string.Format("{0}", persenList.Where(t => t.Tone == "Positif").Select(t => decimal.Ceiling(t.Percentage)).FirstOrDefault());
                hdnTotalNetral.Value = string.Format("{0}", persenList.Where(t => t.Tone == "Netral").Select(t => decimal.Ceiling(t.Percentage)).FirstOrDefault());

                string toneTemplate = @"

<div class=""kt-widget14__legends"">
    <h4 class=""kt-widget14__title"">{0} Artikel Internet
    </h4>
    <div class=""kt-widget14__legend"">
        <span class=""kt-widget14__bullet kt-bg-success""></span>
        <span class=""kt-widget14__stats"">{1}% Positif</span>
    </div>
    <div class=""kt-widget14__legend"">
        <span class=""kt-widget14__bullet kt-bg-danger""></span>
        <span class=""kt-widget14__stats"">{2}% Negatif</span>
    </div>
    <div class=""kt-widget14__legend"">
        <span class=""kt-widget14__bullet kt-bg-brand""></span>
        <span class=""kt-widget14__stats"">{3}% Netral</span>
    </div>
</div>
";
                litToneBerita.Text = string.Format(toneTemplate, hdnTotalArticle.Value, hdnTotalPositif.Value, hdnTotalNegatif.Value, hdnTotalNetral.Value);
            }


            string jenisMediaTempalte = @"
 <div class=""kt-widget14__legends"">
    <h4 class=""kt-widget14__title"">Total Artikel
    </h4>
    <div class=""kt-widget14__legend"">
        <span class=""kt-widget14__stats""><i class=""fa fa-globe-asia""></i> d{0} Artikel</span>
    </div>
    <div class=""kt-widget14__legend"">
        <span class=""kt-widget14__stats""><i class=""fa fa-tv""></i> {1} Artikel</span>
    </div>
    <div class=""kt-widget14__legend"">
        <span class=""kt-widget14__stats""><i class=""fa fa-newspaper""></i> {2} Artikel</span>
    </div>
</div>
";
            List<Dto.Cstm.tbl_MonitoringEvaluasi_Media_Type> mediaList = tbl_MonitoringEvaluasi_MediaItem.GetMediaType(monitotingType);
            if (mediaList != null)
            {

                decimal totalInternetPositif = mediaList.Where(t => t.Media_Type == "Internet" && t.Tone == "Positif").Sum(t => t.TotalArticle);
                decimal totalTVPositif = mediaList.Where(t => t.Media_Type == "TV" && t.Tone == "Positif").Sum(t => t.TotalArticle);
                decimal totalCetakPositif = mediaList.Where(t => t.Media_Type == "Cetak" && t.Tone == "Positif").Sum(t => t.TotalArticle);

                decimal totalInternetNegatif = mediaList.Where(t => t.Media_Type == "Internet" && t.Tone == "Negatif").Sum(t => t.TotalArticle);
                decimal totalTVNegatif = mediaList.Where(t => t.Media_Type == "TV" && t.Tone == "Negatif").Sum(t => t.TotalArticle);
                decimal totalCetakNegatif = mediaList.Where(t => t.Media_Type == "Cetak" && t.Tone == "Negatif").Sum(t => t.TotalArticle);

                decimal totalInternetNetral = mediaList.Where(t => t.Media_Type == "Internet" && t.Tone == "Netral").Sum(t => t.TotalArticle);
                decimal totalTVNetral = mediaList.Where(t => t.Media_Type == "TV" && t.Tone == "Netral").Sum(t => t.TotalArticle);
                decimal totalCetakNetral = mediaList.Where(t => t.Media_Type == "Cetak" && t.Tone == "Netral").Sum(t => t.TotalArticle);

                hdnInternetPositif.Value = string.Format("{0}", totalInternetPositif);
                hdnInternetNegatif.Value = string.Format("{0}", totalInternetNegatif);
                hdnInternetNetral.Value = string.Format("{0}", totalInternetNetral);

                hdnTVPositif.Value = string.Format("{0}", totalTVPositif);
                hdnTVNegatif.Value = string.Format("{0}", totalTVNegatif);
                hdnTVNetral.Value = string.Format("{0}", totalTVNetral);

                hdnCetakPositif.Value = string.Format("{0}", totalCetakPositif);
                hdnCetakNegatif.Value = string.Format("{0}", totalCetakNegatif);
                hdnCetakNetral.Value = string.Format("{0}", totalCetakNetral);


                decimal totalInternet = mediaList.Where(t => t.Media_Type == "Internet").Sum(t => t.TotalArticle);
                decimal totalTV = mediaList.Where(t => t.Media_Type == "TV").Sum(t => t.TotalArticle);
                decimal totalCetak = mediaList.Where(t => t.Media_Type == "Cetak").Sum(t => t.TotalArticle);
                litJenisMedia.Text = string.Format(jenisMediaTempalte, totalInternet, totalTV, totalCetak);
            }
        }



        /*
<ul class="nav nav-pills nav-fill" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content"
                                        role="tab" aria-selected="false">Mingguan
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content" role="tab"
                                        aria-selected="true">Bulanan
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " data-toggle="tab" href="#kt_portlet_base_demo_2_4_tab_content" role="tab"
                                        aria-selected="true">Tahunan
                                    </a>
                                </li>
                            </ul>
         */
        void LoadTab()
        {
            string template = @"
<li class=""nav-item"">
    <a class=""nav-link"" href=""{0}"" aria-selected=""true"">{1}</a>
</li>
";

            string templateActive = @"
<li class=""nav-item"">
    <a class=""nav-link active"" href=""{0}"" aria-selected=""true"">{1}</a>
</li>
";
            StringBuilder sb = new StringBuilder();
            List<DataItem> tabs = Utilities.GetDataSource<Monitoring_Type>();
            for (int i = 0; i < tabs.Count; i++)
            {
                DataItem tab = tabs[i];
                string _url = string.Format("media-monitoring.aspx{0}&tab={1}", PrevUrl, tab.Code);

                if (tab.Code == string.Format("{0}", ActiveTab)) { sb.AppendFormat(templateActive, _url, tab.Text); }
                else if (ActiveTab <= 0 && i == 0) { sb.AppendFormat(templateActive, _url, tab.Text); }
                else
                {
                    sb.AppendFormat(template, _url, tab.Text);
                }
            }

            litTab.Text = sb.ToString();
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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Media_Monitoring);
                if (item != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (item.file_blob != null)
                    {
                        imageUrl = Business.Utilities.ByteToString(item.file_blob);
                    }

                    lblHeader.Text = string.Format(header_template, imageUrl, item.template_header);
                    lblTitle.Text = item.template_title;
                    lblIsi.Text = item.template_desc;
                }
                #endregion
                LoadTab();
                BindingData();
            }
        }
    }
}