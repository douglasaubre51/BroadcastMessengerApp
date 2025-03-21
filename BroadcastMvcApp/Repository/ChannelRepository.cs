﻿using BroadcastMvcApp.Models;
using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
namespace BroadcastMvcApp.Repository
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly ApplicationDbContext _context;
        public ChannelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Channel>> GetAll()
        {
            return await _context.Channels.Include(e => e.Accounts).ToListAsync();
        }

        public async Task<Channel> GetById(int id)
        {
            return await _context.Channels.SingleAsync(c => c.ChannelId == id);
        }

        public async Task<List<Channel>> GetByAccount(Account account)
        {
            return await _context.Channels.Include(e => e.Accounts).Where(e => e.Accounts.Contains(account)).ToListAsync();
        }

        public async Task AddToChannel(Account account, Channel channel)
        {
            var acc = await _context.Channels.Include(e => e.Accounts).FirstAsync(e => e.ChannelId == channel.ChannelId);

            if (acc.Accounts == null) acc.Accounts = new List<Account>();

            acc.Accounts.Add(account);

            await _context.SaveChangesAsync();
        }

        public void RemoveFromChannel(Account account, Channel channel)
        {
            var ch = _context.Channels.Include(e => e.Accounts).First(e => e.ChannelId == channel.ChannelId);

            ch.Accounts.RemoveAll(e => e.AccountId == account.AccountId);
            _context.SaveChanges();
        }


        public bool IsExists(string channelName)
        {
            return _context.Channels.Any(e => e.ChannelName == channelName);
        }

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
            return (newEntries = _context.SaveChanges()) > 0 ? true : false;
        }
    }
}
