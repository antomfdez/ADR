using AklDiscordRanking.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AklDiscordRanking.DAL;

public sealed class AppDbContext : DbContext
{
    public AppDbContext() { }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<User>(x =>
        {
            x.HasKey(y => y.Id);
            x.Property(y => y.Id).ValueGeneratedNever();
        }
    );

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={Constants.RelativeDbPath}");
}