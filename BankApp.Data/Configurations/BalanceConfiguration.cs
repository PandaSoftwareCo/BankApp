using BankApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Data.Configurations
{
    internal class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.ToTable("Balances");

            builder.HasKey(i => i.BalanceId);
            builder.Property(i => i.BalanceId).IsRequired().UseIdentityColumn();

            builder.Property(i => i.Amount).HasColumnType("money");

            builder.HasOne(i => i.Account).WithMany(i => i.Balances).HasForeignKey(i => i.AccountId);
        }
    }
}
