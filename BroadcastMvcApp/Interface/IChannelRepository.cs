using BroadcastMvcApp.Models;
namespace BroadcastMvcApp.Interface
{
    public interface IChannelRepository
    {
        Task<IEnumerable<Channel>> GetAll();

        bool IsExists(string channelName);

        bool Add(Channel channel);
        bool Update(Channel channel);
        bool Delete(Channel channel);
        bool Save();
    }
}
