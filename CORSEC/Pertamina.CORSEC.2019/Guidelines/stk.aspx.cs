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

namespace Pertamina.CORSEC._2019.Guidelines
{
    public partial class stk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //rptPager.ItemDataBound += RptPager_ItemDataBound;
                List<DataItem> list = new List<DataItem>();
                list.Add(new DataItem("10"));
                list.Add(new DataItem("20"));
                list.Add(new DataItem("50"));
                list.Add(new DataItem("100"));
                ddlPageSizePedoman.DataSource = list;
                ddlPageSizePedoman.DataBind();

                ddlPageSizeTKO.DataSource = list;
                ddlPageSizeTKO.DataBind();

                ddlPageSizeTKI.DataSource = list;
                ddlPageSizeTKI.DataBind();

                ddlPageSizeDaftarInformasiDikecualikan.DataSource = list;
                ddlPageSizeDaftarInformasiDikecualikan.DataBind();

                ddlPageSizePeraturanCompliance.DataSource = list;
                ddlPageSizePeraturanCompliance.DataBind();

                ddlDocumentType.DataSource = tbl_Combo_DetailItem.GetByHeader("Tipe_Dokumen");
                ddlDocumentType.DataBind();

                List<DataItem> years = new List<DataItem>();
                for (int i = 0; i < 6; i++)
                {
                    years.Add(new DataItem(string.Format("{0}", DateTime.Now.Year - i)));
                }

                years.Insert(0, new DataItem("Tahun"));

                ddlYear.DataSource = years;
                ddlYear.DataBind();

                string header_template = @"
  <div class=""kt-sc"" style=""background-image: url('{0}')  "">
      <div class=""kt-container "">
          <div class=""kt-sc__bottom"">
              <h3 class=""kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium"">                        
                  {1}
              </h3>
          </div>
      </div>
  </div>
";

                tbl_File_Template itemTemplate = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Guidelines_Policy);
                if (itemTemplate != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (itemTemplate.file_blob != null)
                    {
                        imageUrl = Business.Utilities.ByteToString(itemTemplate.file_blob);
                    }
                    lblHeader.Text = string.Format(header_template, imageUrl, itemTemplate.template_header);
                    lblTitle.Text = itemTemplate.template_title;
                    lblIsi.Text = itemTemplate.template_desc;
                }


                //    tbl_Guidelines_Info item = tbl_Guidelines_InfoItem.GetAll().FirstOrDefault();
                //if (item != null)
                //{
                //    string imageUrl = string.Format(" url('{0}') ", ResolveUrl("~/Content/assets/media/bg/bg-9.jpg"));
                //    tbl_File_Template file = tbl_File_TemplateItem.GetByReff(ReferenceTable.tbl_Struktur_Organisasi.ToString(), item.id.ToString());
                //    if (file != null)
                //    {
                //        imageUrl = string.Format(" url('data:image/png;base64,{0}') ", Convert.ToBase64String(file.file_blob));
                //    }

                //    lblHeader.Text = string.Format(header_template, imageUrl, item.title);
                //    lblTittle.Text = item.title;
                //    lblIsi.Text = item.body;
                //}

                BindingData();
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
                HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                HiddenField hdnFileID = e.Row.FindControl("hdnFileID") as HiddenField;
                HiddenField hdnFileExt = e.Row.FindControl("hdnFileExt") as HiddenField;


                HyperLink linkFile = e.Row.FindControl("linkFile") as HyperLink;
                if (!string.IsNullOrEmpty(hdnFileID.Value))
                {
                    linkFile.ToolTip = "Download";
                    linkFile.NavigateUrl = ResolveUrl(string.Format("~/GuidelinesFileHandler.ashx?FileID={0}", hdnFileID.Value));
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
            BindingData();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            string tipeDocument = (sender as LinkButton).CommandName;
            if (tipeDocument == "Pedoman")
            {
                hdnPagePedoman.Value = pageIndex.ToString();
            }
            else if (tipeDocument == "TKO")
            {
                hdnPageTKO.Value = pageIndex.ToString();
            }
            else if (tipeDocument == "TKI")
            {
                hdnPageTKI.Value = pageIndex.ToString();
            }
            else if (tipeDocument == "Daftar Informasi Dikecualikan")
            {
                hdnPageDaftarInformasiDikecualikan.Value = pageIndex.ToString();
            }
            else if (tipeDocument == "Peraturan Compliance")
            {
                hdnPagePeraturanCompliance.Value = pageIndex.ToString();
            }


            BindingData();
        }

        void BindingData()
        {
            BindingDataPedoman("", 0);
            BindingDataTKO("", 0);
            BindingDataTKI("", 0);
            BindingDataDaftarInformasiDikecualikan("", 0);
            BindingDataPeraturanCompliance("", 0);
        }

        void BindingDataPedoman(string judul, int tahun)
        {
            int pageIndex = 0;
            string totalRecordInfoPedoman = "";
            int totalRows = 0;
            int pageSizePedoman = 10;
            int.TryParse(ddlPageSizePedoman.SelectedValue, out pageSizePedoman);
            int.TryParse(hdnPagePedoman.Value, out pageIndex);
            gridPedoman.PageSize = pageSizePedoman;
            gridPedoman.DataSource = tbl_Guidelines_DocItem.GetDataPaging(pageIndex, pageSizePedoman, "Pedoman", judul, tahun, out totalRows);
            gridPedoman.DataBind();

            pageIndex += 1;

            rptPagerPedoman.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizePedoman, out totalRecordInfoPedoman);
            rptPagerPedoman.DataBind();
            lblTotalInfoPedoman.Text = totalRecordInfoPedoman;

            rptPagerPedoman.Visible = totalRows > 0;
        }

        void BindingDataTKO(string judul, int tahun)
        {
            int pageIndex = 0;
            string totalRecordInfo = "";
            int totalRows = 0;
            int pageSize = 10;
            int.TryParse(ddlPageSizeTKO.SelectedValue, out pageSize);
            int.TryParse(hdnPageTKO.Value, out pageIndex);

            gridTKO.PageSize = pageSize;
            gridTKO.DataSource = tbl_Guidelines_DocItem.GetDataPaging(pageIndex, pageSize, "TKO", judul, tahun, out totalRows);
            gridTKO.DataBind();

            pageIndex += 1;

            rptPagerTKO.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSize, out totalRecordInfo);
            rptPagerTKO.DataBind();
            lblTotalInfoTKO.Text = totalRecordInfo;

            pagerTKO.Visible = totalRows > 0;
        }

        void BindingDataTKI(string judul, int tahun)
        {
            int pageIndex = 0;
            string totalRecordInfo = "";
            int totalRows = 0;
            int pageSize = 10;
            int.TryParse(ddlPageSizeTKI.SelectedValue, out pageSize);
            int.TryParse(hdnPageTKI.Value, out pageIndex);

            gridTKI.PageSize = pageSize;
            gridTKI.DataSource = tbl_Guidelines_DocItem.GetDataPaging(pageIndex, pageSize, "TKI", judul, tahun, out totalRows);
            gridTKI.DataBind();

            pageIndex += 1;

            rptPagerTKI.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSize, out totalRecordInfo);
            rptPagerTKI.DataBind();
            lblTotalInfoTKI.Text = totalRecordInfo;

            pagerTKI.Visible = totalRows > 0;
        }

        void BindingDataDaftarInformasiDikecualikan(string judul, int tahun)
        {
            int pageIndex = 0;
            string totalRecordInfo = "";
            int totalRows = 0;
            int pageSize = 10;
            int.TryParse(ddlPageSizeDaftarInformasiDikecualikan.SelectedValue, out pageSize);
            int.TryParse(hdnPageDaftarInformasiDikecualikan.Value, out pageIndex);

            gridDaftarInformasiDikecualikan.PageSize = pageSize;
            gridDaftarInformasiDikecualikan.DataSource = tbl_Guidelines_DocItem.GetDataPaging(pageIndex, pageSize, "Daftar Informasi Dikecualikan", judul, tahun, out totalRows);
            gridDaftarInformasiDikecualikan.DataBind();

            pageIndex += 1;

            rptPagerDaftarInformasiDikecualikan.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSize, out totalRecordInfo);
            rptPagerDaftarInformasiDikecualikan.DataBind();
            lblTotalInfoDaftarInformasiDikecualikan.Text = totalRecordInfo;

            pagerDaftarInformasiDikecualikan.Visible = totalRows > 0;
        }


        void BindingDataPeraturanCompliance(string judul, int tahun)
        {
            int pageIndex = 0;
            string totalRecordInfo = "";
            int totalRows = 0;
            int pageSize = 10;
            int.TryParse(ddlPageSizePeraturanCompliance.SelectedValue, out pageSize);
            int.TryParse(hdnPagePeraturanCompliance.Value, out pageIndex);

            gridPeraturanCompliance.PageSize = pageSize;
            gridPeraturanCompliance.DataSource = tbl_Guidelines_DocItem.GetDataPaging(pageIndex, pageSize, "Peraturan Compliance", judul, tahun, out totalRows);
            gridPeraturanCompliance.DataBind();

            pageIndex += 1;

            rptPagerPeraturanCompliance.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSize, out totalRecordInfo);
            rptPagerPeraturanCompliance.DataBind();
            lblTotalInfoPeraturanCompliance.Text = totalRecordInfo;

            pagerPeraturanCompliance.Visible = totalRows > 0;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string judul = txtSearch.Text.Trim();
            string tipeDocument = string.Format("{0}", ddlDocumentType.SelectedValue);
            if (tipeDocument == "Jenis Dokumen") tipeDocument = string.Empty;
            int tahun = 0;
            int.TryParse(ddlYear.SelectedValue, out tahun);

            if (tipeDocument == "Pedoman")
            {
                hdnPagePedoman.Value = "0";
                BindingDataPedoman(judul, tahun);
                BindingDataTKO("", 0);
                BindingDataTKI("", 0);
                BindingDataDaftarInformasiDikecualikan("", 0);
                BindingDataPeraturanCompliance("", 0);
            }
            else if (tipeDocument == "TKO")
            {
                hdnPageTKO.Value = "0";
                BindingDataPedoman("", 0);
                BindingDataTKO(judul, tahun);
                BindingDataTKI("", 0);
                BindingDataDaftarInformasiDikecualikan("", 0);
                BindingDataPeraturanCompliance("", 0);
            }
            else if (tipeDocument == "TKI")
            {
                hdnPageTKI.Value = "0";
                BindingDataPedoman("", 0);
                BindingDataTKO("", 0);
                BindingDataTKI(judul, tahun);
                BindingDataDaftarInformasiDikecualikan("", 0);
                BindingDataPeraturanCompliance("", 0);
            }
            else if (tipeDocument == "Daftar Informasi Dikecualikan")
            {
                hdnPageDaftarInformasiDikecualikan.Value = "0";
                BindingDataPedoman("", 0);
                BindingDataTKO("", 0);
                BindingDataTKI("", 0);
                BindingDataDaftarInformasiDikecualikan(judul, tahun);
                BindingDataPeraturanCompliance("", 0);
            }
            else if (tipeDocument == "Peraturan Compliance")
            {
                hdnPagePeraturanCompliance.Value = "0";
                BindingDataPedoman("", 0);
                BindingDataTKO("", 0);
                BindingDataTKI("", 0);
                BindingDataDaftarInformasiDikecualikan("", 0);
                BindingDataPeraturanCompliance(judul, tahun);
            }

        }

        protected void ddlDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindingData(0);
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindingData(0);
        }
    }
}