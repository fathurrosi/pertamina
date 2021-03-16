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

namespace Pertamina.CORSEC._2019.Admin.StakeHolderManagement.Details
{
    public partial class stake_holder : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //List<tbl_Stake_Holder_Management_Country> catList = tbl_Stake_Holder_Management_CountryItem.GetAll();
                //catList.Insert(0, new tbl_Stake_Holder_Management_Country() { id = 0, country = "--Please Select--" });
                //ddlcountry.DataSource = catList;
                //ddlcountry.DataValueField = "id";
                //ddlcountry.DataTextField = "country";
                //ddlcountry.DataBind();

                List<DataItem> docList = Utilities.GetDataSource<StakeHolderDatabase_Type>();
                ddldata_type.DataSource = docList;
                ddldata_type.DataValueField = "Code";
                ddldata_type.DataTextField = "Text";
                ddldata_type.DataBind();



                fileUploaded.Visible = false;
                //btnDelete.Visible = false;
                tbl_Stake_Holder_Management_Stake_Holder_Database item = tbl_Stake_Holder_Management_Stake_Holder_DatabaseItem.GetByPK(ItemID);
                if (item != null)
                {
                    //  btnDelete.Visible = true;
                    txtTitle.Text = item.title;
                    txtContent.Value = item.body;
                    ddldata_type.SelectedValue = string.Format("{0}", item.data_type);
                    //ddlcountry.SelectedValue = string.Format("{0}", item.country);

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
            tbl_Stake_Holder_Management_Stake_Holder_Database item = tbl_Stake_Holder_Management_Stake_Holder_DatabaseItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Stake_Holder_Management_Stake_Holder_Database();
                item.created = DateTime.Now;
                item.created_by = username;

            }

            int _tahun = 0;
            int.TryParse(txtTahun.Text, out _tahun);
            item.created = item.created.HasValue ? item.created : DateTime.Now;
            item.year = _tahun;

            item.title = txtTitle.Text;
            item.body = txtContent.Value;
            int data_type = 0;
            //int country = 0;
            int.TryParse(ddldata_type.SelectedValue, out data_type);
            //int.TryParse(ddlcountry.SelectedValue, out country);
            item.data_type = data_type;
            //item.country = country;
            item.updated = DateTime.Now;
            item.updated_by = username;



            if (item.year < 1900)
            {
                lblMessage.Text = GetValidationMessage("Tahun tidak valid. Tahun harus lebih besar dari 1900");
                return;
            }
            else if (string.IsNullOrEmpty(item.title))
            {
                lblMessage.Text = GetValidationMessage("Judul harus diisi");
                return;
            }

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

            tbl_Stake_Holder_Management_Stake_Holder_Database result = null;
            if (!isEdit)
            {
                result = tbl_Stake_Holder_Management_Stake_Holder_DatabaseItem.Insert(item);
            }
            else
            {
                result = tbl_Stake_Holder_Management_Stake_Holder_DatabaseItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/StakeHolderManagement/stake-holder.aspx{0}", PrevUrl)));
            }
        }
    }
}