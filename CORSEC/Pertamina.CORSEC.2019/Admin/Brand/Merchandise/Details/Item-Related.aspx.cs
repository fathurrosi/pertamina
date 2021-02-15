using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;
using System.Linq;

namespace Pertamina.CORSEC._2019.Admin.Brand.Merchandise.Details
{
    public partial class Item_Related : AuthorizeAdminPage
    {
        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            int _id = 0;
            int.TryParse(lbtn.CommandArgument, out _id);
            tbl_product_relatedItem.Delete(_id);

            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Details/Item.aspx{0}&id={1}", PrevUrl, ItemID)));
        }

        protected void CheckAll(object sender, EventArgs e)
        {
            CheckBox chckheader = (CheckBox)grid.HeaderRow.FindControl("checkbox2");
            foreach (GridViewRow row in grid.Rows)
            {
                CheckBox chckrw = (CheckBox)row.FindControl("IDCheckbox");
                if (chckheader.Checked == true)
                {
                    chckrw.Checked = true;

                }
                else
                {
                    chckrw.Checked = false;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btnDelete.Visible = false;
                List<Dto.Cstm.tbl_product_related> list = tbl_product_relatedItem.GetMerchandiseHub_ByRelated(ParentItemID);
                //if (item != null)
                //{
                //    imgThumnail.ImageUrl = Utilities.ByteToString(item.file_blob);
                //    btnDelete.Visible = true;
                //}



                List<tbl_product> parentList = tbl_productItem.GetByProduct_Type((int)product_type.Merchandise_hub);
                grid.DataSource = parentList.Where(t => t.id != ParentItemID).ToList();
                grid.DataBind();

                foreach (GridViewRow row in grid.Rows)
                {
                    CheckBox chckrw = (CheckBox)row.FindControl("IDCheckbox");
                    HiddenField hdn = (HiddenField)row.FindControl("hdn");
                    int product_id = 0;
                    int.TryParse(hdn.Value, out product_id);
                    if(list.Where( t=> t.product_id == product_id).Count() >0)
                    {
                        chckrw.Checked = true;
                    }

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
                //HiddenField hiddenField = e.Row.FindControl("hdn") as HiddenField;
                //HyperLink hyperLink = e.Row.FindControl("hlEdit") as HyperLink;
                //hyperLink.NavigateUrl = ResolveUrl(string.Format("~/Admin/Brand/Merchandise/Details/Item-Related.aspx{0}&pid={1}&id={2}", PrevUrl, ItemID, hiddenField.Value));
                //LinkButton lbtn = e.Row.FindControl("lbDel") as LinkButton;
                //lbtn.OnClientClick = "return confirm('Anda yakin akan menghapus item ini?');";
                //lbtn.CommandArgument = hiddenField.Value;

            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            tbl_product_related file = tbl_product_relatedItem.GetByPK(ItemID);
            if (file != null) tbl_product_relatedItem.Delete(file.id);
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Merchandise/Details/Item.aspx{0}&id={1}", PrevUrl, ParentItemID)));
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Merchandise/Details/Item.aspx{0}&id={1}", PrevUrl, ParentItemID)));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<int> children = new List<int>();
            foreach (GridViewRow row in grid.Rows)
            {
                CheckBox chckrw = (CheckBox)row.FindControl("IDCheckbox");
                HiddenField hdn = (HiddenField)row.FindControl("hdn");
                if (chckrw.Checked)
                {
                    children.Add(Convert.ToInt32(hdn.Value));
                }

            }

            tbl_product_relatedItem.InsertAll(ParentItemID, children);
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Merchandise/Details/Item.aspx{0}&id={1}", PrevUrl, ParentItemID)));

        }

    }
}