using Microsoft.EntityFrameworkCore;

namespace BroadcastMvcApp.Data;

public class Delete
{
    public static void DeleteData(IApplicationBuilder applicationBuilder)
    {
        using (var streamWriter = new StreamWriter("delete.txt"))
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                streamWriter.WriteLine($"{DateTime.Now}");

                //to remove given accounts
                // var account = context.Accounts.FirstOrDefault(e => e.Username == "Boruto Uzumaki");

                // if (account != null)
                // {
                //     context.Accounts.Remove(account);
                //     context.SaveChanges();
                //     streamWriter.WriteLine("removed  account!");
                // }

                // else streamWriter.WriteLine("account doesnot exist!");

                //to remove accounts inside all channels!
                // var account = context.Channels.Include(e => e.Accounts).ToList();

                // foreach (var acc in account)
                // {
                //     acc.Accounts.Clear();
                // }

                // context.SaveChanges();

                // streamWriter.WriteLine("cleared all accounts inside the channels!");
            }
        }
    }
}
