using System;
using BroadcastMvcApp.Models;

namespace BroadcastMvcApp.Interface;

public interface IChatService
{
    Task<List<Message>> GetMessages();
}
