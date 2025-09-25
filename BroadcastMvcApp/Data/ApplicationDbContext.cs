using BroadcastMvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BroadcastMvcApp.Data;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .HasIndex(e => e.Email)
            .IsUnique();

        modelBuilder.Entity<Account>()
            .HasMany<>

        base.OnModelCreating(modelBuilder);
    }
}
