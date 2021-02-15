using System;
using System.IO;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Brand.Details
{
    public partial class aplikasi_inspirasi : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                tbl_brand_guideline_aplikasi_inspirasi_detail item = tbl_brand_guideline_aplikasi_inspirasi_detailItem.GetByPK(ItemID);
                if (item != null)
                {
                    if (item.image_blob != null)
                        imgThumnail.ImageUrl = ConvertUrl(item.image_blob);
                    lblTitle.Text = item.title;
                    lblContent.Value = item.body;              
                }
            }
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            bool newFile = false;
            tbl_brand_guideline_aplikasi_inspirasi_detail item = tbl_brand_guideline_aplikasi_inspirasi_detailItem.GetByPK(ItemID);

            if (item == null)
            {
                newFile = true;
                item = new tbl_brand_guideline_aplikasi_inspirasi_detail();
                item.created = DateTime.Now;
                item.created_by = username;
            }
            else
            {
                item.updated = DateTime.Now;
                item.updated_by = username;
            }

            item.logo_type = (int)LogoType.Logo_Corporate;
            item.title = lblTitle.Text;
            item.body = lblContent.Value;
         
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

            if (!newFile) { tbl_brand_guideline_aplikasi_inspirasi_detailItem.Update(item); }
            else { tbl_brand_guideline_aplikasi_inspirasi_detailItem.Insert(item); }
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/aplikasi-inspirasi.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }

    }
}