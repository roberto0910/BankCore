namespace BankCore.Domain.Common;

public interface IUnitOfWork : IDisposable
{
    Task<int> CompleteAsync();
}