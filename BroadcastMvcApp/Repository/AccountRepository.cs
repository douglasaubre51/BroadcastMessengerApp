using BroadcastMvcApp.Models;
using BroadcastMvcApp.Data;
using BroadcastMvcApp.Interface;
using Microsoft.EntityFrameworkCore;

namespace BroadcastMvcApp.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _context;
    public AccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Account>> GetAll()
    {
        return await _context.Accounts.ToListAsync();
    }
    public async Task<Account> GetById(int id)
    {
        return await _context.Accounts.Include(e => e.Channels).FirstAsync(e => e.Id == id);
    }

    public async Task<Account> GetByEmail(string emailId)
    {
        return await _context.Accounts.FirstOrDefaultAsync(e => e.Email == emailId);
    }

    public bool Add(Account account)
    {
        _context.Add(account);
        return Save();
    }
    public bool Update(Account account)
    {
        _context.Update(account);
        return Save();
    }
    public bool Delete(Account account)
    {
        _context.Remove(account);
        return true;
    }
    public bool Save()
    {
        int newEntries = _context.SaveChanges();
        return newEntries > 0 ? true : false;
    }
}
