using System.ComponentModel.DataAnnotations;
using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
using BroadcastMvcApp.Data;
using System.Reflection;
namespace BroadcastMvcApp.Attributes
{
    public class UniqueChannelAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context=(IChannelRepository)validationContext.GetService(typeof(IChannelRepository));

            var channelName = value?.ToString();

            if (channelName == null)
            {
                return new ValidationResult("enter channel name!");
            }

            bool isChannelExists =_context.IsExists(channelName);

            if (!isChannelExists)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("channel already exists!");
        }
    }
}
