using Microsoft.EntityFrameworkCore;
using Tattelecom.Entities;

namespace Tattelecom.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public DbSet<AssignmentsEntity> Assignments { get; set; }
    public DbSet<CategoriesEntity> Categories { get; set; }
    public DbSet<EmployeesEntity> Employees { get; set; }
    public DbSet<StatusesEntity> Statuses { get; set; }
    public DbSet<TicketsEntity> Tickets { get; set; }
    public DbSet<UsersEntity> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        // Убеждаемся, что база данных создана при создании контекста
        Database.EnsureCreated();
    }

    public ApplicationDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignmentsEntity>(assignmentsConfiguration =>
        {
            assignmentsConfiguration.HasKey(a => a.Id);
        });

        modelBuilder.Entity<CategoriesEntity>(categoriesConfiguration =>
        {
            categoriesConfiguration.HasKey(c => c.Id);
        });

        modelBuilder.Entity<EmployeesEntity>(employeesConfiguration =>
        {
            employeesConfiguration.HasKey(e => e.Id);
        });

        modelBuilder.Entity<StatusesEntity>(statusesConfiguration =>
        {
            statusesConfiguration.HasKey(s => s.Id);
        });

        modelBuilder.Entity<TicketsEntity>(ticketsConfiguration =>
        {
            ticketsConfiguration.HasKey(t => t.Id);
        });

        modelBuilder.Entity<UsersEntity>(usersConfiguration =>
        {
            usersConfiguration.HasKey(u => u.Id);
        });
    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=10.0.2.2;user=root;password=1234;database=tattelecom_bd_niz;",
            new MySqlServerVersion(new Version(8, 0, 39)));
    }
}
