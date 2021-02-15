using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Controls
{
    public partial class ctlHeaderMenu : System.Web.UI.UserControl
    {
        public int PID
        {
            get
            {
                int temp = 0;
                string _id = Request.QueryString["p"];
                Int32.TryParse(_id, out temp);
                return temp;
            }
        }

        public int MID
        {
            get
            {
                int temp = 0;
                string _id = Request.QueryString["m"];
                Int32.TryParse(_id, out temp);
                return (temp == 0) ? 37 : temp;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // disini ada engecekan is admin
            List<tbl_Menu> list = new List<tbl_Menu>();
            if (Utilities.IsLoggedin)
            {
                if (Utilities.IsUser)
                    list = Utilities.GetTOP_MENU();
                GenerateMenus(list);
            }
            else
            {
                list = Utilities.GetTOP_BEFORE_MENU();
                GenerateMenus(list);
            }
        }


        private void GenerateMenus(List<tbl_Menu> list)
        {
            List<tbl_Menu> parentList = list.Where(t => ((!t.ParentID.HasValue) || t.ParentID == 0) && (!t.Deleted.HasValue || t.Deleted == 0)).OrderBy(t => t.Sequence).ToList();
            List<tbl_Menu> children = list.Where(t => !parentList.Select(u => u.ID).ToList().Contains(t.ID)).OrderBy(t => t.Sequence).ToList();



            parentList.ForEach(t =>
            {
                bool hasChild = list.Where(t1 => t1.ParentID == t.ID).Count() > 0;
                HtmlGenericControl liParent = AddParent(t, hasChild);
                if (hasChild)
                {
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes.Add("class", "kt-menu__submenu kt-menu__submenu--classic kt-menu__submenu--left");

                    List<tbl_Menu> menuList = children.Where(t2 => t2.ParentID == t.ID).OrderBy(t3 => t3.Sequence).ToList();
                    HtmlGenericControl ul = AddMenu(menuList);

                    div.Controls.Add(ul);
                    liParent.Controls.Add(div);
                }
                topNav.Controls.Add(liParent);
            });
        }


        private HtmlGenericControl AddMenu(List<tbl_Menu> children)
        {
            /*
<ul class="kt-menu__subnav">
    <li class="kt-menu__item " aria-haspopup="true"><a href="index.html" class="kt-menu__link"><i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span class="kt-menu__link-text">Media Monitoring</span></a></li>
    <li class="kt-menu__item " aria-haspopup="true"><a href="index.html" class="kt-menu__link"><i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span class="kt-menu__link-text">Data & Information</span></a></li>
    <li class="kt-menu__item " aria-haspopup="true"><a href="index.html" class="kt-menu__link"><i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span class="kt-menu__link-text">Risk Management</span></a></li>
    <li class="kt-menu__item " aria-haspopup="true"><a href="index.html" class="kt-menu__link"><i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span class="kt-menu__link-text">Corporate Integrated Survey</span></a></li>
</ul>
             */

            //List<tbl_Menu> grandChildren = children.Where(t => !children.Select(u => u.ID).ToList().Contains(t.ID)).OrderBy(t => t.Sequence).ToList();
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Attributes.Add("class", "kt-menu__subnav");
            children.ForEach(t =>
            {
                string id = string.Format("menu{0}", t.ID);
                string text = t.Name;
                string url = (string.Format("{0}", t.Url).Length > 0) ? string.Format("{0}?p={1}&m={2}", t.Url, t.ParentID, t.ID) : "#";
                string icon = string.Format("{0}", t.Icon);

                //<li class="kt-menu__item kt-menu__item--active" 
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Attributes.Add("class", "kt-menu__item");
                li.Attributes.Add("aria-haspopup", "true");

                //li.Attributes.Add("class", "kt-menu__item");
                li.ID = id;
                HtmlGenericControl anchor = new HtmlGenericControl("a");
                anchor.Attributes.Add("href", ResolveUrl(url));
                anchor.Attributes.Add("class", "kt-menu__link");

                HtmlGenericControl i = new HtmlGenericControl("i");
                i.Attributes.Add("class", icon);
                i.Controls.Add(new HtmlGenericControl("span"));

                anchor.Controls.Add(i);


                HtmlGenericControl span = new HtmlGenericControl("span");
                span.Attributes.Add("class", "kt-menu__link-text");
                span.InnerText = text;
                anchor.Controls.Add(span);


                li.Controls.Add(anchor);
                ul.Controls.Add(li);


            });
            return ul;
        }
        private HtmlGenericControl AddParent(tbl_Menu parent, bool hasChild = false)
        {


            string id = string.Format("menu{0}", parent.ID);
            string text = parent.Name;
            string url = (string.Format("{0}", parent.Url).Length > 0) ? string.Format("{0}?p={1}&m={2}", parent.Url, parent.ParentID, parent.ID) : "#";
            string icon = string.Format("{0}", parent.Icon);


            /*
<li class="kt-menu__item  kt-menu__item--submenu kt-menu__item--rel" data-ktmenu-submenu-toggle="click" aria-haspopup="true">
               <a href="javascript:;" class="kt-menu__link kt-menu__toggle"> <span class="kt-menu__link-text">Corporate Communication</span></a>
                 <div class="kt-menu__submenu kt-menu__submenu--classic kt-menu__submenu--left">
                   <ul class="kt-menu__subnav">
                     <li class="kt-menu__item " aria-haspopup="true"><a href="strategi-komunikasi-korporat.html"
                         class="kt-menu__link"><i
                           class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
                           class="kt-menu__link-text">Strategi Komunikasi Korporat</span></a></li>
                     <li class="kt-menu__item " aria-haspopup="true"><a href="strategi-pengelolaan-krisis.html"
                         class="kt-menu__link"><i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span
                           class="kt-menu__link-text">Strategi Pengelolaan Krisis</span></a></li>
                   </ul>
                 </div>
               </li>
            */


            HtmlGenericControl liParent = new HtmlGenericControl("li");
            liParent.ID = id;


            liParent.Attributes.Add("class", "kt-menu__item  kt-menu__item--submenu kt-menu__item--rel");
            liParent.Attributes.Add("data-ktmenu-submenu-toggle", "click");
            liParent.Attributes.Add("aria-haspopup", "true");

            HtmlGenericControl anchor = new HtmlGenericControl("a");
            if (!hasChild && url != "#")
            {
                anchor.Attributes.Add("href", ResolveUrl(url));
                anchor.Attributes.Add("class", "kt-menu__link");
                anchor.Attributes.Add("target", "_blank");

            }
            else
            {
                anchor.Attributes.Add("href", "javascript:;");
                anchor.Attributes.Add("class", "kt-menu__link kt-menu__toggle");
            }


            // <li class="kt-menu__item kt-menu__item--submenu kt-menu__item--rel" data-ktmenu-submenu-toggle="click" aria-haspopup="true">
            //    <a href="javascript:;" class="kt-menu__link kt-menu__toggle"><span class="kt-menu__link-text">Monitoring</span></a>
            //    <div class="kt-menu__submenu kt-menu__submenu--classic">
            //        <ul class="kt-menu__subnav">
            //            <li class="kt-menu__item " aria-haspopup="true"><a href="index.html" class="kt-menu__link"><i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span class="kt-menu__link-text">Media Monitoring</span></a></li>
            //            <li class="kt-menu__item " aria-haspopup="true"><a href="index.html" class="kt-menu__link"><i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span class="kt-menu__link-text">Data & Information</span></a></li>
            //            <li class="kt-menu__item " aria-haspopup="true"><a href="index.html" class="kt-menu__link"><i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span class="kt-menu__link-text">Risk Management</span></a></li>
            //            <li class="kt-menu__item " aria-haspopup="true"><a href="index.html" class="kt-menu__link"><i class="kt-menu__link-bullet kt-menu__link-bullet--dot"><span></span></i><span class="kt-menu__link-text">Corporate Integrated Survey</span></a></li>
            //        </ul>
            //    </div>
            //</li>

            // target="_blank" class="kt-menu__link"><span class="kt-menu__link-text">CORRESPONDENCE</span></a>/

            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerText = text;
            span.Attributes.Add("class", "kt-menu__link-text");
            anchor.Controls.Add(span);
            if (hasChild)
            {
                //i = new HtmlGenericControl("i");
                //i.Attributes.Add("class", "kt-menu__ver-arrow la la-angle-right");
                //anchor.Controls.Add(i);
            }

            liParent.Controls.Add(anchor);
            return liParent;
        }
    }
}