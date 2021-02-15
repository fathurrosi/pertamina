using System;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;
using System.Linq;
using Pertamina.CORSEC.Business;
using System.Collections.Generic;
using Pertamina.CORSEC.Business.Enum;

namespace Pertamina.CORSEC._2019.ProfilCorsec
{
    public partial class visi_misi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                #region Template

                string header_template = @"
  <div class=""kt-sc"" style=""background-image:  url('{0}') "">
      <div class=""kt-container "">
          <div class=""kt-sc__bottom"">
              <h3 class=""kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium"">                        
                  {1}
              </h3>
          </div>
      </div>
  </div>
";
                tbl_File_Template itemTemplate = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Overview_Visi_Misi);
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

                //tbl_Profile_Template item = tbl_Profile_TemplateItem.GetByType("Visi_Misi");
                //if (item != null)
                //{
                //    string imageUrl = string.Format(" url('{0}') ", ResolveUrl("~/Content/assets/media/bg/bg-9.jpg"));
                //    tbl_File_Template file = tbl_File_TemplateItem.GetByReff(ReferenceTable.tbl_Profile_Template.ToString(), item.id.ToString());
                //    if (file != null)
                //    {
                //        imageUrl = string.Format(" url('data:image/png;base64,{0}') ", Convert.ToBase64String(file.file_blob));
                //    }
                //    lblHeader.Text = string.Format(header_template, imageUrl, item.header);
                //}


                List<tbl_Profile_Visi_Misi> list = tbl_Profile_Visi_MisiItem.GetAll();
                List<string> tabs = list.Select(t => t.tab_text).Distinct().ToList();
                for (int i = 0; i < tabs.Count; i++)
                {
                    string tab = tabs[i];
                    if (i == 0)
                    {
                        tbl_Profile_Visi_Misi _item = list.Where(t => t.tab_text == tab).FirstOrDefault();
                        if (_item != null)
                        {
                            lblTab1.Text = tab;
                            lblContent1.Text = _item.Contents;
                            lblSubtitle1.Text = _item.SubTitle;
                            lblTitle1.Text = _item.Title;

                            lblVisi1.Text = _item.Visi;
                            lblMisi1.Text = _item.Misi;


                            lblVisiContent1.Text = _item.Visi_Content;
                            lblMisiContent1.Text = _item.Misi_Content;
                        }
                    }
                    else
                    {
                        tbl_Profile_Visi_Misi _item = list.Where(t => t.tab_text == tab).FirstOrDefault();
                        if (_item != null)
                        {
                            lblTab2.Text = tab;
                            lblContent2.Text = _item.Contents;
                            lblSubtitle2.Text = _item.SubTitle;
                            lblTitle2.Text = _item.Title;

                            lblVisi2.Text = _item.Visi;
                            lblMisi2.Text = _item.Misi;

                            lblVisiContent2.Text = _item.Visi_Content;
                            lblMisiContent2.Text = _item.Misi_Content;
                        }
                    }
                }

            }
        }
    }
}