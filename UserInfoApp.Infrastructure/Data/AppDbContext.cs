using Microsoft.EntityFrameworkCore;
using UserInfoApp.Domain.Entities;

namespace UserInfoApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Info> Infos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Info)
                .WithOne(i => i.Person)
                .HasForeignKey<Info>(i => i.PersonId);

            // Optional: seed data for testing
        }
    }
}
