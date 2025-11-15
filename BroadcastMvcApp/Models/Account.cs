using BroadcastMvcApp.Enum;
using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Models;

public class Account
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Profile { get; set; }

    public Roles Role { get; set; }
    public Departments? Department { get; set; }
    public Semesters? Semester { get; set; }
    public Status Status { get; set; } = Status.Offline;

    public List<Channel>? Channels { get; set; }
}
