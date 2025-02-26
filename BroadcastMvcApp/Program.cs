using BroadcastMvcApp.Data;
using BroadcastMvcApp.Helpers;
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
});
//adding Iphotoservice
builder.Services.AddScoped<IPhotoService, PhotoService>();
//added cloudinary service
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinaryConfiguration"));
//repo init
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IChannelRepository, ChannelRepository>();
//session state
builder.Services.AddSession();

var app = builder.Build();

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

//session 
app.UseSession();
app.Run();
