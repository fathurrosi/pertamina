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
    public partial class pojok_kreasi : CORSECPage
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
                tab_Print_Ad.ClientIDMode = ClientIDMode.Static;//1
                tab_Stock_Photo.ClientIDMode = ClientIDMode.Static;//2
                tab_TVC.ClientIDMode = ClientIDMode.Static;//3

                kt_portlet_base_demo_2_3_tab_content.ClientIDMode = ClientIDMode.Static;
                kt_portlet_base_demo_2_2_tab_content.ClientIDMode = ClientIDMode.Static;
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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Pojok_Kreasi);
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
                ddlPageSizePrint_Ad.DataSource = list;
                ddlPageSizePrint_Ad.DataBind();


           

                //ddlPageSizeStock_Photo.DataSource = list;
                //ddlPageSizeStock_Photo.DataBind();

                list = new List<DataItem>();
                list.Add(new DataItem("4"));
                list.Add(new DataItem("8"));
                list.Add(new DataItem("16"));
                list.Add(new DataItem("40"));
                list.Add(new DataItem("80"));
                ddlPageSizeTVC.DataSource = list;
                ddlPageSizeTVC.DataBind();

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

                tab_Print_Ad.HRef = ResolveUrl(string.Format("~/Media/pojok-kreasi.aspx{0}&tab={1}", PrevUrl, (int)Infographic_Type.Print_Ad));
                tab_Stock_Photo.HRef = ResolveUrl(string.Format("~/Media/pojok-kreasi.aspx{0}&tab={1}", PrevUrl, (int)Infographic_Type.Stock_Photo));
                tab_TVC.HRef = ResolveUrl(string.Format("~/Media/pojok-kreasi.aspx{0}&tab={1}", PrevUrl, (int)Infographic_Type.TVC));

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
                string _url = (Year > 1900) ? string.Format("pojok-kreasi.aspx{0}&tab={1}&ar={2}", PrevUrl, ActiveTab, _archive.Archive) : string.Format("pojok-kreasi.aspx{0}&tab={1}&ar={2}", PrevUrl, ActiveTab, _archive.Archive);
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
            kt_portlet_base_demo_2_4_tab_content.Attributes["class"] = "tab-pane";

            tab_Print_Ad.Attributes["class"] = "nav-link";
            tab_TVC.Attributes["class"] = "nav-link";
            tab_Stock_Photo.Attributes["class"] = "nav-link";

            if (ActiveTab > 0)
            {
                if (ActiveTab == (int)Infographic_Type.Print_Ad)
                {
                    tab_Print_Ad.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_4_tab_content.Attributes["class"] = "tab-pane active";
                }
                else if (ActiveTab == (int)Infographic_Type.Stock_Photo)
                {
                    tab_Stock_Photo.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_3_tab_content.Attributes["class"] = "tab-pane active";
                }
                else if (ActiveTab == (int)Infographic_Type.TVC)
                {
                    tab_TVC.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_2_tab_content.Attributes["class"] = "tab-pane active";
                }
                else
                {
                    tab_Print_Ad.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_4_tab_content.Attributes["class"] = "tab-pane active";
                }
            }
            else
            {
                tab_Print_Ad.Attributes["class"] = "nav-link active";
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
            hdnPagePrint_Ad.Value = "0";
            //hdnPageStock_Photo.Value = "0";
            hdnPageTVC.Value = "0";
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
            else if (tipeDocument == Infographic_Type.Stock_Photo.ToString())
            {
                //hdnPageStock_Photo.Value = pageIndex.ToString();
            }
            else if (tipeDocument == Infographic_Type.TVC.ToString())
            {
                hdnPageTVC.Value = pageIndex.ToString();
            }


            BindingData();
        }

        void BindingData()
        {
            if (ActiveTab == (int)Infographic_Type.Print_Ad)
            {
                BindingDataPrint_Ad("");
            }
            else if (ActiveTab == (int)Infographic_Type.Stock_Photo)
            {
                BindingDataStock_Photo("");
            }
            else if (ActiveTab == (int)Infographic_Type.TVC)
            {
                BindingDataTVC("");
            }
            else
            {
                BindingDataPrint_Ad("");
            }

        }


        void BindingDataTVC(string judul)
        {
            int pageIndex = 0;
            string totalRecordInfoTVC = "";
            int totalRows = 0;
            int pageSizeTVC = 10;
            int.TryParse(ddlPageSizeTVC.SelectedValue, out pageSizeTVC);
            int.TryParse(hdnPageTVC.Value, out pageIndex);



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


            //listViewTVC.PageSize = pageSizeTVC;
            listViewTVC.DataSource = tbl_MediaItem.GetDataPaging(pageIndex, pageSizeTVC, (int)Infographic_Type.TVC, tahunAwal, tahunAkhir, out totalRows);
            listViewTVC.DataBind();

            pageIndex += 1;

            rptPagerTVC.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeTVC, out totalRecordInfoTVC);
            rptPagerTVC.DataBind();
            lblTotalInfoTVC.Text = totalRecordInfoTVC;

            rptPagerTVC.Visible = totalRows > 0;
        }
        void BindingDataStock_Photo(string judul)
        {
            int pageIndex = 0;
            //string totalRecordInfoStock_Photo = "";
            int totalRows = 0;
            //int pageSizeStock_Photo = 10;
            //int.TryParse(ddlPageSizeStock_Photo.SelectedValue, out pageSizeStock_Photo);
            //int.TryParse(hdnPageStock_Photo.Value, out pageIndex);



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


            //listViewStock_Photo.PageSize = pageSizeStock_Photo;
            listViewStock_Photo.DataSource = tbl_MediaItem.GetByType((int)Infographic_Type.Stock_Photo, tahunAwal, tahunAkhir);
            listViewStock_Photo.DataBind();

            pageIndex += 1;

            //rptPagerStock_Photo.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeStock_Photo, out totalRecordInfoStock_Photo);
            //rptPagerStock_Photo.DataBind();
            //lblTotalInfoStock_Photo.Text = totalRecordInfoStock_Photo;

            //rptPagerStock_Photo.Visible = totalRows > 0;
        }
        void BindingDataPrint_Ad(string judul)
        {
            int pageIndex = 0;
            string totalRecordInfoPrint_Ad = "";
            int totalRows = 0;
            int pageSizePrint_Ad = 10;
            int.TryParse(ddlPageSizePrint_Ad.SelectedValue, out pageSizePrint_Ad);
            int.TryParse(hdnPagePrint_Ad.Value, out pageIndex);



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


            //listViewPrint_Ad.PageSize = pageSizePrint_Ad;
            listViewPrint_Ad.DataSource = tbl_MediaItem.GetDataPaging(pageIndex, pageSizePrint_Ad, (int)Infographic_Type.Print_Ad, tahunAwal, tahunAkhir, out totalRows);
            listViewPrint_Ad.DataBind();

            pageIndex += 1;

            rptPagerPrint_Ad.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizePrint_Ad, out totalRecordInfoPrint_Ad);
            rptPagerPrint_Ad.DataBind();
            lblTotalInfoPrint_Ad.Text = totalRecordInfoPrint_Ad;

            rptPagerPrint_Ad.Visible = totalRows > 0;
        }
    }
}