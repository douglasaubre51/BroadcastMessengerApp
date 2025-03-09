using BroadcastMvcApp.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BroadcastMvcApp.Attributes;
using System.Runtime.CompilerServices;

namespace BroadcastMvcApp.Models;

public class Account
{
    [Key]
    public int AccountId { get; set; }
    public List<Channel>? channels { get; set; }
    public List<Message>? messages { get; set; }

    [Required]
    public string? Username { get; set; }
    [UniqueEmail]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    public string? ProfilePhotoURL { get; set; }

    [NotMapped]
    public string? Authorization { get; set; }

    public Roles roles { get; set; }
    public Departments? departments { get; set; }
    public Semesters? semesters { get; set; }
    public Status? status { get; set; }
}