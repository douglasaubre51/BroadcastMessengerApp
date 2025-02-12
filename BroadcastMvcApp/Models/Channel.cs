using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroadcastMvcApp.Models;

public class Channel
{
    [Key]
    int ChannelId { get; set; }
    string ChannelName { get; set; }
    [ForeignKey("MessageId")]
    Message Messages { get; set; }
    int JoinedUsersId { get; set; }

}
