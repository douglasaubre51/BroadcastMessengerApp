using System;
using BroadcastMvcApp.Models;

namespace BroadcastMvcApp.Interface;

public interface IAccountRepository
{
    Task<List<Account>> GetAll();
//    Task<Account> GetById(int id);
    Task<Account> GetByEmail(string emailId);

    bool Add(Account account);
    bool Update(Account account);
    bool Delete(Account account);
    bool Save();
}
