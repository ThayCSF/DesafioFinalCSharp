using BlueBank.System.Domain.OrderManagement.Entities;
using Microsoft.EntityFrameworkCore;


namespace BlueBank.System.Data.Contexts
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Operation> AccountOperations { get; set; }   
    }
}

