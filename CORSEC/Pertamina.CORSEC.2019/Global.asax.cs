using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Pertamina.CORSEC.Business;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC._2019
{
    public class Global : System.Web.HttpApplication
    {
        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
               "EventIndex",
               "event",
               "~/Events/EventsIndex.aspx"
           );
            routes.MapPageRoute(
               "EventList",
               "eventlist",
               "~/Events/EventsList.aspx"
           );
            routes.MapPageRoute(
                "EventDetail",
                "event/{OrderNumber}",
                "~/Events/EventsDetail.aspx"
            );
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            WebControl.DisabledCssClass = "";
            RegisterCustomRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpRequest request = HttpContext.Current.Request;
            if (request != null && 
                request.CurrentExecutionFilePathExtension == ".aspx" && 
                ConfigReader.Debug)
            {
                //track log visited page                
                Log.Info(request.RawUrl);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                tbl_Log log = Log.Error(ex);
                Server.ClearError();
                Server.Transfer(string.Format("~/ErrorPage.aspx?id={0}", log.ID), true);
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}