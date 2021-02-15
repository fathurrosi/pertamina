using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.StakeHolderManagement
{
    public partial class strategic_stake_holder_engagement : System.Web.UI.Page
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
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Strategic_Stake_holder_Engagement);
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

            }
        }
    }
}