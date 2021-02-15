using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.CorporateCommunication
{
    public partial class strategi_pengelolaan_krisis : CORSECPage
    {
        public int Category
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["cat"];
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

        Int64 LoadCategory()
        {
            Int64 selected = 0;
            #region Cateogry
            string templateCategory = @"
 <ul class=""nav nav-pills nav-fill"" role=""tablist"">
    {0}
</ul>
";

            string templateCategoryItem = @"
    <li class=""nav-item"">
        <a class=""nav-link"" href=""{0}"" >{1} </a>
    </li>   
";


            string templateCategoryActiveItem = @"
    <li class=""nav-item"">
        <a class=""nav-link active"" href=""{0}"" >{1}</a>
    </li>   
";

            List<tbl_CorporateCommunication_Category> catList = tbl_CorporateCommunication_CategoryItem.GetAll();
            string temps = "";
            for (int i = 0; i < catList.Count; i++)
            {
                tbl_CorporateCommunication_Category cat = catList[i];
                string _url = string.Format("strategi-pengelolaan-krisis.aspx{0}&cat={1}&y={2}", PrevUrl, cat.id, Year);
                if (Year <= 1900)
                {
                    _url = string.Format("strategi-pengelolaan-krisis.aspx{0}&cat={1}", PrevUrl, cat.id);
                }

                if (Category == 0 && catList.Count > 0 && i == 0)
                {
                    var c = catList.FirstOrDefault();
                    temps += string.Format(templateCategoryActiveItem, _url, c.Name);
                    selected = c.id;
                }
                else if (Category == cat.id)
                {
                    temps += string.Format(templateCategoryActiveItem, _url, cat.Name);
                    selected = cat.id;
                }
                else
                {
                    temps += string.Format(templateCategoryItem, _url, cat.Name);
                }

            }

            litCategory.Text = string.Format(templateCategory, temps);
            #endregion

            return selected;
        }
        void LoadSubCategory(Int64 selectedCategory, int year)
        {
            List<tbl_CorporateCommunication_Sub_Category> subList = tbl_CorporateCommunication_Sub_CategoryItem.GetByFK(selectedCategory);
            string templateSub = @"
    <div class=""col-md-3 text-center"">
        <a href=""strategi-pengelolaan-krisis-detail.aspx{0}&sub={1}"">
            <i class=""fa fa-folder-open fa-7x""></i>
            <h4>{2}</h4>
        </a>
    </div>
";

            string templateSubYear = @"
    <div class=""col-md-3 text-center"">
        <a href=""strategi-pengelolaan-krisis-detail.aspx{0}&sub={1}&y={2}"">
            <i class=""fa fa-folder-open fa-7x""></i>
            <h4>{3}</h4>
        </a>
    </div>
";

            string temps = "";
            for (int i = 0; i < subList.Count; i++)
            {
                tbl_CorporateCommunication_Sub_Category sub = subList[i];

                if (year <= 1900)
                    temps += string.Format(templateSub, PrevUrl, sub.id, sub.Name);
                else
                    temps += string.Format(templateSubYear, PrevUrl, sub.id, year, sub.Name);

            }

            litSubCategory.Text = temps;
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
                string _url = (Category > 0) ? string.Format("strategi-pengelolaan-krisis.aspx{0}&cat={1}&y={2}", PrevUrl, Category, maxYear) : string.Format("strategi-pengelolaan-krisis.aspx{0}&y={1}", PrevUrl, maxYear);
                selectedArciveTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, maxYear);
                maxYear--;
            }
            selectedArciveTemplate += "</div>";
            litYear.Text = selectedArciveTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            return selectedYear;
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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Strategi_Pengelolaan_Krisis);
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




                //int currentYear = DateTime.Now.Year;
                //selectedArciveTemplate += @" 
                //<div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop"">";
                //foreach (ArchiveFilter _archive in archiveList)
                //{
                //    string _url = (Year > 1900) ? string.Format("presentasi.aspx{0}&tab={1}&ar={2}", PrevUrl, ActiveTab, _archive.Archive) : string.Format("presentasi.aspx{0}&tab={1}&ar={2}", PrevUrl, ActiveTab, _archive.Archive);
                //    selectedArciveTemplate += string.Format(@"
                //        <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, _archive.Display);
                //}
                //selectedArciveTemplate += "</div>";
                //lblFilter.Text = selectedArciveTemplate;

                Int64 selectedCategory = LoadCategory();

                int selectedYear = LoadYear();

                LoadSubCategory(selectedCategory, selectedYear);


            }


        }
    }
}