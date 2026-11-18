using BankCore.Domain.Common;
using BankCore.Infrastructure.Persistence;

namespace BankCore.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BankCoreDbContext _context;

    public UnitOfWork(BankCoreDbContext context)
    {
        _context = context;
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}