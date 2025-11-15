using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Models;

public class Channel
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Profile { get; set; }
    public string? Description { get; set; }

    public string? PinnedMessage { get; set; }

    public List<Account>? Accounts { get; set; }
    public List<Message>? Messages { get; set; }
}
