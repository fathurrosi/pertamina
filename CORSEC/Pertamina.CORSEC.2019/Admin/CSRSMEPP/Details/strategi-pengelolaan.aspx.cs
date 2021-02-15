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

namespace Pertamina.CORSEC._2019.Admin.CSRSMEPP.Details
{
    public partial class strategi_pengelolaan : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<tbl_CSR_SMEP_Program_Related_Document> docList = tbl_CSR_SMEP_Program_Related_DocumentItem.GetAll().OrderBy(t => t.Sequence).ToList();
                docList.Insert(0, new tbl_CSR_SMEP_Program_Related_Document() { id = 0, Name = "--Please Select--" });

                ddlDocument.DataSource = docList;
                ddlDocument.DataValueField = "id";
                ddlDocument.DataTextField = "Name";
                ddlDocument.DataBind();

                var data_typeList = Utilities.GetDataSource<BL_SMEPP_Data_Type>();
                data_typeList.Add(new DataItem("") { Text="--Please Select--" });
                ddldata_type.DataSource = data_typeList;
                ddldata_type.DataValueField = "Code";
                ddldata_type.DataTextField = "Text";
                ddldata_type.DataBind();

                List<tbl_CSR_SMEP_Program_Category> catList = tbl_CSR_SMEP_Program_CategoryItem.GetAll().OrderBy(t => t.Sequence).ToList();
                catList.Insert(0, new tbl_CSR_SMEP_Program_Category() { id = 0, Name = "--Please Select--" });

                ddlKateori.DataSource = catList;
                ddlKateori.DataValueField = "id";
                ddlKateori.DataTextField = "Name";
                ddlKateori.DataBind();


                fileUploaded.Visible = false;
                //btnDelete.Visible = false;
                tbl_CSR_SMEP_Program item = tbl_CSR_SMEP_ProgramItem.GetByPK(ItemID);
                if (item != null)
                {
                    //  btnDelete.Visible = true;
                    txtTitle.Text = item.title;
                    txtContent.Value = item.body;
                    ddldata_type.SelectedValue = string.Format("{0}", item.data_type);
                    ddlDocument.SelectedValue = string.Format("{0}", item.related_document);
                    ddlKateori.SelectedValue = string.Format("{0}", item.category);
                    txtTahun.Text = string.Format("{0}", item.year);

                    fileUploaded.Visible = true;
                    fileUploaded.Text = item.file_name;
                    fileUploaded.NavigateUrl = ResolveUrl(string.Format("~/StrategiPengelolaanKrisisHandler.ashx?id={0}", item.id));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_CSR_SMEP_Program item = tbl_CSR_SMEP_ProgramItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_CSR_SMEP_Program();
                item.created = DateTime.Now;
                item.created_by = username;
                item.year = DateTime.Now.Year;
            }
            else
            {
                int _tahun = 0;
                int.TryParse(txtTahun.Text, out _tahun);
                item.year = _tahun;
            }

            item.created = item.created.HasValue ? item.created : DateTime.Now;
   

            item.title = txtTitle.Text;
            item.body = txtContent.Value;
            int data_type = 0;
            int document = 0;
            int category = 0;
            int.TryParse(ddldata_type.SelectedValue, out data_type);
            int.TryParse(ddlDocument.SelectedValue, out document);
            int.TryParse(ddlKateori.SelectedValue, out category);
            item.data_type = data_type;
            item.related_document= document;
            item.category = category;
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.is_dynamic = 1;
            item.data_type = null;

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


            tbl_CSR_SMEP_Program result = null;
            if (!isEdit)
            {
                result = tbl_CSR_SMEP_ProgramItem.Insert(item);
            }
            else
            {
                result = tbl_CSR_SMEP_ProgramItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/CSRSMEPP/strategi-pengelolaan.aspx{0}", PrevUrl)));
            }
        }
    }
}