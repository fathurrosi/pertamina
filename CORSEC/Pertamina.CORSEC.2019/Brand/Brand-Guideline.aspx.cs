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

namespace Pertamina.CORSEC._2019.Brand
{
    public partial class Brand_Guideline : CORSECPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Template Baru
                string header_template = @"
  	<div class=""kt-sc"" style=""background-image: url('{0}')"">
		<div class=""kt-container "">

			<div class=""kt-sc__bottom"">
				<h3 class=""kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium"">
					{1}
				</h3>
			</div>
		</div>
	</div>
";
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Brand_Guideline);
                if (item != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (item.file_blob != null)
                    {
                        imageUrl = Business.Utilities.ByteToString(item.file_blob);
                    }


                    lblHeader.Text = string.Format(header_template, imageUrl, item.template_header);
                    lblTittle.Text = item.template_title;
                    lblIsi.Text = item.template_desc;
                }
                #endregion


                string templateCorporate = @"
<a href=""{0}"">
    <div class=""mb-4"">
        <div class=""media"">
            <asp:Image ID=""imgThumnail"" ImageUrl=""{1}"" runat=""server"" alt=""photo"" Width=""100%"" />
        </div>
    </div>
    <h3 class=""kt-iconbox__title"">
        {2}
    </h3>
</a>

";

                tbl_brand_guideline itemCorpotare = tbl_brand_guidelineItem.GetByLogoType((int)LogoType.Logo_Corporate);
                if (itemCorpotare != null)
                {
                    string imageUrl = itemCorpotare.file_blob == null ? "~/Content/assets/media/project-logos/3.png" : Utilities.ByteToString(itemCorpotare.file_blob);
                    lblNamaLogo.Text = itemCorpotare.logo_name;
                    imgThumnail.ImageUrl = imageUrl;

                    string url = string.Format("logo-detail.aspx{0}&tp={1}", PrevUrl, (int)LogoType.Logo_Corporate);
                    //lblCorporate.Text = string.Format(templateCorporate, url, imageUrl, itemCorpotare.logo_name);
                    corporate.HRef = url;
                }

                tbl_brand_guideline itemHUT = tbl_brand_guidelineItem.GetByLogoType((int)LogoType.Logo_HUT);
                if (itemHUT != null)
                {
                    string imageUrl = itemHUT.file_blob == null ? "~/Content/assets/media/project-logos/2.png" : Utilities.ByteToString(itemHUT.file_blob);
                    lblNamaLogoHUT.Text = itemHUT.logo_name;
                    imgThumnailHUT.ImageUrl = imageUrl;


                    string url = string.Format("logo-detail.aspx{0}&tp={1}", PrevUrl, (int)LogoType.Logo_HUT);
                    hut.HRef = url;
                    //lblHUT.Text = string.Format(templateCorporate, url, imageUrl, itemHUT.logo_name);

                }

            }
        }
    }
}