using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Admin.StakeHolderManagement.Details
{
    public partial class Country : AuthorizeAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtName.Text = "";
                txtUrut.Text = "";
                tbl_Stake_Holder_Management_Country item = tbl_Stake_Holder_Management_CountryItem.GetByPK(ItemID);
                if (item != null)
                {
                    txtName.Text = item.country;
                    txtUrut.Text = string.Format("{0}", item.sequence);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            string username = Utilities.Username;
            tbl_Stake_Holder_Management_Country item = tbl_Stake_Holder_Management_CountryItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Stake_Holder_Management_Country();
                item.created = DateTime.Now;
                item.created_by = username;

            }

            int _seq = 0;
            int.TryParse(txtUrut.Text, out _seq);
            item.created = item.created.HasValue ? item.created : DateTime.Now;
            item.sequence = _seq;
            item.country = txtName.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;

            tbl_Stake_Holder_Management_Country result = null;
            if (!isEdit)
            {
                result = tbl_Stake_Holder_Management_CountryItem.Insert(item);
            }
            else
            {
                result = tbl_Stake_Holder_Management_CountryItem.Update(item);
            }

            if (result != null)
            {
                Response.Redirect(ResolveUrl(string.Format("~/Admin/StakeHolderManagement/Country.aspx{0}", PrevUrl)));
            }
        }
    }
}