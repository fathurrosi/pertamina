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
    public partial class infografis_detail  : CORSECPage
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
                tbl_File_Template templateItem = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Infografis);
                if (templateItem != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (templateItem.file_blob != null)
                    {
                        imageUrl = Business.Utilities.ByteToString(templateItem.file_blob);
                    }

                    lblHeader.Text = string.Format(header_template, imageUrl, item != null ? item.title : "");
                }
                #endregion



                if (item != null)
                {
                    string downloadUrl = ResolveUrl(string.Format("~/DesignGrafisHandler.ashx?id={0}", item.id));
                    lblImages.Text = "";
                    aBack.HRef = ResolveUrl(string.Format("~/DesignGrafis/infografis.aaspx{0}&tab={1}", PrevUrl, item.data_type));
                    string templateImages = @"
<div class=""carousel-item{0}"">
    <img src=""{1}"" class=""center-block h-100"" alt=""..."">
    <div class=""carousel-caption d-none d-md-block"" id=""black-light-caption"">
        <h5>{2} <span class=""pull-right download""><a href=""{4}""><i class=""fa fa-download""></i></a></span></h5>
        {3}
    </div>
</div>
";
                    lblTitle.Text = item.title;
                    List<tbl_Design_Grafis_File> files = tbl_Design_Grafis_FileItem.GetByFK(item.id);
                    for (int i = 0; i < files.Count; i++)
                    {
                        tbl_Design_Grafis_File file = files[i];
                        lblImages.Text += string.Format(templateImages, i == 0 ? " active" : "", file.file_blob == null ? "" : Utilities.ByteToString(file.file_blob), file.title, file.body, downloadUrl);
                    }

                }
            }

        }
    }
}