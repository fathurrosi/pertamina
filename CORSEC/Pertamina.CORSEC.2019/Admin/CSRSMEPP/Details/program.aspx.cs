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
    public partial class program_kemitraan : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<MonthHelper> monthList = Utilities.GetAllMonth();
                monthList.Insert(0, new MonthHelper(0, "--Please Select--"));
                ddlBulan.DataSource = monthList;
                ddlBulan.DataValueField = "ID";
                ddlBulan.DataTextField = "Name";
                ddlBulan.DataBind();

                List<tbl_CSR_SMEP_Program_Related_Document> docList = tbl_CSR_SMEP_Program_Related_DocumentItem.GetAll().OrderBy(t => t.Sequence).ToList();
                docList.Insert(0, new tbl_CSR_SMEP_Program_Related_Document() { id = 0, Name = "--Please Select--" });

                ddlDocument.DataSource = docList;
                ddlDocument.DataValueField = "id";
                ddlDocument.DataTextField = "Name";
                ddlDocument.DataBind();


                List<DataItem> CSR_SMEP_ProgramType_List = new List<DataItem>();

                List<DataItem> data_type_list = new List<DataItem>();
                if (PageType.ToLower() == "csr")
                {
                    List<DataItem> BL_SMEPP_Data_Type_List = Utilities.GetDataSource<BL_SMEPP_Data_Type>();
                    BL_SMEPP_Data_Type_List.ForEach(t =>
                    {
                        t.Text = string.Format("BL - {0}", t.Text);
                        data_type_list.Add(t);
                    });

                    List<DataItem> CSR_SMEPP_Data_Type_List = Utilities.GetDataSource<CSR_SMEPP_Data_Type>();
                    CSR_SMEPP_Data_Type_List.ForEach(t =>
                    {
                        t.Text = string.Format("CCR - {0}", t.Text);
                        data_type_list.Add(t);
                    });

                    CSR_SMEP_ProgramType_List = Utilities.GetDataSource<CSR_SMEP_ProgramType>().Where(t => t.Code == "3" || t.Code == "4").ToList();
                }

                else
                {
                    List<DataItem> Kemitraan_Data_Type_List = Utilities.GetDataSource<Kemitraan_Data_Type>();
                    Kemitraan_Data_Type_List.ForEach(t =>
                    {
                        t.Text = string.Format("Kemitraan - {0}", t.Text);
                        data_type_list.Add(t);
                    });

                    CSR_SMEP_ProgramType_List = Utilities.GetDataSource<CSR_SMEP_ProgramType>().Where(t => t.Code == "1" || t.Code == "2").ToList();
                }


                data_type_list.Insert(0, new DataItem("") { Text = "--Please Select--" });
                ddldata_type.DataSource = data_type_list;
                ddldata_type.DataValueField = "Code";
                ddldata_type.DataTextField = "Text";
                ddldata_type.DataBind();

                CSR_SMEP_ProgramType_List.Insert(0, new DataItem("") { Text = "--Please Select--" });
                ddlKateori.DataSource = CSR_SMEP_ProgramType_List;
                ddlKateori.DataValueField = "Code";
                ddlKateori.DataTextField = "Text";
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
                    ddlBulan.SelectedValue = string.Format("{0}", item.bulan);
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

            int bulan = 0;
            int.TryParse(ddlBulan.SelectedValue, out bulan);
            item.bulan = bulan;
            item.data_type = data_type;
            item.related_document = document;
            item.category = category;
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.is_dynamic = 0;
            item.data_type = data_type;

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
                Response.Redirect(ResolveUrl(string.Format("~/Admin/CSRSMEPP/program-kemitraan.aspx{0}", PrevUrl)));
            }
        }

        protected void ddlKateori_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabDiv.Visible = true;
            bulanDiv.Visible = true;
            docDiv.Visible = true;
            tahunDiv.Visible = false;
            DropDownList ddl = sender as DropDownList;
            if (!string.IsNullOrEmpty(ddl.SelectedValue))
            {
                List<DataItem> data_type_list = new List<DataItem>();
                List<DataItem> CSR_SMEP_ProgramType_List = Utilities.GetDataSource<CSR_SMEP_ProgramType>();
                List<DataItem> BL_SMEPP_Data_Type_List = Utilities.GetDataSource<BL_SMEPP_Data_Type>();
                List<DataItem> CSR_SMEPP_Data_Type_List = Utilities.GetDataSource<CSR_SMEPP_Data_Type>();
                List<DataItem> Kemitraan_Data_Type_List = Utilities.GetDataSource<Kemitraan_Data_Type>();
                if (ddl.SelectedValue == string.Format("{0}", (int)CSR_SMEP_ProgramType.Pengelolaan_BL))
                {
                    BL_SMEPP_Data_Type_List.ForEach(t =>
                    {
                        t.Text = string.Format("BL - {0}", t.Text);
                        data_type_list.Add(t);
                    });
                }
                else if (ddl.SelectedValue == string.Format("{0}", (int)CSR_SMEP_ProgramType.Pengelolaan_CSR))

                {
                    CSR_SMEPP_Data_Type_List.ForEach(t =>
                    {
                        t.Text = string.Format("CCR - {0}", t.Text);
                        data_type_list.Add(t);
                    });
                }
                else if (ddl.SelectedValue == string.Format("{0}", (int)CSR_SMEP_ProgramType.Program_Kemitraan))
                {

                    Kemitraan_Data_Type_List.ForEach(t =>
                    {
                        t.Text = string.Format("Kemitraan - {0}", t.Text);
                        data_type_list.Add(t);
                    });
                }
                else if (ddl.SelectedValue == string.Format("{0}", (int)CSR_SMEP_ProgramType.Kolektibilitas_PK))
                {
                    data_type_list.Insert(0, new DataItem("") { Text = "--Please Select--" });
                    tabDiv.Visible = false;
                    bulanDiv.Visible = false;
                    tahunDiv.Visible = true;
                    docDiv.Visible = false;
                }



                ddldata_type.DataSource = data_type_list;
                ddldata_type.DataValueField = "Code";
                ddldata_type.DataTextField = "Text";
                ddldata_type.DataBind();
            }
        }
    }
}