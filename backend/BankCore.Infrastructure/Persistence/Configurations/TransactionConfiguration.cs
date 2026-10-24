using BankCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankCore.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.TransactionId);

        // Relación con la cuenta de origen (SourceAccount)
        builder.HasOne(t => t.SourceAccount)
            .WithMany(a => a.SentTransactions)
            .HasForeignKey(t => t.SourceAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación con la cuenta de destino (DestinationAccount)
        builder.HasOne(t => t.DestinationAccount)
            .WithMany(a => a.ReceivedTransactions)
            .HasForeignKey(t => t.DestinationAccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}