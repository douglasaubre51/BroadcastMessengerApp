﻿using BroadcastMvcApp.Models;
namespace BroadcastMvcApp.Interface
{
    public interface IChannelRepository
    {
        Task<List<Channel>> GetAll();
        Task<Channel> GetById(int id);
        Task AddToChannel(Account account, string ChannelName);

        bool IsExists(string channelName);

        bool Add(Channel channel);
        bool Update(Channel channel);
        bool Delete(Channel channel);
        bool Save();
    }
}
