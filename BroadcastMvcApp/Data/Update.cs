using System;

namespace BroadcastMvcApp.Data;

public class Update
{
    public static void UpdateData(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
        }
    }
}
