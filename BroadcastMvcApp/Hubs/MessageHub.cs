using System;
using Microsoft.AspNetCore.SignalR;

namespace BroadcastMvcApp.Hubs;

public class MessageHub : Hub
{
    public static DateTime message;
    public async Task SendAMessage()
    {
        message = DateTime.Now;
        await Clients.All.SendAsync("sendAMessage", message);
    }
}
