using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;
using System.Linq;

namespace Pertamina.CORSEC._2019.Mitra
{
    public partial class mitra_binaan : CORSECPage
    {
        public int Category
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["c"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public int Sort
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["s"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        void SetFIlter()
        {
            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter filter $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$            
            List<tbl_Combo_Detail> categoryList = tbl_Combo_DetailItem.GetByHeader("Mitra_binaan_Category");
            string selectedCategory = "Kategori";
            if (Category > 0)
            {
                tbl_Combo_Detail selectedItem = categoryList.Where(t => t.id == Category).FirstOrDefault();
                selectedCategory = selectedItem.name;
            }


            ////<div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop1"">
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive A</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive B</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive C</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive D</a>
            ////</div>


            string filterTemplate = string.Format(@" 
<button id=""btnGroupDrop"" type=""button"" class=""btn btn-secondary dropdown-toggle"" 
data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
{0}</button>", selectedCategory);
            filterTemplate += @" 
                <div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop"">";
            foreach (tbl_Combo_Detail _item in categoryList)
            {
                string _url = string.Format("Mitra-binaan.aspx{0}&c={1}&s={2}", PrevUrl, _item.id, Sort);
                filterTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, _item.name);
            }
            filterTemplate += "</div>";
            lblFilter.Text = filterTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter filter  $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        }


        void SetSort()
        {
            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter sort $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            List<DataItem> list = Utilities.GetDataSource<Mitra_Sort>();
            string selectedTtext = "Sort list";
            if (Sort > 0)
            {
                DataItem selectedItem = list.Where(t => t.Code == Sort.ToString()).FirstOrDefault();
                selectedTtext = selectedItem.Text;
            }


            ////<div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop1"">
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive A</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive B</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive C</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive D</a>
            ////</div>


            string filterTemplate = string.Format(@" 
<button id=""btnGroupDrop"" type=""button"" class=""btn btn-secondary dropdown-toggle"" 
data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
{0}</button>", selectedTtext);
            filterTemplate += @" 
                <div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop"">";
            foreach (DataItem _item in list)
            {
                string _url = string.Format("Mitra-binaan.aspx{0}&c={1}&s={2}", PrevUrl, Category, _item.Code);
                filterTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, _item.Text);
            }
            filterTemplate += "</div>";
            lblSort.Text = filterTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter sort $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        }




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DataItem> list = new List<DataItem>();
                list.Add(new DataItem("4"));
                list.Add(new DataItem("12"));
                list.Add(new DataItem("24"));
                list.Add(new DataItem("40"));
                list.Add(new DataItem("80"));

                ddlPageSizeMerchandiseHub.DataSource = list;
                ddlPageSizeMerchandiseHub.DataBind();


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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Mitra_binaan);
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

                SetFIlter();
                SetSort();
                BindingDataMerchandiseHub();
            }

        }



        void BindingDataMerchandiseHub()
        {
            int pageIndex = 0;
            string totalRecordInfoMerchandiseHub = "";
            int totalRows = 0;
            int pageSizeMerchandiseHub = 6;
            int.TryParse(ddlPageSizeMerchandiseHub.SelectedValue, out pageSizeMerchandiseHub);
            int.TryParse(hdnPageMerchandiseHub.Value, out pageIndex);

            List<tbl_Combo_Detail> categoryList = tbl_Combo_DetailItem.GetByHeader("Mitra_binaan_Category");
            string selectedCategory = "";
            if (Category > 0)
            {
                tbl_Combo_Detail selectedItem = categoryList.Where(t => t.id == Category).FirstOrDefault();
                selectedCategory = selectedItem.name;
            }


            listViewMerchandiseHub.DataSource = tbl_productItem.GetPagingCustom(pageIndex, pageSizeMerchandiseHub, selectedCategory, (int)product_type.Mitra_binaan, Sort, out totalRows);
            listViewMerchandiseHub.DataBind();

            pageIndex += 1;

            rptPagerMerchandiseHub.DataSource = Utilities.PopulatePager(totalRows, pageIndex, pageSizeMerchandiseHub, out totalRecordInfoMerchandiseHub);
            rptPagerMerchandiseHub.DataBind();
            lblTotalInfoMerchandiseHub.Text = totalRecordInfoMerchandiseHub;

            rptPagerMerchandiseHub.Visible = totalRows > 0;
        }


        protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

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
            hdnPageMerchandiseHub.Value = "0";
            BindingDataMerchandiseHub();
        }

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            pageIndex -= 1;
            string tipeDocument = (sender as LinkButton).CommandName;

            hdnPageMerchandiseHub.Value = pageIndex.ToString();


            BindingDataMerchandiseHub();
        }

    }
}