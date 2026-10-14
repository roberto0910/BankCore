using BankCore.Domain.Enums;

namespace BankCore.Domain.Entities;

public class Account 
{
    public Guid AccountId { get; set; } = Guid.NewGuid();
    public string AccountNumber { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public AccountType AccountType { get; set; }
    public decimal Balance { get; set; } = 0.00m;
    public string Currency { get; set; } = "USD";
    public AccountStatus Status { get; set; } = AccountStatus.ACTIVE;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

    //Propiedades de navegación
    public User User { get; set;} = null!; 
    public ICollection<Transaction> SentTransactions { get; set; } = new List<Transaction>();
    public ICollection<Transaction> ReceivedTransactions { get; set; } = new List<Transaction>();  
}