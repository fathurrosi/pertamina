using System;
using System.IO;
using System.Linq;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Brand
{
    public partial class Brand_Guideline : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ddlTemplateType.DataSource = Utilities.GetDataSource<TemplateType>();
                //ddlTemplateType.DataValueField = "Code";
                //ddlTemplateType.DataTextField = "Text";
                //ddlTemplateType.DataBind();


                tbl_brand_guideline itemCorpotare = tbl_brand_guidelineItem.GetByLogoType((int)LogoType.Logo_Corporate);
                if (itemCorpotare != null)
                {
                    lblNamaLogo.Text = itemCorpotare.logo_name;
                    imgThumnail.ImageUrl = Utilities.ByteToString(itemCorpotare.file_blob);
                }

                tbl_brand_guideline itemHUT= tbl_brand_guidelineItem.GetByLogoType((int)LogoType.Logo_HUT);
                if (itemHUT != null)
                {
                    lblNamaLogoHUT.Text = itemHUT.logo_name;
                    imgThumnailHUT.ImageUrl = Utilities.ByteToString(itemHUT.file_blob);
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_brand_guideline itemCorpotare = tbl_brand_guidelineItem.GetByLogoType((int)LogoType.Logo_Corporate);
            if (itemCorpotare == null)
            {
                isEdit = false;
                itemCorpotare = new tbl_brand_guideline();
                itemCorpotare.created = DateTime.Now;
                itemCorpotare.created_by = username;
            }

            itemCorpotare.logo_name = lblNamaLogo.Text;
            itemCorpotare.logo_type = (int)LogoType.Logo_Corporate;


            byte[] fileBinary;
            if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
            {
                fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                string fileName = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                itemCorpotare.file_blob = fileBinary;
                itemCorpotare.created_by = Utilities.Username;
                itemCorpotare.file_name = fileName;
                itemCorpotare.file_path = fuImportImage.PostedFile.FileName;
                itemCorpotare.created = DateTime.Now;
                itemCorpotare.created_by = username;
                itemCorpotare.file_ext = Path.GetExtension(fileName);
                itemCorpotare.file_type = FileType.Image.ToString();
                itemCorpotare.file_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);
            }

            if (isEdit) itemCorpotare = tbl_brand_guidelineItem.Update(itemCorpotare);
            else itemCorpotare = tbl_brand_guidelineItem.Insert(itemCorpotare);
            if (itemCorpotare != null)
            {
                imgThumnail.ImageUrl = Utilities.ByteToString(itemCorpotare.file_blob);
            }





            tbl_brand_guideline itemHUT = tbl_brand_guidelineItem.GetByLogoType((int)LogoType.Logo_HUT);
            if (itemHUT == null)
            {
                isEdit = false;
                itemHUT = new tbl_brand_guideline();
                itemHUT.created = DateTime.Now;
                itemHUT.created_by = username;
            }

            itemHUT.logo_name = lblNamaLogoHUT.Text;
            itemHUT.logo_type = (int)LogoType.Logo_HUT;


            byte[] fileBinaryHUT;
            if ((fuImportImageHUT.PostedFile != null) && (fuImportImageHUT.PostedFile.ContentLength > 0))
            {
                fileBinaryHUT = Utilities.StreamToBytes(fuImportImageHUT.PostedFile.InputStream);
                string fileName = System.IO.Path.GetFileName(fuImportImageHUT.PostedFile.FileName);
                itemHUT.file_blob = fileBinaryHUT;
                itemHUT.created_by = Utilities.Username;
                itemHUT.file_name = fileName;
                itemHUT.file_path = fuImportImageHUT.PostedFile.FileName;
                itemHUT.created = DateTime.Now;
                itemHUT.created_by = username;
                itemHUT.file_ext = Path.GetExtension(fileName);
                itemHUT.file_type = FileType.Image.ToString();
                itemHUT.file_size = Utilities.FormatSize(fuImportImageHUT.PostedFile.ContentLength);
            }

            if (isEdit) itemHUT = tbl_brand_guidelineItem.Update(itemHUT);
            else itemHUT = tbl_brand_guidelineItem.Insert(itemHUT);
            if (itemHUT != null)
            {
                imgThumnailHUT.ImageUrl = Utilities.ByteToString(itemHUT.file_blob);
            }

            lblMessage.Text = GetSucceedMessage();
            //Response.Redirect(ResolveUrl(string.Format("~/Admin/About/artikel.aspx{0}", PrevUrl)));
            //}
        }
    }
}