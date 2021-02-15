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
    public partial class TVC : AuthorizeAdminPage
    {
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            tbl_Media item = tbl_MediaItem.GetByPK(ItemID);
            if (item != null)
            {
                tbl_Media_Video file = tbl_Media_VideoItem.GetByFK(ItemID).FirstOrDefault();
                if (file != null)
                {
                    try
                    {
                        File.Delete(file.file_physical_path);
                        tbl_Media_VideoItem.Delete(file.id);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }


                }
                if (item.infographic_type == (int)Infographic_Type.TVC)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/TVC.aspx{0}&id={1}", PrevUrl, ItemID)));
                }
            }
        }
        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            int _id = 0;
            int.TryParse(lbtn.CommandArgument, out _id);
            tbl_Media_FileItem.Delete(_id);

            Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/TVC.aspx{0}&id={1}", PrevUrl, ItemID)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                videoContainter.Visible = false;
                btnDelete.Visible = false;
                tbl_Design_Grafis item = tbl_Design_GrafisItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    if (item.img_blob != null) imgThumnail.ImageUrl = Utilities.ByteToString(item.img_blob);
                    item.title = lblTitle.Text;

                    lblContent.Value = item.body;
                    lblTahun.Text = string.Format("{0}", item.data_year);

                    List<tbl_Design_Grafis_Video> files = tbl_Design_Grafis_VideoItem.GetByFK(ItemID);

                    if (files.Count > 0)
                    {
                        tbl_Design_Grafis_Video file = files.FirstOrDefault();
                        string file_ext = file.file_ext.Replace(".", "");
                        string templateVideo = @"
<video id=""example_video_1"" class=""video-js"" controls="""" preload=""auto"" width=""540"" height=""264"" poster=""{2}""  data-setup=""{{}}"">
    <source src=""{0}"" type=""video/{1}"" />
</video>
";

                        if (file.file_name.Length > 0)
                        {
                            btnAdd.Text = "Ubah Video";
                            videoContainter.Visible = true;
                            lblVideo.Text = string.Format(templateVideo, ResolveUrl(file.file_virtual_path), file_ext, Utilities.ByteToString(item.img_blob));
                            btnDelete.Visible = true;
                        }
                        else
                        {
                            btnAdd.Text = "Tambah Video";
                        }
                    }
                    else
                    {
                        btnAdd.Text = "Tambah Video";
                    }

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int tahun = DateTime.Now.Year;
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Design_Grafis item = tbl_Design_GrafisItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Design_Grafis();
                item.created = DateTime.Now;
                item.created_by = username;
            }
            else
            {
                item.updated = DateTime.Now;
                item.updated_by = username;
            }

            int.TryParse(lblTahun.Text, out tahun);

            int.TryParse(lblTahun.Text, out tahun);
            if (tahun <= 1900) tahun = DateTime.Now.Year;

            item.title = lblTitle.Text;
            item.body = lblContent.Value;
            item.data_type = (int)Design_Grafis_Desain_Type.TVC;
            item.data_year = tahun;
            //item.body = hdnDuration.Value;
            byte[] fileBinary;
            if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
            {
                fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                string fileName = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                item.img_blob = fileBinary;
                item.img_name = fileName;
                item.img_path = fuImportImage.PostedFile.FileName;
                item.img_ext = Path.GetExtension(fileName);
                item.img_type = FileType.Image.ToString();
                item.img_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);
            }

            tbl_Design_Grafis result = null;
            if (!isEdit)
            {
                result = tbl_Design_GrafisItem.Insert(item);
            }
            else
            {
                result = tbl_Design_GrafisItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Print-Ad.aspx{0}&t={1}", PrevUrl, item.data_type)));
                //Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/TVC.aspx{0}", PrevUrl)));
            }


        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int tahun = DateTime.Now.Year;
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Design_Grafis item = tbl_Design_GrafisItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Design_Grafis();
                item.created = DateTime.Now;
                item.created_by = username;
            }
            else
            {
                item.updated = DateTime.Now;
                item.updated_by = username;
            }

            int.TryParse(lblTahun.Text, out tahun);

            if (tahun <= 1900) tahun = DateTime.Now.Year;

            item.title = lblTitle.Text;
            //item.body = hdnDuration.Value;
            item.data_type = (int)Design_Grafis_Desain_Type.TVC;
            item.data_year = tahun;


            byte[] fileBinary;
            if ((fuImportImage.PostedFile != null) && (fuImportImage.PostedFile.ContentLength > 0))
            {
                fileBinary = Utilities.StreamToBytes(fuImportImage.PostedFile.InputStream);
                string fileName = System.IO.Path.GetFileName(fuImportImage.PostedFile.FileName);
                item.img_blob = fileBinary;
                item.img_name = fileName;
                item.img_path = fuImportImage.PostedFile.FileName;
                item.img_ext = Path.GetExtension(fileName);
                item.img_type = FileType.Image.ToString();
                item.img_size = Utilities.FormatSize(fuImportImage.PostedFile.ContentLength);
            }

            tbl_Design_Grafis result = null;
            if (!isEdit)
            {
                result = tbl_Design_GrafisItem.Insert(item);
            }
            else
            {
                result = tbl_Design_GrafisItem.Update(item);
            }
            if (result != null)
            {
                List<tbl_Design_Grafis_File> files = tbl_Design_Grafis_FileItem.GetByFK(ItemID);
                Int64 _id = 0;
                if (files.Count > 0)
                {
                    _id = files.FirstOrDefault().id;
                }

                if (_id > 0)
                {
                    Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Video-Add.aspx{0}&pid={1}&id={2}", PrevUrl, result.id, _id)));
                }
                else { Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Video-Add.aspx{0}&pid={1}", PrevUrl, result.id))); }
            }

        }

    }
}
