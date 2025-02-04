using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Enum;

public enum Departments
{
    [Display(Name = "Computer Engineering")]
    CT,
    [Display(Name = "Electrical and Electronics Engineering")]
    EEE,
    [Display(Name = "Civil Engineering")]
    CE,
    [Display(Name = "Mechanical Engineering")]
    ME,
    [Display(Name = "Electronics Engineering")]
    EE
}