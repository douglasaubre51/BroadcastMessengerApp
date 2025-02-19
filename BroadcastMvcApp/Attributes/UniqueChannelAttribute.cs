using System.ComponentModel.DataAnnotations;
using BroadcastMvcApp.Data;
namespace BroadcastMvcApp.Attributes
{
    public class UniqueChannelAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var _context=(ApplicationDbContext) validationContext.GetService(typeof(ApplicationDbContext));

            var channelName=value?.ToString();

            if (channelName == null)
            {
                return new ValidationResult("enter channel name!");
            }

            bool isChannelExists;

            



        
    }
}
