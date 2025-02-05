using System;
using BroadcastMvcApp.Enum;
using System.ComponentModel.DataAnnotations;
using BroadcastMvcApp.Attributes;

namespace BroadcastMvcApp.Models;

public class Account
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Username { get; set; }
    [UniqueEmail]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    public string? ProfilePhotoURL { get; set; }

    public Roles roles { get; set; }
    public Departments departments { get; set; }
    public Semesters semesters { get; set; }
}