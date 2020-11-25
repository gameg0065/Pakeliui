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
        public DbSet<User> Users { get; set; }
        protected void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}