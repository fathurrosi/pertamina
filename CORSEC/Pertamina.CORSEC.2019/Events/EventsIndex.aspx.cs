using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pertamina.CORSEC._2019.Events
{
    public partial class EventsIndex : System.Web.UI.Page
    {
        public List<EventServices.New_GetList_OperationResponse> Resp_ = new List<EventServices.New_GetList_OperationResponse>();
        public List<EventServices.New_GetList_OperationResponse> Resp_Sub = new List<EventServices.New_GetList_OperationResponse>();
        public int counter;
        public int counterSub;
        protected void Page_Load(object sender, EventArgs e)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            EventServices.AuthenticationInfo User = new EventServices.AuthenticationInfo();
            User.userName = "corpsecintegration";
            User.password = "Pertamin@123";
            this.counter = 0;
            this.counterSub = 0;
            List<EventServices.New_GetList_OperationResponse> _RESP = new List<EventServices.New_GetList_OperationResponse>();
            EventServices.New_Port_0PortTypeClient eventService = new EventServices.New_Port_0PortTypeClient();
            eventService.Open();
            for (int i = 0; i < 3; i++)
            {
                EventServices.New_GetList_OperationRequest req = new EventServices.New_GetList_OperationRequest(User, "'Summary' = \"Request Feature Input Event Dashboard\" AND Status = \"Completed\" AND 'SR Type Field 48' > \"" + dateString2 + "\"", "" + i + "", "1");
                try
                {
                    var resp = eventService.New_GetList_OperationAsync(req);
                    this.Resp_.Add(resp.Result);
                }
                catch (Exception execption)
                {
                    Console.WriteLine(execption);
                }

            }
            for (int i = 2; i < 5; i++)
            {
                EventServices.New_GetList_OperationRequest req = new EventServices.New_GetList_OperationRequest(User, "'Summary' = \"Request Feature Input Event Dashboard\" AND Status = \"Completed\" AND 'SR Type Field 48' > \"" + dateString2 + "\"", "" + i + "", "1");
                try
                {
                    var resp = eventService.New_GetList_OperationAsync(req);
                    this.Resp_Sub.Add(resp.Result);
                }
                catch (Exception execption)
                {
                    Console.WriteLine(execption);
                }
            }


            eventService.Close();
        }
    }
}