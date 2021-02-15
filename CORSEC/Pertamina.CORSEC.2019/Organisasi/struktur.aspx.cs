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

namespace Pertamina.CORSEC._2019.Organisasi
{
    public partial class struktur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string header_template = @"
  <div class=""kt-sc"" style=""background-image: url('{0}') "">
      <div class=""kt-container "">
          <div class=""kt-sc__bottom"">
              <h3 class=""kt-sc__heading kt-heading kt-heading--center kt-heading--xxl kt-heading--medium"">                        
                  {1}
              </h3>
          </div>
      </div>
  </div>
";
                tbl_File_Template itemTemplate = tbl_File_TemplateItem.GetByTemplateType((int)TemplateType.Struktur_Organisasi);
                if (itemTemplate != null)
                {
                    string imageUrl = ResolveUrl("~/Content/assets/media/bg/bg-9.jpg");
                    if (itemTemplate.file_blob != null)
                    {
                        imageUrl = Business.Utilities.ByteToString(itemTemplate.file_blob);
                    }
                    lblHeader.Text = string.Format(header_template, imageUrl, itemTemplate.template_header);
                    //lblTitle.Text = itemTemplate.template_title;
                    //lblIsi.Text = itemTemplate.template_desc;
                }

                //tbl_Struktur_Organisasi item = tbl_Struktur_OrganisasiItem.GetAll().FirstOrDefault();
                //if (item != null)
                //{
                //    string imageUrl = string.Format(" url('{0}') ", ResolveUrl("~/Content/assets/media/bg/bg-9.jpg"));
                //    tbl_File file = tbl_FileItem.GetByReff(ReferenceTable.tbl_Struktur_Organisasi.ToString(), item.id.ToString());
                //    if (file != null)
                //    {
                //        imageUrl = string.Format(" url('data:image/png;base64,{0}') ", Convert.ToBase64String(file.file_blob));
                //    }

                //    lblHeader.Text = string.Format(header_template, imageUrl, item.title);
                //    //lblTittleSub.Text = item.sub_title;
                //    //lblIsi.Text = item.body;
                //    //lblRoot.Text = item.root_text;
                //}

                lblorganization_Corsec.Text = GetStructureCorsec();
                lblorganization_Corcom.Text = GetStructureCorcom();
            }
        }


        string GetChildrenCorsec(int id, List<tbl_Struktur_Organisasi_Diagram_Corsec> structureList, List<tbl_Struktur_Organisasi_Anggota> memberList, List<tbl_Struktur_Organisasi_Jabatan> positionList)
        {
            string result = "";


            string template_parent = @"
<ul>
    {0}
</ul>
";


            string template_child_member = @"
 
     <div class=""row"">
         <div class=""col-md-5"">
             <!--begin::Accordion-->
             <div class=""accordion accordion-solid accordion-toggle-plus"" id=""accordionExample{0}"">
                 <div class=""card"">
                     <div class=""card-header"" id=""headingOne{0}"">
                         <div class=""card-title collapsed"" data-toggle=""collapse"" data-target=""#collapseOne{0}"" aria-expanded=""false"" aria-controls=""collapseOne{0}"">
                             <span class=""tree_label""></span>{1}
                         </div>
                     </div>
                     <div id=""collapseOne{0}"" class=""collapse"" aria-labelledby=""headingOne{0}"" data-parent=""#accordionExample{0}"" style="""">
                         <div class=""card-body"">
                             <div class=""kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur"">
                                 <div class=""kt-portlet__body m-0 p-0"">
                                     <div class=""kt-callout__body"">
                                         <div class=""kt-callout__content"">
                                             <h3 class=""text-right kt-font-bolder"">{2} <br /> <small>{3}</small> </h3>
                                             <span class=""text-left""><i class=""fa fa-phone""></i>{4}</span><br />
                                             <span class=""text-left""><i class=""flaticon2-new-email""></i>{5}</span>
                                         </div>
                                     </div>
                                 </div>
                             </div>
                         </div>
                     </div>
                 </div>
             </div>
             <!--end::Accordion-->
         </div>
         <!-- end 6th row -->
     </div>
 
";

            string templete_grand_child_member = @"

 <input type=""checkbox"" id=""c{0}"" />
    <div class=""row"">
        <div class=""col-md-5"">
            <!--begin::Accordion-->
            <div class=""accordion accordion-solid accordion-toggle-plus"" id=""accordionExample{0}"">
                <div class=""card"">
                    <div class=""card-header"" id=""headingOne{0}"">
                        <div class=""card-title collapsed"" data-toggle=""collapse"" data-target=""#collapseOne{0}"" aria-expanded=""false"" aria-controls=""collapseOne{0}"">
                            <label class=""tree_label"" for=""c{0}""></label>
                            {1}
                        </div>
                    </div>
                    <div id=""collapseOne{0}"" class=""collapse"" aria-labelledby=""headingOne{0}"" data-parent=""#accordionExample{0}"" style="""">
                        <div class=""card-body"">
                            <div class=""kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur bg-struktur"">
                                <div class=""kt-portlet__body m-0 p-0"">
                                    <div class=""kt-callout__body"">
                                        <div class=""kt-callout__content"">
                                            <h3 class=""text-right kt-font-bolder"">{2} <br /> <small>{3}</small></h3>
                                            <span class=""text-left""><i class=""fa fa-phone""></i>{4}</span><br />
                                            <span class=""text-left""><i class=""flaticon2-new-email""></i>{5}</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--end::Accordion-->
        </div>
        <!-- end 6th row -->
    </div>    
";

            string parent_with_member = "<li>";


            //gel all children
            List<tbl_Struktur_Organisasi_Diagram_Corsec> childrenList = structureList.Where(t => t.parent_id == id).ToList();

            foreach (tbl_Struktur_Organisasi_Diagram_Corsec child in childrenList)
            {

                tbl_Struktur_Organisasi_Jabatan jabatan = positionList.Where(t => t.id == child.jabatan_id).FirstOrDefault();
                tbl_Struktur_Organisasi_Anggota anggota = memberList.Where(t => t.jabatan_id == jabatan.id).FirstOrDefault();
                if (anggota == null) anggota = new tbl_Struktur_Organisasi_Anggota();

                string child_with_member = "";
                if (structureList.Where(t => t.parent_id == child.id).Count() <= 0)
                {
                    string member = "<li>";
                    member += string.Format(template_child_member, child.id, jabatan.name, anggota.nama, anggota.nip, anggota.telp, anggota.email);
                    member += "</li>";
                    child_with_member += string.Format("{0}", member);

                }
                else
                {
                    //get child

                    string member = "<li>";
                    member += string.Format(templete_grand_child_member, child.id, jabatan.name, anggota.nama, anggota.nip, anggota.telp, anggota.email);
                    member += GetChildrenCorsec(child.id, structureList, memberList, positionList);
                    member += "</li>";
                    child_with_member += string.Format("{0}", member);
                }

                parent_with_member += child_with_member;
            }

            parent_with_member += "</li>";

            result = string.Format(template_parent, parent_with_member);

            return result;
        }



        string GetChildrenCorcom(int id, List<tbl_Struktur_Organisasi_Diagram_Corcom> structureList, List<tbl_Struktur_Organisasi_Anggota> memberList, List<tbl_Struktur_Organisasi_Jabatan> positionList)
        {
            string result = "";


            string template_parent = @"
<ul>
    {0}
</ul>
";


            string template_child_member = @"
 
     <div class=""row"">
         <div class=""col-md-5"">
             <!--begin::Accordion-->
             <div class=""accordion accordion-solid accordion-toggle-plus"" id=""accordionExample_{0}"">
                 <div class=""card"">
                     <div class=""card-header"" id=""headingOne_{0}"">
                         <div class=""card-title collapsed"" data-toggle=""collapse"" data-target=""#collapseOne_{0}"" aria-expanded=""false"" aria-controls=""collapseOne_{0}"">
                             <span class=""tree_label""></span>{1}
                         </div>
                     </div>
                     <div id=""collapseOne_{0}"" class=""collapse"" aria-labelledby=""headingOne_{0}"" data-parent=""#accordionExample_{0}"" style="""">
                         <div class=""card-body"">
                             <div class=""kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur"">
                                 <div class=""kt-portlet__body m-0 p-0"">
                                     <div class=""kt-callout__body"">
                                         <div class=""kt-callout__content"">
                                             <h3 class=""text-right kt-font-bolder"">{2} <br /> <small>{3}</small> </h3>
                                             <span class=""text-left""><i class=""fa fa-phone""></i>{4}</span><br />
                                             <span class=""text-left""><i class=""flaticon2-new-email""></i>{5}</span>
                                         </div>
                                     </div>
                                 </div>
                             </div>
                         </div>
                     </div>
                 </div>
             </div>
             <!--end::Accordion-->
         </div>
         <!-- end 6th row -->
     </div>
 
";

            string templete_grand_child_member = @"

 <input type=""checkbox"" id=""c_{0}"" />
    <div class=""row"">
        <div class=""col-md-5"">
            <!--begin::Accordion-->
            <div class=""accordion accordion-solid accordion-toggle-plus"" id=""accordionExample_{0}"">
                <div class=""card"">
                    <div class=""card-header"" id=""headingOne_{0}"">
                        <div class=""card-title collapsed"" data-toggle=""collapse"" data-target=""#collapseOne_{0}"" aria-expanded=""false"" aria-controls=""collapseOne_{0}"">
                            <label class=""tree_label"" for=""c_{0}""></label>
                            {1}
                        </div>
                    </div>
                    <div id=""collapseOne_{0}"" class=""collapse"" aria-labelledby=""headingOne_{0}"" data-parent=""#accordionExample_{0}"" style="""">
                        <div class=""card-body"">
                            <div class=""kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur bg-struktur"">
                                <div class=""kt-portlet__body m-0 p-0"">
                                    <div class=""kt-callout__body"">
                                        <div class=""kt-callout__content"">
                                            <h3 class=""text-right kt-font-bolder"">{2} <br /> <small>{3}</small></h3>
                                            <span class=""text-left""><i class=""fa fa-phone""></i>{4}</span><br />
                                            <span class=""text-left""><i class=""flaticon2-new-email""></i>{5}</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--end::Accordion-->
        </div>
        <!-- end 6th row -->
    </div>    
";

            string parent_with_member = "<li>";


            //gel all children
            List<tbl_Struktur_Organisasi_Diagram_Corcom> childrenList = structureList.Where(t => t.parent_id == id).ToList();

            foreach (tbl_Struktur_Organisasi_Diagram_Corcom child in childrenList)
            {

                tbl_Struktur_Organisasi_Jabatan jabatan = positionList.Where(t => t.id == child.jabatan_id).FirstOrDefault();
                tbl_Struktur_Organisasi_Anggota anggota = memberList.Where(t => t.jabatan_id == jabatan.id).FirstOrDefault();
                if (anggota == null) anggota = new tbl_Struktur_Organisasi_Anggota();

                string child_with_member = "";
                if (structureList.Where(t => t.parent_id == child.id).Count() <= 0)
                {
                    string member = "<li>";
                    member += string.Format(template_child_member, child.id, jabatan.name, anggota.nama, anggota.nip, anggota.telp, anggota.email);
                    member += "</li>";
                    child_with_member += string.Format("{0}", member);

                }
                else
                {
                    //get child

                    string member = "<li>";
                    member += string.Format(templete_grand_child_member, child.id, jabatan.name, anggota.nama, anggota.nip, anggota.telp, anggota.email);
                    member += GetChildrenCorcom(child.id, structureList, memberList, positionList);
                    member += "</li>";
                    child_with_member += string.Format("{0}", member);
                }

                parent_with_member += child_with_member;
            }

            parent_with_member += "</li>";

            result = string.Format(template_parent, parent_with_member);

            return result;
        }


        string GetStructureCorcom()
        {

            List<tbl_Struktur_Organisasi_Diagram_Corcom> structureList = tbl_Struktur_Organisasi_Diagram_CorcomItem.GetAll();
            List<tbl_Struktur_Organisasi_Anggota> memberList = tbl_Struktur_Organisasi_AnggotaItem.GetAll();
            List<tbl_Struktur_Organisasi_Jabatan> positionList = tbl_Struktur_Organisasi_JabatanItem.GetAll();

            List<tbl_Struktur_Organisasi_Diagram_Corcom> parentList = structureList.Where(t => t.parent_id.Value <= 0).ToList();

            string result = "";
            string template_root = @"
<div class=""organization"">
{0}    
</div>

";

            string template_parent = @"
<ul class=""tree-view"">
<li>
    {0}
	{1}
	</li>
</ul>
";

            string templete__member = @"
 <input type=""checkbox"" id=""c_{0}"" />
    <div class=""row"">
        <div class=""col-md-5"">
            <!--begin::Accordion-->
            <div class=""accordion accordion-solid accordion-toggle-plus"" id=""accordionExample_{0}"">
                <div class=""card"">
                    <div class=""card-header"" id=""headingOne_{0}"">
                        <div class=""card-title collapsed"" data-toggle=""collapse"" data-target=""#collapseOne_{0}"" aria-expanded=""false"" aria-controls=""collapseOne_{0}"">
                            <label class=""tree_label"" for=""c_{0}""></label>
                            {1}
                        </div>
                    </div>
                    <div id=""collapseOne_{0}"" class=""collapse"" aria-labelledby=""headingOne_{0}"" data-parent=""#accordionExample_{0}"" style="""">
                        <div class=""card-body"">
                            <div class=""kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur bg-struktur"">
                                <div class=""kt-portlet__body m-0 p-0"">
                                    <div class=""kt-callout__body"">
                                        <div class=""kt-callout__content"">
                                            <h3 class=""text-right kt-font-bolder"">{2} <br /> <small>{3}</small></h3>
                                            <span class=""text-left""><i class=""fa fa-phone""></i>{4}</span><br />
                                            <span class=""text-left""><i class=""flaticon2-new-email""></i>{5}</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--end::Accordion-->
        </div>
        <!-- end 6th row -->
    </div>
";

            string parent_with_member = "";
            foreach (tbl_Struktur_Organisasi_Diagram_Corcom parentItem in parentList)
            {
                tbl_Struktur_Organisasi_Jabatan jabatan = positionList.Where(t => t.id == parentItem.jabatan_id).FirstOrDefault();
                tbl_Struktur_Organisasi_Anggota anggota = memberList.Where(t => t.jabatan_id == jabatan.id).FirstOrDefault();
                if (anggota == null) anggota = new tbl_Struktur_Organisasi_Anggota();

                string member = string.Format(templete__member, parentItem.id, jabatan.name, anggota.nama, anggota.nip, anggota.telp, anggota.email);

                // has child
                if (structureList.Where(t => t.parent_id == parentItem.id).Count() > 0)
                {
                    //get child
                    string children = GetChildrenCorcom(parentItem.id, structureList, memberList, positionList);
                    parent_with_member += string.Format(template_parent, member, children);
                }
                else
                {
                    parent_with_member += string.Format(template_parent, member, "");
                }
            }
            result = string.Format(template_root, parent_with_member);
            return result;
        }

        string GetStructureCorsec()
        {

            List<tbl_Struktur_Organisasi_Diagram_Corsec> structureList = tbl_Struktur_Organisasi_Diagram_CorsecItem.GetAll();
            List<tbl_Struktur_Organisasi_Anggota> memberList = tbl_Struktur_Organisasi_AnggotaItem.GetAll();
            List<tbl_Struktur_Organisasi_Jabatan> positionList = tbl_Struktur_Organisasi_JabatanItem.GetAll();

            List<tbl_Struktur_Organisasi_Diagram_Corsec> parentList = structureList.Where(t => t.parent_id.Value <= 0).ToList();

            string result = "";
            string template_root = @"
<div class=""organization"">
{0}    
</div>

";

            string template_parent = @"
<ul class=""tree-view"">
<li>
    {0}
	{1}
	</li>
</ul>
";

            string templete__member = @"
 <input type=""checkbox"" id=""c{0}"" />
    <div class=""row"">
        <div class=""col-md-5"">
            <!--begin::Accordion-->
            <div class=""accordion accordion-solid accordion-toggle-plus"" id=""accordionExample{0}"">
                <div class=""card"">
                    <div class=""card-header"" id=""headingOne{0}"">
                        <div class=""card-title collapsed"" data-toggle=""collapse"" data-target=""#collapseOne{0}"" aria-expanded=""false"" aria-controls=""collapseOne{0}"">
                            <label class=""tree_label"" for=""c{0}""></label>
                            {1}
                        </div>
                    </div>
                    <div id=""collapseOne{0}"" class=""collapse"" aria-labelledby=""headingOne{0}"" data-parent=""#accordionExample{0}"" style="""">
                        <div class=""card-body"">
                            <div class=""kt-portlet kt-callout kt-callout--info kt-callout--diagonal-bg bg-struktur bg-struktur"">
                                <div class=""kt-portlet__body m-0 p-0"">
                                    <div class=""kt-callout__body"">
                                        <div class=""kt-callout__content"">
                                            <h3 class=""text-right kt-font-bolder"">{2} <br /> <small>{3}</small></h3>
                                            <span class=""text-left""><i class=""fa fa-phone""></i>{4}</span><br />
                                            <span class=""text-left""><i class=""flaticon2-new-email""></i>{5}</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--end::Accordion-->
        </div>
        <!-- end 6th row -->
    </div>
";

            string parent_with_member = "";
            foreach (tbl_Struktur_Organisasi_Diagram_Corsec parentItem in parentList)
            {
                tbl_Struktur_Organisasi_Jabatan jabatan = positionList.Where(t => t.id == parentItem.jabatan_id).FirstOrDefault();
                tbl_Struktur_Organisasi_Anggota anggota = memberList.Where(t => t.jabatan_id == jabatan.id).FirstOrDefault();
                if (anggota == null) anggota = new tbl_Struktur_Organisasi_Anggota();

                string member = string.Format(templete__member, parentItem.id, jabatan.name, anggota.nama, anggota.nip, anggota.telp, anggota.email);

                // has child
                if (structureList.Where(t => t.parent_id == parentItem.id).Count() > 0)
                {
                    //get child
                    string children = GetChildrenCorsec(parentItem.id, structureList, memberList, positionList);
                    parent_with_member += string.Format(template_parent, member, children);
                }
                else
                {
                    parent_with_member += string.Format(template_parent, member, "");
                }
            }
            result = string.Format(template_root, parent_with_member);
            return result;
        }
    }
}