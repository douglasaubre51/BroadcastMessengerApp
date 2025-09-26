using BroadcastMvcApp.Data;
using BroadcastMvcApp.Helpers;
using BroadcastMvcApp.Hubs;
using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Repository;
using BroadcastMvcApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BroadcastDbString")
        );
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});

builder.Services.AddSignalR();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinaryConfiguration"));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IChannelRepository, ChannelRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

builder.Services.AddScoped<PhotoService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapHub<MessageHub>("/Hubs/MessageHub");

app.Run();
