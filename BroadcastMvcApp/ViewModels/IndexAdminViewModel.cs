using System;
using BroadcastMvcApp.Enum;
using BroadcastMvcApp.Models;

namespace BroadcastMvcApp.ViewModels;

public class IndexAdminViewModel
{
    public List<Account> accounts { get; set; }
    public List<Channel> channels { get; set; }
}
