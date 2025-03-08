using System;
using Microsoft.EntityFrameworkCore;

namespace BroadcastMvcApp.Data;

public class PendingMigrations
{
    public static void PendingMigrationsList(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            var migrateList = context.Database.GetPendingMigrations();

            using (var streamWriter = new StreamWriter("pendingMigrationsList.txt"))
            {
                if (migrateList.Any())
                {
                    streamWriter.WriteLine($"there are pending Migrations!");

                    migrateList.ToList().ForEach(e => streamWriter.WriteLine(e.ToString()));
                }

                else streamWriter.WriteLine("no pending migrations!");

            }
        }
    }

}
