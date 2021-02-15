using System;
using Pertamina.CORSEC.Business.Enum;
using Pertamina.CORSEC.Dta;
using System.Linq;
using Pertamina.CORSEC.Business.Helper;

namespace Pertamina.CORSEC.Business
{
    public class CORSECPage : System.Web.UI.Page
    {
        public string Crop(object text, int length)
        {
            return string.Format("{0}..", Utilities.Crop(string.Format("{0}", text), length));
        }
        public string ConvertUrl(object blob)
        {
            if (blob == null) return "";
            byte[] file_blob = (byte[])blob;
            return Utilities.ByteToString(file_blob);
        }
        public int PageCode { get; set; }
        public string GetFailedMessage()
        {
            return string.Format("<span style=\"color: red\">[Updated : failed]</span>");
        }


        public string GetSucceedMessage()
        {
            return string.Format("<span style=\"color: blue\">[Updated : {0:dd MMM yyyy HH:mm:ss}]</span>", DateTime.Now);
        }

        public string GetValidationMessage(string message)
        {
            return string.Format("<span style=\"color: orange\">[{0}]</span>", message);
        }
        public int ItemID
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["id"];
                int.TryParse(_id, out id);
                return id;
            }
        }

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

        //public string PrevPage
        //{
        //    get
        //    {
        //        string previousPageName = "";
        //        if (Request.UrlReferrer != null)
        //        {
        //            string previousPageUrl = Request.UrlReferrer.AbsoluteUri;
        //            //Request.UrlReferrer.AbsolutePath
        //            previousPageName = System.IO.Path.GetFileName(previousPageUrl);
        //        }

        //        return previousPageName;
        //    }
        //}

        public string CurrentUrl
        {
            get
            {
                string currentPageName = "";
                if (Request.Url != null)
                {
                    string virtualFolder = ResolveUrl("~");
                    currentPageName = string.Format("{0}", Request.Url.PathAndQuery).Replace(virtualFolder, string.Empty);
                    //string currentPageUrl = Request.Url.AbsoluteUri;
                    //currentPageName = System.IO.Path.GetFileName(currentPageUrl);

                }

                return currentPageName;
            }
        }

        public string PrevUrl
        {
            get
            {
                return string.Format("?p={0}&m={1}", ParentID, MenuID);
            }
        }
    }
    public class AuthorizePage : System.Web.UI.Page
    {
        public string CurrentPage
        {
            get
            {
                string currentPageName = "";
                if (Request.Url != null)
                {
                    string currentPageUrl = Request.Url.AbsoluteUri;
                    currentPageName = System.IO.Path.GetFileName(currentPageUrl);
                }

                return currentPageName;
            }
        }

        public int PageCode { get; set; }
        protected override void OnInit(EventArgs e)
        {
            string username = Utilities.Username;
            //if (username == "Guest")
            //{
            //    Response.Redirect(ResolveUrl(string.Format("~/Login.aspx?ReturnUrl={0}", Server.UrlEncode(CurrentPage))));
            //}
            base.OnInit(e);
        }
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

        public string GetFailedMessage()
        {
            return string.Format("<span style=\"color: red\">[Updated : failed]</span>");
        }


        public string GetSucceedMessage()
        {
            return string.Format("<span style=\"color: blue\">[Updated : {0:dd MMM yyyy HH:mm:ss}]</span>", DateTime.Now);
        }

        public string GetValidationMessage(string message)
        {
            return string.Format("<span style=\"color: orange\">[Validation : {0}]</span>", message);
        }

        public int ItemID
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["id"];
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
    }

    public class AuthorizeAdminPage : System.Web.UI.Page
    {
        public string ConvertUrl(object blob)
        {
            if (blob == null) return "";
            byte[] file_blob = (byte[])blob;
            return Utilities.ByteToString(file_blob);
        }
        public string Crop(object text)
        {

            return string.Format("{0}..", Utilities.Crop(string.Format("{0}", text), 66));
        }

        public string EmptyImage
        {
            get
            {
                return ResolveUrl("~/Images/empty.png");
            }
        }
        public int ItemID
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["id"];
                int.TryParse(_id, out id);
                return id;
            }
        }

        public string ItemCode
        {
            get
            {
                return string.Format("{0}", Request.QueryString["id"]);
            }
        }

        public int ParentItemID
        {
            get
            {
                int id = 0;
                string _id = Request.QueryString["pid"];
                int.TryParse(_id, out id);
                return id;
            }
        }
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

        public string GetFailedMessage()
        {
            return string.Format("<span style=\"color: red\">[Updated : failed]</span>");
        }

        public string GetSucceedMessage()
        {
            return string.Format("<span style=\"color: blue\">[Updated : {0:dd MMM yyyy HH:mm:ss}]</span>", DateTime.Now);
        }

        public string GetValidationMessage(string message)
        {
            return string.Format("<span style=\"color: orange\">[Validation : {0}]</span>", message);
        }

        public string GetInformationMessage(string message)
        {
            return string.Format("<span style=\"color: blue\">[Info : {0}]</span>", message);
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

        public string PageType
        {
            get
            {
                return string.Format("{0}", Request.QueryString["t"]);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            string username = Utilities.Username;
            if (username == string.Format("{0}", UserType.Anonymous))
            {
                Response.Redirect(ResolveUrl("~/Admin/Login.aspx"));
            }
            else
            {
                Dto.Cstm.tbl_User item = SessionHelper.GetUserLogin();
                if (item == null)
                {
                    Response.Redirect(ResolveUrl("~/Admin/Login.aspx"));
                }
                else if (item.Roles.Where(t => string.Format("{0}", t.Name).ToLower() == string.Format("{0}", UserType.Administrator).ToLower()).Count() == 0)
                {
                    Response.Redirect(ResolveUrl("~/Admin/Login.aspx"));
                }
            }
            base.OnInit(e);
        }

        public string PrevUrl
        {
            get
            {
                return string.Format("?p={0}&m={1}", ParentID, MenuID);
            }
        }

    }
}
