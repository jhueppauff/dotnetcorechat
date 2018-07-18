using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace dotnetcorechat
{
    public class ChatHub : Hub
    {      
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", Context.User.Identity.Name, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "joined");
        }
    }
}