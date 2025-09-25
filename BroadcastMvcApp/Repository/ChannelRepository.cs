using BroadcastMvcApp.Data;
using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
using Microsoft.EntityFrameworkCore;
namespace BroadcastMvcApp.Repository
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly ApplicationDbContext _context;
        public ChannelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsExists(string channelName)
        {
            return _context.Channels.Any(e => e.Title == channelName);
        }

        // getters
        public async Task<List<Channel>> GetAll()
        {
            return await _context.Channels.Include(e => e.Accounts).ToListAsync();
        }

        public async Task<Channel> GetById(int id)
        {
            return await _context.Channels.Include(e => e.Accounts).Include(e => e.Messages).SingleAsync(c => c.Id == id);
        }

        public async Task<List<Channel>> GetByAccount(Account account)
        {
            return await _context.Channels.Include(e => e.Accounts).Where(e => e.Accounts.Contains(account)).ToListAsync();
        }

        // advanced crud
        public async Task AddToChannel(Account account, Channel channel)
        {
            var acc = await _context.Channels.Include(e => e.Accounts).FirstAsync(e => e.Id == channel.Id);

            if (acc.Accounts == null) acc.Accounts = new List<Account>();

            acc.Accounts.Add(account);

            await _context.SaveChangesAsync();
        }

        public void RemoveFromChannel(Account account, Channel channel)
        {
            var ch = _context.Channels.Include(e => e.Accounts).First(e => e.Id == channel.Id);

            ch.Accounts.RemoveAll(e => e.Id == account.Id);
            _context.SaveChanges();
        }


        public async Task<List<Message>> GetChannelMessages(int id)
        {
            return await _context.Channels.Include(e => e.Messages).Where(e => e.Id == id).Select(e => e.Messages).FirstOrDefaultAsync() ?? null;
        }

        // basic crud
        public bool Add(Channel channel)
        {
            _context.Add(channel);
            return Save();

        }

        public bool Delete(Channel channel)
        {
            _context.Remove(channel);
            return Save();
        }

        public bool Update(Channel channel)
        {
            _context.Update(channel);
            return Save();
        }

        public bool Save()
        {
            int newEntries;
            bool result = (newEntries = _context.SaveChanges()) > 0 ? true : false;
            Console.WriteLine(newEntries);
            return result;
        }
    }
}
