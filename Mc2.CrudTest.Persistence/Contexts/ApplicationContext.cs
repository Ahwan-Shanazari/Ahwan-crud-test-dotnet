using Domain.Customers;
using Mc2.CrudTest.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence.Contexts;

public class ApplicationContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerConfigurations());
    }
}