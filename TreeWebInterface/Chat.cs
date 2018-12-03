using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeWebInterface
{
    public class Chat : Hub
    {
        public void BroadcastMessage(string name, string message)
        {

            Clients.All.SendAsync("BroadcastMessage", name, message);

        }

        public void Ping()
        {

            Clients.All.SendAsync("Ping", Context.ConnectionId);

        }

        public void SendTree(string[] Tree)
        {

            Clients.All.SendAsync("SendTree", Tree);

        }

        public void ReturnPing(string SourceConnection)
        {

            Clients.Client(SourceConnection).SendAsync("BroadcastMessage", "PING", "RETURN PING");

        }

        public void Echo(string name, string message)
        {
            Clients.Client(Context.ConnectionId).SendAsync("Echo", name, message + " (echo from server)");
        }

    }

}
