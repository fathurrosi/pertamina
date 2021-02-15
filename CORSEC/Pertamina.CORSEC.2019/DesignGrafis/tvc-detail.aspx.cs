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

namespace Pertamina.CORSEC._2019.DesignGrafis
{
    public partial class tvc_detail : CORSECPage
    {
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
                tbl_Design_Grafis item = tbl_Design_GrafisItem.GetByPK(ItemID);
                //tbl_File_Template templateItem = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Pojok_Kreasi);
                tbl_File_Template templateItem = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Infografis);
                if (templateItem != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (templateItem.file_blob != null)
                    {
                        imageUrl = Business.Utilities.ByteToString(templateItem.file_blob);
                    }

                    lblHeader.Text = string.Format(header_template, imageUrl, "Video Pojok Kreasi");
                }
                #endregion



                if (item != null)
                {
                    lblTitle.Text = item.title;
                    List<tbl_Design_Grafis_Video> files = tbl_Design_Grafis_VideoItem.GetByFK(item.id);
                    if (files.Count > 0)
                    {
                        tbl_Design_Grafis_Video file = files.FirstOrDefault();
                        string file_ext = file.file_ext.Replace(".", "");
                        string templateVideo = @"
<video id=""example_video_1"" class=""video-js"" controls="""" preload=""auto"" width=""600"" height=""400"" poster=""{2}""  data-setup=""{{}}"">
    <source src=""{0}"" type=""video/{1}"" />
</video>
";
                        if (file.file_name.Length > 0)
                        {
                            lblImages.Text = string.Format(templateVideo, ResolveUrl(file.file_virtual_path), file_ext, Utilities.ByteToString(item.img_blob));
                        }

                    }


                }
            }

        }
    }
}