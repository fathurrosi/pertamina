using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pertamina.CORSEC._2019.Events
{
    public partial class EventsDetail : System.Web.UI.Page
    {
        public string countingDown;
        public EventServices.New_GetList_OperationResponse Resp_;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Resp_ = new EventServices.New_GetList_OperationResponse();
            string orderNumber = Page.RouteData.Values["OrderNumber"] as String;
            EventServices.AuthenticationInfo User = new EventServices.AuthenticationInfo();
            User.userName = "corpsecintegration";
            User.password = "Pertamin@123";
            try
            {
                if (orderNumber != null)
                {
                    EventServices.New_Port_0PortTypeClient eventService = new EventServices.New_Port_0PortTypeClient();
                    EventServices.New_GetList_OperationRequest req = new EventServices.New_GetList_OperationRequest(User, "'Summary' = \"Request Feature Input Event Dashboard\"  AND 'Request Number'=\"" + orderNumber + "\" ", "0", "1");
                    eventService.Open();
                    var Response = eventService.New_GetList_OperationAsync(req);
                    eventService.Close();
                    try
                    {
                        this.Resp_ = Response.Result;
                        SetCounting_Down(Response.Result.TanggalPelaksanaanDari.ToString());
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.Message);
                    }
                }
                else
                {
                    Response.Redirect("~/EventIndex.aspx");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }
        void SetCounting_Down(String DateEvent)
        {
            Char[] spearator = { '/' };
            String[] strList = DateEvent.Split(spearator);
            Char[] sparator2 = { ' ' };
            String[] Years = strList[2].Split(sparator2);

            this.countingDown = Years[0] + "/" + strList[1] + "/" + strList[0];
        }
    }
}