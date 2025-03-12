using BroadcastMvcApp.Enum;
using Microsoft.AspNetCore.Identity;

namespace BroadcastMvcApp.Models;

public class Account : IdentityUser
{
    public List<Channel>? channels { get; set; }
    public List<Message>? messages { get; set; }

    public string Name { get; set; }

    public string? ProfilePhotoURL { get; set; }

    public Roles roles { get; set; }
    public Departments? departments { get; set; }
    public Semesters? semesters { get; set; }
    public Status? status { get; set; }
}