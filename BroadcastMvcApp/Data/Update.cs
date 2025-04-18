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

                var account = context.Accounts.First(e => e.UserName == "Luffy");

                streamWriter.WriteLine($"{DateTime.Now}");
                streamWriter.WriteLine($"account name :{account.UserName}");

                var channel = context.Channels.First(e => e.ChannelName == "raftel");

                channel.Accounts.First(e => e.UserName == "Luffy").Id = account.Id;

                context.SaveChanges();

                streamWriter.WriteLine($"account name :{channel.Accounts.First(e => e.UserName == account.UserName).UserName}");
                streamWriter.WriteLine($"account id :{channel.Accounts.First(e => e.UserName == account.UserName).Id}");

                streamWriter.WriteLine("hello? account added to selected channel!");
            }
        }
    }
}
