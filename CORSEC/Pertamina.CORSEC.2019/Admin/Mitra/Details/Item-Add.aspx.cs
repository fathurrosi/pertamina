using System;
using System.IO;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Mitra.Details
{
    public partial class Item_Add : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Visible = false;
                tbl_product_File item = tbl_product_FileItem.GetByPK(ItemID);
                if (item != null)
                {
                    imgThumnail.ImageUrl = Utilities.ByteToString(item.file_blob);
                    btnDelete.Visible = true;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Mitra/Details/Item.aspx{0}&id={1}", PrevUrl, ParentItemID)));
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            tbl_product_File file = tbl_product_FileItem.GetByPK(ItemID);
            if (file != null) tbl_product_FileItem.Delete(file.id);
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Mitra/Details/Item.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            tbl_product item = tbl_productItem.GetByPK(ParentItemID);
            if (item != null)
            {
                byte[] fileBinary;
                if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
                {
                    bool newFile = false;
                    fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                    tbl_product_File file = tbl_product_FileItem.GetByPK(ItemID);
                    if (file == null)
                    {
                        newFile = true;
                        file = new tbl_product_File();
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
                    file.product_id = item.id;
                    file.file_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);
                    file.Merchandise_Type = (int)MitraType.Gallery;
                    if (!newFile) { tbl_product_FileItem.Update(file); }
                    else { tbl_product_FileItem.Insert(file); }
                }
            }
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Mitra/Details/Item.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }

    }
}