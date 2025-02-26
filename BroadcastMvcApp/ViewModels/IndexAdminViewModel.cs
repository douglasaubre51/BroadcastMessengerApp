using System;
using BroadcastMvcApp.Enum;
using BroadcastMvcApp.Models;

namespace BroadcastMvcApp.ViewModels;

public class IndexAdminViewModel
{
    public IEnumerable<Account> accounts { get; set; }
    public IEnumerable<Channel> channels { get; set; }
}
