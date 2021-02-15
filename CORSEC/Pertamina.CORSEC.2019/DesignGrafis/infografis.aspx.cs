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

namespace Pertamina.CORSEC._2019.DesignGrafis
{
    public partial class infografis : CORSECPage
    {
        public int ActiveTab
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["tab"];
                int.TryParse(_id, out id);
                if (id == 0) return (int)Design_Grafis_Desain_Type.Print_Ad;
                return id;
            }
        }


        void LoadTab()
        {
            //int doc = Document;
            //int bln = Bulan;
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
            List<DataItem> tabs = Utilities.GetDataSource<Design_Grafis_Desain_Type>().Where(t => t.Code != string.Format("{0}", (int)Design_Grafis_Desain_Type.Banner)).ToList();
            string queryString = "";
            //if (doc > 0) queryString += string.Format("&doc={0}", doc);
            //if (bln > 0) queryString += string.Format("&bln={0}", bln);
            for (int i = 0; i < tabs.Count; i++)
            {
                DataItem tabItem = tabs[i];
                string _url = string.Format("infografis.aspx{0}&tab={1}{2}", PrevUrl, tabItem.Code, queryString);
                if (tabItem.Code == string.Format("{0}", tab)) { sb.AppendFormat(templateActive, _url, tabItem.Text); }
                else if (tab <= 0 && i == 0) { sb.AppendFormat(templateActive, _url, tabItem.Text); }
                else
                {
                    sb.AppendFormat(template, _url, tabItem.Text);
                }
            }

            litTab.Text = sb.ToString();
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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Infografis);
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
                list.Add(new DataItem("4"));
                list.Add(new DataItem("8"));
                list.Add(new DataItem("16"));
                list.Add(new DataItem("40"));
                list.Add(new DataItem("80"));
                ddlPageSizePrint_Ad.DataSource = list;
                ddlPageSizePrint_Ad.DataBind();


                LoadTab();
                LoadData();

            }

        }

        protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HiddenField hdndata_type = e.Item.FindControl("hdndata_type") as HiddenField;
                HiddenField hdnId = e.Item.FindControl("hdn") as HiddenField;
                HiddenField hdnFileExt = e.Item.FindControl("hdnFileExt") as HiddenField;

                HyperLink linkDetail = e.Item.FindControl("linkDetail") as HyperLink;
                linkDetail.CssClass = "btn btn-sm btn-label-brand btn-bold";
                linkDetail.NavigateUrl = string.Format("infografis-detail.aspx{0}&id={1}", PrevUrl, hdnId.Value);
                linkDetail.Text = "Lihat";

                if (hdndata_type.Value == string.Format("{0}", (int)Design_Grafis_Desain_Type.Stock_Photo))
                {
                    linkDetail.NavigateUrl = string.Format("infografis-photo.aspx{0}&id={1}", PrevUrl, hdnId.Value);
                }
            }
        }


        //protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        e.Row.TableSection = TableRowSection.TableHeader;
        //    }
        //    else if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        HiddenField hdndata_type = e.Row.FindControl("hdndata_type") as HiddenField;
        //        HiddenField hdnFileID = e.Row.FindControl("hdn") as HiddenField;
        //        HiddenField hdnFileExt = e.Row.FindControl("hdnFileExt") as HiddenField;

        //        HyperLink linkDetail = e.Row.FindControl("linkDetail") as HyperLink;
        //        linkDetail.CssClass = "btn btn-sm btn-label-brand btn-bold";
        //        linkDetail.NavigateUrl = ResolveUrl(string.Format("~/DesignGrafis/infografis-detail.aspx{0}&id={1}", PrevUrl, Eval("id")));
        //        linkDetail.Text = "Lihat";

        //        if (hdndata_type.Value == string.Format("{0}", (int)Design_Grafis_Desain_Type.Stock_Photo))
        //        {
        //            linkDetail.NavigateUrl = ResolveUrl(string.Format("~/DesignGrafis/infografis-photo.aspx{0}&id={1}", PrevUrl, Eval("id")));
        //        }

        //        HyperLink linkFile = e.Row.FindControl("linkFile") as HyperLink;
        //        if (!string.IsNullOrEmpty(hdnFileID.Value))
        //        {
        //            linkFile.ToolTip = "Download";
        //            linkFile.NavigateUrl = ResolveUrl(string.Format("~/InfographicHandler.ashx?id={0}", hdnFileID.Value));
        //        }

        //        Image img = e.Row.FindControl("imgFile") as Image;
        //        img.ImageUrl = ResolveUrl(string.Format("~/Content/assets/media/files/{0}.svg", hdnFileExt.Value.Replace(".", "").ToLower()));
        //        if (string.IsNullOrEmpty(hdnFileExt.Value))
        //        {
        //            img.Visible = false;
        //        }
        //    }
        //}

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
            LoadData();
        }


        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            string tipeDocument = (sender as LinkButton).CommandName;
            hdnPagePrint_Ad.Value = pageIndex.ToString();

            LoadData();
        }

        void LoadData()
        {
            int pageIndex = 0;
            string totalRecordInfoPrint_Ad = "";
            int totalRows = 0;
            int pageSizePrint_Ad = 10;
            int.TryParse(ddlPageSizePrint_Ad.SelectedValue, out pageSizePrint_Ad);
            int.TryParse(hdnPagePrint_Ad.Value, out pageIndex);

            List<DataItem> tabs = Utilities.GetDataSource<Design_Grafis_Desain_Type>().Where(t => t.Code != string.Format("{0}", (int)Design_Grafis_Desain_Type.Banner)).ToList();

            int data_type = ActiveTab;
            if (tabs.Where(t => t.Code == string.Format("{0}", data_type)).Count() == 0)
            {
                data_type = (int)Design_Grafis_Desain_Type.Print_Ad;
            }

            if (data_type == (int)Design_Grafis_Desain_Type.TVC)
            {
                divTvc.Visible = true;
                divPrintAdd.Visible = false;
                listViewTVC.DataSource = tbl_Design_GrafisItem.GetDataPaging(pageIndex, pageSizePrint_Ad, data_type, out totalRows);
                listViewTVC.DataBind();

                pageIndex += 1;

                rptPagerTVC.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizePrint_Ad, out totalRecordInfoPrint_Ad);
                rptPagerTVC.DataBind();
                lblTotalInfoTVC.Text = totalRecordInfoPrint_Ad;

                rptPagerTVC.Visible = totalRows > 0;

            }
            else
            {
                divTvc.Visible = false;
                divPrintAdd.Visible = true;

                listViewPrint_Ad.DataSource = tbl_Design_GrafisItem.GetDataPaging(pageIndex, pageSizePrint_Ad, data_type, out totalRows);
                listViewPrint_Ad.DataBind();

                pageIndex += 1;

                rptPagerPrint_Ad.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizePrint_Ad, out totalRecordInfoPrint_Ad);
                rptPagerPrint_Ad.DataBind();

                lblTotalInfoPrint_Ad.Text = totalRecordInfoPrint_Ad;

                rptPagerPrint_Ad.Visible = totalRows > 0;
            }


        }
    }
}