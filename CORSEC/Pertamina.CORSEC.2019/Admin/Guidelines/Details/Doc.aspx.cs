using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Guidelines.Details
{
    public partial class Doc : AuthorizeAdminPage
    {
        public string TipeDokumen
        {
            get
            {
                return string.Format("{0}", Request.QueryString["tp"]);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<tbl_Combo_Detail> result = tbl_Combo_DetailItem.GetByHeader("Tipe_Dokumen");
                //result.Insert(0, new tbl_Combo_Detail() { name = "Jenis Dokumen" });

                ddlTipe_Dokumen.DataTextField = "name";
                ddlTipe_Dokumen.DataValueField = "name";
                ddlTipe_Dokumen.DataSource = result;
                ddlTipe_Dokumen.DataBind();

                ddlTipe_Dokumen.SelectedValue = TipeDokumen;
                if(result.Where( t=> string.Format("{0}", t.id )== TipeDokumen).Count() > 0)
                {
                    ddlTipe_Dokumen.Enabled = false;
                }

                List<DataItem> yearList = new List<DataItem>();
                int yearStart = DateTime.Now.AddYears(-10).Year;
                for (int i = 0; i < 20; i++)
                {
                    yearList.Add(new DataItem(yearStart.ToString(), yearStart.ToString()));
                    yearStart++;
                }

                ddlTahun.DataSource = yearList;
                ddlTahun.DataValueField = "Code";
                ddlTahun.DataTextField = "Text";
                ddlTahun.DataBind();

                ddlTahun.SelectedValue = DateTime.Now.Year.ToString();

                tbl_Guidelines_Doc item = tbl_Guidelines_DocItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.Judul;
                    ddlTahun.SelectedValue = string.Format("{0}", item.Tahun);

                    item.Judul = lblTitle.Text;
                    txtNoDoc.Text = item.No_Dokumen;
                    ddlTipe_Dokumen.SelectedValue = item.Tipe_Dokumen;
                    ddlTipe_Dokumen.Enabled = false;

                    tbl_Guidelines_File file = tbl_Guidelines_FileItem.GetByReff(ReferenceTable.tbl_Guidelines_Doc.ToString(), item.id.ToString());
                    if (file != null)
                    {
                        fileUploaded.Text = file.file_name;
                        fileUploaded.NavigateUrl = ResolveUrl(string.Format("~/GuidelinesFileHandler.ashx?FileID={0}", file.file_id));
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Guidelines_Doc item = tbl_Guidelines_DocItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Guidelines_Doc();
                item.created = DateTime.Now;
                item.created_by = username;
            }

            //int seq = 0;
            //int.TryParse(lblSeq.Text, out seq);
            int year = DateTime.Now.Year;

            int.TryParse(ddlTahun.SelectedValue, out year);
            item.Judul = lblTitle.Text;
            item.No_Dokumen = txtNoDoc.Text;
            item.Tipe_Dokumen = ddlTipe_Dokumen.SelectedValue;            
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.Tahun = year;

            tbl_Guidelines_Doc result = null;
            if (!isEdit)
            {
                result = tbl_Guidelines_DocItem.Insert(item);
            }
            else
            {
                result = tbl_Guidelines_DocItem.Update(item);
            }

            if (result != null)
            {
                byte[] fileBinary;
                if ((fileUpload.PostedFile != null) && (fileUpload.PostedFile.ContentLength > 0))
                {
                    fileBinary = Utilities.StreamToBytes(fileUpload.PostedFile.InputStream);
                    tbl_Guidelines_File file = tbl_Guidelines_FileItem.GetByReff(ReferenceTable.tbl_Guidelines_Doc.ToString(), result.id.ToString());
                    if (file == null)
                    {
                        file = new tbl_Guidelines_File();
                    }

                    string fileName = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName);
                    file.file_blob = fileBinary;
                    file.created_by = Utilities.Username;
                    file.file_name = fileName;
                    file.file_path = fileUpload.PostedFile.FileName;
                    file.created = DateTime.Now;
                    file.created_by = username;
                    file.file_ext = Path.GetExtension(fileName);
                    file.file_type = FileType.Document.ToString();

                    if (string.Format("{0}", file.file_id).Length > 0) tbl_Guidelines_FileItem.Update(file);
                    else
                    {
                        file.file_id = Guid.NewGuid().ToString();
                        file.ref_id = result.id.ToString();
                        file.ref_name = ReferenceTable.tbl_Guidelines_Doc.ToString();
                        tbl_Guidelines_FileItem.Insert(file);
                    }
                }

                Response.Redirect(ResolveUrl(string.Format("~/Admin/Guidelines/Doc.aspx{0}", PrevUrl)));
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //divTipeKalender.Visible = false;
            //if (ddlCategory.SelectedValue == "Kalender")
            //{
            //    divTipeKalender.Visible = true;
            //}
        }
    }
}