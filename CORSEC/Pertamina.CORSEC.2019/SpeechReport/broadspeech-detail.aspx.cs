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
    public partial class broadspeech_detail : CORSECPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                #region Template Baru

                string header_template = @"
  <div class=""kt-sc"" style=""background-image:  url('{0}'); "">
      <div class=""kt-container "">
          <div class=""kt-sc__bottom"">
              <h3 class=""kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium"">                        
                  {1}
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

                    lblHeader.Text = string.Format(header_template, imageUrl, "Broad Speech");
                    lblTitle.Text = item.template_title;
                    lblIsi.Text = item.template_desc;
                }
                #endregion


                //tbl_Board_Speech_Presentation_Info item = tbl_Board_Speech_Presentation_InfoItem.GetAll().FirstOrDefault();
                //if (item != null)
                //{
                //    string imageUrl = string.Format(" url('{0}') ", ResolveUrl("~/Content/assets/media/bg/bg-9.jpg"));
                //    tbl_File_Template file = tbl_File_TemplateItem.GetByReff(ReferenceTable.tbl_Board_Speech_Presentation_Info.ToString(), item.id.ToString());
                //    if (file != null)
                //    {
                //        imageUrl = string.Format(" url('data:image/png;base64,{0}') ", Convert.ToBase64String(file.file_blob));
                //    }

                //    lblHeader.Text = string.Format(header_template, imageUrl, "Broad Speech");

                //}
                //#endregion



                tbl_Board_Speech_Presentation contentItem = tbl_Board_Speech_PresentationItem.GetByPK(ItemID);

                if (contentItem != null)
                {
                    lblIsi.Text = contentItem.body;
                    lblTitle.Text = contentItem.title;

                    linkFile.NavigateUrl = "#";

                    tbl_Board_Speech_Presentation_File file_image = tbl_Board_Speech_Presentation_FileItem.GetByReff(ReferenceTable.tbl_Board_Speech_Presentation_Image.ToString(), contentItem.id.ToString());
                    if (file_image != null)
                    {
                        lblImage.Text = string.Format("<div class=\"kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides\" style=\"min-height: 200px; background-image: url('{0}')\"></div>", "data:image/png;base64," + Convert.ToBase64String(file_image.file_blob));
                    }


                    tbl_Board_Speech_Presentation_File file = tbl_Board_Speech_Presentation_FileItem.GetByReff(ReferenceTable.tbl_Board_Speech_Presentation.ToString(), contentItem.id.ToString());
                    if (file != null)
                    {
                        linkFile.NavigateUrl = ResolveUrl(string.Format("~/SpeechReportHandler.ashx?FileID={0}", file.file_id));
                        linkFile.Text = file.file_name;
                        imgFile.ImageUrl = ResolveUrl(string.Format("~/Content/assets/media/files/{0}.svg", file.file_ext.Replace(".", "").ToLower()));
                        if (string.IsNullOrEmpty(file.file_ext))
                        {
                            imgFile.Visible = false;
                        }
                    }


                }

            }
        }
    }
}