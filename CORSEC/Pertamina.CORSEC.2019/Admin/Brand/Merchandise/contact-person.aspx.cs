using System;
using System.IO;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;
using System.Linq;
namespace Pertamina.CORSEC._2019.Admin.Brand.Merchandise
{
    public partial class contact_person : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbl_product_contact_person item = tbl_product_contact_personItem.GetAll().OrderByDescending(T=> T.id).FirstOrDefault();
                if (item != null)
                {
                    lblName.Text = item.name;
                    lblTelp.Text = item.phone;
                    lblEmail.Text = item.email;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            tbl_product_contact_person file = tbl_product_contact_personItem.GetByPK(ItemID);
            if (file != null) tbl_product_contact_personItem.Delete(file.id);
            Response.Redirect(ResolveUrl(string.Format("~/Admin/Brand/Campaign/File.aspx{0}&id={1}", PrevUrl, ParentItemID)));
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string username = Utilities.Username;
                bool newFile = false;
                tbl_product_contact_person item = tbl_product_contact_personItem.GetAll().OrderByDescending(T => T.id).FirstOrDefault();

                if (item == null)
                {
                    newFile = true;
                    item = new tbl_product_contact_person();
                    item.created = DateTime.Now;
                    item.created_by = username;
                }
                else
                {
                    item.updated = DateTime.Now;
                    item.updated_by = username;
                }

                item.name = lblName.Text;
                item.phone = lblTelp.Text;
                item.email = lblEmail.Text;


                if (!newFile) { tbl_product_contact_personItem.Update(item); }
                else { tbl_product_contact_personItem.Insert(item); }
                lblMessage.Text = GetSucceedMessage();
            }
            catch (Exception ex)
            {
                lblMessage.Text = GetFailedMessage();
                Log.Error(ex);
            }
        }

    }
}