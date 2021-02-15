using System;
using System.IO;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Brand.Details
{
    public partial class Exhibition_Add : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Visible = false;
                tbl_brand_Exhibition_File item = tbl_brand_Exhibition_FileItem.GetByPK(ItemID);
                if (item != null)
                {
                    imgThumnail.ImageUrl = Utilities.ByteToString(item.file_blob);
                    btnDelete.Visible = true;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            tbl_brand_Exhibition_File file = tbl_brand_Exhibition_FileItem.GetByPK(ItemID);
            if (file != null) tbl_brand_Exhibition_FileItem.Delete(file.id);
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Details/Exhibition.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_brand_Exhibition parent  = tbl_brand_ExhibitionItem.GetByPK(ParentItemID);
            if (parent != null)
            {
                string username = Utilities.Username;
                tbl_brand_Exhibition item = tbl_brand_ExhibitionItem.GetByPK(ParentItemID);
                if (item != null)
                {
                    byte[] fileBinary;
                    if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
                    {
                        bool newFile = false;
                        fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                        tbl_brand_Exhibition_File file = tbl_brand_Exhibition_FileItem.GetByPK(ItemID);
                        if (file == null)
                        {
                            newFile = true;
                            file = new tbl_brand_Exhibition_File();
                        }

                        string fileName = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                        file.file_blob = fileBinary;
                        file.file_desc = string.Empty;
                        file.created_by = Utilities.Username;
                        file.file_name = fileName;
                        file.file_path = fuImportImage.PostedFile.FileName;
                        file.created = DateTime.Now;
                        file.created_by = username;
                        file.file_ext = Path.GetExtension(fileName);
                        file.file_type = FileType.Image.ToString();
                        file.exhibition_id = item.id;
                        file.file_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);
                        file.exhibition_type = (int)ExhibitionType.Gallery;
                        if (!newFile) { tbl_brand_Exhibition_FileItem.Update(file); }
                        else { tbl_brand_Exhibition_FileItem.Insert(file); }
                    }
                }
            }
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Details/Exhibition.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }

    }
}