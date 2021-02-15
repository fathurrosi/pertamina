using System;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Programs.Details
{
    public partial class Contents : AuthorizeAdminPage
    {
        public Tipe_Program TipeProgram
        {
            get
            {
                try
                {
                    int id = 0;
                    string _id = Request.QueryString["tp"];
                    int.TryParse(_id, out id);
                    Tipe_Program tp = (Tipe_Program)id;

                    return tp;
                }
                catch (Exception)
                {
                    return Tipe_Program.Corporate_Communication;
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProgram.DataTextField = "Text";
                ddlProgram.DataValueField = "Code";
                ddlProgram.DataSource = Utilities.GetDataSource<Tipe_Program>();
                ddlProgram.DataBind();

                if (TipeProgram > 0)
                {
                    ddlProgram.SelectedValue = ((int)TipeProgram).ToString();
                    ddlProgram.Enabled = false;
                }

                //ddlPosition.DataTextField = "Text";
                //ddlPosition.DataValueField = "Code";
                //ddlPosition.DataSource = Utilities.GetDataSource<Image_Position>();
                //ddlPosition.DataBind();

                tbl_Program item = tbl_ProgramItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.title;

                    ddlProgram.SelectedValue = item.prog_type.ToString();
                    //ddlPosition.SelectedValue = item.img_position.ToString();

                    lblContent.Value = item.body;
                    //tbl_File_Program file = tbl_File_ProgramItem.GetByReff(ReferenceTable.tbl_Program.ToString(), item.id.ToString());
                    //if (file != null)
                    //{
                    //    imgThumnail.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(file.file_blob);
                    //}
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Program item = tbl_ProgramItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Program();
                item.created = DateTime.Now;
                item.created_by = username;
            }

            int prog_type = 15;
            int img_position = 1;
            int.TryParse(ddlProgram.SelectedValue, out prog_type);
            //int.TryParse(ddlPosition.SelectedValue, out img_position);

            item.body = lblContent.Value;
            item.prog_type = prog_type;
            item.img_position = img_position;
            item.title = lblTitle.Text;


            item.updated = DateTime.Now;
            item.updated_by = username;

            tbl_Program result = null;
            if (!isEdit)
            {
                result = tbl_ProgramItem.Insert(item);
            }
            else
            {
                result = tbl_ProgramItem.Update(item);
            }

            if (result != null)
            {
                //byte[] fileBinary;
                //if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
                //{
                //    fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                //    tbl_File_Program file = tbl_File_ProgramItem.GetByReff(ReferenceTable.tbl_Program.ToString(), result.id.ToString());
                //    if (file == null)
                //    {
                //        file = new tbl_File_Program();
                //    }

                //    string fileName = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                //    file.file_blob = fileBinary;
                //    file.created_by = Utilities.Username;
                //    file.file_name = fileName;
                //    file.file_path = fuImportImage.PostedFile.FileName;
                //    file.created = DateTime.Now;
                //    file.created_by = username;
                //    file.file_ext = Path.GetExtension(fileName);
                //    file.file_type = FileType.Image.ToString();

                //    if (string.Format("{0}", file.file_id).Length > 0) tbl_File_ProgramItem.Update(file);
                //    else
                //    {
                //        file.file_id = Guid.NewGuid().ToString();
                //        file.ref_id = result.id.ToString();
                //        file.ref_name = ReferenceTable.tbl_Program.ToString();
                //        tbl_File_ProgramItem.Insert(file);
                //    }

                //    file = tbl_File_ProgramItem.GetByReff(ReferenceTable.tbl_Program.ToString(), item.id.ToString());
                //    if (file != null)
                //    {
                //        imgThumnail.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(file.file_blob);
                //    }
                //}



                lblMessage.Text = GetSucceedMessage();
                if (TipeProgram == Tipe_Program.Corporate_Communication)
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Programs/corporate-communication.aspx{0}", PrevUrl)));
                else if (TipeProgram == Tipe_Program.BOD_Support)
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Programs/bod-support.aspx{0}", PrevUrl)));
                else if (TipeProgram == Tipe_Program.CSR_Smepp)
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Programs/csr-smepp.aspx{0}", PrevUrl)));
                else if (TipeProgram == Tipe_Program.Planning_Governance)
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Programs/planning-governance.aspx{0}", PrevUrl)));
                else if (TipeProgram == Tipe_Program.Stakeholder_Relation)
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Programs/stakeholder-relation.aspx{0}", PrevUrl)));
            }
        }
    }
}