using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WsCRM.Models;

namespace WsCRM.DAL
{
   

    public class dbContext : DbContext
    {
        public dbContext() : base("dbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }
}