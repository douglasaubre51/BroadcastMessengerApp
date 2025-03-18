using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Models;

public class Message
{
    [Key]
    public int MessageId { get; set; }
    public string Data { get; set; }
    public DateTime UploadDateTime { get; set; }
    public Account? account { get; set; }
}