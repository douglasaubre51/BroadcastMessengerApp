using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroadcastMvcApp.Models;

public class Channel
{
    [Key]
    public int ChannelId { get; set; }
    public string ChannelName { get; set; }
    [ForeignKey("Message")]
    public int? MessageId { get; set; }
    [ForeignKey("Account")]
    public int? AccountId { get; set; }

}
