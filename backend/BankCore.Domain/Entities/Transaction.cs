using BankCore.Domain.Enums;

namespace BankCore.Domain.Entities;

public class Transaction
{
    public Guid TransactionId { get; set; } = Guid.NewGuid();
    public string ReferenceCode { get; set; } = Guid.NewGuid().ToString();
    public Guid? SourceAccountId { get; set; }
    public Guid? DestinationAccountId { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public TransactionStatus Status { get; set; } = TransactionStatus.COMPLETED; 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Propiedades de navegación
    public Account? SourceAccount { get; set; }
    public Account? DestinationAccount { get; set; }
}