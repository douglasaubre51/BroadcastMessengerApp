using BroadcastMvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BroadcastMvcApp.Data;

public class AddMessage
{
    public static void SetMessage(IApplicationBuilder applicationBuilder, string channelName, string data)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            using (var streamWriter = new StreamWriter("message list.txt"))
            {
                try
                {
                    streamWriter.WriteLine($"{DateTime.Now}");
                    var _context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                    Message textMessage = new Message()
                    {
                        Data = data,
                        UploadDateTime = DateTime.Now
                    };

                    _context.Messages.Add(textMessage);

                    List<Message> messages = _context.Channels.Include(e => e.Messages).Single(e => e.ChannelName == channelName).Messages;

                    if (messages == null) { streamWriter.WriteLine("messages is null!"); }

                    messages.Add(textMessage);

                    _context.SaveChanges();

                    List<Message> messageList = _context.Channels.Include(e => e.Messages).Single(e => e.ChannelName == channelName).Messages;

                    var messageFromMessages = _context.Messages.Select(e => e.Data).ToList();

                    foreach (var m in messageFromMessages)
                    {
                        streamWriter.WriteLine($"message :{m}");
                    }

                    if (messageList == null) { streamWriter.WriteLine("message list is null!"); }

                    streamWriter.WriteLine($"{DateTime.Now}");
                    foreach (var i in messageList)
                    {
                        streamWriter.WriteLine($"message id:{i.MessageId}");
                        streamWriter.WriteLine($"message data:{i.Data}");
                        streamWriter.WriteLine($"upload Date Time:{i.UploadDateTime}");
                        streamWriter.WriteLine("\n\n");
                    }
                }
                catch (Exception e) { streamWriter.WriteLine($"error :{e.StackTrace}"); }
            }
        }
    }
}
