using System;
using System.IO;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;
namespace Pertamina.CORSEC._2019.Admin.Brand.Details
{
    public partial class CC_Logo : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Visible = false;
                tbl_brand_Communication_Campaign_logo item = tbl_brand_Communication_Campaign_logoItem.GetByPK(ItemID);
                if (item != null)
                {
                    imgThumnail.ImageUrl = ConvertUrl(item.file_blob);
                    btnDelete.Visible = true;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            tbl_brand_Communication_Campaign_logo file = tbl_brand_Communication_Campaign_logoItem.GetByPK(ItemID);
            if (file != null) tbl_brand_Communication_Campaign_logoItem.Delete(file.id);
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Communication-Campaign-Logo.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            byte[] fileBinary;
            if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
            {
                bool newFile = false;
                fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                tbl_brand_Communication_Campaign_logo file = tbl_brand_Communication_Campaign_logoItem.GetByPK(ItemID);
                if (file == null)
                {
                    newFile = true;
                    file = new tbl_brand_Communication_Campaign_logo();
                    file.created = DateTime.Now;
                    file.created_by = username;
                }
                else
                {
                    file.updated = DateTime.Now;
                    file.updated_by = username;
                }

                string fileName = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                file.file_blob = fileBinary;
                file.file_name = fileName;
                file.file_path = fuImportImage.PostedFile.FileName;

                file.file_ext = Path.GetExtension(fileName);
                file.file_type = FileType.Image.ToString();
                file.logo_type = (int)LogoType.Logo_Corporate;
                file.file_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);
                if (!newFile) { tbl_brand_Communication_Campaign_logoItem.Update(file); }
                else { tbl_brand_Communication_Campaign_logoItem.Insert(file); }
            }
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Communication-Campaign-Logo.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }

    }
}