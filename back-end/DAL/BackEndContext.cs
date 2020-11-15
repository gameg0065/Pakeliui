using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace BackEnd.DAL
{
    public class BackEndContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public BackEndContext(DbContextOptions<BackEndContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        protected void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Cars");
        }
    }
}