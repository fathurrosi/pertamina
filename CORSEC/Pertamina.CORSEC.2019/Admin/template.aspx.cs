using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin
{
    public partial class template : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DataItem> list = Utilities.GetDataSource<TemplateType>();
                list.Insert(0, new DataItem("0", "--Pilih Template--"));

                ddlTemplateType.DataSource = list;
                ddlTemplateType.DataValueField = "Code";
                ddlTemplateType.DataTextField = "Text";
                ddlTemplateType.DataBind();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            int templateType = (int)TemplateType.Brand_Guideline;
            int.TryParse(ddlTemplateType.SelectedValue, out templateType);

            tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType(templateType);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_File_Template();
                item.file_id = Guid.NewGuid().ToString();
                item.created = DateTime.Now;
                item.created_by = username;
                item.ref_id = item.file_id;
                item.ref_name = ReferenceTable.tbl_File_Template.ToString();
            }

            item.template_desc = lblContent.Value;
            item.template_header = lblHeader.Text;
            item.template_title = lblTitle.Text;

            item.template_type = templateType;


            byte[] fileBinary;
            if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
            {
                fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                string fileName = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                item.file_blob = fileBinary;
                item.created_by = Utilities.Username;
                item.file_name = fileName;
                item.file_path = fuImportImage.PostedFile.FileName;
                item.created = DateTime.Now;
                item.created_by = username;
                item.file_ext = Path.GetExtension(fileName);
                item.file_type = FileType.Image.ToString();
                item.file_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);
            }

            if (isEdit) item = tbl_File_TemplateItem.Update(item);
            else item = tbl_File_TemplateItem.Insert(item);
            if (item != null)
            {
                imgThumnail.ImageUrl = Utilities.ByteToString(item.file_blob);
            }

            lblMessage.Text = GetSucceedMessage();
            //Response.Redirect(ResolveUrl(string.Format("~/Admin/About/artikel.aspx{0}", PrevUrl)));
            //}
        }

        protected void ddlTemplateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTitle.Text = string.Empty;
            lblHeader.Text = string.Empty;
            lblContent.Value = string.Empty;
            imgThumnail.ImageUrl = ResolveUrl("~/Content/assets/media/users/default.jpg");
            int templateType = (int)TemplateType.Brand_Guideline;
            if (int.TryParse(ddlTemplateType.SelectedValue, out templateType))
            {
                tbl_File_Template item = tbl_File_TemplateItem.GetByTemplateType(templateType);
                if (item != null)
                {
                    //ddlTemplateType.SelectedValue = string.Format("{0}", (int)TemplateType.Brand_Guideline);
                    lblTitle.Text = item.template_title;
                    lblHeader.Text = item.template_header;
                    lblContent.Value = item.template_desc;
                    imgThumnail.ImageUrl = Utilities.ByteToString(item.file_blob);
                }
            }


        }
    }
}