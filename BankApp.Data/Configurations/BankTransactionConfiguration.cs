using BankApp.Core.Domain.Entities;
using BankApp.Core.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Data.Configurations
{
    internal class BankTransactionConfiguration : IEntityTypeConfiguration<BankTransaction>
    {
        public void Configure(EntityTypeBuilder<BankTransaction> builder)
        {
            builder.ToTable("BankTransactions");

            builder.HasKey(i => i.BankTransactionId);
            builder.Property(i => i.BankTransactionId).IsRequired().UseIdentityColumn();

            builder.Property(i => i.Location).IsRequired().HasMaxLength(1000);
            builder.Property(i => i.Description).IsRequired().HasMaxLength(1000);
            builder.Property(i => i.Amount).HasColumnType("money");

            //builder.HasIndex(i => i.Location);

            builder.HasOne(i => i.Account).WithMany(i => i.BankTransactions)
                .HasForeignKey(i => i.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(i => i.Category).WithMany(i => i.BankTransactions)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new[]
            {
                new BankTransaction { 
                    BankTransactionId = 1, 
                    Location = "Building", 
                    Description = "Rent", 
                    Date = DateTime.Parse("2023-01-01"),
                    Amount = 3_000.00M,
                    AccountId = 1,
                    CategoryId = 14,
                    TransactionType = TransactionType.Withdrawl 
                },
                new BankTransaction 
                { 
                    BankTransactionId = 2, 
                    Location = "Dentist",
                    Description = "Filling",
                    Date = DateTime.Parse("2023-01-02"),
                    Amount = 500.00M,
                    AccountId = 3,
                    CategoryId = 9,
                    TransactionType = TransactionType.Withdrawl  
                },
                new BankTransaction 
                { 
                    BankTransactionId = 3, 
                    Location = "Fido",
                    Description = "Phone",
                    Date = DateTime.Parse("2023-01-03"),
                    Amount = 100.00M,
                    AccountId = 1,
                    CategoryId = 13,
                    TransactionType = TransactionType.Withdrawl  
                },
                new BankTransaction 
                { 
                    BankTransactionId = 4, 
                    Location = "Telus",
                    Description = "Internet",
                    Date = DateTime.Parse("2023-01-04"),
                    Amount = 100.00M,
                    AccountId = 1,
                    CategoryId = 8,
                    TransactionType = TransactionType.Withdrawl  
                },
                new BankTransaction 
                { 
                    BankTransactionId = 5, 
                    Location = "BCHydro",
                    Description = "Heat",
                    Date = DateTime.Parse("2023-01-05"),
                    Amount = 100.00M,
                    AccountId = 1,
                    CategoryId = 5,
                    TransactionType = TransactionType.Withdrawl  
                }
            });
        }
    }
}
