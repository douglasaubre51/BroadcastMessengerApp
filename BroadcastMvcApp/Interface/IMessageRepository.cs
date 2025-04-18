using BroadcastMvcApp.Models;

namespace BroadcastMvcApp.Interface
{
    public interface IMessageRepository
    {
        // getters
        Task<Message> GetById(int id);
        Task<List<Message>> GetAll();

        // basic crud
        bool Add(Message message);
        bool Update(Message message);
        bool Delete(Message message);
        bool Save();
    }
}
