using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class MyDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyDb;Trusted_Connection=True;");
        }
        public DbSet<Brand> brand { get; set; }
        public DbSet<Cars> cars { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Rental> rentals { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
    }
}
