using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.MonitoringEvaluasi
{
    public partial class kinerja_sekper_monitoring : CORSECPage
    {
        public int ActiveTab
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["tab"];
                int.TryParse(_id, out id);
                if (id == 0) return (int)Kinerja_Monitoring_Type.Kinerja_Sekper;
                return id;
            }
        }

        public int Bulan
        {
            get
            {

                int id = 0;
                string _id = Request.QueryString["ctr"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public int Tahun
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["ctr"];
                int.TryParse(_id, out id);
                return id;
            }
        }


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
            List<DataItem> tabs = Utilities.GetDataSource<Kinerja_Monitoring_Type>();
            for (int i = 0; i < tabs.Count; i++)
            {
                DataItem tab = tabs[i];
                string _url = string.Format("kinerja-sekper-monitoring.aspx{0}&tab={1}", PrevUrl, tab.Code);

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
            string tipeDocument = (sender as LinkButton).CommandName;
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

            DateTime filter = DateTime.Now;
            DateTime.TryParse(txtMonth.Text, out filter);


            int bulan = filter.Month;
            int tahun = filter.Year;
            int tab = ActiveTab;
            totalRows = tbl_MonitoringEvaluasi_KinerjaItem.GetTotalRecord(tab, tahun, bulan);


            grid.PageSize = pageSize;
            grid.DataSource = tbl_MonitoringEvaluasi_KinerjaItem.GetPaging(pageSize, pageIndex, tab, tahun, bulan);
            grid.DataBind();

            pageIndex += 1;

            rptPager.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSize, out totalRecordInfo);
            rptPager.DataBind();
            lblTotalInfo.Text = totalRecordInfo;

            rptPager.Visible = totalRows > 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(txtMonth.Text))
                    txtMonth.Text = string.Format("{0:dd MMMM yyyy}", DateTime.Now);

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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Kinerja_SEKPER);
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
                list.Add(new DataItem("5"));
                list.Add(new DataItem("10"));
                list.Add(new DataItem("20"));
                list.Add(new DataItem("50"));
                list.Add(new DataItem("100"));
                ddlPageSize.DataSource = list;
                ddlPageSize.DataBind();
                LoadTab();
                //LoadCountry();
                BindingData();
            }
        }

        //        protected void Page_Load(object sender, EventArgs e)
        //        {
        //            if (!IsPostBack)
        //            {
        //                #region Template Baru
        //                string header_template = @"
        //<div class=""kt-sc"" style=""background-image: url('{0}');"">
        //    <div class=""kt-container"">
        //        <div class=""kt-sc__bottom"">
        //            <h3 class=""kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium"">{1}
        //            </h3>
        //        </div>
        //    </div>
        //</div>
        //";
        //                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Media_Monitoring);
        //                if (item != null)
        //                {
        //                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
        //                    if (item.file_blob != null)
        //                    {
        //                        imageUrl = Business.Utilities.ByteToString(item.file_blob);
        //                    }

        //                    lblHeader.Text = string.Format(header_template, imageUrl, item.template_header);
        //                    lblTitle.Text = item.template_title;
        //                    lblIsi.Text = item.template_desc;
        //                }
        //                #endregion

        //            }
        //        }
    }
}