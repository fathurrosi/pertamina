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
    public partial class details : CORSECPage
    {
        string GetImagePertahun(int tahun, string category, string tab, List<tbl_Collateral_Corporate_Item> list)
        {
            string result = "";
            //            string template = @"

            // <div class=""carousel-item active"">
            //     <img src=""assets/media/kalender/1.jpg"" class=""center-block h-100"" alt=""..."">
            //     <div class=""carousel-caption d-none d-md-block"" id=""black-light-caption1"">
            //         <h5>First slide label <span class=""pull-right download""><a href=""#""><i
            //             class=""fa fa-download""></i></a></span></h5>
            //         <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
            //     </div>
            // </div>
            // <div class=""carousel-item"">
            //     <img src=""assets/media/kalender/4.jpg"" class=""center-block h-100"" alt=""..."">
            //     <div class=""carousel-caption d-none d-md-block"" id=""black-light-caption2"">
            //         <h5>Second slide label <span class=""pull-right download""><a href=""#""><i
            //             class=""fa fa-download""></i></a></span></h5>
            //         <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
            //     </div>
            // </div>
            // <div class=""carousel-item"">
            //     <img src=""assets/media/kalender/3.jpg"" class=""center-block h-100"" alt=""..."">
            //     <div class=""carousel-caption d-none d-md-block"" id=""black-light-caption3"">
            //         <h5>Third slide label <span class=""pull-right download""><a href=""#""><i
            //             class=""fa fa-download""></i></a></span></h5>
            //         <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
            //     </div>
            // </div>
            // <div class=""carousel-item"">
            //     <img src=""assets/media/products/product2.jpg"" class=""d-block w-100"" alt=""..."">
            //     <div class=""carousel-caption d-none d-md-block"" id=""black-light-caption4"">
            //         <h5>Second slide label <span class=""pull-right download""><a href=""#""><i class=""fa fa-download""></i></a></span>
            //         </h5>
            //         <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
            //     </div>
            // </div>
            //";

            List<tbl_Collateral_Corporate_Item> items = list.Where(t => t.year == tahun && t.category == category && t.calender_type == tab).ToList();
            for (int i = 0; i < items.Count; i++)
            {
                string imageBase64 = "";
                tbl_Collateral_Corporate_Item item = items[i];
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
         <h5>{1} <span class=""pull-right download""><a href=""#""><i class=""fa fa-download""></i></a></span></h5>
         {2}
     </div>
 </div>
", imageBase64, item.title, item.body);
                }
                else
                {
                    result += string.Format(@"
<div class=""carousel-item"">
     <img src=""{0}"" class=""center-block h-100"" alt=""..."">
     <div class=""carousel-caption d-none d-md-block"" id=""black-light-caption"">
         <h5>{1} <span class=""pull-right download""><a href=""#""><i class=""fa fa-download""></i></a></span></h5>
         {2}
     </div>
 </div>
", imageBase64, item.title, item.body);
                }
            }

            return result;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                tbl_Collateral_Corporate_Detail item = tbl_Collateral_Corporate_DetailItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblJudul.Text = item.category;

                    List<tbl_Collateral_Corporate_Item> list = tbl_Collateral_Corporate_ItemItem.GetAll().Where(t => t.category == item.category).ToList();
                    List<int> years = list.Select(t => t.year.Value).OrderBy(t => t).Distinct().ToList();
                    List<string> tabs = list.Select(t => t.calender_type).Distinct().ToList();


                    string template_tabs = @"
  <ul class=""nav nav-pills nav-fill"" role=""tablist"">
     {0}
  </ul>
";
                    string content_tabs = "";
                    for (int i = 0; i < tabs.Count; i++)
                    {
                        string tab = tabs[i];
                        if (i == 0)
                        {
                            content_tabs += string.Format(@"
  <li class=""nav-item"">
          <a class=""nav-link active"" data-toggle=""tab"" href=""#kt_portlet_base_demo_{0}_tab_content""
              role=""tab"" aria-selected=""true"">{1}
          </a>
      </li>
", tab.Replace(" ", "_"), tab);
                        }
                        else
                        {
                            content_tabs += string.Format(@"
  <li class=""nav-item"">
          <a class=""nav-link"" data-toggle=""tab"" href=""#kt_portlet_base_demo_{0}_tab_content""
              role=""tab"" aria-selected=""true"">{1}
          </a>
      </li>
", tab.Replace(" ", "_"), tab);
                        }
                    }

                    lblTabImages.Text = string.Format(template_tabs, content_tabs);




                    string templateTahun = @"
        <div class=""col-md-4"">
            <div class=""kt-widget4"">
                {0}
            </div>
        </div>          
                        ";




                    string groupTahun = "";
                    for (int i = 0; i < years.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            groupTahun += string.Format(@"
<div class=""kt-widget4__item p-2"">
    <a href=""#"" class=""kt-widget4__title kt-widget4__title--light"">Kalender tahun {0}
    </a>
    <span class=""kt-widget3__number kt-font-info"">
        <a href=""#"" class=""btn-label-brand btn btn-sm btn-bold"">Lihat</a>
    </span>
</div>
", years[i]);
                        }
                        else
                        {
                            groupTahun += string.Format(@"
<div class=""kt-widget4__item p-2"">
    <a href=""#"" class=""kt-widget4__title kt-widget4__title--light"">Kalender tahun {0}
    </a>
    <span class=""kt-widget3__number kt-font-info"">
        <a href=""#"" class=""btn-label-brand btn btn-sm btn-bold"">Lihat</a>
    </span>
</div>
", years[i]);
                        }

                    }

                    string group = string.Format(templateTahun, groupTahun);


                    string template_pertab = @"

<div class=""tab-pane active"" id=""kt_portlet_base_demo_2_3_tab_content"" role=""tabpanel"">
    <div class=""row"">
        <div class=""col-md-8"">
            <div id=""SliderCarouselKalender"">
                <div id=""carouselExampleCaptions"" class=""carousel slide"" data-ride=""carousel"">
                    <div class=""carousel-inner"">
                       {0}
                    </div>
                    <a class=""carousel-control-prev"" href=""#carouselExampleCaptions"" role=""button""
                        data-slide=""prev"">
                        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                        <span class=""sr-only"">Previous</span>
                    </a>
                    <a class=""carousel-control-next"" href=""#carouselExampleCaptions"" role=""button""
                        data-slide=""next"">
                        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                        <span class=""sr-only"">Next</span>
                    </a>
                </div>
            </div>
        </div>


      {1}
    </div>
</div>

";

                    string imagepertahun = GetImagePertahun(years.FirstOrDefault(), item.category, tabs.FirstOrDefault(), list);
                    lblImages.Text = string.Format(template_pertab, imagepertahun, group);
                }

            }
        }
    }
}