namespace BankCore.Domain.Common;

public interface IUnit0fWork : IDisposable
{
    Task<int> CompleteAsync();
}