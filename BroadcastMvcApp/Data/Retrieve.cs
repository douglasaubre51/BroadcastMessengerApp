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
                    streamWriter.WriteLine($"Channel Id :{i.ChannelId}");
                    streamWriter.WriteLine($"Channel Name :{i.ChannelName}");
                }

                foreach (var ch in accountList)
                {
                    streamWriter.WriteLine($"\nAccounts in channel : {ch.ChannelName}");
                    foreach (var j in ch.Accounts)
                    {
                        streamWriter.WriteLine($"Account Name :{j.Username}");
                        streamWriter.WriteLine($"Account Id:{j.AccountId}");
                    }
                }

                streamWriter.WriteLine("\nAccounts");
                foreach (var i in context.Accounts.ToList())
                {
                    streamWriter.WriteLine($"Account id: {i.AccountId}");
                    streamWriter.WriteLine($"Username : {i.Username}");

                    if (i.channels != null)
                    {
                        foreach (var j in i.channels)
                        {
                            streamWriter.WriteLine($"Channel Id:{j.ChannelId}");
                            streamWriter.WriteLine($"Channel Name:{j.ChannelName}");
                        }
                    }
                }
            }
        }
    }
}
