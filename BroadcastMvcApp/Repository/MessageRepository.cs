using BroadcastMvcApp.Models;
using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Data;

using Microsoft.EntityFrameworkCore;

public class MessageRepository : IMessageRepository
{
    private readonly ApplicationDbContext _context;

    public MessageRepository(ApplicationDbContext context) { _context = context; }

    // getters
    public async Task<Message> GetById(int id) { return await _context.Messages.SingleAsync(e => e.Id == id); }

    public async Task<List<Message>> GetAll() { return await _context.Messages.ToListAsync(); }

    // basic crud
    public bool Add(Message message) { _context.Messages.Add(message); return Save(); }
    public bool Update(Message message) { _context.Messages.Update(message); return Save(); }
    public bool Delete(Message message) { _context.Messages.Remove(message); return Save(); }

    public bool Save() { return _context.SaveChanges() > 0; }
}
