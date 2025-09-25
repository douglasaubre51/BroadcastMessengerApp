using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Models;

public class Message
{
    [Key]
    public int Id { get; set; }

    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public Account Account { get; set; } = new();
    public Channel Channel { get; set; } = new();
}
