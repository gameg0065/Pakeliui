using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace BackEnd.DAL
{
    public class BackEndContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public BackEndContext() : base()
        {
        }

        public DbSet<Car> Cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Pakeliui; User Id = sa; Password = LAMA55lama;");
        }
        protected void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Cars");
        }
    }
}