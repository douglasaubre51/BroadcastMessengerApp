using BroadcastMvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BroadcastMvcApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Message> Messages { get; set; }

    //fluent api
    //added to make email unique
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

	// accounts
	// emails are always unique!
        modelBuilder
	  .Entity<Account>()
	  .HasIndex(e => e.Email)
	  .IsUnique();

	// many to many relations
	modelBuilder
	  .Entity<Account>()
	  .HasMany(e=>e.Channels)
	  .WithMany(e=>e.Accounts);

	modelBuilder
	  .Entity<Channel>()
	  .HasMany(e=>e.Accounts)
	  .WithMany(e=>e.Channels);

	// one to many relations
	modelBuilder
	  .Entity<Account>()
	  .HasMany(e=>e.Messages)
	  .WithOne(e=>e.Account);

	modelBuilder
	  .Entity<Channel>()
	  .HasMany(e=>e.Messages)
	  .WithOne(e=>e.Channel);
    }
}
