using System;
using System.Collections.Generic;
using System.Linq;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.ProfilCorsec
{
    public partial class strategic_partner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                #region Template
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
                tbl_File_Template itemTemplate = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Strategic_Partner);
                if (itemTemplate != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (itemTemplate.file_blob != null)
                    {
                        imageUrl = Utilities.ByteToString(itemTemplate.file_blob);
                    }
                    lblHeader.Text = string.Format(header_template, imageUrl, itemTemplate.template_header);
                }
                #endregion

                //tbl_Profile_Template item = tbl_Profile_TemplateItem.GetByType("Strategic_Partner");
                //if (item != null)
                //{
                //    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                //    tbl_File_Template file = tbl_File_TemplateItem.GetByReff(ReferenceTable.tbl_Profile_Template.ToString(), item.id.ToString());
                //    if (file != null)
                //    {
                //        imageUrl = string.Format(" url('data:image/png;base64,{0}') ", Convert.ToBase64String(file.file_blob));
                //    }
                //    lblHeader.Text = string.Format(header_template, imageUrl, item.header);
                //}

                List<tbl_Profile_Strategic_Partner> list = tbl_Profile_Strategic_PartnerItem.GetAll();
                List<string> tabs = list.Select(t => t.tab_text).Distinct().ToList();
                for (int i = 0; i < tabs.Count; i++)
                {
                    string tab = tabs[i];
                    if (i == 0)
                    {
                        tbl_Profile_Strategic_Partner _item = list.Where(t => t.tab_text == tab).FirstOrDefault();
                        if (_item != null)
                        {
                            lblTab1.Text = tab;
                            lblTitle1.Text = _item.title;
                            lblContent1.Text = _item.body;
                        }
                    }
                    else
                    {
                        tbl_Profile_Strategic_Partner _item = list.Where(t => t.tab_text == tab).FirstOrDefault();
                        if (_item != null)
                        {
                            lblTab2.Text = tab;
                            lblTitle2.Text = _item.title;
                            lblContent2.Text = _item.body;
                        }
                    }
                }

            }
        }
    }
}