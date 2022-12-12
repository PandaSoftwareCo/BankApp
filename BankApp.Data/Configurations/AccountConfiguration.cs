using BankApp.Core.Domain.Entities;
using BankApp.Core.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Data.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(i => i.AccountId);
            builder.Property(i => i.AccountId).IsRequired().UseIdentityColumn();

            builder.Property(i => i.AccountName).IsRequired().HasMaxLength(100);

            builder.HasIndex(i => i.AccountName);

            builder.HasData(new[]
            {
                new Account { AccountId = 1, AccountName = "Personal", AccountType = AccountType.Debit },
                new Account { AccountId = 2, AccountName = "Visa", AccountType = AccountType.Credit },
                new Account { AccountId = 3, AccountName = "MasterCard", AccountType = AccountType.Credit },
                new Account { AccountId = 4, AccountName = "Corporate", AccountType = AccountType.Debit },
                new Account { AccountId = 5, AccountName = "Corporate MasterCard", AccountType = AccountType.Credit }
            });
        }
    }
}
