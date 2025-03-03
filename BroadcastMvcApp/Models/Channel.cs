using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Models;

public class Channel
{
    [Key]
    public int ChannelId { get; set; }
    public string ChannelName { get; set; }
    public List<Account>? Accounts { get; set; }
}