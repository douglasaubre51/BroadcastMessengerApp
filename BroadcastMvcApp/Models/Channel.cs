using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Models;

public class Channel
{
    [Key]
    public int Id { get; set; }

    // many to many
    public List<Account>? Accounts { get; set; }
    // one to many
    public List<Message>? Messages { get; set; }


    public string ChannelName { get; set; }
    public string? ProfilePhotoURL { get; set; }
    public string? Description { get; set; }
}
