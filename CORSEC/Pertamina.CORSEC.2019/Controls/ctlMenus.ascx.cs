using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019.Controls
{
    public partial class ctlMenus : System.Web.UI.UserControl
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
                return (temp == 0) ? 1 : temp;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<tbl_Menu> list = Utilities.GetFRONTEND_MENU();
            GenerateMenus(list);
        }


        private tbl_Menu GetGrandParent(tbl_Menu child, List<tbl_Menu> list)
        {
            if (child == null) return null;
            tbl_Menu parent = list.Where(t => t.ID == child.ParentID).FirstOrDefault();
            if (parent == null)
            {
                return child;
            }
            else
            {
                return GetGrandParent(parent, list);
            }
        }
        private void GenerateMenus(List<tbl_Menu> list)
        {
            string username = Utilities.Username;
            List<tbl_Menu> parentList = list.Where(t => ((!t.ParentID.HasValue) || t.ParentID == 0) && (!t.Deleted.HasValue || t.Deleted == 0)).OrderBy(t => t.Sequence).ToList();
            List<tbl_Menu> children = list.Where(t => !parentList.Select(u => u.ID).ToList().Contains(t.ID)).OrderBy(t => t.Sequence).ToList();

            tbl_Menu current = list.Where(t => t.ID == MID).FirstOrDefault();
            tbl_Menu grandParent = GetGrandParent(current, list);

            parentList.ForEach(t =>
            {

                bool hasChild = list.Where(t1 => t1.ParentID == t.ID).Count() > 0;
                bool selected = (hasChild && grandParent != null) ? t.ID == grandParent.ID : t.ID == MID;
                HtmlGenericControl liParent = AddParent(t, selected, hasChild);
                if (hasChild)
                {
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes.Add("class", "kt-menu__submenu");
                    HtmlGenericControl span = new HtmlGenericControl("span");
                    span.Attributes.Add("class", "kt-menu__arrow");
                    div.Controls.Add(span);

                    List<tbl_Menu> menuList = children.Where(t2 => t2.ParentID == t.ID).OrderBy(t3 => t3.Sequence).ToList();
                    List<tbl_Menu> grandList = children.Where(t2 => menuList.Select(t3 => t3.ID).ToList().Contains(t2.ParentID.HasValue ? t2.ParentID.Value : 0)).OrderBy(t3 => t3.Sequence).ToList();
                    HtmlGenericControl ul = AddMenu(menuList, grandList);

                    div.Controls.Add(ul);
                    liParent.Controls.Add(div);
                }
                mainNav.Controls.Add(liParent);
            });
        }


        private HtmlGenericControl AddMenu(List<tbl_Menu> children, List<tbl_Menu> grandChild = null)
        {
            if (grandChild == null) grandChild = new List<tbl_Menu>();

            HtmlGenericControl ul = new HtmlGenericControl("ul");
            ul.Attributes.Add("class", "kt-menu__subnav");
            children.ForEach(t =>
            {
                string id = string.Format("menu{0}", t.ID);
                string text = t.Name;
                string url = (string.Format("{0}", t.Url).Length > 0) ? string.Format("{0}?p={1}&m={2}", t.Url, t.ParentID, t.ID) : "#";
                string icon = string.Format("{0}", t.Icon);
                bool hasChild = grandChild.Where(t1 => t1.ParentID == t.ID).Count() > 0;

                if (!hasChild)
                {
                    bool selected = t.ID == MID;

                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("class", selected ? "kt-menu__item kt-menu__item--active" : "kt-menu__item");

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
                }
                else
                {


                    var parent = grandChild.Where(gc => gc.ID == MID).FirstOrDefault();
                    bool selected = (parent == null) ? false : t.ID == parent.ParentID;
                    HtmlGenericControl li = new HtmlGenericControl("li");

                    li.Attributes.Add("class", selected ? "kt-menu__item  kt-menu__item--submenu kt-menu__item--open kt-menu__item--here" : "kt-menu__item kt-menu__item--submenu");
                    li.ID = id;


                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                    anchor.Attributes.Add("href", "javascript:;");
                    anchor.Attributes.Add("class", "kt-menu__link kt-menu__toggle");

                    HtmlGenericControl i = new HtmlGenericControl("i");
                    i.Attributes.Add("class", icon);
                    i.Controls.Add(new HtmlGenericControl("span"));

                    anchor.Controls.Add(i);


                    HtmlGenericControl span = new HtmlGenericControl("span");
                    span.Attributes.Add("class", "kt-menu__link-text");
                    span.InnerText = text;
                    anchor.Controls.Add(span);

                    i = new HtmlGenericControl("i");
                    i.Attributes.Add("class", "kt-menu__ver-arrow la la-angle-right");
                    anchor.Controls.Add(i);

                    li.Controls.Add(anchor);


                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes.Add("class", "kt-menu__submenu");

                    HtmlGenericControl span1 = new HtmlGenericControl("span");
                    span1.Attributes.Add("class", "kt-menu__arrow");
                    div.Controls.Add(span1);

                    List<tbl_Menu> menuList = grandChild.Where(t2 => t2.ParentID == t.ID).OrderBy(t3 => t3.Sequence).ToList();
                    HtmlGenericControl ul1 = AddMenu(menuList);
                    div.Controls.Add(ul1);

                    li.Controls.Add(div);

                    ul.Controls.Add(li);

                }

            });
            return ul;
        }
        private HtmlGenericControl AddParent(tbl_Menu parent, bool selected, bool hasChild = false)
        {

            string id = string.Format("menu{0}", parent.ID);
            string text = parent.Name;
            string url = (string.Format("{0}", parent.Url).Length > 0) ? string.Format("{0}?p={1}&m={2}", parent.Url, parent.ParentID, parent.ID) : "#";
            string icon = string.Format("{0}", parent.Icon);

            HtmlGenericControl liParent = new HtmlGenericControl("li");
            liParent.ID = id;


            liParent.Attributes.Add("class", (selected) ? "kt-menu__item kt-menu__item--open kt-menu__item--here" : "kt-menu__item kt-menu__item--submenu");
            HtmlGenericControl anchor = new HtmlGenericControl("a");
            if (!hasChild && url != "#") anchor.Attributes.Add("href", ResolveUrl(url));

            anchor.Attributes.Add("class", "kt-menu__link kt-menu__toggle");

            HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes.Add("class", "kt-menu__link-icon");

            HtmlGenericControl i = new HtmlGenericControl("i");
            i.Attributes.Add("class", icon);
            span.Controls.Add(i);
            anchor.Controls.Add(span);

            span = new HtmlGenericControl("span");
            span.InnerText = text;
            span.Attributes.Add("class", "kt-menu__link-text");
            anchor.Controls.Add(span);

            if (hasChild)
            {
                i = new HtmlGenericControl("i");
                i.Attributes.Add("class", "kt-menu__ver-arrow la la-angle-right");
                anchor.Controls.Add(i);
            }

            liParent.Controls.Add(anchor);
            return liParent;
        }


    }
}