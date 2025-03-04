using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace BroadcastMvcApp.Data;

public class Retrieve
{
    public static void RetrieveData(IApplicationBuilder applicationBuilder)
    {
        using (var streamWriter = new StreamWriter("C:\\Users\\user\\OneDrive\\Desktop\\WorkSpaces\\miscellaneous\\Misc\\retreiveData.txt"))
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                var channel = context.Channels.ToList();

                streamWriter.WriteLine(DateTime.Now);

                streamWriter.WriteLine("Channels");
                foreach (var i in channel)
                {
                    streamWriter.WriteLine($"Channel Id :{i.ChannelId}");
                    streamWriter.WriteLine($"Channel Name :{i.ChannelName}");

                    if (i?.Accounts != null)
                    {
                        streamWriter.WriteLine("\nChannels added to this user");
                        foreach (var j in i.Accounts)
                        {
                            streamWriter.WriteLine($"Account Id :{j.AccountId}");
                        }
                    }
                }

                streamWriter.WriteLine("\nAccounts");
                foreach (var i in context.Accounts.ToList())
                {
                    streamWriter.WriteLine($"Account id: {i.AccountId}");
                    streamWriter.WriteLine($"Username : {i.Username}");

                    if (i.channel != null)
                    {
                        foreach (var j in i.channel)
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
