using BankApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(i => i.UserId);
            builder.Property(i => i.UserId).UseIdentityColumn().HasColumnName("user_id").ValueGeneratedOnAdd();
            builder.Property(i => i.FirstName).HasColumnName("first_name").HasMaxLength(100);
            builder.Property(i => i.LastName).HasColumnName("last_name").HasMaxLength(100);
            builder.Property(i => i.UserName).HasColumnName("user_name").HasMaxLength(100);
            builder.Ignore(i => i.Password);
            builder.Property(i => i.PasswordBytes).HasColumnName("password_bytes");
            builder.Property(i => i.Salt).HasColumnName("salt");
            builder.Property(i => i.Role).HasColumnName("role").HasMaxLength(100);
            //builder.Property(i => i.Price).HasColumnType("money");

            //builder.HasData(new List<User>
            //{
            //});
        }
    }
}
