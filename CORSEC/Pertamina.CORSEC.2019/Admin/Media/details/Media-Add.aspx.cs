using System;
using System.IO;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Media.details
{
    public partial class Media_Add : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Visible = false;
                tbl_Media parentItem = tbl_MediaItem.GetByPK(ParentItemID);
                if (parentItem != null)
                {
                    if (parentItem.infographic_type == (int)Infographic_Type.Stock_Photo)
                    {
                        textContainer.Visible = false;
                    }

                    tbl_Media_File item = tbl_Media_FileItem.GetByPK(ItemID);
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
            tbl_Media item = tbl_MediaItem.GetByPK(ParentItemID);
            if (item != null)
            {
                tbl_Media_File file = tbl_Media_FileItem.GetByPK(ItemID);
                if (file != null) tbl_Media_FileItem.Delete(file.id);

                if (item.infographic_type == (int)Infographic_Type.Infografis_corporate)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Infografis-corporate.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.Pertapedia)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Pertapedia.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.Konten_social_media)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Konten-social-media.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.Media_external)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Media-external.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.Print_Ad)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.Stock_Photo)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Stock-Photo.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.TVC)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/TVC.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            tbl_Media item = tbl_MediaItem.GetByPK(ParentItemID);
            if (item != null)
            {
                byte[] fileBinary;
                if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
                {
                    bool newFile = false;
                    fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                    tbl_Media_File file = tbl_Media_FileItem.GetByPK(ItemID);
                    if (file == null)
                    {
                        newFile = true;
                        file = new tbl_Media_File();
                    }

                    if (item.infographic_type == (int)Infographic_Type.TVC)
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
                        file.infographic_id = item.id;
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
                        file.infographic_id = item.id;
                        file.file_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);

                    }


                    if (!newFile) { tbl_Media_FileItem.Update(file); }
                    else { tbl_Media_FileItem.Insert(file); }
                }


                if (item.infographic_type == (int)Infographic_Type.Infografis_corporate)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Infografis-corporate.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.Pertapedia)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Pertapedia.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.Konten_social_media)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Konten-social-media.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.Media_external)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Media-external.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.Print_Ad)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Print-Ad.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.Stock_Photo)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Stock-Photo.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
                else if (item.infographic_type == (int)Infographic_Type.TVC)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/TVC.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }
            }


        }

    }
}