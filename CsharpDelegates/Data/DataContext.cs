using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDelegates.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LIFE-HO-ICT-105;Initial Catalog=CustomerDb;Integrated Security=SSPI;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                        .HasMany(c => c.Accounts)
                        .WithOne(a => a.Customer)
                        .HasForeignKey(a => a.CustomerId);
        }
    }
}
