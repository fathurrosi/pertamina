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

namespace Pertamina.CORSEC._2019.SpeechReport
{
    public partial class kinerja_sekper : CORSECPage
    {
        public int ActiveTab
        {
            get
            {
                int id = 1;
                string _id = Request.QueryString["tab"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public int Year
        {
            get
            {
                int id = DateTime.Now.Year;
                string _id = Request.QueryString["y"];
                if (int.TryParse(_id, out id))
                    return id;
                else return DateTime.Now.Year;
            }
        }

        //public string Archive
        //{
        //    get
        //    {
        //        return string.Format("{0}", Request.QueryString["ar"]).Length == 0 ? "A" : string.Format("{0}", Request.QueryString["ar"]);
        //        //int id = 0;
        //        //string _id = Request.QueryString["ar"];
        //        //int.TryParse(_id, out id);
        //        //if (id == 0) return 1;
        //        //return id;
        //    }
        //}

        void SetFilter()
        {
            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            int maxYear = DateTime.Now.Year;
            int minYear = maxYear - 5;
            //List<ArchiveFilter> archiveList = GetArchiveList();
            //string selectedArchive = "";
            //if (!string.IsNullOrEmpty(Archive))
            //{
            //    selectedArchive = Archive;
            //    ArchiveFilter selectedArchiveFilter = archiveList.Where(t => t.Archive == selectedArchive).FirstOrDefault();
            //    maxYear = selectedArchiveFilter.Begin;
            //    minYear = selectedArchiveFilter.End;
            //}


            ////<div class=""dropdown-menu"" aria-labelledby=""btnGroupDrop1"">
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive A</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive B</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive C</a>
            ////    <a class=""dropdown-item"" href=""#"">5 Tahun Terakhir & Archive D</a>
            ////</div>


            string selectedArciveTemplate = string.Format(@" 
<button id=""btnGroupDrop"" type=""button"" class=""btn btn-secondary dropdown-toggle"" 
data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
Tahun {0}</button>", Year);

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
            for (int i = 0; i < 5; i++)
            //foreach (ArchiveFilter _archive in archiveList)
            {

                string _url = (Year > 1900) ? string.Format("kinerja-sekper.aspx{0}&tab={1}&y={2}", PrevUrl, ActiveTab, maxYear) : string.Format("kinerja-sekper.aspx{0}&tab={1}&y={2}", PrevUrl, ActiveTab, maxYear);
                selectedArciveTemplate += string.Format(@"
                        <a class=""dropdown-item"" href=""{0}"">Tahun {1}</a>", _url, maxYear);
                maxYear--;
            }
            selectedArciveTemplate += "</div>";
            lblFilter.Text = selectedArciveTemplate;

            // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ filter Archive $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        }


        void SetSelectedTab()
        {
            //tab_Board_Speech.ClientIDMode = ClientIDMode.Static;//1
            //tab_Presentasi_Corporate.ClientIDMode = ClientIDMode.Static;//2
            //tab_Email_Broadcast.ClientIDMode = ClientIDMode.Static;//3
            //tab_Materi_Presentasi.ClientIDMode = ClientIDMode.Static;//4 

            //class="tab-pane active"

            tab_Semester1.HRef = ResolveUrl(string.Format("~/SpeechReport/kinerja-sekper.aspx{0}&tab={1}&y={2}", PrevUrl, (int)KinerjaSekper.Semester1, Year));
            tab_Semester2.HRef = ResolveUrl(string.Format("~/SpeechReport/kinerja-sekper.aspx{0}&tab={1}&y={2}", PrevUrl, (int)KinerjaSekper.Semester2, Year));

            kt_portlet_base_demo_2_3_tab_content.Attributes["class"] = "tab-pane";
            kt_portlet_base_demo_2_2_tab_content.Attributes["class"] = "tab-pane";

            tab_Semester1.Attributes["class"] = "nav-link";
            tab_Semester2.Attributes["class"] = "nav-link";

            if (ActiveTab > 0)
            {
                if (ActiveTab == 1)
                {
                    tab_Semester1.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_3_tab_content.Attributes["class"] = "tab-pane active";
                }
                else if (ActiveTab == 2)
                {
                    tab_Semester2.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_2_tab_content.Attributes["class"] = "tab-pane active";
                }
                else
                {
                    tab_Semester1.Attributes["class"] = "nav-link active";
                    kt_portlet_base_demo_2_3_tab_content.Attributes["class"] = "tab-pane active";
                }
            }
            else
            {
                tab_Semester1.Attributes["class"] = "nav-link active";
                kt_portlet_base_demo_2_3_tab_content.Attributes["class"] = "tab-pane active";
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //                #region Template Info
                //                string header_template = @"
                //  <div class=""kt-sc"" style=""background-image: {0} "">
                //      <div class=""kt-container "">
                //          <div class=""kt-sc__bottom"">
                //              <h3 class=""kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium"">                        
                //                  {1}
                //              </h3>
                //          </div>
                //      </div>
                //  </div>
                //";
                //                tbl_Kinerja_Sekper_Info item = tbl_Kinerja_Sekper_InfoItem.GetAll().FirstOrDefault();
                //                if (item != null)
                //                {
                //                    string imageUrl = string.Format(" url('{0}') ", ResolveUrl("~/Content/assets/media/bg/bg-9.jpg"));
                //                    tbl_File_Template file = tbl_File_TemplateItem.GetByReff(ReferenceTable.tbl_Kinerja_Sekper_Info.ToString(), item.id.ToString());
                //                    if (file != null)
                //                    {
                //                        imageUrl = string.Format(" url('data:image/png;base64,{0}') ", (file.file_blob == null) ? "" : Convert.ToBase64String(file.file_blob));
                //                    }

                //                    lblHeader.Text = string.Format(header_template, imageUrl, item.title);
                //                    lblTittle.Text = item.title;
                //                    lblIsi.Text = item.body;
                //                }
                //                #endregion


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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Materi_Presentasi);
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
                SetSelectedTab();
                SetFilter();

                Dto.Cstm.tbl_Kinerja_Sekper dataItem1 = tbl_Kinerja_SekperItem.GetByTahunSemester(this.Year, (int)Business.Enum.KinerjaSekper.Semester1);
                Dto.Cstm.tbl_Kinerja_Sekper dataItem2 = tbl_Kinerja_SekperItem.GetByTahunSemester(this.Year, (int)Business.Enum.KinerjaSekper.Semester2);
                if (dataItem1 != null)
                {
                    img_semester_1.ImageUrl = Utilities.ByteToString(dataItem1.file_blob);
                }

                if (dataItem2 != null)
                {
                    img_semester_2.ImageUrl = Utilities.ByteToString(dataItem2.file_blob);
                }
            }
        }
    }
}