using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.CollateralCorporate
{
    public partial class collateral_corporate : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbl_Collateral_Corporate item = tbl_Collateral_CorporateItem.GetAll().FirstOrDefault();
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    lblTitleSub.Text = item.sub_title;
                    lblContent.Value = item.body;
                    tbl_File_Template file = tbl_File_TemplateItem.GetByReff(ReferenceTable.tbl_Collateral_Corporate.ToString(), item.id.ToString());
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
            tbl_Collateral_Corporate item = tbl_Collateral_CorporateItem.GetAll().FirstOrDefault();
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Collateral_Corporate();
                item.created = DateTime.Now;
                item.created_by = username;
            }


            item.body = lblContent.Value;
            item.title = lblTitle.Text;
            item.sub_title = lblTitleSub.Text;

            item.updated = DateTime.Now;
            item.updated_by = username;

            tbl_Collateral_Corporate result = null;
            if (!isEdit)
            {
                result = tbl_Collateral_CorporateItem.Insert(item);
            }
            else
            {
                result = tbl_Collateral_CorporateItem.Update(item);
            }

            if (result != null)
            {
                byte[] fileBinary;
                if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
                {
                    fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                    tbl_File_Template file = tbl_File_TemplateItem.GetByReff(ReferenceTable.tbl_Collateral_Corporate.ToString(), result.id.ToString());
                    if (file == null)
                    {
                        file = new tbl_File_Template();
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

                    if (string.Format("{0}", file.file_id).Length > 0) tbl_File_TemplateItem.Update(file);
                    else
                    {
                        file.file_id = Guid.NewGuid().ToString();
                        file.ref_id = result.id.ToString();
                        file.ref_name = ReferenceTable.tbl_Collateral_Corporate.ToString();
                        tbl_File_TemplateItem.Insert(file);
                    }

                    imgThumnail.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(file.file_blob);
                }

                //Response.Redirect(ResolveUrl(string.Format("~/Admin/About/artikel.aspx{0}", PrevUrl)));
            }
        }
    }
}