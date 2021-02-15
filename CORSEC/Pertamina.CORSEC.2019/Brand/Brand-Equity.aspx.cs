using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Brand
{
    public partial class Brand_Equity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emptyTemplate = @"

<div class=""kt-portlet"">
	<div class=""kt-portlet__body"">
		<div class=""kt-infobox"">
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
		</div>
	</div>
</div>
";

            if (!Page.IsPostBack)
            {
                string result = "";
                List<tbl_brand_equity> list = tbl_brand_equityItem.GetAll();
                foreach (tbl_brand_equity item in list)
                {
                    //Business.Enum.Image_Position pos = item.img_position.HasValue ? (Business.Enum.Image_Position)item.img_position.Value : Business.Enum.Image_Position.Left;
                    //if (item.file_blob != null)
                    //{                        
                    //    string imageUrl = string.Format(" url('data:image/png;base64,{0}') ", Convert.ToBase64String(item.file_blob));
                    //    result += string.Format(pos == Business.Enum.Image_Position.Left ? leftTemplate : rightTemplate, item.title, item.body, imageUrl);
                    //}
                    //else
                    //{
                    result += string.Format(emptyTemplate, item.title, item.body);
                    //}
                }

                lblContent.Text = result;

            }
        }
    }
}