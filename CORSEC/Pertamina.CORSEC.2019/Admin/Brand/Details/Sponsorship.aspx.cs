using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.Brand.Details
{
    public partial class Sponsorship : AuthorizeAdminPage
    {
        public string ConvertUrl(object blob)
        {
            if (blob == null) return "";
            byte[] file_blob = (byte[])blob;
            return Utilities.ByteToString(file_blob);
        }
        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            int _id = 0;
            int.TryParse(lbtn.CommandArgument, out _id);
            tbl_brand_Sponsorship_FileItem.Delete(_id);

            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Details/Sponsorship.aspx{0}&id={1}", PrevUrl, ItemID)));
        }

        protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                HyperLink hyperLink = e.Row.FindControl("hlEdit") as HyperLink;
                hyperLink.NavigateUrl = ResolveUrl(string.Format("~/Admin/Brand/Details/Sponsorship-File.aspx{0}&pid={1}&id={2}", PrevUrl, ItemID, hiddenField.Value));
                LinkButton lbtn = e.Row.FindControl("lbDel") as LinkButton;
                lbtn.OnClientClick = "return confirm('Anda yakin akan menghapus item ini?');";
                lbtn.CommandArgument = hiddenField.Value;

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                tbl_brand_Sponsorship item = tbl_brand_SponsorshipItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    lblContent.Value = item.body;
                    item.title = lblTitle.Text;
                    lblLokasi.Text = item.location;
                    lblAward.Text = item.award;
                    List<tbl_brand_Sponsorship_File> files = tbl_brand_Sponsorship_FileItem.GetByFK(ItemID);
                    listViewSponsorship.DataSource = files.Where(t => t.sponsorship_type == (int)SponsorshipType.Gallery).ToList();
                    listViewSponsorship.DataBind();

                    grid.DataSource = files.Where(t => t.sponsorship_type == (int)SponsorshipType.Materi_Poster).ToList();
                    grid.DataBind();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_brand_Sponsorship item = tbl_brand_SponsorshipItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_brand_Sponsorship();
                item.created = DateTime.Now;
                item.created_by = username;
            }

            item.title = lblTitle.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.body = lblContent.Value;
            item.location = lblLokasi.Text;
            item.award = lblAward.Text;

            tbl_brand_Sponsorship result = null;
            if (!isEdit)
            {
                result = tbl_brand_SponsorshipItem.Insert(item);
            }
            else
            {
                result = tbl_brand_SponsorshipItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Sponsorship.aspx{0}", PrevUrl)));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_brand_Sponsorship item = tbl_brand_SponsorshipItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_brand_Sponsorship();
                item.created = DateTime.Now;
                item.created_by = username;
            }

            item.title = lblTitle.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.body = lblContent.Value;
            item.location = lblLokasi.Text;
            item.award = lblAward.Text;
            tbl_brand_Sponsorship result = null;
            if (!isEdit)
            {
                result = tbl_brand_SponsorshipItem.Insert(item);
            }
            else
            {
                result = tbl_brand_SponsorshipItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Details/Sponsorship-Add.aspx{0}&pid={1}", PrevUrl, result.id)));
            }
        }

        protected void btnAddFile_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_brand_Sponsorship item = tbl_brand_SponsorshipItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_brand_Sponsorship();
                item.created = DateTime.Now;
                item.created_by = username;
            }

            item.title = lblTitle.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.body = lblContent.Value;
            item.location = lblLokasi.Text;
            item.award = lblAward.Text;
            tbl_brand_Sponsorship result = null;
            if (!isEdit)
            {
                result = tbl_brand_SponsorshipItem.Insert(item);
            }
            else
            {
                result = tbl_brand_SponsorshipItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Details/Sponsorship-File.aspx{0}&pid={1}", PrevUrl, result.id)));
            }
        }
    }
}