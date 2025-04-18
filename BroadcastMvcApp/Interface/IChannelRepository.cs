using BroadcastMvcApp.Models;
namespace BroadcastMvcApp.Interface
{
    public interface IChannelRepository
    {
        bool IsExists(string channelName);

	// getters
        Task<List<Channel>> GetAll();

        Task<Channel> GetById(int id);

        Task<List<Channel>> GetByAccount(Account account);

        Task<List<Message>> GetChannelMessages(int id);

	// advanced crud
        Task AddToChannel(Account account, Channel channel);

        void RemoveFromChannel(Account account, Channel channel);

	// basic crud
        bool Add(Channel channel);
        bool Update(Channel channel);
        bool Delete(Channel channel);
        bool Save();
    }
}
