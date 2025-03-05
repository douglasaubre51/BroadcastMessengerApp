using System;

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

                var account = context.Accounts.FirstOrDefault(e => e.Username == "Asta");

                streamWriter.WriteLine($"{DateTime.Now}");
                if (account != null)
                {
                    context.Accounts.Remove(account);
                    context.SaveChanges();
                    streamWriter.WriteLine("removed  account!");
                }

                else streamWriter.WriteLine("account doesnot exist!");
            }
        }
    }
}
