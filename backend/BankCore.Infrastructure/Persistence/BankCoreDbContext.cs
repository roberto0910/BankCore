using Microsoft.EntityFrameworkCore;
using BankCore.Domain.Entities;

namespace BankCore.Infrastructure.Persistence;

public class BankCoreDbContext : DbContext 
{
    public BankCoreDbContext(DbContextOptions<BankCoreDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplica automáticamente cualquier configuración de mapeo que hagamos en el futuro
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankCoreDbContext).Assembly);
    }
}