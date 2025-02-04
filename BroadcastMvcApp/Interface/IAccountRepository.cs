using System;
using BroadcastMvcApp.Models;

namespace BroadcastMvcApp.Interface;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAll();
    Task<Account> GetById(int id);
    bool Add(Account account);
    bool Update(Account account);
    bool Delete(Account account);
    bool Save();
}
