using System;

namespace BroadcastMvcApp.Models;

public class ChannelList
{
    public string Title { get; set; }
    public bool IsChecked { get; set; }
    public Channel channel { get; set; }
}