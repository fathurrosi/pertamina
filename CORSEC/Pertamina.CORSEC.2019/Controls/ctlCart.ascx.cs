using System;
using System.Collections.Generic;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Business.Helper;
using Pertamina.CORSEC.Dto.Cstm;

namespace Pertamina.CORSEC._2019.Controls
{
    public partial class ctlCart : System.Web.UI.UserControl
    {
        public int MenuID
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["m"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public int ParentID
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["p"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public string PrevUrl
        {
            get
            {
                return string.Format("?p={0}&m={1}", ParentID, MenuID);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            divCart.Attributes.Add("style", "display: none");
            string username = Utilities.Username;
            if (username != string.Format("{0}", UserType.Anonymous))
            {
                lblTotalItem.Attributes.Remove("style");
                List<tbl_product> list = SessionHelper.GetCarts();
                if (list != null)
                {
                    string templateTotalButton = @" <button type=""button"" class=""btn btn-success btn-sm"" style="""">{0}</button>";
                    lblTotalItem.Text = string.Format(templateTotalButton, list.Count > 1 ? string.Format("{0} Items", list.Count) : string.Format("{0} Item", list.Count));
                    listView.DataSource = list;
                    listView.DataBind();
                    divCart.Attributes.Add("style", "display:normal");
                }
            }
        }
    }
}