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

namespace Pertamina.CORSEC._2019.CollateralCorporate
{
    public partial class kalender : CORSECPage
    {

        string GetImageByFilter(int maxYear, int minYear, int tahun, string category, string tab, List<tbl_Collateral_Corporate_Item> list)
        {

            List<tbl_Collateral_Corporate_Item> items = list.Where(t => t.year == tahun && t.category == category && t.calender_type == tab).ToList();
            List<int> years = items.Select(t => t.year.Value).OrderByDescending(t => t).Distinct().ToList();

            string result = string.Format(@"
<div class=""tab-pane active"" id=""kt_portlet_base_demo_{0}_tab_content"" role=""tabpanel"">
	<div class=""row"">

 <div class=""col-md-8"">
      <div id=""SliderCarouselKalender"">
          <div id=""myCarousel"" class=""carousel slide"" data-ride=""carousel"">
              <div class=""carousel-inner"">
", tab.Replace(" ", "_"));

            for (int i = 0; i < items.Count; i++)
            {
                string imageBase64 = "";
                tbl_Collateral_Corporate_Item item = items[i];
                string downloadUrl = ResolveUrl(string.Format("~/CCFileHandler.ashx?id={0}", item.id));
                tbl_File file = tbl_FileItem.GetByReff(ReferenceTable.tbl_Collateral_Corporate_Item.ToString(), item.id.ToString());
                if (file != null)
                {
                    imageBase64 = "data:image/png;base64," + Convert.ToBase64String(file.file_blob);
                }

                if (i == 0)
                {
                    result += string.Format(@"
                    <div class=""carousel-item active"">
                         <img src=""{0}"" class=""center-block h-100"" alt=""..."">
                         <div class=""carousel-caption d-none d-md-block"" id=""black-light-caption"">                             
                             <h5>{1} <span class=""pull-right download""><a href=""{3}""><i class=""fa fa-download""></i></a></span></h5>
                             {2}
                         </div>
                     </div>
", imageBase64, item.title, item.body, downloadUrl);
                }
                else
                {
                    result += string.Format(@"
                    <div class=""carousel-item"">
                         <img src=""{0}"" class=""center-block h-100"" alt=""..."">
                         <div class=""carousel-caption d-none d-md-block"" id=""black-light-caption"">
                             <h5>{1} <span class=""pull-right download""><a href=""{3}""><i class=""fa fa-download""></i></a></span></h5>
                             {2}
                         </div>
                     </div>
", imageBase64, item.title, item.body, downloadUrl);
                }
            }

            result += @"
			</div>
            <a class=""carousel-control-prev"" href=""#myCarousel"" role=""button"" data-slide=""prev"">
                <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                <span class=""sr-only"">Previous</span>
            </a>
            <a class=""carousel-control-next"" href=""#myCarousel"" role=""button"" data-slide=""next"">
                <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                <span class=""sr-only"">Next</span>
            </a>
        </div>
    </div>
</div>
";



            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& tahun &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            string filterTahun = @"
<div class=""col-md-4"">
    <div class=""kt-widget4"">";
            for (int i = maxYear; i > minYear; i--)
            {
                //string _url = string.Format("kalender.aspx{0}&id={1}&y={2}&ar={3}&tab={4}", PrevUrl, ItemID, years[i], Archive, tab);
                string _url = string.Format("kalender.aspx{0}&id={1}&y={2}&ar={3}&tab={4}", PrevUrl, ItemID, i, Archive, tab);
                if (i % 2 == 0)
                {
                    filterTahun += string.Format(@"
<div class=""kt-widget4__item p-2"">
    <a href=""{1}"" class=""kt-widget4__title kt-widget4__title--light"">Kalender tahun {0}
    </a>
    <span class=""kt-widget3__number kt-font-info"">
        <a href=""{1}"" class=""btn-label-brand btn btn-sm btn-bold"">Lihat</a>
    </span>
</div>
", i, _url);
                }
                else
                {
                    filterTahun += string.Format(@"
<div class=""kt-widget4__item p-2"">
    <a href=""{1}"" class=""kt-widget4__title kt-widget4__title--light"">Kalender tahun {0}
    </a>
    <span class=""kt-widget3__number kt-font-info"">
        <a href=""{1}"" class=""btn-label-brand btn btn-sm btn-bold"">Lihat</a>
    </span>
</div>
", i, _url);
                }

            }

            filterTahun += @"
    </div>
</div>";
            result += filterTahun;
            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& tahun &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&




            //            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& tahun &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            //            string filterTahun = @"
            //<div class=""col-md-4"">
            //    <div class=""kt-widget4"">";
            //            for (int i = 0; i < years.Count; i++)
            //            {
            //                string _url = string.Format("kalender.aspx{0}&id={1}&y={2}&ar={3}&tab={4}", PrevUrl, ItemID, years[i], Archive, tab);
            //                if (i % 2 == 0)
            //                {
            //                    filterTahun += string.Format(@"
            //<div class=""kt-widget4__item p-2"">
            //    <a href=""{1}"" class=""kt-widget4__title kt-widget4__title--light"">Kalender tahun {0}
            //    </a>
            //    <span class=""kt-widget3__number kt-font-info"">
            //        <a href=""{1}"" class=""btn-label-brand btn btn-sm btn-bold"">Lihat</a>
            //    </span>
            //</div>
            //", years[i], _url);
            //                }
            //                else
            //                {
            //                    filterTahun += string.Format(@"
            //<div class=""kt-widget4__item p-2"">
            //    <a href=""{1}"" class=""kt-widget4__title kt-widget4__title--light"">Kalender tahun {0}
            //    </a>
            //    <span class=""kt-widget3__number kt-font-info"">
            //        <a href=""{1}"" class=""btn-label-brand btn btn-sm btn-bold"">Lihat</a>
            //    </span>
            //</div>
            //", years[i], _url);
            //                }

            //            }

            //            filterTahun += @"
            //    </div>
            //</div>";
            //            result += filterTahun;
            //            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& tahun &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            result += @"
    </div>
</div>";

            return result;

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

        protected List<ArchiveFilter> GetArchiveList(int maxYear, int minYear)
        {
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

        public string Tab
        {
            get
            {
                return string.Format("{0}", Request.QueryString["tab"]);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string header_template = @"
  <div class=""kt-sc"" style=""background-image: url('{0}') "">
      <div class=""kt-container "">
          <div class=""kt-sc__bottom"">
              <h3 class=""kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium"">                        
                  {1}
              </h3>
          </div>
      </div>
  </div>
";


            string filterTemplate = @"
<div class=""kt-portlet__head"">
    <div class=""kt-portlet__head-label"">
        <h3>Kalender</h3>
    </div>
    <div class=""kt-portlet__head-toolbar"">
        <b>Urutkan:</b>
        <div class=""btn-group ml-1"" role=""group"" aria-label=""Button group with nested dropdown"">
            <div class=""btn-group"" role=""group"">               
                {0}
                {1}                                          
            </div>
        </div>
    </div>
</div>

";
            if (!IsPostBack)
            {

                #region Template
                string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                tbl_File_Template itemTemplate = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Collateral_Corporate_Kalender);
                if (itemTemplate != null)
                {
                    if (itemTemplate.file_blob != null)
                        imageUrl = Utilities.ByteToString(itemTemplate.file_blob);
                    lblHeader.Text = string.Format(header_template, imageUrl, itemTemplate.template_header);
                }

                #endregion

                tbl_Collateral_Corporate_Detail item = tbl_Collateral_Corporate_DetailItem.GetByPK(ItemID);
                if (item != null)
                {
                    // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
                    List<tbl_Collateral_Corporate_Item> list = tbl_Collateral_Corporate_ItemItem.GetByCategory(item.category);
                    List<int> years = list.Select(t => t.year.Value).OrderByDescending(t => t).Distinct().ToList();
                    List<string> tabs = list.Select(t => t.calender_type).OrderBy(t => t).Distinct().ToList();
                    //hdnMaxYear.Value = string.Format("{0}", years.Max());
                    //hdnMinYear.Value = string.Format("{0}", years.Min());
                    int maxYear = years.Max();
                    int minYear = years.Min();
                    List<ArchiveFilter> archiveList = GetArchiveList(years.Max(), years.Min());
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
     5 Tahun Terakhir & Archive {0}
 </button>
", selectedArchive);

                    int selectedYear = maxYear;
                    if (Year > 0 && Year <= maxYear && Year >= minYear)
                    {
                        selectedYear = Year;
                    }
                    else
                    {
                        selectedYear = maxYear;
                    }

                    string selectedYearTemplate = @"<div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop"">";
                    int currentYear = DateTime.Now.Year;


                    foreach (ArchiveFilter _archive in archiveList)
                    {
                        string _url = (Year > 1900) ? string.Format("Kalender.aspx{0}&id={1}&y={2}&ar={3}", PrevUrl, item.id, selectedYear, _archive.Archive) : string.Format("Kalender.aspx{0}&id={1}&ar={2}", PrevUrl, item.id, _archive.Archive);
                        selectedYearTemplate += string.Format(@"    <a class=""dropdown-item"" href=""{0}"">{1}</a>", _url, _archive.Display);
                    }
                    selectedYearTemplate += "</div>";

                    lblFilter.Text = string.Format(filterTemplate, selectedArciveTemplate, selectedYearTemplate);
                    // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

                    //WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW TAB WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
                    string templateTab = @"
<div class=""kt-portlet__head-toolbar"">
    <ul class=""nav nav-pills nav-fill"" >
        {0}
    </ul>
</div>
";

                    string selectedTab = tabs.FirstOrDefault();
                    if (Tab.Length > 0)
                    {
                        selectedTab = Tab;
                    }

                    string selectedTabTemplate = "";
                    foreach (string _tab in tabs)
                    {
                        string _url = string.Format("kalender.aspx{0}&id={1}&y={2}&ar={3}&tab={4}", PrevUrl, item.id, Year, Archive, _tab);
                        selectedTabTemplate += string.Format(@"   
 <li class=""nav-item"">
     <a class=""{0}"" href=""{1}"" 
         aria-selected=""false"">{2}
     </a>
 </li>
", selectedTab == _tab ? "nav-link active" : "nav-link", _url, _tab);
                    }

                    lblTab.Text = string.Format(templateTab, selectedTabTemplate);
                    //WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW


                    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Data imgage @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                    lblTabImages.Text = GetImageByFilter(maxYear, minYear, selectedYear, item.category, selectedTab, list);
                    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Data imgage @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                }
            }
        }
    }
}