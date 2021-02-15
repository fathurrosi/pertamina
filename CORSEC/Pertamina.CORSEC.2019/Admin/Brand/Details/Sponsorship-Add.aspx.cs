using System;
using System.IO;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Brand.Details
{
    public partial class Sponsorship_Add : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Visible = false;
                tbl_brand_Sponsorship_File item = tbl_brand_Sponsorship_FileItem.GetByPK(ItemID);
                if (item != null)
                {
                    imgThumnail.ImageUrl = Utilities.ByteToString(item.file_blob);
                    btnDelete.Visible = true;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            tbl_brand_Sponsorship_File file = tbl_brand_Sponsorship_FileItem.GetByPK(ItemID);
            if (file != null) tbl_brand_Sponsorship_FileItem.Delete(file.id);
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Details/Sponsorship.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            tbl_brand_Sponsorship item = tbl_brand_SponsorshipItem.GetByPK(ParentItemID);
            if (item != null)
            {
                byte[] fileBinary;
                if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
                {
                    bool newFile = false;
                    fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                    tbl_brand_Sponsorship_File file = tbl_brand_Sponsorship_FileItem.GetByPK(ItemID);
                    if (file == null)
                    {
                        newFile = true;
                        file = new tbl_brand_Sponsorship_File();
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
                    file.sponsorship_id = item.id;
                    file.file_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);
                    file.sponsorship_type = (int)SponsorshipType.Gallery;
                    if (!newFile) { tbl_brand_Sponsorship_FileItem.Update(file); }
                    else { tbl_brand_Sponsorship_FileItem.Insert(file); }
                }
            }
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Details/Sponsorship.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }

    }
}