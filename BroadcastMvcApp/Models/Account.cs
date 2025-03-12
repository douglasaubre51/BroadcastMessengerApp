using BroadcastMvcApp.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BroadcastMvcApp.Attributes;
using System.Runtime.CompilerServices;

namespace BroadcastMvcApp.Models;

public class Account : IdentityUser
{
    [Key]
    public int AccountId { get; set; }
    public List<Channel>? channels { get; set; }
    public List<Message>? messages { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? ProfilePhotoURL { get; set; }

    public Roles roles { get; set; }
    public Departments? departments { get; set; }
    public Semesters? semesters { get; set; }
    public Status? status { get; set; }
}