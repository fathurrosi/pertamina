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

namespace Pertamina.CORSEC._2019.Admin.DesignGrafis.details
{
    public partial class Media_Add : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Visible = false;
                tbl_Design_Grafis parentItem = tbl_Design_GrafisItem.GetByPK(ParentItemID);
                if (parentItem != null)
                {
                    if (parentItem.data_type  == (int)Design_Grafis_Desain_Type.Stock_Photo)
                    {
                        textContainer.Visible = false;
                    }

                    tbl_Design_Grafis_File item = tbl_Design_Grafis_FileItem.GetByPK(ItemID);
                    if (item != null)
                    {
                        imgThumnail.ImageUrl = Utilities.ByteToString(item.file_blob);
                        lblTitle.Text = item.title;
                        lblContent.Value = item.body;
                        btnDelete.Visible = true;

                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            tbl_Design_Grafis item = tbl_Design_GrafisItem.GetByPK(ParentItemID);
            if (item != null)
            {
                tbl_Design_Grafis_File file = tbl_Design_Grafis_FileItem.GetByPK(ItemID);
                if (file != null) tbl_Design_Grafis_FileItem.Delete(file.id);

                if (item.data_type == (int)Design_Grafis_Desain_Type.Print_Ad)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.data_type  == (int)Design_Grafis_Desain_Type.Banner)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.data_type  == (int)Design_Grafis_Desain_Type.Lainnya)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.data_type  == (int)Design_Grafis_Desain_Type.Stock_Photo)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.data_type  == (int)Design_Grafis_Desain_Type.TVC)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
              
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            tbl_Design_Grafis item = tbl_Design_GrafisItem.GetByPK(ParentItemID);
            if (item != null)
            {
                byte[] fileBinary;
                if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
                {
                    bool newFile = false;
                    fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                    tbl_Design_Grafis_File file = tbl_Design_Grafis_FileItem.GetByPK(ItemID);
                    if (file == null)
                    {
                        newFile = true;
                        file = new tbl_Design_Grafis_File();
                    }

                    if (item.data_type  == (int)Design_Grafis_Desain_Type.TVC)
                    {
                        string fileRealname = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                        string ext = Path.GetExtension(fileRealname);
                        string fileName = string.Format("{0}{1}", Guid.NewGuid().ToString(), ext);

                        string temps = ResolveUrl("~/Files");
                        string virtualLocation = string.Format("~/Files/{0}", fileName);

                        string pathLocation = Server.MapPath("~") + string.Format("Files/{0}", fileName);
                        try
                        {
                            fuImportImage.PostedFile.SaveAs(pathLocation);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex);
                        }

                        file.title = virtualLocation;
                        file.created_by = Utilities.Username;
                        file.file_name = fileRealname;
                        file.body = pathLocation;
                        file.file_path = fuImportImage.PostedFile.FileName;
                        file.created = DateTime.Now;
                        file.created_by = username;
                        file.file_ext = Path.GetExtension(fileName);
                        file.file_type = FileType.Video.ToString();
                        file.design_grafis_id = item.id;
                        file.file_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);
                    }
                    else
                    {
                        string fileName = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                        file.file_blob = fileBinary;
                        file.title = lblTitle.Text;
                        file.body = lblContent.Value;
                        file.created_by = Utilities.Username;
                        file.file_name = fileName;
                        file.file_path = fuImportImage.PostedFile.FileName;
                        file.created = DateTime.Now;
                        file.created_by = username;
                        file.file_ext = Path.GetExtension(fileName);
                        file.file_type = FileType.Image.ToString();
                        file.design_grafis_id = item.id;
                        file.file_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);

                    }


                    if (!newFile) { tbl_Design_Grafis_FileItem.Update(file); }
                    else { tbl_Design_Grafis_FileItem.Insert(file); }
                }

                if (item.data_type == (int)Design_Grafis_Desain_Type.Print_Ad)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.data_type == (int)Design_Grafis_Desain_Type.Banner)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.data_type == (int)Design_Grafis_Desain_Type.Lainnya)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.data_type == (int)Design_Grafis_Desain_Type.Stock_Photo)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.data_type == (int)Design_Grafis_Desain_Type.TVC)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }

            }


        }

    }
}