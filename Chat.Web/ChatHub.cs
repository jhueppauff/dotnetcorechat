using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace dotnetcorechat
{
    [Authorize]
    public class ChatHub : Hub
    {      
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", Context.User.Identity.Name, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Join", Context.User.Identity.Name, "joined");
        }

        public override async Task OnDisconnectedAsync(Exception execption)
        {
            await Clients.All.SendAsync("Leave", Context.User.Identity.Name, "joined");
        }
    }
}