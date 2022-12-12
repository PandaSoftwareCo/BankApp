using BankApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(i => i.CategoryId);
            builder.Property(i => i.CategoryId).IsRequired().UseIdentityColumn();

            builder.Property(i => i.Name).IsRequired().HasMaxLength(100);

            builder.HasData(new[] { 
                new Category { CategoryId = 1, Name = "Car Insurance" },
                new Category { CategoryId = 2, Name = "Car Lease" }, 
                new Category { CategoryId = 3, Name = "Car Repair" },
                new Category { CategoryId = 4, Name = "Computer" },
                new Category { CategoryId = 5, Name = "Electricity" },
                new Category { CategoryId = 6, Name = "Gas" },
                new Category { CategoryId = 7, Name = "Home Insurance" },
                new Category { CategoryId = 8, Name = "Internet" },
                new Category { CategoryId = 9, Name = "Medical" },
                new Category { CategoryId = 10, Name = "Office Furniture" },
                new Category { CategoryId = 11, Name = "Office Supplies" },
                new Category { CategoryId = 12, Name = "Parking" },
                new Category { CategoryId = 13, Name = "Phone" },
                new Category { CategoryId = 14, Name = "Rent" },
                new Category { CategoryId = 15, Name = "Salary" },
                new Category { CategoryId = 16, Name = "Dividend" },
                new Category { CategoryId = 17, Name = "Tuition" }
            });
        }
    }
}
