using Domain.Entities.Manager.Admin;
using Microsoft.AspNetCore.SignalR;

namespace RealTime.Notifications.Admin;


public sealed class AdminHub : Hub
{
    public async override Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("hello",$"my id is{Context.UserIdentifier}");
        
    }


    public async Task SendMessage(string content)
    {
        await this.Clients.All.SendAsync("ReceiveMessage", content);
    }
}