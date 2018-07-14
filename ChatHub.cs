namespace dotnetcorechat
{

public class ChatHub : Hub
    {      
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", nick, message);
        }
    }
}