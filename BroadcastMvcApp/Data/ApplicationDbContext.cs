using System;
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
        modelBuilder.Entity<Account>().HasIndex(e => e.Email).IsUnique();
        base.OnModelCreating(modelBuilder);
    }
}
