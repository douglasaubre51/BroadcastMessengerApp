using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroadcastMvcApp.Models;

public class Message
{
    [Key]
    public int Id { get; set; }

    // navigation properties
    public Account Account { get; set; }
    public Channel Channel { get; set; }


    public string Data { get; set; }
    public DateTime UploadDateTime { get; set; }
}
