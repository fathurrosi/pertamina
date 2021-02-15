using System;
using System.IO;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Brand.Details
{
    public partial class Exhibition_File : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fileUploaded.Visible = false;
                tbl_brand_Exhibition_File item = tbl_brand_Exhibition_FileItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.file_desc;
                    fileUploaded.Visible = true;
                    fileUploaded.Text = item.file_name;
                    fileUploaded.NavigateUrl = ResolveUrl(string.Format("~/ExhibitionFileHandler.ashx?id={0}", item.id));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_brand_Exhibition parent = tbl_brand_ExhibitionItem.GetByPK(ParentItemID);
            if (parent != null)
            {
                bool isEdit = true;
                string username = Utilities.Username;
                tbl_brand_Exhibition_File item = tbl_brand_Exhibition_FileItem.GetByPK(ItemID);
                if (item == null)
                {
                    isEdit = false;
                    item = new tbl_brand_Exhibition_File();
                    item.created = DateTime.Now;
                    item.created_by = username;
                    item.exhibition_id = ParentItemID;
                    item.exhibition_type = (int)ExhibitionType.Materi_Poster;
                }
                
                item.file_desc = lblTitle.Text;
                byte[] fileBinary;
                if ((fileUpload.PostedFile != null) && (fileUpload.PostedFile.ContentLength > 0))
                {
                    fileBinary = Utilities.StreamToBytes(fileUpload.PostedFile.InputStream);
                    if (item == null)
                    {
                        item = new tbl_brand_Exhibition_File();
                    }

                    string fileName = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName);
                    item.file_blob = fileBinary;
                    item.created_by = Utilities.Username;
                    item.file_name = fileName;
                    item.file_path = fileUpload.PostedFile.FileName;
                    item.created = DateTime.Now;
                    item.created_by = username;
                    item.file_ext = Path.GetExtension(fileName);
                    item.file_type = FileType.Document.ToString();
                    item.file_size = Utilities.FormatSize(fileUpload.PostedFile.ContentLength);
                }

                if (!isEdit) { tbl_brand_Exhibition_FileItem.Insert(item); }
                else { tbl_brand_Exhibition_FileItem.Update(item); }

            }

            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Details/Exhibition.aspx{0}&id={1}", PrevUrl, ParentItemID)));
        }

    }
}