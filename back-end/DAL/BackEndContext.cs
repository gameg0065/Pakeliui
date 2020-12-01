using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.DAL
{
    public class BackEndContext : DbContext
    {
        public BackEndContext(DbContextOptions<BackEndContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }

        protected void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Preference>().ToTable("Preferences");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");
            modelBuilder.Entity<Travel>().ToTable("Travels");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserPreference>().ToTable("UserPreferences");
        }
    }
}