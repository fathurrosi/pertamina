using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;


namespace Pertamina.CORSEC._2019.Admin.SpeechReport.Details
{
    public partial class MateriPresentasi : AuthorizeAdminPage
    {
        public string Tipe
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
                List<DataItem> listItem = Utilities.GetDataSource<Business.Enum.Speech_Report_Type>();

                ddlTipe.DataTextField = "Text";
                ddlTipe.DataValueField = "Code";
                ddlTipe.DataSource = listItem;
                ddlTipe.DataBind();

                ddlTipe.SelectedValue = Tipe;
                if (listItem.Where(t => string.Format("{0}", t.Code) == Tipe).Count() > 0)
                {
                    ddlTipe.Enabled = false;
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

                tbl_Board_Speech_Presentation item = tbl_Board_Speech_PresentationItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    ddlTahun.SelectedValue = string.Format("{0}", item.data_year);
                    lblContent.Value = item.body;
                    item.title = lblTitle.Text;
                    ddlTipe.SelectedValue = string.Format("{0}", item.data_type);
                    ddlTipe.Enabled = false;

                    tbl_Board_Speech_Presentation_File file = tbl_Board_Speech_Presentation_FileItem.GetByReff(ReferenceTable.tbl_Board_Speech_Presentation.ToString(), item.id.ToString());
                    if (file != null)
                    {
                        fileUploaded.Text = file.file_name;
                        fileUploaded.NavigateUrl = ResolveUrl(string.Format("~/SpeechReportHandler.ashx?FileID={0}", file.file_id));
                    }
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Board_Speech_Presentation item = tbl_Board_Speech_PresentationItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Board_Speech_Presentation();
                item.created = DateTime.Now;
                item.created_by = username;
            }

            //int seq = 0;
            //int.TryParse(lblSeq.Text, out seq);
            int year = DateTime.Now.Year;
            int data_type = (int)Business.Enum.Speech_Report_Type.MateriPresentasi;
            int.TryParse(ddlTipe.SelectedValue, out data_type);
            int.TryParse(ddlTahun.SelectedValue, out year);
            item.title = lblTitle.Text;
            item.data_type = data_type;
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.data_year = year;
            item.body = lblContent.Value;
            tbl_Board_Speech_Presentation result = null;
            if (!isEdit)
            {
                result = tbl_Board_Speech_PresentationItem.Insert(item);
            }
            else
            {
                result = tbl_Board_Speech_PresentationItem.Update(item);
            }

            if (result != null)
            {
                byte[] fileBinary;
                if ((fileUpload.PostedFile != null) && (fileUpload.PostedFile.ContentLength > 0))
                {
                    fileBinary = Utilities.StreamToBytes(fileUpload.PostedFile.InputStream);
                    tbl_Board_Speech_Presentation_File file = tbl_Board_Speech_Presentation_FileItem.GetByReff(ReferenceTable.tbl_Board_Speech_Presentation.ToString(), result.id.ToString());
                    if (file == null)
                    {
                        file = new tbl_Board_Speech_Presentation_File();
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

                    //string fileSize = "";
                    //int ContentLength = fileUpload.PostedFile.ContentLength;
                    //// Allow only files less than 2,100,000 bytes (approximately 2 MB) to be uploaded.
                    //if (ContentLength > 0)
                    //{
                    //    long total = 0;
                    //    if (ContentLength >= 1073741824)
                    //    {
                    //        total = ContentLength / 1073741824;
                    //        fileSize = string.Format("{0} GB", total.ToString("0.00"));
                    //    }
                    //    else if (ContentLength >= 1048576)
                    //    {
                    //        total = ContentLength / 1048576;
                    //        fileSize = string.Format("{0} MB", total.ToString("0.00"));
                    //    }
                    //    else
                    //    {
                    //        total = ContentLength / 1024;
                    //        fileSize = string.Format("{0} KB", total.ToString("0.00"));
                    //    }
                    //}
                    file.file_size = Utilities.FormatSize(fileUpload.PostedFile.ContentLength);

                    if (string.Format("{0}", file.file_id).Length > 0) tbl_Board_Speech_Presentation_FileItem.Update(file);
                    else
                    {
                        file.file_id = Guid.NewGuid().ToString();
                        file.ref_id = result.id.ToString();
                        file.ref_name = ReferenceTable.tbl_Board_Speech_Presentation.ToString();
                        tbl_Board_Speech_Presentation_FileItem.Insert(file);
                    }
                }

                Response.Redirect(ResolveUrl(string.Format("~/Admin/SpeechReport/MateriPresentasi.aspx{0}", PrevUrl)));
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