using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Business.Helper;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Services
{
    /// <summary>
    /// Summary description for Session
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Session : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public string Add(string data)
        {
            int id = 0;
            if (int.TryParse(data, out id))
            {
                Dto.Cstm.tbl_product item = tbl_productItem.GetByID(id);
                if (item != null)
                {
                    tbl_product_wishlist wlObj = new tbl_product_wishlist();
                    wlObj.product_id = item.id;
                    wlObj.Created = DateTime.Now;
                    wlObj.Username = Utilities.Username;
                    tbl_product_wishlistItem.Insert(wlObj);
                    SessionHelper.ClearCart();
                    return "Item sudah ditambahkan kedalam cart";
                }
            }
            return "Item tidak dapat ditambahkan kedalam cart";
        }

        [WebMethod(EnableSession = true)]
        public string SetTabPresentasi(string tab)
        {
            SessionHelper.Set(SessionHelper._TAB_Presentasi, tab);
            return "OK";
        }

        [WebMethod(EnableSession = true)]
        public string GetTabPresentasi()
        {
            return (string)SessionHelper.Get(SessionHelper._TAB_Presentasi);
        }
    }
}
