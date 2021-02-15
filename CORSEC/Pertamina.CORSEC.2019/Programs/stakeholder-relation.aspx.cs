using System;
using System.Collections.Generic;
using System.Web.UI;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto.Cstm;

namespace Pertamina.CORSEC._2019.Programs
{
    public partial class stakeholder_relation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//"background-image: {0}
         //            string leftTemplate = @"

            //<div class=""kt-portlet"">
            //	<div class=""kt-portlet__body"">
            //		<div class=""kt-infobox"">
            //			<div class=""kt-infobox__header"">
            //				<h2 class=""kt-infobox__title"">{0}</h2>
            //			</div>
            //			<div class=""kt-infobox__body"">
            //				<div class=""kt-infobox__section"">
            //					<div class=""kt-infobox__content text-justify"">
            //						<div class=""row"">							
            //							<div class=""col-md-8"">
            //								{1}
            //							</div>
            //                            <div class=""col-md-4"">
            //								<div class=""kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides""
            //									style=""min-height: 200px; background-image: {2}"">
            //								</div>
            //							</div>
            //						</div>

            //					</div>
            //				</div>
            //			</div>
            //		</div>
            //	</div>
            //</div>
            //";

            //            string rightTemplate = @"
            //<div class=""kt-portlet"">
            //	<div class=""kt-portlet__body"">
            //		<div class=""kt-infobox"">
            //			<div class=""kt-infobox__header"">
            //				<h2 class=""kt-infobox__title"">{0}</h2>
            //			</div>
            //			<div class=""kt-infobox__body"">
            //				<div class=""kt-infobox__section"">
            //					<div class=""kt-infobox__content text-justify"">
            //						<div class=""row"">
            //							<div class=""col-md-4"">
            //								<div class=""kt-widget19__pic kt-portlet-fit--top kt-portlet-fit--sides""
            //									style=""min-height: 200px; background-image: {2}"">
            //								</div>
            //							</div>
            //							<div class=""col-md-8"">
            //								{1}
            //							</div>
            //						</div>

            //					</div>
            //				</div>
            //			</div>
            //		</div>
            //	</div>
            //</div>

            //";

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
                List<tbl_Program> list = tbl_ProgramItem.GetByTipeProgram(((int)Business.Enum.Tipe_Program.Stakeholder_Relation).ToString());
                foreach (tbl_Program item in list)
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