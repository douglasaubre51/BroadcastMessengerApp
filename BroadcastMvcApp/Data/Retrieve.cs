using Microsoft.EntityFrameworkCore;

namespace BroadcastMvcApp.Data;
public class Retrieve
{
    public static void RetrieveData(IApplicationBuilder applicationBuilder)
    {
        using (var streamWriter = new StreamWriter("RetreiveData.txt"))
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                var channel = context.Channels.ToList();
                var accountList = context.Channels.Include(e => e.Accounts).ToList();

                streamWriter.WriteLine(DateTime.Now);

                streamWriter.WriteLine("Channels");
                foreach (var i in channel)
                {
                    streamWriter.WriteLine($"Channel Id :{i.Id}");
                    streamWriter.WriteLine($"Channel Name :{i.ChannelName}");
                }

                foreach (var ch in accountList)
                {
                    streamWriter.WriteLine($"\nAccounts in channel : {ch.ChannelName}");
                    foreach (var j in ch.Accounts)
                    {
                        streamWriter.WriteLine($"Account Name :{j.UserName}");
                        streamWriter.WriteLine($"Account Id:{j.Id}");
                    }
                }

                streamWriter.WriteLine("\nAccounts");
                foreach (var i in context.Accounts.ToList())
                {
                    streamWriter.WriteLine($"Account id: {i.Id}");
                    streamWriter.WriteLine($"UserName : {i.UserName}");

                    if (i.Channels != null)
                    {
                        foreach (var j in i.Channels)
                        {
                            streamWriter.WriteLine($"Channel Id:{j.Id}");
                            streamWriter.WriteLine($"Channel Name:{j.ChannelName}");
                        }
                    }
                }

                streamWriter.WriteLine("\nMessages");

                var messages = context.Messages.ToList();

                foreach (var m in messages)
                {
                    streamWriter.WriteLine(m.Data);
                }
            }
        }
    }
}
