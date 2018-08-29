/*
 * -----------------------------------------------------------------------
 *  <copyright file="ChatHub.cs" company=""
 *  Copyright 2018 julian
 *  MIT Licence
 *  For licence details visit https://github.com/jhueppauff/dotnetcorechat/blob/master/LICENSE
 *  </copyright>
 * -----------------------------------------------------------------------
 */

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
        public async Task Send(string message, Guid roomId)
        {
            var claims = Context.User.Claims;
            string displayName = claims.FirstOrDefault(v => v.Type == ClaimTypes.GivenName).Value;
            await Clients.Group(roomId.ToString()).SendAsync("Send", displayName, message);
        }

        // deprecated replace with join room
        public override async Task OnConnectedAsync()
        {
            var claims = Context.User.Claims;
            string displayName = claims.FirstOrDefault(v => v.Type == ClaimTypes.GivenName).Value;
            await Clients.All.SendAsync("Join", displayName, "joined");
        }

        public async Task JoinRoom(Guid roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            
            var claims = Context.User.Claims;
            string displayName = claims.FirstOrDefault(v => v.Type == ClaimTypes.GivenName).Value;

            await Clients.Group(roomId.ToString()).SendAsync("Join", displayName, "joined");
        }

        public async Task LeaveRoom(Guid roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());

            var claims = Context.User.Claims;
            string displayName = claims.FirstOrDefault(v => v.Type == ClaimTypes.GivenName).Value;

            await Clients.Group(roomId.ToString()).SendAsync("Leave", displayName, "left");
        }

        // deprecated replace with leave room
        public override async Task OnDisconnectedAsync(Exception execption)
        {
            var claims = Context.User.Claims;
            string displayName = claims.FirstOrDefault(v => v.Type == ClaimTypes.GivenName).Value;
            await Clients.All.SendAsync("Leave", displayName, "left");
        }
    }
}