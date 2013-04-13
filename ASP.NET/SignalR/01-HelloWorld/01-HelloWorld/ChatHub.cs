using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace _01_HelloWorld
{

    //Web Sockets - SSE - Forever Frame - Long polling
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            //Clients.All.hello();

            var msg = String.Format("{0}: {1}", Context.ConnectionId, message);
            Clients.All.newMessage(msg);

            //Clients.Caller.newMessage(message);
            //Clients.Client(Context.ConnectionId.newMessage(message));

            //Clients.All
            //Clients.Others.All.newMessage

            Clients.AllExcept(Context.ConnectionId);
        }

        public void JoinRoom(string room)
        {
            Groups.Add(Context.ConnectionId, room);
        }

        public void SendMessageToRoom(string room, string message)
        {
            var msg = String.Format("{0}: {1}", Context.ConnectionId, message);
            Clients.Group(room).newMessage(msg);
        }

        

        public void SendMessageData(ComplexData data)
        {
            Clients.All.newData(data);
        }

        //public Task<int> SendMessageAsync()
        //{
            
        //}


        public override Task OnConnected()
        {
            sendMonitorData("Connected",Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            sendMonitorData("Disconnected", Context.ConnectionId);
            return base.OnDisconnected();
        }
        public override Task OnReconnected()
        {
            sendMonitorData("Reconnected", Context.ConnectionId);
            return base.OnReconnected();
        }

        private void sendMonitorData(string eventType, string connection)
        {
            var connectionContext = GlobalHost.ConnectionManager.GetHubContext<MoniorHub>();
            connectionContext.Clients.All.newEvent(eventType, connection);
        }
    }
    public class ComplexData
    {

    }
}