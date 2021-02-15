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

namespace Pertamina.CORSEC._2019.Admin.CorporateCommunication.Details
{
    public partial class Korporat : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //List<tbl_CorporateCommunication_Category> catList = tbl_CorporateCommunication_CategoryItem.GetAll();
                //catList.Insert(0, new tbl_CorporateCommunication_Category() { id = 0, Name = "--Please Select--" });
                //ddlKategori.DataSource = catList;
                //ddlKategori.DataValueField = "id";
                //ddlKategori.DataTextField = "Name";
                //ddlKategori.DataBind();

                //List<DataItem> docList = Utilities.GetDataSource<Krisis_Jenis_Documen>();
                //ddlJenisDokumen.DataSource = docList;
                //ddlJenisDokumen.DataValueField = "Code";
                //ddlJenisDokumen.DataTextField = "Text";
                //ddlJenisDokumen.DataBind();



                fileUploaded.Visible = false;
                //btnDelete.Visible = false;
                tbl_CorporateCommunication_Corporate item = tbl_CorporateCommunication_CorporateItem.GetByPK(ItemID);
                if (item != null)
                {
                    //  btnDelete.Visible = true;
                    txtTitle.Text = item.title;
                    txtContent.Value = item.body;
                    //ddlJenisDokumen.SelectedValue = string.Format("{0}", item.Jenis_Documen);
                    

                    //tbl_CorporateCommunication_Sub_Category subItem = tbl_CorporateCommunication_Sub_CategoryItem.GetByPK(item.SubCategory.HasValue ? item.SubCategory.Value : 0);
                    //if (subItem != null)
                    //{
                    //    ddlKategori.SelectedValue = string.Format("{0}", subItem.Category);
                    //    if (subItem.Category.HasValue)
                    //    {
                    //        ddlSubKategori.DataSource = tbl_CorporateCommunication_Sub_CategoryItem.GetByFK(subItem.Category.Value);
                    //        ddlSubKategori.DataValueField = "id";
                    //        ddlSubKategori.DataTextField = "Name";
                    //        ddlSubKategori.DataBind();
                    //        ddlSubKategori.SelectedValue = string.Format("{0}", subItem.id);
                    //    }
                    //}
                    //txtTahun.Text = string.Format("{0}", item.Tahun);

                    fileUploaded.Visible = true;
                    fileUploaded.Text = item.file_name;
                    fileUploaded.NavigateUrl = ResolveUrl(string.Format("~/strategi-komunikasi-korporat-Handler.ashx?id={0}", item.id));
                }
            }
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    tbl_CorporateCommunication_Corporate file = tbl_CorporateCommunication_CorporateItem.GetByPK(ItemID);
        //    if (file != null) tbl_CorporateCommunication_CorporateItem.Delete(file.id);
        //    Response.Redirect(ResolveUrl(string.Format("~/Admin/CorporateCommunication/krisis.aspx{0}&id={1}", PrevUrl, ParentItemID)));
        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            bool newFile = false;
            tbl_CorporateCommunication_Corporate item = tbl_CorporateCommunication_CorporateItem.GetByPK(ItemID);

            if (item == null)
            {
                newFile = true;
                item = new tbl_CorporateCommunication_Corporate();
                item.created = DateTime.Now;
                item.created_by = username;
            }
            else
            {
                item.updated = DateTime.Now;
                item.updated_by = username;
            }


            //int tahun = 0;
            //int.TryParse(txtTahun.Text, out tahun);
            //int subCat = 0;
            //int.TryParse(ddlSubKategori.SelectedValue, out subCat);
            //item.SubCategory = subCat;
            //int jenisDoc = 0;
            //int.TryParse(ddlJenisDokumen.SelectedValue, out jenisDoc);
            //item.Jenis_Documen = jenisDoc;

            //item.Tahun = tahun;

            item.title = txtTitle.Text;
            item.body = txtContent.Value;
            byte[] fileBinary;
            if ((fileUpload.PostedFile != null) && (fileUpload.PostedFile.ContentLength > 0))
            {

                fileBinary = Utilities.StreamToBytes(fileUpload.PostedFile.InputStream);

                string fileName = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName);
                item.file_blob = fileBinary;
                item.file_name = fileName;
                item.file_path = fileUpload.PostedFile.FileName;
                item.file_ext = Path.GetExtension(fileName);
                item.file_type = FileType.Document.ToString();

                item.file_size = Utilities.FormatSize(fileUpload.PostedFile.ContentLength);

            }

            if (!newFile) { tbl_CorporateCommunication_CorporateItem.Update(item); }
            else { tbl_CorporateCommunication_CorporateItem.Insert(item); }
            Response.Redirect(ResolveUrl(string.Format("~/Admin/CorporateCommunication/Korporat.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }

        protected void ddlKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            if (!string.IsNullOrEmpty(ddl.SelectedValue))
            {
                int itemId = 0;
                int.TryParse(ddl.SelectedValue, out itemId);
                //ddlSubKategori.DataSource = tbl_CorporateCommunication_Sub_CategoryItem.GetByFK(itemId);
                //ddlSubKategori.DataValueField = "id";
                //ddlSubKategori.DataTextField = "Name";
                //ddlSubKategori.DataBind();
            }

        }
    }
}