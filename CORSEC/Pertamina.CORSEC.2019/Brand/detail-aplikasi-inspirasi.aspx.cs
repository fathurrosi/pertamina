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
    public partial class detail_aplikasi_inspirasi : CORSECPage
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

                    string headerText = "";
                    tbl_brand_guideline_aplikasi_inspirasi aiItem = tbl_brand_guideline_aplikasi_inspirasiItem.GetAll().FirstOrDefault();
                    if (aiItem != null)
                    {
                        headerText = aiItem.title;
                    }


                    lblHeader.Text = string.Format(header_template, imageUrl, string.Format("Detil {0}", headerText));
                    //lblTittle.Text = item.template_title;
                    //lblIsi.Text = item.template_desc;
                }
                #endregion


                #region CONTAINT DETAIL 
                string templateDetail = @"

<div class=""kt-infobox__header"">
    <h2 class=""kt-infobox__title"">{0}</h2>
</div>
<div class=""kt-infobox__body"">
    <div class=""kt-infobox__section"">
        <div class=""kt-infobox__content text-justify"">
            <div class=""row"">
                <div class=""col-md-9"">
                    <img src=""{1}"" style=""max-width: 100%; width: 100%;"" />
                </div>
                <div class=""col-md-3"">
                    {2}
                </div>
            </div>
        </div>
    </div>
</div>
";
                string templateDetailNoImage = @"

<div class=""kt-infobox__header"">
    <h2 class=""kt-infobox__title"">{0}</h2>
</div>
<div class=""kt-infobox__body"">
    <div class=""kt-infobox__section"">
        <div class=""kt-infobox__content text-justify"">
            <div class=""row"">                
                <div class=""col-md-12"">
                    {1}
                </div>
            </div>
        </div>
    </div>
</div>
";
                tbl_brand_guideline_aplikasi_inspirasi_detail detailItem = tbl_brand_guideline_aplikasi_inspirasi_detailItem.GetByPK(ItemID);
                if (detailItem != null)
                {
                    if (detailItem.image_blob != null)
                    {
                        string imageUrl = Utilities.ByteToString(detailItem.image_blob);
                        lblDetail.Text = string.Format(templateDetail, detailItem.title, imageUrl, detailItem.body);
                    }
                    else
                    {
                        string imageUrl = Utilities.ByteToString(detailItem.image_blob);
                        lblDetail.Text = string.Format(templateDetailNoImage, detailItem.title, detailItem.body);
                    }
                }
                #endregion
            }
        }
    }
}