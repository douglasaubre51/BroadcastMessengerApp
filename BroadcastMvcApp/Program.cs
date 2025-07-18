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

//added by me
//appdbcontext initialization
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BroadcastDbString"));
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});

//adding user account authorization
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

//adding Iphotoservice
builder.Services.AddScoped<IPhotoService, PhotoService>();

//added cloudinary service
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinaryConfiguration"));

//repo init
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IChannelRepository, ChannelRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

//session state
builder.Services.AddSession();

//signalR
builder.Services.AddSignalR();

var app = builder.Build();

//seed data
if (args.Length == 1 && args[0].ToLower() == "see")
{
    Seed.SeedData(app);
    return;
}

//retrieve data
if (args.Length == 1 && args[0].ToLower() == "ret")
{
    Retrieve.RetrieveData(app);
    return;
}

//update data
if (args.Length == 1 && args[0].ToLower() == "upd")
{
    Update.UpdateData(app);
    return;
}

//delete data
if (args.Length == 1 && args[0].ToLower() == "del")
{
    Delete.DeleteData(app);
    return;
}

//get pending migration list
if (args.Length == 1 && args[0].ToLower() == "pen")
{
    PendingMigrations.PendingMigrationsList(app);
    return;
}

if (args.Length == 3 && args[0].ToLower() == "msg")
{
    AddMessage.SetMessage(app, args[1], args[2]);
    return;
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseWebSockets();
}

app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapHub<MessageHub>("/Hubs/MessageHub");

app.Run();
