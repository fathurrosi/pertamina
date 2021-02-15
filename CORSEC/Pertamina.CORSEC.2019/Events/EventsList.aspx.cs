using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pertamina.CORSEC._2019.Events
{
    public partial class EventsList : System.Web.UI.Page
    {
        public List<EventServices.New_GetList_OperationResponse> Resp_ = new List<EventServices.New_GetList_OperationResponse>();
        public string Test;
        public Boolean onLoad;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.onLoad = true;
            this.Resp_ = new List<EventServices.New_GetList_OperationResponse>();
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            EventServices.AuthenticationInfo User = new EventServices.AuthenticationInfo();
            User.userName = "corpsecintegration";
            User.password = "Pertamin@123";
            EventServices.New_Port_0PortTypeClient eventService = new EventServices.New_Port_0PortTypeClient();

            eventService.Open();
            for (int i = 0; i < 12; i++)
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
                finally
                {
                    this.onLoad = false;
                }
            }
            eventService.Close();
        }

        protected void Check_Clicked(object sender, EventArgs e)
        {
            this.Resp_ = new List<EventServices.New_GetList_OperationResponse>();
            this.onLoad = true;
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            EventServices.AuthenticationInfo User = new EventServices.AuthenticationInfo();
            EventServices.New_Port_0PortTypeClient eventService = new EventServices.New_Port_0PortTypeClient();
            User.userName = "corpsecintegration";
            User.password = "Pertamin@123";
            string query = "'Summary' = \"Request Feature Input Event Dashboard\" AND Status = \"Completed\" AND 'SR Type Field 48' > \"" + dateString2 + "\"";
            if (checkboxTalkShow.Checked)
            {
                query += " AND 'SR Type Field 33' LIKE \"Talkshow%\"";
            }

            if (checkboxSeremoni.Checked)
            {
                query += " AND 'SR Type Field 33' LIKE \"Seremoni%\"";
            }

            if (checkboxPeresmian.Checked)
            {
                query += " AND 'SR Type Field 33' LIKE \"Peresmian%\"";
            }
            if (checkboxPameran.Checked)
            {
                query += " AND 'SR Type Field 33' LIKE \"Pameran%\"";
            }

            if (checkboxMWTVirtual.Checked)
            {
                query += " AND 'SR Type Field 33' LIKE \"MWT Virtual%\"";
            }

            if (checkboxEventTahunan.Checked)
            {
                query += " AND 'SR Type Field 33' LIKE \"Event Tahunan%\"";
            }

            if (checkboxBranchmarking.Checked)
            {
                query += " AND 'SR Type Field 33' LIKE \"Branchmarking%\"";
            }
            eventService.Open();
            for (int i = 0; i < 12; i++)
            {
                EventServices.New_GetList_OperationRequest req = new EventServices.New_GetList_OperationRequest(User, query, "" + i + "", "1");
                try
                {
                    var resp = eventService.New_GetList_OperationAsync(req);
                    this.Resp_.Add(resp.Result);
                }
                catch (Exception execption)
                {
                    Console.WriteLine(execption);
                }
                finally
                {
                    this.onLoad = false;
                }
            }
            eventService.Close();
        }
    }
}
