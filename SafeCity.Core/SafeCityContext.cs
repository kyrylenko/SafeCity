using System;
using Microsoft.EntityFrameworkCore;
using SafeCity.Core.Entities;

namespace SafeCity.Core
{
    public class SafeCityContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<User> Users { get; set; }

        public SafeCityContext(DbContextOptions<SafeCityContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Project>()
                .Property(e => e.Images)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Project>()
                .Property(e => e.Attachments)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Project>()
                .HasData(Seed.Projects);

            modelBuilder.Entity<Donation>()
                .HasData(Seed.Donations);

            modelBuilder.Entity<User>()
                .HasData(Seed.Users);

            base.OnModelCreating(modelBuilder);
        }
    }
}
