using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;

namespace dotnetcorechat
{
    [Authorize]
    public class ChatHub : Hub
    {      
        public async Task Send(string message)
        {
            var claims = Context.User.Claims;
            string displayName = claims.FirstOrDefault(v => v.Type == ClaimTypes.GivenName).Value;
            await Clients.All.SendAsync("Send", displayName, message);
        }

        public override async Task OnConnectedAsync()
        {
            var claims = Context.User.Claims;
            string displayName = claims.FirstOrDefault(v => v.Type == ClaimTypes.GivenName).Value;
            await Clients.All.SendAsync("Join", displayName, "joined");
        }

        public override async Task OnDisconnectedAsync(Exception execption)
        {
            var claims = Context.User.Claims;
            string displayName = claims.FirstOrDefault(v => v.Type == ClaimTypes.GivenName).Value;
            await Clients.All.SendAsync("Leave", displayName, "joined");
        }
    }
}