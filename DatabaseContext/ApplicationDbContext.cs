using Microsoft.EntityFrameworkCore;
using Tattelecom.Entities;

namespace ElectronicShopOleynik.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public DbSet<AssignmentsEntity> Assignments { get; set; } 
    public DbSet<CategoriesEntity> Categories { get; set; } 
    public DbSet<EmployeesEntity> Employees { get; set; } 
    public DbSet<StatusesEntity>Statuses { get; set; } 
    public DbSet<TicketsEntity> Tickets { get; set; }
    public DbSet<UsersEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignmentsEntity>(productsConfiguration =>
        {
            productsConfiguration.HasKey(a => a.Id);
        });

        modelBuilder.Entity<CategoriesEntity>(productsConfiguration =>
        {
            productsConfiguration.HasKey(c => c.Id);
        });

        modelBuilder.Entity<EmployeesEntity>(productsConfiguration =>
        {
            productsConfiguration.HasKey(e => e.Id);
        });

        modelBuilder.Entity<StatusesEntity>(productsConfiguration =>
        {
            productsConfiguration.HasKey(s => s.Id);
        });

        modelBuilder.Entity<TicketsEntity>(productsConfiguration =>
        {
            productsConfiguration.HasKey(t => t.Id);
        });

        modelBuilder.Entity<UsersEntity>(productsConfiguration =>
        {
            productsConfiguration.HasKey(u => u.Id);
        });
    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=localhost;user=(root);password=(1234);database=(tattelecom_bd_niz);",
            new MySqlServerVersion(new Version(8, 0, 39)));
    }
}
