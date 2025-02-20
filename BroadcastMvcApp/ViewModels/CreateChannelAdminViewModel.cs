using BroadcastMvcApp.Models;
using BroadcastMvcApp.Attributes;
namespace BroadcastMvcApp.ViewModels
{
    public class CreateChannelAdminViewModel
    {
        [UniqueChannel]
        public string ChannelName { get; set; }
    }
}
