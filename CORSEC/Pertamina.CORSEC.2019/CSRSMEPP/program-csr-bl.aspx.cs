using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.CSRSMEPP
{
    public partial class program_csr_bl : CORSECPage
    {

        #region "BAGIAN 2"
        public int ActiveTab2
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["tab2"];
                int.TryParse(_id, out id);
                if (id == 0) return (int)BL_SMEPP_Data_Type.BL_RKAP;
                return id;
            }
        }

        public int Document2
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["doc2"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public int Bulan2
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["bln2"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        int LoadBulan2()
        {
            int doc = Document2;
            int tab = ActiveTab2;
            int bln = Bulan2;
            int category = (int)CSR_SMEP_ProgramType.Pengelolaan_BL;
            List<tbl_bulan> bulans = tbl_CSR_SMEP_ProgramItem.GetBulan(tab, doc, bln, category);

            tbl_bulan selectedCountry = bulans.Where(t => t.id == bln).FirstOrDefault();

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

            string selectedArciveTemplate = string.Format(@" 
    <button id=""btnGroupDropBulan2"" type=""button"" class=""btn btn-secondary dropdown-toggle""
       data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
       {0}
   </button>", (selectedCountry != null) ? selectedCountry.nama : "Bulan");


            int currentYear = DateTime.Now.Year;
            selectedArciveTemplate += @"
<div class=""dropdown-menu"" aria-labelledby=""btnGroupDropBulan2"">
";
            string queryString = "";
            if (tab > 0) queryString += string.Format("&tab2={0}", tab);
            if (doc > 0) queryString += string.Format("&doc2={0}", doc);
            for (int i = 0; i < bulans.Count; i++)
            {
                tbl_bulan bulanItem = bulans[i];
                string _url = string.Format("program-csr-bl.aspx{0}{1}&bln2={2}", PrevUrl, queryString, bulanItem.id);
                selectedArciveTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, bulanItem.nama);
            }
            selectedArciveTemplate += "</div>";
            litBulan2.Text = selectedArciveTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            return bln;
        }

        int LoadDocument2()
        {
            int doc = Document2;
            int tab = ActiveTab2;
            int bln = Bulan2;
            List<tbl_CSR_SMEP_Program_Related_Document> docs = tbl_CSR_SMEP_Program_Related_DocumentItem.GetAll();
            tbl_CSR_SMEP_Program_Related_Document selectedCountry = docs.Where(t => t.id == doc).FirstOrDefault();

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

            string selectedArciveTemplate = string.Format(@" 
    <button id=""btnGroupDropDoc2"" type=""button"" class=""btn btn-secondary dropdown-toggle""
       data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
       {0}
   </button>", (selectedCountry != null) ? selectedCountry.Name : "Related Document");


            int currentYear = DateTime.Now.Year;
            selectedArciveTemplate += @"
<div class=""dropdown-menu"" aria-labelledby=""btnGroupDropDoc2"">
";

            string queryString = "";
            if (tab > 0) queryString += string.Format("&tab2={0}", tab);
            if (bln > 0) queryString += string.Format("&bln2={0}", bln);
            for (int i = 0; i < docs.Count; i++)
            {
                tbl_CSR_SMEP_Program_Related_Document countryItem = docs[i];
                string _url = string.Format("program-csr-bl.aspx{0}{1}&doc2={2}", PrevUrl, queryString, countryItem.id);
                selectedArciveTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, countryItem.Name);
            }
            selectedArciveTemplate += "</div>";
            litDocument2.Text = selectedArciveTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            return doc;
        }

        void LoadTab2()
        {
            int doc = Document2;
            int bln = Bulan2;
            int tab = ActiveTab2;
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
            List<DataItem> tabs = Utilities.GetDataSource<BL_SMEPP_Data_Type>();
            string queryString = "";
            if (doc > 0) queryString += string.Format("&doc2={0}", doc);
            if (bln > 0) queryString += string.Format("&bln2={0}", bln);
            for (int i = 0; i < tabs.Count; i++)
            {
                DataItem tabItem = tabs[i];
                string _url = string.Format("program-csr-bl.aspx{0}&tab2={1}{2}", PrevUrl, tabItem.Code, queryString);
                if (tabItem.Code == string.Format("{0}", tab)) { sb.AppendFormat(templateActive, _url, tabItem.Text); }
                else if (tab <= 0 && i == 0) { sb.AppendFormat(templateActive, _url, tabItem.Text); }
                else
                {
                    sb.AppendFormat(template, _url, tabItem.Text);
                }
            }

            litTab2.Text = sb.ToString();
        }

        #endregion


        #region "BAGIAN 1"

        public int ActiveTab
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["tab"];
                int.TryParse(_id, out id);
                if (id == 0) return (int)CSR_SMEPP_Data_Type.CSR_RKAP;
                return id;
            }
        }

        public int Document
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["doc"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public int Bulan
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["bln"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        int LoadBulan()
        {
            int _bulan = Bulan;
            int doc = Document;
            int tab = ActiveTab;
            int bln = Bulan;
            int category = (int)CSR_SMEP_ProgramType.Pengelolaan_CSR;
            List<tbl_bulan> bulans = tbl_CSR_SMEP_ProgramItem.GetBulan(tab, doc, bln, category);

            tbl_bulan selectedCountry = bulans.Where(t => t.id == _bulan).FirstOrDefault();

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

            string selectedArciveTemplate = string.Format(@" 
    <button id=""btnGroupDropBulan"" type=""button"" class=""btn btn-secondary dropdown-toggle""
       data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
       {0}
   </button>", (selectedCountry != null) ? selectedCountry.nama : "Bulan");


            int currentYear = DateTime.Now.Year;
            selectedArciveTemplate += @"
<div class=""dropdown-menu"" aria-labelledby=""btnGroupDropBulan"">
";
            string queryString = "";
            if (tab > 0) queryString += string.Format("&tab={0}", tab);
            if (doc > 0) queryString += string.Format("&doc={0}", doc);
            for (int i = 0; i < bulans.Count; i++)
            {
                tbl_bulan bulanItem = bulans[i];
                string _url = string.Format("program-csr-bl.aspx{0}{1}&bln={2}", PrevUrl, queryString, bulanItem.id);
                selectedArciveTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, bulanItem.nama);
            }
            selectedArciveTemplate += "</div>";
            litBulan.Text = selectedArciveTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            return _bulan;
        }

        int LoadDocument()
        {
            int doc = Document;
            int tab = ActiveTab;
            int bln = Bulan;
            List<tbl_CSR_SMEP_Program_Related_Document> docs = tbl_CSR_SMEP_Program_Related_DocumentItem.GetAll();
            tbl_CSR_SMEP_Program_Related_Document selectedCountry = docs.Where(t => t.id == doc).FirstOrDefault();

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

            string selectedArciveTemplate = string.Format(@" 
    <button id=""btnGroupDropCountry"" type=""button"" class=""btn btn-secondary dropdown-toggle""
       data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
       {0}
   </button>", (selectedCountry != null) ? selectedCountry.Name : "Related Document");


            int currentYear = DateTime.Now.Year;
            selectedArciveTemplate += @"
<div class=""dropdown-menu"" aria-labelledby=""btnGroupDropCountry"">
";

            string queryString = "";
            if (tab > 0) queryString += string.Format("&tab={0}", tab);
            if (bln > 0) queryString += string.Format("&bln={0}", bln);
            for (int i = 0; i < docs.Count; i++)
            {
                tbl_CSR_SMEP_Program_Related_Document countryItem = docs[i];
                string _url = string.Format("program-csr-bl.aspx{0}{1}&doc={2}", PrevUrl, queryString, countryItem.id);
                selectedArciveTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, countryItem.Name);
            }
            selectedArciveTemplate += "</div>";
            litDocument.Text = selectedArciveTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            return doc;
        }

        void LoadTab()
        {
            int doc = Document;
            int bln = Bulan;
            int tab = ActiveTab;
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
            List<DataItem> tabs = Utilities.GetDataSource<CSR_SMEPP_Data_Type>();
            string queryString = "";
            if (doc > 0) queryString += string.Format("&doc={0}", doc);
            if (bln > 0) queryString += string.Format("&bln={0}", bln);
            for (int i = 0; i < tabs.Count; i++)
            {
                DataItem tabItem = tabs[i];
                string _url = string.Format("program-csr-bl.aspx{0}&tab={1}{2}", PrevUrl, tabItem.Code, queryString);
                if (tabItem.Code == string.Format("{0}", tab)) { sb.AppendFormat(templateActive, _url, tabItem.Text); }
                else if (tab <= 0 && i == 0) { sb.AppendFormat(templateActive, _url, tabItem.Text); }
                else
                {
                    sb.AppendFormat(template, _url, tabItem.Text);
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
            DropDownList ddl = sender as DropDownList;
            if (ddl.ID == ddlPageSize2.ID)
            {
                hdnPage2.Value = "0";
                BindingData2();
            }
            else if (ddl.ID == ddlPageSize.ID)
            {
                hdnPage.Value = "0";
                BindingData();
            }
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;            
            int pageIndex = int.Parse((lb).CommandArgument);
            pageIndex -= 1;
            string tipeDocument = (lb).CommandName;
            RepeaterItem rptItem = lb.NamingContainer as RepeaterItem;
            if (rptItem != null)
            {
                if (rptItem.NamingContainer.ID == rptPager2.ID)
                {
                    hdnPage2.Value = pageIndex.ToString();
                    BindingData2();
                }
                else if (rptItem.NamingContainer.ID == rptPager.ID)
                {
                    hdnPage.Value = pageIndex.ToString();
                    BindingData();
                }
            }
        }

        void BindingData()
        {
            int pageIndex = 0;
            string totalRecordInfo = "";
            int totalRows = 0;
            int pageSize = 10;
            int.TryParse(ddlPageSize.SelectedValue, out pageSize);
            int.TryParse(hdnPage.Value, out pageIndex);

            int doc = Document;
            int tab = ActiveTab;
            int bln = Bulan;
            int category = (int)CSR_SMEP_ProgramType.Pengelolaan_CSR;
            totalRows = tbl_CSR_SMEP_ProgramItem.GetCount(tab, doc, bln, category);


            grid.PageSize = pageSize;
            grid.DataSource = tbl_CSR_SMEP_ProgramItem.GetPaging(pageSize, pageIndex, tab, doc, bln, category);
            grid.DataBind();

            pageIndex += 1;

            rptPager.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSize, out totalRecordInfo);
            rptPager.DataBind();
            lblTotalInfo.Text = totalRecordInfo;

            rptPager.Visible = totalRows > 0;
        }
        #endregion



        void BindingData2()
        {
            int pageIndex = 0;
            string totalRecordInfo = "";
            int totalRows = 0;
            int pageSize = 10;
            int.TryParse(ddlPageSize2.SelectedValue, out pageSize);
            int.TryParse(hdnPage2.Value, out pageIndex);

            int doc = Document2;
            int tab = ActiveTab2;
            int bln = Bulan2;
            int category = (int)CSR_SMEP_ProgramType.Pengelolaan_BL;
            totalRows = tbl_CSR_SMEP_ProgramItem.GetCount(tab, doc, bln, category);


            grid2.PageSize = pageSize;
            grid2.DataSource = tbl_CSR_SMEP_ProgramItem.GetPaging(pageSize, pageIndex, tab, doc, bln, category);
            grid2.DataBind();

            pageIndex += 1;

            rptPager2.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSize, out totalRecordInfo);
            rptPager2.DataBind();
            lblTotalInfo2.Text = totalRecordInfo;

            rptPager2.Visible = totalRows > 0;
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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Strategi_Pengelolaan_CSR_BL);
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

                List<DataItem> list = new List<DataItem>();
                //list.Add(new DataItem("5"));
                list.Add(new DataItem("10"));
                list.Add(new DataItem("20"));
                list.Add(new DataItem("50"));
                list.Add(new DataItem("100"));
                ddlPageSize.DataSource = list;
                ddlPageSize.DataBind();

                ddlPageSize2.DataSource = list;
                ddlPageSize2.DataBind();

                LoadBulan();
                LoadTab();
                LoadDocument();
                BindingData();

                LoadBulan2();
                LoadTab2();
                LoadDocument2();
                
                BindingData2();
            }
        }
    }
}