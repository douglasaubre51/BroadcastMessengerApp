using BroadcastMvcApp.Enum;
using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Models;

public class Account
{
    public List<Channel>? channels { get; set; }
    public List<Message>? messages { get; set; }


    [Key]
    public int AccountId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public string? ProfilePhotoURL { get; set; }

    public Roles roles { get; set; }
    public Departments? departments { get; set; }
    public Semesters? semesters { get; set; }
    public Status? status { get; set; }
}