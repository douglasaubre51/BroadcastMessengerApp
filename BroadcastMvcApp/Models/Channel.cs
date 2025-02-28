using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Models;

public class Channel
{
    [Key]
    public int ChannelId { get; set; }
    public string ChannelName { get; set; }
    public IEnumerable<Message>? MessageList { get; set; }
    public IEnumerable<Account>? AccountList { get; set; }
}