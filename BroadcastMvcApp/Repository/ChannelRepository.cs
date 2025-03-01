﻿using BroadcastMvcApp.Models;
using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Data;
using Microsoft.EntityFrameworkCore;
namespace BroadcastMvcApp.Repository
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly ApplicationDbContext _context;
        public ChannelRepository(ApplicationDbContext context) { 
            _context= context;
        }
        public async Task<IEnumerable<Channel>> GetAll()
        {
            return await _context.Channels.ToListAsync();
        }

        public bool IsExists(string channelName)
        {
            return _context.Channels.Any(e=> e.ChannelName==channelName);
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
            return (newEntries = _context.SaveChanges()) >0 ? true : false;
        }
    }
}
