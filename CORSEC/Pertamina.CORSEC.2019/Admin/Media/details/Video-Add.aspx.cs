using System;
using System.IO;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;
using System.Linq;

namespace Pertamina.CORSEC._2019.Admin.Media.details
{
    public partial class Video_Add : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //tbl_Media parentItem = tbl_MediaItem.GetByPK(ParentItemID);
                //if (parentItem != null)
                //{
                //    tbl_Media_Video file = tbl_Media_VideoItem.GetByFK(item.id).FirstOrDefault();
                //    if (item != null)
                //    {
                //    }
                //}
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
                    tbl_Media_Video file = tbl_Media_VideoItem.GetByFK(item.id).FirstOrDefault();
                    if (file == null)
                    {
                        newFile = true;
                        file = new tbl_Media_Video();
                        file.created = DateTime.Now;
                        file.created_by = username;
                    }
                    else
                    {
                        file.updated = DateTime.Now;
                        file.updated_by = username;
                    }

                    if (item.infographic_type == (int)Infographic_Type.TVC)
                    {
                        string fileRealname = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                        string ext = Path.GetExtension(fileRealname);
                        string fileName = string.Format("{0}{1}", Guid.NewGuid().ToString(), ext);
                        string virtualLocation = string.Format("~/Files/{0}", fileName);
                        string pathLocation = string.Format("{0}/{1}", ConfigReader.filePath, fileName);
                        try
                        {
                            fuImportImage.PostedFile.SaveAs(pathLocation);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex);
                        }
                        file.file_duration = lblDurasi.Value;
                        file.file_virtual_path = virtualLocation;
                        file.file_physical_path = pathLocation;
                        file.file_name = fileRealname;
                        file.file_ext = Path.GetExtension(fileName);
                        file.file_type = FileType.Video.ToString();
                        file.infographic_id = item.id;
                        file.file_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);
                    }

                    if (!newFile) { tbl_Media_VideoItem.Update(file); }
                    else { tbl_Media_VideoItem.Insert(file); }

                    Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/TVC.aspx{0}&id={1}", PrevUrl, ParentItemID)));
                }

            }


        }

    }
}