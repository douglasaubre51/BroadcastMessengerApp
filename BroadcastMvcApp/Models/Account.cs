using BroadcastMvcApp.Enum;
using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Models;

public class Account
{

    [Key]
    public int Id { get; set; }

    // many to many relation with channels
    public List<Channel>? Channels { get; set; }
    // one to many relation with messages
    public List<Message>? Messages { get; set; }


    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public string? ProfilePhotoURL { get; set; }

    public Roles roles { get; set; }
    public Departments? departments { get; set; }
    public Semesters? semesters { get; set; }
    public Status? status { get; set; }
}
