using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto.Cstm;

namespace Pertamina.CORSEC.Business.Helper
{
    public class SessionHelper
    {
        public const string _UserLogin = "user_login";
        public const string _MY_CART = "my_cart";
        public const string _FOOTER = "footer";
        public const string _PARTICIPANT_SURVEY_DONE = "participant_already_survey";
        public const string _TAB_Presentasi = "TAB_Presentasi";
        public static void Set(string key, object value)
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session[key] = value;
        }

        public static object Get(string key)
        {
            if (HttpContext.Current.Session != null)
                return HttpContext.Current.Session[key];

            return null;
        }

        public static Dto.Cstm.tbl_User GetUserLogin()
        {
            object obj = Get(_UserLogin);
            if (obj == null)
            {
                Dto.Cstm.tbl_User user = tbl_UserItem.GetUser(Utilities.Username);
                Set(_UserLogin, user);
                return user;
            }
            else return (Dto.Cstm.tbl_User)obj;
        }

        public static List<tbl_product> GetCarts()
        {
            object obj = null;

            obj = Get(_MY_CART);
            if (obj == null)
            {
                List<tbl_product> list = tbl_productItem.GetWishlist(Utilities.Username);
                if (list.Count > 0)
                {
                    Set(_MY_CART, list);
                    return list;
                }
                else return null;

            }
            else
            {
                return (List<tbl_product>)obj;
            }

        }

        public static void ClearUserLogin()
        {
            Set(_UserLogin, null);
        }
        public static void ClearCart()
        {
            Set(_MY_CART, null);
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
