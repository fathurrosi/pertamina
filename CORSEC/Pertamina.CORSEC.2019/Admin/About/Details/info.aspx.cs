using System;
using System.IO;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.About.Details
{
    public partial class info : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitle.Text = "";
                lblContent.Value = "";
                tbl_Info item = tbl_InfoItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    lblContent.Value = item.body;
                    tbl_File file = tbl_FileItem.GetByReff(ReferenceTable.tbl_Info.ToString(), item.id.ToString());
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
            tbl_Info item = tbl_InfoItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Info();
                item.created = DateTime.Now;
                item.created_by = username;

            }

            item.created = item.created.HasValue ? item.created : DateTime.Now;
            item.body = lblContent.Value;
            item.title = lblTitle.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;

            tbl_Info result = null;
            if (!isEdit)
            {
                result = tbl_InfoItem.Insert(item);
            }
            else
            {
                result = tbl_InfoItem.Update(item);
            }

            if (result != null)
            {
                byte[] fileBinary;
                if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
                {
                    fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                    tbl_File file = tbl_FileItem.GetByReff(ReferenceTable.tbl_Info.ToString(), result.id.ToString());
                    if (file == null)
                    {
                        file = new tbl_File();
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

                    if (string.Format("{0}", file.file_id).Length > 0) tbl_FileItem.Update(file);
                    else
                    {
                        file.file_id = Guid.NewGuid().ToString();
                        file.ref_id = result.id.ToString();
                        file.ref_name = ReferenceTable.tbl_Info.ToString();
                        tbl_FileItem.Insert(file);
                    }
                }

                Response.Redirect(ResolveUrl(string.Format("~/Admin/About/info.aspx{0}", PrevUrl)));
            }
        }
    }
}