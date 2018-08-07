using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using qms.Models;
using System.Threading.Tasks;
using qms.Utility;

namespace qms.SignalRHub
{
    [HubName("notifyDisplay")]
    public class NotifyDisplay : Hub
    {
        
        //public void PushNotification(int branch_id)
        //{
        //    DisplayManager dm = new DisplayManager();

        //    var tokenInProgress = dm.GetNextTokensCounter(branch_id);

        //    string nextToken = dm.GetNextTokens(branch_id);

        //    Clients.All.response(tokenInProgress, nextToken);
        //}

        //public void GetNotification(int branch_id)
        //{
        //    DisplayManager dm = new DisplayManager();

        //    var tokenInProgress = dm.GetNextTokensCounter(branch_id);

        //    string nextToken = dm.GetNextTokens(branch_id);

        //    Clients.All.response(tokenInProgress, nextToken);
        //}


        public override Task OnConnected()
        {
            return base.OnConnected();

        }

        [HubMethodName("sendMessages")]
        public static void SendMessages(int branch_id, string counter_no, string token_no)
        {
            
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotifyDisplay>();
            if (token_no == "null")
            {
                context.Clients.All.updateMessages("", branch_id);

                context.Clients.All.broadCustMessage(new BroadcustMessage() {
                    branch_id = branch_id,
                    text = ""
                });
            }
            else
            {
               
                //string text = ApplicationSetting.CounterText + " " + counter_no + " " + ApplicationSetting.TokenText + " " + token_no;
                string text = string.Format(ApplicationSetting.voiceText, token_no, counter_no);

                //AudioManager.TextToMP3(text, branch_id);
                context.Clients.All.updateMessages(text, branch_id);
                context.Clients.All.broadCustMessage(new BroadcustMessage()
                {
                    branch_id = branch_id,
                    text = text
                });

            }
        }

        

    }

    public class BroadcustMessage
    {
        public int branch_id;
        public String text;
    }

}