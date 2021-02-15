using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;
namespace Pertamina.CORSEC._2019.Admin.Mitra.Details
{
    public partial class Item : AuthorizeAdminPage
    {
        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            int _id = 0;
            int.TryParse(lbtn.CommandArgument, out _id);
            tbl_product_relatedItem.Delete(_id);

            Response.Redirect(ResolveUrl(string.Format("~/Admin/Mitra/Details/Item.aspx{0}&id={1}", PrevUrl, ItemID)));
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
                hyperLink.NavigateUrl = ResolveUrl(string.Format("~/Admin/Mitra/Details/Item-Related.aspx{0}&pid={1}&id={2}", PrevUrl, ItemID, hiddenField.Value));
                LinkButton lbtn = e.Row.FindControl("lbDel") as LinkButton;
                lbtn.OnClientClick = "return confirm('Anda yakin akan menghapus item ini?');";
                lbtn.CommandArgument = hiddenField.Value;

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.DataTextField = "name";
                ddlCategory.DataValueField = "name";
                ddlCategory.DataSource = tbl_Combo_DetailItem.GetByHeader("Mitra_binaan_Category");
                ddlCategory.DataBind();

                tbl_product item = tbl_productItem.GetByPK(ItemID);
                if (item != null)
                {
                    List<tbl_product_File> files = tbl_product_FileItem.GetByFK(ItemID);
                    listViewMitra_binaan.DataSource = files.Where(t => t.Merchandise_Type== (int)MitraType.Gallery).ToList();
                    listViewMitra_binaan.DataBind();

                    lblContent.Value = item.body;
                    lblTitle.Text = item.title;
                    lblQuantity.Text = string.Format("{0}", item.Min_Quantity);
                    lblHargaMulai.Text = string.Format("{0:N0}", item.Estimasi_Harga_Mulai);
                    lblHargaSampai.Text = string.Format("{0:N0}", item.Estimasi_Harga_Hingga);
                    lblSKU.Text = item.SKU;
                    ddlCategory.SelectedValue = item.Kategori;


                    grid.DataSource = tbl_product_relatedItem.GetMerchandiseHub_ByRelated(item.id);
                    grid.DataBind();

                }
            }
        }

        protected void btnAddFile_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            tbl_product item = tbl_productItem.GetByPK(ItemID);
            bool newFile = false;
            if (item == null)
            {
                newFile = true;
                item = new tbl_product();
                item.created = DateTime.Now;
                item.created_by = username;
                item.product_type = (int)product_type.Mitra_binaan;
            }
            else
            {
                item.updated = DateTime.Now;
                item.updated_by = username;
            }

            int quantity = 0;
            int.TryParse(lblQuantity.Text, out quantity);

            decimal mulai = 0;
            decimal hingga = 0;

            decimal.TryParse(lblHargaMulai.Text, out mulai);
            decimal.TryParse(lblHargaSampai.Text, out hingga);

            item.body = lblContent.Value;
            item.title = lblTitle.Text;
            item.SKU = lblSKU.Text;
            item.Min_Quantity = quantity;
            item.Kategori = ddlCategory.SelectedValue;
            item.Estimasi_Harga_Mulai = mulai;
            item.Estimasi_Harga_Hingga = hingga;

            tbl_product result = null;
            if (!newFile) { result = tbl_productItem.Update(item); }
            else { result = tbl_productItem.Insert(item); }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Mitra/Details/Item-Related.aspx{0}&pid={1}", PrevUrl, result.id)));
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            tbl_product item = tbl_productItem.GetByPK(ItemID);
            bool newFile = false;
            if (item == null)
            {
                newFile = true;
                item = new tbl_product();
                item.created = DateTime.Now;
                item.created_by = username;
                item.product_type = (int)product_type.Mitra_binaan;
            }
            else
            {
                item.updated = DateTime.Now;
                item.updated_by = username;
            }

            int quantity = 0;
            int.TryParse(lblQuantity.Text, out quantity);

            decimal mulai = 0;
            decimal hingga = 0;

            decimal.TryParse(lblHargaMulai.Text, out mulai);
            decimal.TryParse(lblHargaSampai.Text, out hingga);

            item.body = lblContent.Value;
            item.title = lblTitle.Text;
            item.SKU = lblSKU.Text;
            item.Min_Quantity = quantity;
            item.Kategori = ddlCategory.SelectedValue;
            item.Estimasi_Harga_Mulai = mulai;
            item.Estimasi_Harga_Hingga = hingga;

            tbl_product result = null;
            if (!newFile) { result=tbl_productItem.Update(item); }
            else { result=tbl_productItem.Insert(item); }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/Mitra/Details/Item-Add.aspx{0}&pid={1}", PrevUrl, result.id)));
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string username = Utilities.Username;
            tbl_product item = tbl_productItem.GetByPK(ItemID);
            bool newFile = false;
            if (item == null)
            {
                newFile = true;
                item = new tbl_product();
                item.created = DateTime.Now;
                item.created_by = username;
                item.product_type = (int)product_type.Mitra_binaan;
            }
            else
            {
                item.updated = DateTime.Now;
                item.updated_by = username;
            }

            int quantity = 0;
            int.TryParse(lblQuantity.Text, out quantity);

            decimal mulai = 0;
            decimal hingga = 0;

            decimal.TryParse(lblHargaMulai.Text, out mulai);
            decimal.TryParse(lblHargaSampai.Text, out hingga);

            item.body = lblContent.Value;
            item.title = lblTitle.Text;
            item.SKU = lblSKU.Text;
            item.Min_Quantity = quantity;
            item.Kategori = ddlCategory.SelectedValue;
            item.Estimasi_Harga_Mulai = mulai;
            item.Estimasi_Harga_Hingga = hingga;


            if (!newFile) { tbl_productItem.Update(item); }
            else { tbl_productItem.Insert(item); }

            Response.Redirect(ResolveUrl(string.Format("~/Admin/Mitra/Items.aspx{0}", PrevUrl)));

        }

    }
}