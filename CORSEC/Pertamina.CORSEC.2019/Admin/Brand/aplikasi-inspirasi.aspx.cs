using System;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;
using System.Linq;

namespace Pertamina.CORSEC._2019.Admin.Brand
{
    public partial class aplikasi_inspirasi : AuthorizeAdminPage
    {
        //public string PrevUrl { get; set; }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Details/aplikasi-inspirasi.aspx{0}", PrevUrl)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbl_brand_guideline_aplikasi_inspirasi item = tbl_brand_guideline_aplikasi_inspirasiItem.GetAll().FirstOrDefault();
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    lblContent.Value = item.body;
                }
            }

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
                HyperLink hlEdit = e.Row.FindControl("hlEdit") as HyperLink;
                hlEdit.NavigateUrl = string.Format("~/Admin/Brand/Details/aplikasi-inspirasi.aspx{0}&id={1}&t=e", PrevUrl, hiddenField.Value);

                LinkButton lbtn = e.Row.FindControl("lbDel") as LinkButton;
                lbtn.OnClientClick = "return confirm('Anda yakin akan menghapus item ini?');";
                lbtn.CommandArgument = hiddenField.Value;
            }
        }

        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            int _id = 0;
            int.TryParse(lbtn.CommandArgument, out _id);
            tbl_brand_guideline_aplikasi_inspirasi_detailItem.Delete(_id);

            grid.DataBind();
        }

        protected void ddlTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid.DataBind();
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            bool newFile = false;
            tbl_brand_guideline_aplikasi_inspirasi item = tbl_brand_guideline_aplikasi_inspirasiItem.GetAll().FirstOrDefault();

            if (item == null)
            {
                newFile = true;
                item = new tbl_brand_guideline_aplikasi_inspirasi();
                item.created = DateTime.Now;
                item.created_by = username;
            }
            else
            {
                item.updated = DateTime.Now;
                item.updated_by = username;
            }

            item.logo_type = (int)LogoType.Logo_Corporate;
            item.title = lblTitle.Text;
            item.body = lblContent.Value;


            if (!newFile) { tbl_brand_guideline_aplikasi_inspirasiItem.Update(item); }
            else { tbl_brand_guideline_aplikasi_inspirasiItem.Insert(item); }

            lblMessage.Text = GetSucceedMessage();

        }
    }
}