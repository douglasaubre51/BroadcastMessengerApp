using BroadcastMvcApp.Models;
namespace BroadcastMvcApp.Interface
{
    public interface IChannelRepository
    {
        Task<List<Channel>> GetAll();
        Task<Channel> GetById(int id);
        Task<List<Channel>> GetByAccount(Account account);
        Task AddToChannel(Account account, Channel channel);
        void RemoveFromChannel(Account account, Channel channel);
        Task<List<Message>> GetChannelMessages(int id);

        bool IsExists(string channelName);

        bool Add(Channel channel);
        bool Update(Channel channel);
        bool Delete(Channel channel);
        bool Save();
    }
}
