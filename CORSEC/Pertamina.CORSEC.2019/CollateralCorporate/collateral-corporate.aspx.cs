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

namespace Pertamina.CORSEC._2019.CollateralCorporate
{
    public partial class collateral_corporate : CORSECPage
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


                tbl_File_Template itemTemplate = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Collateral_Corporate);
                if (itemTemplate != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (itemTemplate.file_blob != null)
                    {
                        imageUrl = Business.Utilities.ByteToString(itemTemplate.file_blob);
                    }
                    lblHeader.Text = string.Format(header_template, imageUrl, itemTemplate.template_header);
                    lblTitle.Text = itemTemplate.template_title;
                    lblIsi.Text = itemTemplate.template_desc;
                }
                #endregion


                List<tbl_Collateral_Corporate_Detail> details = tbl_Collateral_Corporate_DetailItem.GetTOP3();

                string template = @"
 <div class=""col-md-4"">
     <div class=""kt-portlet kt-portlet--height-fluid kt-widget19"">
         <div class=""kt-portlet__body kt-portlet__body--fit kt-portlet__body--unfill"">
             <div class=""kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides""
                 style=""min-height: 200px; background-image: {0}"">
                 <h3 class=""kt-widget19__title kt-font-light"">{1}
                 </h3>
                 <div class=""kt-widget19__shadow""></div>
             </div>
         </div>
         <div class=""kt-portlet__body"">
             <div class=""kt-widget19__wrapper"">
                 <div class=""kt-widget19__text"">
                     {2}
                 </div>
             </div>
             <div class=""kt-widget19__action"">
                 <a href=""{3}"" class=""btn btn-sm btn-label-brand btn-bold pull-right"">Lihat...</a>
             </div>
         </div>
     </div>
 </div>
";
                string temps = "";
                foreach (tbl_Collateral_Corporate_Detail detail in details)
                {
                    string imageUrl1 = string.Format(" url('{0}') ", ResolveUrl("~/Content/assets/media/products/product27.jpg"));
                    tbl_File file1 = tbl_FileItem.GetByReff(ReferenceTable.tbl_Collateral_Corporate_Detail.ToString(), detail.id.ToString());
                    if (file1 != null)
                    {
                        imageUrl1 = string.Format(" url('data:image/png;base64,{0}') ", Convert.ToBase64String(file1.file_blob));
                    }

                    string url = ResolveUrl(string.Format("~/CollateralCorporate/kalender.aspx{0}&id={1}", PrevUrl, detail.id));
                    if (detail.category == "Kalender")
                    {
                        url = ResolveUrl(string.Format("~/CollateralCorporate/kalender.aspx{0}&id={1}", PrevUrl, detail.id));
                    }
                    else if (detail.category == "Agenda")
                    {
                        url = ResolveUrl(string.Format("~/CollateralCorporate/agenda.aspx{0}&id={1}", PrevUrl, detail.id));
                    }
                    else if (detail.category == "Kartu Ucapan")
                    {
                        url = ResolveUrl(string.Format("~/CollateralCorporate/kartu.aspx{0}&id={1}", PrevUrl, detail.id));
                    }

                    temps += string.Format(template, imageUrl1, detail.title, detail.body, url);
                }

                lblDetail.Text = temps;
            }

        }
    }
}