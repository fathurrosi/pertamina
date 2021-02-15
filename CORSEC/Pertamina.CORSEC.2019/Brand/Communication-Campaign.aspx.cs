using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;


namespace Pertamina.CORSEC._2019.Brand
{
    public partial class Communication_Campaign : CORSECPage
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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Communication_Campaign);
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

                #region CONTENT PANDUAN
                string templatePanduan = @"
<div class=""kt-portlet kt-callout"">
    <div class=""kt-portlet__body"">
        <div class=""kt-callout__body"">
            <div class=""kt-callout__content"">
{0}
{1}
            </div>
            {2}
        </div>
    </div>
</div>
                    ";
                string templateContent = @"
                <h3 class=""kt-callout__title"">{0}</h3>
                <p class=""kt-callout__desc text-justify"">
                    {1}
                </p>
";
                string templateDownload = @"
                <span class=""kt-media kt-media--sm"">
                    <img src=""{0}"" class=""float-left mr-2"" alt="" image"">
                    <a href=""{1}"" class=""kt-link kt-font-boldest mt-2"" data-toggle=""kt-tooltip"" data-skin=""dark""
                        data-placement=""right"" title=""Download"">{2}
                    </a>
                </span>
";

                string templateGambar = @"
            <div class=""kt-callout__action"">
                <div class=""thumbnail"">
                    <div class=""media"">
                        <span class=""meta bottom darken"">
                            <p class=""m-0 semibold"">
                                {0}
                            </p>
                        </span>
                        <img src=""{1}"" alt=""Photo"" width=""100%"">
                    </div>
                </div>
            </div>

";
                lblContent.Text = "";
                List<tbl_brand_Communication_Campaign_user_manual> list = tbl_brand_Communication_Campaign_user_manualItem.GetAll();
                foreach (tbl_brand_Communication_Campaign_user_manual _item in list)
                {
                    string content = string.Format(templateContent, _item.title, _item.body);
                    string download = _item.file_blob == null ? "" : string.Format(templateDownload,
                        ResolveUrl(string.Format("~/Content/assets/media/files/{0}.svg", string.Format("{0}", _item.file_ext).Replace(".", "").ToLower())),
                         ResolveUrl(string.Format("~/FileCommunicationCampaignHandler.ashx?id={0}", _item.id)), _item.file_name);
                    string gambar = _item.image_blob == null ? "" : string.Format(templateGambar, _item.image_desc, Utilities.ByteToString(_item.image_blob));
                    lblContent.Text += string.Format(templatePanduan, content, download, gambar);
                }

                #endregion

                #region CONTENT LOGO
                List<tbl_brand_Communication_Campaign_logo> logoList = tbl_brand_Communication_Campaign_logoItem.GetAll();
                string templateLogos = @"
 <div class=""kt-widget4__item p-3"">
     <img class=""kt-mr-10"" src=""{0}"" height=""75"" alt="""">
     <small class=""kt-widget4__number fsize-11 kt-mr-20"">{1}</small>
     <span class=""kt-widget3__number kt-font-info"">
         <a href=""{2}"" class=""btn-label-brand btn btn-sm btn-bold"">Download</a>
     </span>
 </div>
";
                lblLogos.Text = "";
                foreach (tbl_brand_Communication_Campaign_logo _logos in logoList)
                {
                    lblLogos.Text += string.Format(templateLogos, Utilities.ByteToString(_logos.file_blob),
                        string.Format("{0} - {1}", _logos.file_ext.Replace(".", "").ToUpper(), _logos.file_size),
                         ResolveUrl(string.Format("~/LogoCommunicationCampaignHandler.ashx?id={0}", _logos.id)));
                }

                #endregion
                
            }
        }
    }
}