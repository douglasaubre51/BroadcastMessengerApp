using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Models;

public class Message
{
    [Key]
    public int MessageId { get; set; }
    public string TextMessage { get; set; }
    public DateTime UploadDateTime { get; set; }
    public Account? account { get; set; }
}