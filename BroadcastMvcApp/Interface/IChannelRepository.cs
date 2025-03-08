using BroadcastMvcApp.Models;
namespace BroadcastMvcApp.Interface
{
    public interface IChannelRepository
    {
        Task<List<Channel>> GetAll();
        Task<Channel> GetById(int id);
        void AddToChannel(Account account, Channel channel);
        void RemoveFromChannel(Account account, Channel channel);

        bool IsExists(string channelName);

        bool Add(Channel channel);
        bool Update(Channel channel);
        bool Delete(Channel channel);
        bool Save();
    }
}
