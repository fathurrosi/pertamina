using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Media.details
{
    public partial class Stock_Photo : AuthorizeAdminPage
    {
        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            int _id = 0;
            int.TryParse(lbtn.CommandArgument, out _id);
            tbl_Media_FileItem.Delete(_id);

            Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Stock-Photo.aspx{0}&id={1}", PrevUrl, ItemID)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                tbl_Media item = tbl_MediaItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    if (item.img_blob != null) imgThumnail.ImageUrl = Utilities.ByteToString(item.img_blob);
                    item.title = lblTitle.Text;
                    lblTahun.Text = string.Format("{0}", item.infographic_year);

                    List<tbl_Media_File> files = tbl_Media_FileItem.GetByFK(ItemID);
                    listViewExhibition.DataSource = files;
                    listViewExhibition.DataBind();

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int tahun = DateTime.Now.Year;
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Media item = tbl_MediaItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Media();
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
            item.infographic_type = (int)Infographic_Type.Stock_Photo;
            item.infographic_year = tahun;

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

            tbl_Media result = null;
            if (!isEdit)
            {
                result = tbl_MediaItem.Insert(item);
            }
            else
            {
                result = tbl_MediaItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/pojok-kreasi.aspx{0}", PrevUrl)));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int tahun = DateTime.Now.Year;
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Media item = tbl_MediaItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Media();
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

            item.body = string.Empty;
            item.infographic_type = (int)Infographic_Type.Stock_Photo;
            item.infographic_year = tahun;


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

            tbl_Media result = null;
            if (!isEdit)
            {
                result = tbl_MediaItem.Insert(item);
            }
            else
            {
                result = tbl_MediaItem.Update(item);
            }
            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Media-Add.aspx{0}&pid={1}", PrevUrl, result.id)));
            }
        }

    }
}