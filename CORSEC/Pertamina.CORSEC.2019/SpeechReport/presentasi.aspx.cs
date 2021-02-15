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

namespace Pertamina.CORSEC._2019.SpeechReport
{
    public partial class presentasi : CORSECPage
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
                //int id = 0;
                //string _id = Request.QueryString["ar"];
                //int.TryParse(_id, out id);
                //if (id == 0) return 1;
                //return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tab_Board_Speech.ClientIDMode = ClientIDMode.Static;//1
                tab_Presentasi_Corporate.ClientIDMode = ClientIDMode.Static;//2
                tab_Email_Broadcast.ClientIDMode = ClientIDMode.Static;//3
                tab_Materi_Presentasi.ClientIDMode = ClientIDMode.Static;//4            

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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Materi_Presentasi);
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


//                #region Template Info
//                string header_template = @"
//  <div class=""kt-sc"" style=""background-image: {0} "">
//      <div class=""kt-container "">
//          <div class=""kt-sc__bottom"">
//              <h3 class=""kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium"">                        
//                  {1}
//              </h3>
//          </div>
//      </div>
//  </div>
//";
//                tbl_Board_Speech_Presentation_Info item = tbl_Board_Speech_Presentation_InfoItem.GetAll().FirstOrDefault();
//                if (item != null)
//                {
//                    string imageUrl = string.Format(" url('{0}') ", ResolveUrl("~/Content/assets/media/bg/bg-9.jpg"));
//                    tbl_File_Template file = tbl_File_TemplateItem.GetByReff(ReferenceTable.tbl_Board_Speech_Presentation_Info.ToString(), item.id.ToString());
//                    if (file != null)
//                    {
//                        imageUrl = string.Format(" url('data:image/png;base64,{0}') ", Convert.ToBase64String(file.file_blob));
//                    }

//                    lblHeader.Text = string.Format(header_template, imageUrl, item.title);
//                    lblTittle.Text = item.title;
//                    lblIsi.Text = item.body;
//                }
//                #endregion

                List<DataItem> list = new List<DataItem>();
                list.Add(new DataItem("5"));
                list.Add(new DataItem("10"));
                list.Add(new DataItem("20"));
                list.Add(new DataItem("50"));
                list.Add(new DataItem("100"));
                ddlPageSizeMateriPresentasi.DataSource = list;
                ddlPageSizeMateriPresentasi.DataBind();


                ddlPageSizePresentasiCorporate.DataSource = list;
                ddlPageSizePresentasiCorporate.DataBind();

                ddlPageSizeEmailBroadcast.DataSource = list;
                ddlPageSizeEmailBroadcast.DataBind();

                list = new List<DataItem>();
                list.Add(new DataItem("4"));
                list.Add(new DataItem("8"));
                list.Add(new DataItem("16"));
                list.Add(new DataItem("40"));
                list.Add(new DataItem("80"));

                ddlPageSizeBoardSpeech.DataSource = list;
                ddlPageSizeBoardSpeech.DataBind();

                tab_Board_Speech.HRef = ResolveUrl(string.Format("~/SpeechReport/presentasi.aspx{0}&tab={1}", PrevUrl, (int)Speech_Report_Type.BoardSpeech));
                tab_Presentasi_Corporate.HRef = ResolveUrl(string.Format("~/SpeechReport/presentasi.aspx{0}&tab={1}", PrevUrl, (int)Speech_Report_Type.PresentasiCorporate));
                tab_Email_Broadcast.HRef = ResolveUrl(string.Format("~/SpeechReport/presentasi.aspx{0}&tab={1}", PrevUrl, (int)Speech_Report_Type.EmailBroadcast));
                tab_Materi_Presentasi.HRef = ResolveUrl(string.Format("~/SpeechReport/presentasi.aspx{0}&tab={1}", PrevUrl, (int)Speech_Report_Type.MateriPresentasi));

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


            ////<div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop1"">
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive A</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive B</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive C</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive D</a>
            ////</div>


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
                string _url = (Year > 1900) ? string.Format("presentasi.aspx{0}&tab={1}&ar={2}", PrevUrl, ActiveTab, _archive.Archive) : string.Format("presentasi.aspx{0}&tab={1}&ar={2}", PrevUrl, ActiveTab, _archive.Archive);
                selectedArciveTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, _archive.Display);
            }
            selectedArciveTemplate += "</div>";
            lblFilter.Text = selectedArciveTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        }


        void SetSelectedTab()
        {
            //tab_Board_Speech.ClientIDMode = ClientIDMode.Static;//1
            //tab_Presentasi_Corporate.ClientIDMode = ClientIDMode.Static;//2
            //tab_Email_Broadcast.ClientIDMode = ClientIDMode.Static;//3
            //tab_Materi_Presentasi.ClientIDMode = ClientIDMode.Static;//4 

            //class="tab-pane active"
            kt_portlet_base_demo_2_3_tab_content.Attributes["class"] = "tab-pane";
            kt_portlet_base_demo_2_2_tab_content.Attributes["class"] = "tab-pane";
            kt_portlet_base_demo_2_31_tab_content.Attributes["class"] = "tab-pane";
            kt_portlet_base_demo_2_4_tab_content.Attributes["class"] = "tab-pane";

            tab_Board_Speech.Attributes["class"] = "nav-link";
            tab_Email_Broadcast.Attributes["class"] = "nav-link";
            tab_Materi_Presentasi.Attributes["class"] = "nav-link";
            tab_Presentasi_Corporate.Attributes["class"] = "nav-link";

            if (ActiveTab > 0)
            {
                if (ActiveTab == 1)
                {
                    tab_Board_Speech.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_4_tab_content.Attributes["class"] = "tab-pane active";
                }
                else if (ActiveTab == 2)
                {
                    tab_Presentasi_Corporate.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_3_tab_content.Attributes["class"] = "tab-pane active";
                }
                else if (ActiveTab == 3)
                {
                    tab_Email_Broadcast.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_2_tab_content.Attributes["class"] = "tab-pane active";
                }
                else if (ActiveTab == 4)
                {
                    tab_Materi_Presentasi.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_31_tab_content.Attributes["class"] = "tab-pane active";
                }
                else
                {
                    tab_Board_Speech.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_4_tab_content.Attributes["class"] = "tab-pane active";
                }
            }
            else
            {
                tab_Board_Speech.Attributes["class"] = "nav-link active";
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
                //HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                HiddenField hdnFileID = e.Row.FindControl("hdnFileID") as HiddenField;
                HiddenField hdnFileExt = e.Row.FindControl("hdnFileExt") as HiddenField;


                HyperLink linkFile = e.Row.FindControl("linkFile") as HyperLink;
                if (!string.IsNullOrEmpty(hdnFileID.Value))
                {
                    linkFile.ToolTip = "Download";
                    linkFile.NavigateUrl = ResolveUrl(string.Format("~/SpeechReportHandler.ashx?FileID={0}", hdnFileID.Value));
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
            hdnPageMateriPresentasi.Value = "0";
            hdnPageEmailBroadcast.Value = "0";
            hdnPagePresentasiCorporate.Value = "0";
            hdnPageBoardSpeech.Value = "0";
            BindingData();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            string tipeDocument = (sender as LinkButton).CommandName;
            if (tipeDocument == Speech_Report_Type.MateriPresentasi.ToString())
            {
                hdnPageMateriPresentasi.Value = pageIndex.ToString();
            }
            else if (tipeDocument == Speech_Report_Type.EmailBroadcast.ToString())
            {
                hdnPageEmailBroadcast.Value = pageIndex.ToString();
            }
            else if (tipeDocument == Speech_Report_Type.PresentasiCorporate.ToString())
            {
                hdnPagePresentasiCorporate.Value = pageIndex.ToString();
            }
            else if (tipeDocument == Speech_Report_Type.BoardSpeech.ToString())
            {
                hdnPageBoardSpeech.Value = pageIndex.ToString();
            }

            BindingData();
        }

        void BindingData()
        {
            if (ActiveTab == 1)
            {
                BindingDataBoardSpeech("");
            }
            else if (ActiveTab == 2)
            {
                BindingDataPresentasiCorporate("");
            }
            else if (ActiveTab == 3)
            {
                BindingDataEmailBroadcast("");
            }
            else if (ActiveTab == 4)
            {
                BindingDataMateriPresentasi("");
            }
            else
            {
                BindingDataBoardSpeech("");
            }

        }


        void BindingDataBoardSpeech(string judul)
        {
            int pageIndex = 0;
            string totalRecordInfoBoardSpeech = "";
            int totalRows = 0;
            int pageSizeBoardSpeech = 4;
            int.TryParse(ddlPageSizeBoardSpeech.SelectedValue, out pageSizeBoardSpeech);
            int.TryParse(hdnPageBoardSpeech.Value, out pageIndex);



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


            //gridBoardSpeech.PageSize = pageSizeBoardSpeech;
            //gridBoardSpeech.DataSource = tbl_Board_Speech_PresentationItem.GetDataPaging(pageIndex, pageSizeBoardSpeech, (int)Speech_Report_Type.BoardSpeech, tahunAwal, tahunAkhir, out totalRows);
            //gridBoardSpeech.DataBind();

            listViewBoardSpeech.DataSource = tbl_Board_Speech_PresentationItem.GetDataBoardSpeechPaging(pageIndex, pageSizeBoardSpeech, (int)Speech_Report_Type.BoardSpeech, tahunAwal, tahunAkhir, out totalRows);
            listViewBoardSpeech.DataBind();

            pageIndex += 1;

            rptPagerBoardSpeech.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeBoardSpeech, out totalRecordInfoBoardSpeech);
            rptPagerBoardSpeech.DataBind();
            lblTotalInfoBoardSpeech.Text = totalRecordInfoBoardSpeech;

            rptPagerBoardSpeech.Visible = totalRows > 0;
        }
        void BindingDataPresentasiCorporate(string judul)
        {
            int pageIndex = 0;
            string totalRecordInfoPresentasiCorporate = "";
            int totalRows = 0;
            int pageSizePresentasiCorporate = 10;
            int.TryParse(ddlPageSizePresentasiCorporate.SelectedValue, out pageSizePresentasiCorporate);
            int.TryParse(hdnPagePresentasiCorporate.Value, out pageIndex);



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


            gridPresentasiCorporate.PageSize = pageSizePresentasiCorporate;
            gridPresentasiCorporate.DataSource = tbl_Board_Speech_PresentationItem.GetDataPaging(pageIndex, pageSizePresentasiCorporate, (int)Speech_Report_Type.PresentasiCorporate, tahunAwal, tahunAkhir, out totalRows);
            gridPresentasiCorporate.DataBind();

            pageIndex += 1;

            rptPagerPresentasiCorporate.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizePresentasiCorporate, out totalRecordInfoPresentasiCorporate);
            rptPagerPresentasiCorporate.DataBind();
            lblTotalInfoPresentasiCorporate.Text = totalRecordInfoPresentasiCorporate;

            rptPagerPresentasiCorporate.Visible = totalRows > 0;
        }
        void BindingDataEmailBroadcast(string judul)
        {
            int pageIndex = 0;
            string totalRecordInfoEmailBroadcast = "";
            int totalRows = 0;
            int pageSizeEmailBroadcast = 10;
            int.TryParse(ddlPageSizeEmailBroadcast.SelectedValue, out pageSizeEmailBroadcast);
            int.TryParse(hdnPageEmailBroadcast.Value, out pageIndex);



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


            gridEmailBroadcast.PageSize = pageSizeEmailBroadcast;
            gridEmailBroadcast.DataSource = tbl_Board_Speech_PresentationItem.GetDataPaging(pageIndex, pageSizeEmailBroadcast, (int)Speech_Report_Type.EmailBroadcast, tahunAwal, tahunAkhir, out totalRows);
            gridEmailBroadcast.DataBind();

            pageIndex += 1;

            rptPagerEmailBroadcast.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeEmailBroadcast, out totalRecordInfoEmailBroadcast);
            rptPagerEmailBroadcast.DataBind();
            lblTotalInfoEmailBroadcast.Text = totalRecordInfoEmailBroadcast;

            rptPagerEmailBroadcast.Visible = totalRows > 0;
        }
        void BindingDataMateriPresentasi(string judul)
        {
            int pageIndex = 0;
            string totalRecordInfoMateriPresentasi = "";
            int totalRows = 0;
            int pageSizeMateriPresentasi = 10;
            int.TryParse(ddlPageSizeMateriPresentasi.SelectedValue, out pageSizeMateriPresentasi);
            int.TryParse(hdnPageMateriPresentasi.Value, out pageIndex);



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


            gridMateriPresentasi.PageSize = pageSizeMateriPresentasi;
            gridMateriPresentasi.DataSource = tbl_Board_Speech_PresentationItem.GetDataPaging(pageIndex, pageSizeMateriPresentasi, (int)Speech_Report_Type.MateriPresentasi, tahunAwal, tahunAkhir, out totalRows);
            gridMateriPresentasi.DataBind();

            pageIndex += 1;

            rptPagerMateriPresentasi.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeMateriPresentasi, out totalRecordInfoMateriPresentasi);
            rptPagerMateriPresentasi.DataBind();
            lblTotalInfoMateriPresentasi.Text = totalRecordInfoMateriPresentasi;

            rptPagerMateriPresentasi.Visible = totalRows > 0;
        }
    }
}