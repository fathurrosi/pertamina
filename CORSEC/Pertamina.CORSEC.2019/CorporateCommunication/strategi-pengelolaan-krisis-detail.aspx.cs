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

namespace Pertamina.CORSEC._2019.CorporateCommunication
{
    public partial class strategi_pengelolaan_krisis_detail : CORSECPage
    {

        public int SubCategory
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["sub"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public int DocumentType
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["doc"];
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

        void LoadDocumentType()
        {
            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            //int maxYear = DateTime.Now.Year;
            //int minYear = maxYear - 5;
            //int selectedYear = maxYear;
            //if (Year > 0 && Year <= maxYear && Year >= minYear)
            //{
            //    selectedYear = Year;
            //}
            //else
            //{
            //    selectedYear = maxYear;
            //}

            List<DataItem> docList = Utilities.GetDataSource<Krisis_Jenis_Documen>(); // Krisis_Jenis_Documen
            DataItem selectedDoc = docList.Where(t => t.Code == string.Format("{0}", DocumentType)).FirstOrDefault();
            string selectedArciveTemplate = string.Format(@" 
  <button id=""btnGroupDrop"" type=""button"" class=""btn btn-secondary dropdown-toggle""
      data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
      {0}
  </button>", (selectedDoc == null) ? "Search Jenis Dokumen" : selectedDoc.Text);


            int currentYear = DateTime.Now.Year;
            selectedArciveTemplate += @"
<div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop"" x-placement=""bottom-start""
            style=""position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 39px, 0px);"">
";
            for (int i = 0; i < docList.Count; i++)
            {
                DataItem doc = docList[i];
                string _url = string.Format("strategi-pengelolaan-krisis-detail.aspx{0}&sub={3}&doc={1}&y={2}", PrevUrl, doc.Code, Year, SubCategory);
                selectedArciveTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, doc.Text);

            }
            selectedArciveTemplate += "</div>";
            litDocType.Text = selectedArciveTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            //return selectedYear;
        }

        int LoadYear()
        {
            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            int maxYear = DateTime.Now.Year;
            int minYear = maxYear - 5;
            int selectedYear = maxYear;
            if (Year > 0 && Year <= maxYear && Year >= minYear)
            {
                selectedYear = Year;
            }
            else
            {
                selectedYear = maxYear;
            }

            string selectedArciveTemplate = string.Format(@" 
  <button id=""btnGroupDrop"" type=""button"" class=""btn btn-secondary dropdown-toggle""
      data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
      {0}
  </button>", (selectedYear > 1900) ? selectedYear.ToString() : "Tahun");


            int currentYear = DateTime.Now.Year;
            selectedArciveTemplate += @"
<div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop"" x-placement=""bottom-start""
            style=""position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 39px, 0px);"">
";
            for (int i = 0; i < 5; i++)
            {
                string _url = (DocumentType > 0) ? string.Format("strategi-pengelolaan-krisis-detail.aspx{0}&sub={3}&doc={1}&y={2}", PrevUrl, DocumentType, maxYear, SubCategory) : string.Format("strategi-pengelolaan-krisis-detail.aspx{0}&sub{2}&y={1}", PrevUrl, maxYear, SubCategory);
                selectedArciveTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, maxYear);
                maxYear--;
            }
            selectedArciveTemplate += "</div>";
            litYear.Text = selectedArciveTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            return selectedYear;
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
                HiddenField hdnFileID = e.Row.FindControl("hdnID") as HiddenField;
                HiddenField hdnFileExt = e.Row.FindControl("hdnFileExt") as HiddenField;


                HyperLink linkFile = e.Row.FindControl("linkFile") as HyperLink;
                if (!string.IsNullOrEmpty(hdnFileID.Value))
                {
                    linkFile.ToolTip = "Download";
                    linkFile.NavigateUrl = ResolveUrl(string.Format("~/strategi-pengelolaan-krisisHandler.ashx?id={0}", hdnFileID.Value));
                }

                Image img = e.Row.FindControl("imgFile") as Image;
                img.ImageUrl = Utilities.ExtToImage(hdnFileExt.Value);
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
            hdnPage.Value = "0";
            BindingData();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            hdnPage.Value = pageIndex.ToString();

            BindingData();
        }

        void BindingData()
        {
            int pageIndex = 0;
            string totalRecordInfo = "";
            int totalRows = 0;
            int pageSize = 10;
            int.TryParse(ddlPageSize.SelectedValue, out pageSize);
            int.TryParse(hdnPage.Value, out pageIndex);


            totalRows = tbl_CorporateCommunication_KrisisItem.GetTotalRecord(SubCategory, Year, DocumentType);

            grid.PageSize = pageSize;
            grid.DataSource = tbl_CorporateCommunication_KrisisItem.GetPaging(pageSize, pageIndex, SubCategory, Year, DocumentType);
            grid.DataBind();

            pageIndex += 1;

            rptPager.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSize, out totalRecordInfo);
            rptPager.DataBind();
            lblTotalInfo.Text = totalRecordInfo;

            rptPager.Visible = totalRows > 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Strategi_Pengelolaan_Krisis_Detail);
                if (item != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (item.file_blob != null)
                    {
                        imageUrl = Business.Utilities.ByteToString(item.file_blob);
                    }

                    lblHeader.Text = string.Format(header_template, imageUrl, item.template_header);
                    lblTitle.Text = item.template_title;
                    //lblIsi.Text = item.template_desc;
                }
                #endregion


                //Int64 selectedCategory = LoadCategory();
                LoadDocumentType();
                int selectedYear = LoadYear();



                List<DataItem> list = new List<DataItem>();
                list.Add(new DataItem("10"));
                list.Add(new DataItem("20"));
                list.Add(new DataItem("50"));
                list.Add(new DataItem("100"));
                ddlPageSize.DataSource = list;
                ddlPageSize.DataBind();


                BindingData();

            }
        }
    }
}