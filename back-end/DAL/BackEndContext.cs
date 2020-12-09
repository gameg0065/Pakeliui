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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Feedback>().ToTable("Feedbacks");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");
            modelBuilder.Entity<Post>().ToTable("Posts");
        }
    }
}