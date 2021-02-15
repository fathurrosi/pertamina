using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Media
{
    public partial class Infographic : CORSECPage
    {
        public int ActiveTab
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["tab"];
                int.TryParse(_id, out id);
                return id;
            }
        }

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

        protected List<ArchiveFilter> GetArchiveList()
        {
            int minYear = DateTime.Now.Year - 25;
            int maxYear = DateTime.Now.Year;
            List<ArchiveFilter> result = new List<ArchiveFilter>();
            string[] arr = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int index = 0;
            int i = maxYear;
            bool stop = false;
            while (!stop)
            {
                result.Add(new ArchiveFilter(arr[index], i, i - 5));
                i = i - 5;
                index++;
                if (i <= minYear)
                {
                    stop = true;
                }
            }

            return result;
        }


        public string Archive
        {
            get
            {
                return string.Format("{0}", Request.QueryString["ar"]).Length == 0 ? "A" : string.Format("{0}", Request.QueryString["ar"]);                
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tab_Infografis_corporate.ClientIDMode = ClientIDMode.Static;//1
                tab_Pertapedia.ClientIDMode = ClientIDMode.Static;//2
                tab_Konten_social_media.ClientIDMode = ClientIDMode.Static;//3
                tab_Media_external.ClientIDMode = ClientIDMode.Static;//4            

                kt_portlet_base_demo_2_3_tab_content.ClientIDMode = ClientIDMode.Static;
                kt_portlet_base_demo_2_2_tab_content.ClientIDMode = ClientIDMode.Static;
                kt_portlet_base_demo_2_31_tab_content.ClientIDMode = ClientIDMode.Static;
                kt_portlet_base_demo_2_4_tab_content.ClientIDMode = ClientIDMode.Static;

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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Infographic);
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


                List<DataItem> list = new List<DataItem>();
                list.Add(new DataItem("5"));
                list.Add(new DataItem("10"));
                list.Add(new DataItem("20"));
                list.Add(new DataItem("50"));
                list.Add(new DataItem("100"));
                ddlPageSizeInfografis_corporate.DataSource = list;
                ddlPageSizeInfografis_corporate.DataBind();


                ddlPageSizeKonten_social_media.DataSource = list;
                ddlPageSizeKonten_social_media.DataBind();

                ddlPageSizePertapedia.DataSource = list;
                ddlPageSizePertapedia.DataBind();

                list = new List<DataItem>();
                list.Add(new DataItem("4"));
                list.Add(new DataItem("8"));
                list.Add(new DataItem("16"));
                list.Add(new DataItem("40"));
                list.Add(new DataItem("80"));

                ddlPageSizeMedia_external.DataSource = list;
                ddlPageSizeMedia_external.DataBind();

                /*
 [Description("Infografis corporate")]
        Infografis_corporate = 1,
        [Description("Pertapedia")]
        Pertapedia,
        [Description("Konten social media")]
        Konten_social_media,
        [Description("Media external")]
        Media_external

                 */

                tab_Infografis_corporate.HRef = ResolveUrl(string.Format("~/Media/Infographic.aspx{0}&tab={1}", PrevUrl, (int)Infographic_Type.Infografis_corporate));
                tab_Pertapedia.HRef = ResolveUrl(string.Format("~/Media/Infographic.aspx{0}&tab={1}", PrevUrl, (int)Infographic_Type.Pertapedia));
                tab_Konten_social_media.HRef = ResolveUrl(string.Format("~/Media/Infographic.aspx{0}&tab={1}", PrevUrl, (int)Infographic_Type.Konten_social_media));
                tab_Media_external.HRef = ResolveUrl(string.Format("~/Media/Infographic.aspx{0}&tab={1}", PrevUrl, (int)Infographic_Type.Media_external));

                SetSelectedTab();
                SetFilter();
                BindingData();
            }
        }

        void SetFilter()
        {
            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            int maxYear = DateTime.Now.Year;
            int minYear = maxYear - 5;
            List<ArchiveFilter> archiveList = GetArchiveList();
            string selectedArchive = "";
            if (!string.IsNullOrEmpty(Archive))
            {
                selectedArchive = Archive;
                ArchiveFilter selectedArchiveFilter = archiveList.Where(t => t.Archive == selectedArchive).FirstOrDefault();
                maxYear = selectedArchiveFilter.Begin;
                minYear = selectedArchiveFilter.End;
            }

            
            string selectedArciveTemplate = string.Format(@" 
<button id=""btnGroupDrop"" type=""button"" class=""btn btn-secondary dropdown-toggle"" 
data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
5 Tahun Terakhir & Archive {0}</button>", selectedArchive);

            int selectedYear = maxYear;
            if (Year > 0 && Year <= maxYear && Year >= minYear)
            {
                selectedYear = Year;
            }
            else
            {
                selectedYear = maxYear;
            }

            int currentYear = DateTime.Now.Year;
            selectedArciveTemplate += @" 
                <div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop"">";
            foreach (ArchiveFilter _archive in archiveList)
            {
                string _url = (Year > 1900) ? string.Format("Infographic.aspx{0}&tab={1}&ar={2}", PrevUrl, ActiveTab, _archive.Archive) : string.Format("Infographic.aspx{0}&tab={1}&ar={2}", PrevUrl, ActiveTab, _archive.Archive);
                selectedArciveTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, _archive.Display);
            }
            selectedArciveTemplate += "</div>";
            lblFilter.Text = selectedArciveTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        }


        void SetSelectedTab()
        {
            //class="tab-pane active"
            kt_portlet_base_demo_2_3_tab_content.Attributes["class"] = "tab-pane";
            kt_portlet_base_demo_2_2_tab_content.Attributes["class"] = "tab-pane";
            kt_portlet_base_demo_2_31_tab_content.Attributes["class"] = "tab-pane";
            kt_portlet_base_demo_2_4_tab_content.Attributes["class"] = "tab-pane";

            tab_Infografis_corporate.Attributes["class"] = "nav-link";
            tab_Konten_social_media.Attributes["class"] = "nav-link";
            tab_Media_external.Attributes["class"] = "nav-link";
            tab_Pertapedia.Attributes["class"] = "nav-link";

            if (ActiveTab > 0)
            {
                if (ActiveTab == 1)
                {
                    tab_Infografis_corporate.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_4_tab_content.Attributes["class"] = "tab-pane active";
                }
                else if (ActiveTab == 2)
                {
                    tab_Pertapedia.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_3_tab_content.Attributes["class"] = "tab-pane active";
                }
                else if (ActiveTab == 3)
                {
                    tab_Konten_social_media.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_2_tab_content.Attributes["class"] = "tab-pane active";
                }
                else if (ActiveTab == 4)
                {
                    tab_Media_external.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_31_tab_content.Attributes["class"] = "tab-pane active";
                }
                else
                {
                    tab_Infografis_corporate.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_4_tab_content.Attributes["class"] = "tab-pane active";
                }
            }
            else
            {
                tab_Infografis_corporate.Attributes["class"] = "nav-link active";
                kt_portlet_base_demo_2_4_tab_content.Attributes["class"] = "tab-pane active";
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
                HiddenField hdnFileID = e.Row.FindControl("hdn") as HiddenField;
                HiddenField hdnFileExt = e.Row.FindControl("hdnFileExt") as HiddenField;


                HyperLink linkFile = e.Row.FindControl("linkFile") as HyperLink;
                if (!string.IsNullOrEmpty(hdnFileID.Value))
                {
                    linkFile.ToolTip = "Download";
                    linkFile.NavigateUrl = ResolveUrl(string.Format("~/InfographicHandler.ashx?id={0}", hdnFileID.Value));
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
            hdnPageInfografis_corporate.Value = "0";
            hdnPagePertapedia.Value = "0";
            hdnPageKonten_social_media.Value = "0";
            hdnPageMedia_external.Value = "0";
            BindingData();
        }

        /*

        [Description("Infografis corporate")]
        Infografis_corporate = 1,
        [Description("Pertapedia")]
        Pertapedia,
        [Description("Konten social media")]
        Konten_social_media,
        [Description("Media external")]
        Media_external
         */
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            string tipeDocument = (sender as LinkButton).CommandName;
            if (tipeDocument == Infographic_Type.Infografis_corporate.ToString())
            {
                hdnPageInfografis_corporate.Value = pageIndex.ToString();
            }
            else if (tipeDocument == Infographic_Type.Pertapedia.ToString())
            {
                hdnPagePertapedia.Value = pageIndex.ToString();
            }
            else if (tipeDocument == Infographic_Type.Konten_social_media.ToString())
            {
                hdnPageKonten_social_media.Value = pageIndex.ToString();
            }
            else if (tipeDocument == Infographic_Type.Media_external.ToString())
            {
                hdnPageMedia_external.Value = pageIndex.ToString();
            }

            BindingData();
        }

        void BindingData()
        {
            if (ActiveTab == 1)
            {
                BindingDataInfografis_corporate(""); 
            }
            else if (ActiveTab == 2)
            {
                BindingDataPertapedia("");                
            }
            else if (ActiveTab == 3)
            {
                BindingDataKonten_social_media("");
            }
            else if (ActiveTab == 4)
            {
                BindingDataMedia_external("");
            }
            else
            {
                BindingDataInfografis_corporate("");
            }

        }


        void BindingDataMedia_external(string judul)
        {
            int pageIndex = 0;
            string totalRecordInfoMedia_external = "";
            int totalRows = 0;
            int pageSizeMedia_external = 4;
            int.TryParse(ddlPageSizeMedia_external.SelectedValue, out pageSizeMedia_external);
            int.TryParse(hdnPageMedia_external.Value, out pageIndex);



            int tahunAwal = 0;
            int tahunAkhir = 0;
            if (!string.IsNullOrEmpty(Archive))
            {

                ArchiveFilter selectedArchiveFilter = GetArchiveList().Where(t => t.Archive == Archive).FirstOrDefault();
                tahunAwal = selectedArchiveFilter.End;
                tahunAkhir = selectedArchiveFilter.Begin;
            }
            else
            {
                tahunAwal = tahunAwal - 5;
                tahunAkhir = DateTime.Now.Year;

            }

            
            listViewMedia_external.DataSource = tbl_MediaItem.GetDataPaging(pageIndex, pageSizeMedia_external, (int)Infographic_Type.Media_external, tahunAwal, tahunAkhir, out totalRows);
            listViewMedia_external.DataBind();

            pageIndex += 1;

            rptPagerMedia_external.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeMedia_external, out totalRecordInfoMedia_external);
            rptPagerMedia_external.DataBind();
            lblTotalInfoMedia_external.Text = totalRecordInfoMedia_external;

            rptPagerMedia_external.Visible = totalRows > 0;
        }
        void BindingDataKonten_social_media(string judul)
        {
            int pageIndex = 0;
            string totalRecordInfoKonten_social_media = "";
            int totalRows = 0;
            int pageSizeKonten_social_media = 10;
            int.TryParse(ddlPageSizeKonten_social_media.SelectedValue, out pageSizeKonten_social_media);
            int.TryParse(hdnPageKonten_social_media.Value, out pageIndex);



            int tahunAwal = 0;
            int tahunAkhir = 0;
            if (!string.IsNullOrEmpty(Archive))
            {

                ArchiveFilter selectedArchiveFilter = GetArchiveList().Where(t => t.Archive == Archive).FirstOrDefault();
                tahunAwal = selectedArchiveFilter.End;
                tahunAkhir = selectedArchiveFilter.Begin;
            }
            else
            {
                tahunAwal = tahunAwal - 5;
                tahunAkhir = DateTime.Now.Year;

            }


            //listViewKonten_social_media.PageSize = pageSizeKonten_social_media;
            listViewKonten_social_media.DataSource = tbl_MediaItem.GetDataPaging(pageIndex, pageSizeKonten_social_media, (int)Infographic_Type.Konten_social_media, tahunAwal, tahunAkhir, out totalRows);
            listViewKonten_social_media.DataBind();

            pageIndex += 1;

            rptPagerKonten_social_media.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeKonten_social_media, out totalRecordInfoKonten_social_media);
            rptPagerKonten_social_media.DataBind();
            lblTotalInfoKonten_social_media.Text = totalRecordInfoKonten_social_media;

            rptPagerKonten_social_media.Visible = totalRows > 0;
        }
        void BindingDataPertapedia(string judul)
        {
            int pageIndex = 0;
            string totalRecordInfoPertapedia = "";
            int totalRows = 0;
            int pageSizePertapedia = 10;
            int.TryParse(ddlPageSizePertapedia.SelectedValue, out pageSizePertapedia);
            int.TryParse(hdnPagePertapedia.Value, out pageIndex);



            int tahunAwal = 0;
            int tahunAkhir = 0;
            if (!string.IsNullOrEmpty(Archive))
            {

                ArchiveFilter selectedArchiveFilter = GetArchiveList().Where(t => t.Archive == Archive).FirstOrDefault();
                tahunAwal = selectedArchiveFilter.End;
                tahunAkhir = selectedArchiveFilter.Begin;
            }
            else
            {
                tahunAwal = tahunAwal - 5;
                tahunAkhir = DateTime.Now.Year;

            }


            //listViewPertapedia.PageSize = pageSizePertapedia;
            listViewPertapedia.DataSource = tbl_MediaItem.GetDataPaging(pageIndex, pageSizePertapedia, (int)Infographic_Type.Pertapedia, tahunAwal, tahunAkhir, out totalRows);
            listViewPertapedia.DataBind();

            pageIndex += 1;

            rptPagerPertapedia.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizePertapedia, out totalRecordInfoPertapedia);
            rptPagerPertapedia.DataBind();
            lblTotalInfoPertapedia.Text = totalRecordInfoPertapedia;

            rptPagerPertapedia.Visible = totalRows > 0;
        }
        void BindingDataInfografis_corporate(string judul)
        {
            int pageIndex = 0;
            string totalRecordInfoInfografis_corporate = "";
            int totalRows = 0;
            int pageSizeInfografis_corporate = 10;
            int.TryParse(ddlPageSizeInfografis_corporate.SelectedValue, out pageSizeInfografis_corporate);
            int.TryParse(hdnPageInfografis_corporate.Value, out pageIndex);



            int tahunAwal = 0;
            int tahunAkhir = 0;
            if (!string.IsNullOrEmpty(Archive))
            {

                ArchiveFilter selectedArchiveFilter = GetArchiveList().Where(t => t.Archive == Archive).FirstOrDefault();
                tahunAwal = selectedArchiveFilter.End;
                tahunAkhir = selectedArchiveFilter.Begin;
            }
            else
            {
                tahunAwal = tahunAwal - 5;
                tahunAkhir = DateTime.Now.Year;

            }


            //listViewInfografis_corporate.PageSize = pageSizeInfografis_corporate;
            listViewInfografis_corporate.DataSource = tbl_MediaItem.GetDataPaging(pageIndex, pageSizeInfografis_corporate, (int)Infographic_Type.Infografis_corporate, tahunAwal, tahunAkhir, out totalRows);
            listViewInfografis_corporate.DataBind();

            pageIndex += 1;

            rptPagerInfografis_corporate.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeInfografis_corporate, out totalRecordInfoInfografis_corporate);
            rptPagerInfografis_corporate.DataBind();
            lblTotalInfoInfografis_corporate.Text = totalRecordInfoInfografis_corporate;

            rptPagerInfografis_corporate.Visible = totalRows > 0;
        }
    }
}