using BroadcastMvcApp.Models;

namespace BroadcastMvcApp.Data;

public class Update
{
    public static void UpdateData(IApplicationBuilder applicationBuilder)
    {
        using (var streamWriter = new StreamWriter("update.txt"))
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                var account = context.Accounts.First(e => e.Username == "Aizen");

                streamWriter.WriteLine($"{DateTime.Now}");
                streamWriter.WriteLine($"account name :{account.Username}");

                var channel = context.Channels.First(e => e.ChannelName == "Seireitai");

                channel.Accounts=new List<Account>(){
                    account
                };

                context.SaveChanges();

                streamWriter.WriteLine($"account name :{channel.Accounts.First(e => e.Username == account.Username).Username}");

                streamWriter.WriteLine("hello? account added to selected channel!");
            }
        }
    }
}
