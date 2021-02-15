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
    public partial class ks_content : AuthorizeAdminPage
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
                List<DataItem> listItem = Utilities.GetDataSource<Business.Enum.KinerjaSekper>();

                ddlTipe.DataTextField = "Text";
                ddlTipe.DataValueField = "Code";
                ddlTipe.DataSource = listItem;
                ddlTipe.DataBind();

                ddlTipe.SelectedValue = Tipe;
                //if (listItem.Where(t => string.Format("{0}", t.Code) == Tipe).Count() > 0)
                //{
                //    ddlTipe.Enabled = false;
                //}


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

                tbl_Kinerja_Sekper item = tbl_Kinerja_SekperItem.GetByPK(ItemID);
                if (item != null)
                {
                    //lblTitle.Text = item.title;
                    ddlTahun.SelectedValue = string.Format("{0}", item.tahun);
                    //lblContent.Value = item.body;
                    //item.title = lblTitle.Text;
                    ddlTipe.SelectedValue = string.Format("{0}", (int)item.semester);
                    //ddlTipe.Enabled = false;

                    //tbl_Kinerja_Sekper_File file = tbl_Kinerja_Sekper_FileItem.GetByReff(ReferenceTable.tbl_Kinerja_Sekper.ToString(), item.id.ToString());
                    //if (file != null)
                    //{
                    //    fileUploaded.Text = file.file_name;
                    //    fileUploaded.NavigateUrl = ResolveUrl(string.Format("~/SpeechReportHandler.ashx?FileID={0}", file.file_id));
                    //}



                    tbl_Kinerja_Sekper_File file_image = tbl_Kinerja_Sekper_FileItem.GetByReff(ReferenceTable.tbl_Kinerja_Sekper.ToString(), item.id.ToString());
                    if (file_image != null)
                    {
                        imgThumnail.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(file_image.file_blob);
                    }
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Kinerja_Sekper item = tbl_Kinerja_SekperItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Kinerja_Sekper();
                item.created = DateTime.Now;
                item.created_by = username;
            }

            //int seq = 0;
            //int.TryParse(lblSeq.Text, out seq);
            int year = DateTime.Now.Year;
            int data_type = (int)Business.Enum.KinerjaSekper.Semester1;
            int.TryParse(ddlTipe.SelectedValue, out data_type);
            int.TryParse(ddlTahun.SelectedValue, out year);
            //item.title = lblTitle.Text;
            item.semester = data_type;
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.tahun = year;
            //item.body = lblContent.Value;
            tbl_Kinerja_Sekper result = null;
            if (!isEdit)
            {
                result = tbl_Kinerja_SekperItem.Insert(item);
            }
            else
            {
                result = tbl_Kinerja_SekperItem.Update(item);
            }

            if (result != null)
            {
                byte[] fileBinary;
                if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
                {
                    fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                    tbl_Kinerja_Sekper_File file = tbl_Kinerja_Sekper_FileItem.GetByReff(ReferenceTable.tbl_Kinerja_Sekper.ToString(), result.id.ToString());
                    if (file == null)
                    {
                        file = new tbl_Kinerja_Sekper_File();
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

                    file.file_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);

                    if (string.Format("{0}", file.file_id).Length > 0) tbl_Kinerja_Sekper_FileItem.Update(file);
                    else
                    {
                        file.file_id = Guid.NewGuid().ToString();
                        file.ref_id = result.id.ToString();
                        file.ref_name = ReferenceTable.tbl_Kinerja_Sekper.ToString();
                        tbl_Kinerja_Sekper_FileItem.Insert(file);
                    }
                }

                Response.Redirect(ResolveUrl(string.Format("~/Admin/SpeechReport/ks-content.aspx{0}", PrevUrl)));
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