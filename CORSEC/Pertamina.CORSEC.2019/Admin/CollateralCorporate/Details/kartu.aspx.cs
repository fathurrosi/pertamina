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

namespace Pertamina.CORSEC._2019.Admin.CollateralCorporate.Details
{
    public partial class kartu : AuthorizeAdminPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ////divTipeKalender.Visible = false;
                //ddlCategory.DataSource = tbl_Combo_DetailItem.GetCollateral_Corporate_Category();
                //ddlCategory.DataValueField = "name";
                //ddlCategory.DataTextField = "name";
                //ddlCategory.DataBind();

                //List<tbl_Combo_Detail> tipeKalender = tbl_Combo_DetailItem.GetTipeKanlender();
                //tipeKalender.Insert(0, new tbl_Combo_Detail() { name = "" });
                //ddlTipeKalender.DataSource = tipeKalender;
                //ddlTipeKalender.DataValueField = "name";
                //ddlTipeKalender.DataTextField = "name";
                //ddlTipeKalender.DataBind();


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

                tbl_Collateral_Corporate_Item item = tbl_Collateral_Corporate_ItemItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    lblSeq.Text = string.Format("{0}", item.seq);
                    lblContent.Value = item.body;
                    ddlTahun.SelectedValue = string.Format("{0}", item.year);
                    tbl_File file = tbl_FileItem.GetByReff(ReferenceTable.tbl_Collateral_Corporate_Item.ToString(), item.id.ToString());
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
            tbl_Collateral_Corporate_Item item = tbl_Collateral_Corporate_ItemItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Collateral_Corporate_Item();
                item.created = DateTime.Now;
                item.created_by = username;
            }

            int seq = 0;
            int.TryParse(lblSeq.Text, out seq);
            int year = DateTime.Now.Year;

            int.TryParse(ddlTahun.SelectedValue, out year);

            item.year = year;
            item.calender_type = "";
            item.body = lblContent.Value;
            item.title = lblTitle.Text;
            item.category = "Kartu Ucapan";
            item.seq = seq;
            item.updated = DateTime.Now;
            item.updated_by = username;

            tbl_Collateral_Corporate_Item result = null;
            if (!isEdit)
            {
                result = tbl_Collateral_Corporate_ItemItem.Insert(item);
            }
            else
            {
                result = tbl_Collateral_Corporate_ItemItem.Update(item);
            }

            if (result != null)
            {
                byte[] fileBinary;
                if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
                {
                    fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                    tbl_File file = tbl_FileItem.GetByReff(ReferenceTable.tbl_Collateral_Corporate_Item.ToString(), result.id.ToString());
                    if (file == null)
                    {
                        file = new tbl_File();
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

                    if (string.Format("{0}", file.file_id).Length > 0) tbl_FileItem.Update(file);
                    else
                    {
                        file.file_id = Guid.NewGuid().ToString();
                        file.ref_id = result.id.ToString();
                        file.ref_name = ReferenceTable.tbl_Collateral_Corporate_Item.ToString();
                        tbl_FileItem.Insert(file);
                    }
                }

                Response.Redirect(ResolveUrl(string.Format("~/Admin/CollateralCorporate/kartu.aspx{0}", PrevUrl)));
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