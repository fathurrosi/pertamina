using System;
using System.IO;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Brand.Details
{
    public partial class CC_File : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fileUploaded.Visible = false;
                btnDelete.Visible = false;
                tbl_brand_Communication_Campaign_user_manual item = tbl_brand_Communication_Campaign_user_manualItem.GetByPK(ItemID);
                if (item != null)
                {
                    if (item.image_blob != null)
                        imgThumnail.ImageUrl = ConvertUrl(item.image_blob);
                    btnDelete.Visible = true;
                    lblTitle.Text = item.title;
                    lblContent.Value = item.body;
                    lblImageDesc.Text = item.image_desc;
                    fileUploaded.Visible = true;
                    fileUploaded.Text = item.file_name;
                    fileUploaded.NavigateUrl = ResolveUrl(string.Format("~/FileCommunicationCampaignHandler.ashx?id={0}", item.id));
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            tbl_brand_Communication_Campaign_user_manual file = tbl_brand_Communication_Campaign_user_manualItem.GetByPK(ItemID);
            if (file != null) tbl_brand_Communication_Campaign_user_manualItem.Delete(file.id);
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Campaign/File.aspx{0}&id={1}", PrevUrl, ParentItemID)));
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            bool newFile = false;
            tbl_brand_Communication_Campaign_user_manual item = tbl_brand_Communication_Campaign_user_manualItem.GetByPK(ItemID);

            if (item == null)
            {
                newFile = true;
                item = new tbl_brand_Communication_Campaign_user_manual();
                item.created = DateTime.Now;
                item.created_by = username;
            }
            else
            {
                item.updated = DateTime.Now;
                item.updated_by = username;
            }

            item.image_desc = lblImageDesc.Text;
            item.logo_type = (int)LogoType.Logo_Corporate;
            item.title = lblTitle.Text;
            item.body = lblContent.Value;
            byte[] fileBinary;
            if ((fileUpload.PostedFile != null) && (fileUpload.PostedFile.ContentLength > 0))
            {

                fileBinary = Utilities.StreamToBytes(fileUpload.PostedFile.InputStream);

                string fileName = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName);
                item.file_blob = fileBinary;
                item.file_name = fileName;
                item.file_path = fileUpload.PostedFile.FileName;
                item.file_ext = Path.GetExtension(fileName);
                item.file_type = FileType.Image.ToString();

                item.file_size = Utilities.FormatSize(fileUpload.PostedFile.ContentLength);

            }


            byte[] imageBinary;
            if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
            {

                imageBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);

                string fileName = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                item.image_blob = imageBinary;
                item.image_name = fileName;
                item.image_path = fuImportImage.PostedFile.FileName;
                item.image_ext = Path.GetExtension(fileName);
                item.image_type = FileType.Image.ToString();
                item.image_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);
            }

            if (!newFile) { tbl_brand_Communication_Campaign_user_manualItem.Update(item); }
            else { tbl_brand_Communication_Campaign_user_manualItem.Insert(item); }
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Campaign/File.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }

    }
}