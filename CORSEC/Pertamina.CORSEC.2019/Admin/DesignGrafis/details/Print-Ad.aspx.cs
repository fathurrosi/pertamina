using System;
using System.Collections.Generic;
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
    public partial class Print_Ad : AuthorizeAdminPage
    {
        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            int _id = 0;
            int.TryParse(lbtn.CommandArgument, out _id);
            tbl_Design_Grafis_FileItem.Delete(_id);

            Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/details/Print-Ad.aspx{0}&id={1}", PrevUrl, ItemID)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdndata_type.Value = string.Format("{0}", PageType);
                tbl_Design_Grafis item = tbl_Design_GrafisItem.GetByPK(ItemID);
                if (item != null)
                {
                    lblTitle.Text = item.title;
                    lblContent.Value = item.body;
                    item.title = lblTitle.Text;
                    lblTahun.Text = string.Format("{0}", item.data_year);
                    hdndata_type.Value = string.Format("{0}", item.data_type);
                    List<tbl_Design_Grafis_File> files = tbl_Design_Grafis_FileItem.GetByFK(ItemID);
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
            tbl_Design_Grafis item = tbl_Design_GrafisItem.GetByPK(ItemID);
            int data_type = -1;
            if (!int.TryParse(hdndata_type.Value, out data_type))
            {
                data_type = (int)Design_Grafis_Desain_Type.Print_Ad;
            }
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Design_Grafis();
                item.created = DateTime.Now;
                item.created_by = username;
                item.data_type = data_type;
            }

            int.TryParse(lblTahun.Text, out tahun);

            int.TryParse(lblTahun.Text, out tahun);
            if (tahun <= 1900) tahun = DateTime.Now.Year;

            item.title = lblTitle.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.body = lblContent.Value;

            item.data_year = tahun;

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
                Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Print-Ad.aspx{0}", PrevUrl)));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int tahun = DateTime.Now.Year;
            bool isEdit = true;
            string username = Utilities.Username;
            int data_type = -1;
            if (!int.TryParse(hdndata_type.Value, out data_type))
            {
                data_type = (int)Design_Grafis_Desain_Type.Print_Ad;
            }
            tbl_Design_Grafis item = tbl_Design_GrafisItem.GetByPK(ItemID);
            if (item == null)
            {
                isEdit = false;
                item = new tbl_Design_Grafis();
                item.created = DateTime.Now;
                item.data_type = data_type;
                item.created_by = username;
            }

            int.TryParse(lblTahun.Text, out tahun);

            if (tahun <= 1900) tahun = DateTime.Now.Year;

            item.title = lblTitle.Text;
            item.updated = DateTime.Now;
            item.updated_by = username;
            item.body = lblContent.Value;            
            item.data_year = tahun;

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
                Response.Redirect(ResolveUrl(string.Format("~/Admin/DesignGrafis/Details/Media-Add.aspx{0}&pid={1}", PrevUrl, result.id)));
            }
        }

    }
}