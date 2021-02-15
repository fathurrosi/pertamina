using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.CSRSMEPP
{
    public partial class strategi_pengelolaan : CORSECPage
    {
        public int ActiveTab
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["tab"];
                int.TryParse(_id, out id);
                if (id == 0) return 1;
                return id;
            }
        }

        void LoadTab()
        {
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
            List<tbl_CSR_SMEP_Program_Category> tabList = tbl_CSR_SMEP_Program_CategoryItem.GetAll().Where(t => t.Deleted != 1).OrderBy(t => t.Sequence).ToList();
            for (int i = 0; i < tabList.Count; i++)
            {
                tbl_CSR_SMEP_Program_Category tabItem = tabList[i];
                string _url = string.Format("strategi-pengelolaan.aspx{0}&tab={1}", PrevUrl, tabItem.id);

                if (tabItem.id == tab) { sb.AppendFormat(templateActive, _url, tabItem.Name); }
                else if (tab <= 0 && i == 0) { sb.AppendFormat(templateActive, _url, tabItem.Name); }
                else
                {
                    sb.AppendFormat(template, _url, tabItem.Name);
                }
            }

            litTab.Text = sb.ToString();

        }

        void LoadData()
        {
            string template = @"

      <h2 class=""pb-2 pt-3"">{0}</h2>
      <div class=""row"">
          <div class=""col-md-12"">
              {1}
          </div>
      </div>
";
            string content = "";
            int tab = ActiveTab;
            List<tbl_CSR_SMEP_Program> list = tbl_CSR_SMEP_ProgramItem.GetDynamicData(tab);
            foreach (tbl_CSR_SMEP_Program item in list)
            {
                content += string.Format(template, item.title, item.body);
            }


            litContent.Text = content;
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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Strategi_Pengelolaan_CSR_SMEPP);
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

                LoadTab();

                LoadData();
            }

        }
    }
}