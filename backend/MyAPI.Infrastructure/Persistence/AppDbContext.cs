using Microsoft.EntityFrameworkCore;
using MyAPI.Domain.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace MyAPI.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> Users => Set<Users>();
        public DbSet<Sessions> Sessions => Set<Sessions>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany(u => u.Sessions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
        }
}
