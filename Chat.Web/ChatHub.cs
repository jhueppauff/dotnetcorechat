using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.SignalR;

namespace dotnetcorechat
{
    public class ChatHub : Hub
    {      
        public async Task Send(string nick, string message)
        {
            await Clients.All.SendAsync("Send", nick, message);
        }
    }
}