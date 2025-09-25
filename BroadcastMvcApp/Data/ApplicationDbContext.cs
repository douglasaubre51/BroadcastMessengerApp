using BroadcastMvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BroadcastMvcApp.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Unique indexes

        modelBuilder.Entity<Account>()
            .HasIndex(e => e.Email)
            .IsUnique();

        // Many to many

        modelBuilder.Entity<Account>()
            .HasMany(c => c.Channels)
            .WithMany(a => a.Accounts);

        // One to many

        modelBuilder.Entity<Channel>()
            .HasMany(m => m.Messages)
            .WithOne(c => c.Channel);
    }
}
