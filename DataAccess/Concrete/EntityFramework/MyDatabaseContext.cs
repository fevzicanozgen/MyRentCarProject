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
        public DbSet<Colors> colors { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Rentals> rentals { get; set; }
        public DbSet<Users> users { get; set; }
    }
}
