using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.ProfilCorsec
{
    public partial class VisiMisiTemplate : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbl_Profile_Template item = tbl_Profile_TemplateItem.GetByType("Visi_Misi");
                if (item != null)
                {
                    lblPage_title.Text = item.header;


                    tbl_File_Template file = tbl_File_TemplateItem.GetByReff(ReferenceTable.tbl_Profile_Template.ToString(), item.id.ToString());
                    if (file != null)
                    {
                        imgThumnail.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(file.file_blob);
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Profile_Template item = tbl_Profile_TemplateItem.GetByType("Visi_Misi");
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Profile_Template();
                item.created = DateTime.Now;
                item.created_by = username;

            }
            item.header = lblPage_title.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;

            tbl_Profile_Template result = null;
            if (!isEdit)
            {
                result = tbl_Profile_TemplateItem.Insert(item);
            }
            else
            {
                result = tbl_Profile_TemplateItem.Update(item);
            }

            if (result != null)
            {
                byte[] fileBinary;
                if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
                {
                    fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                    tbl_File_Template file = tbl_File_TemplateItem.GetByReff(ReferenceTable.tbl_Profile_Template.ToString(), result.id.ToString());
                    if (file == null)
                    {
                        file = new tbl_File_Template();
                    }

                    string fileName = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                    file.file_blob = fileBinary;
                    file.created_by = Utilities.Username;
                    file.file_name = fileName;
                    file.file_path = fuImportImage.PostedFile.FileName;
                    file.created = DateTime.Now;
                    file.created_by = username;
                    file.file_ext = Path.GetExtension(fileName);
                    file.file_type = FileType.Image.ToString();

                    if (string.Format("{0}", file.file_id).Length > 0) tbl_File_TemplateItem.Update(file);
                    else
                    {
                        file.file_id = Guid.NewGuid().ToString();
                        file.ref_id = result.id.ToString();
                        file.ref_name = ReferenceTable.tbl_Profile_Template.ToString();
                        tbl_File_TemplateItem.Insert(file);
                    }

                    file = tbl_File_TemplateItem.GetByReff(ReferenceTable.tbl_Profile_Template.ToString(), result.id.ToString());
                    if (file != null)
                    {
                        imgThumnail.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(file.file_blob);
                    }
                }



                lblMessage.Text = GetSucceedMessage();
            }
        }
    }
}