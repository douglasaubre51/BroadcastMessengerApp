using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroadcastMvcApp.Models;

public class Channel
{
    [Key]
    public int ChannelId { get; set; }
    public string ChannelName { get; set; }
    [ForeignKey("MessageId")]
    public Message Messages { get; set; }
    public int JoinedUsersId { get; set; }

}
