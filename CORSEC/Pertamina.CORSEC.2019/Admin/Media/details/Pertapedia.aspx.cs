using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Media.details
{
    public partial class Pertapedia : AuthorizeAdminPage
    {
        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            int _id = 0;
            int.TryParse(lbtn.CommandArgument, out _id);
            tbl_Media_FileItem.Delete(_id);

            Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Details/Pertapedia.aspx{0}&id={1}", PrevUrl, ItemID)));
        }

        //protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        e.Row.TableSection = TableRowSection.TableHeader;
        //    }
        //    else if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
        //        HyperLink hyperLink = e.Row.FindControl("hlEdit") as HyperLink;
        //        hyperLink.NavigateUrl = ResolveUrl(string.Format("~/Admin/Media/Details/Exhibition-File.aspx{0}&pid={1}&id={2}", PrevUrl, ItemID, hiddenField.Value));
        //        LinkButton lbtn = e.Row.FindControl("lbDel") as LinkButton;
        //        lbtn.OnClientClick = "return confirm('Anda yakin akan menghapus item ini?');";
        //        lbtn.CommandArgument = hiddenField.Value;

        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                tbl_Media item = tbl_MediaItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    lblContent.Value = item.body;
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

            int.TryParse(lblTahun.Text, out tahun);

            int.TryParse(lblTahun.Text, out tahun);
            if (tahun <= 1900) tahun = DateTime.Now.Year;

            item.title = lblTitle.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.body = lblContent.Value;
            item.infographic_type = (int)Infographic_Type.Pertapedia;
            item.infographic_year = tahun;

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
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Media/Infographic.aspx{0}", PrevUrl)));
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

            int.TryParse(lblTahun.Text, out tahun);
                       
            if (tahun <= 1900) tahun = DateTime.Now.Year;

            item.title = lblTitle.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.body = lblContent.Value;
            item.infographic_type = (int)Infographic_Type.Pertapedia;
            item.infographic_year = tahun;

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