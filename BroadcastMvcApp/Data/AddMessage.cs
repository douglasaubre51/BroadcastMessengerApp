using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BroadcastMvcApp.Data;

public class AddMessage
{
    private readonly ApplicationDbContext _context;
    public AddMessage(ApplicationDbContext context)
    {
        _context = context;
    }
    public static void SetMessage(string channelName, string data)
    {
        string channelName = "";

        Message textMessage = new Message()
        {
            Data = data,
            UploadDateTime = DateTime.Now
        };

        List<Message> messages = _context.Channels.Include(e => e.Messages).Where(e => e.ChannelName == channelName).Select(e => e.Messages).First();

        messages.Add(textMessage);

        _context.SaveChanges();

        using (var streamWriter = new StreamWriter("message list.txt"))
        {
            List<Message> messageList = _context.Channels.Include(e => e.Messages).Where(e => e.ChannelName == channelName).Select(e => e.Messages).First();

            foreach (var i in messageList)
            {
                streamWriter.WriteLine($"message id:{i.MessageId}");
                streamWriter.WriteLine($"message data:{i.Data}");
                streamWriter.WriteLine($"upload Date Time:{i.UploadDateTime}");
            }
        }
    }
}
